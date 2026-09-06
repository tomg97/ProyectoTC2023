# Skill: Login-Time Database Integrity Verification

## Goal
After a user logs in, verify whether protected database tables have been altered by recalculating digests and comparing them with stored control values.

## Core idea
Use two integrity layers:

1. **DVH (Dígito Verificador Horizontal)**: row-based digest calculated from the values in each row.
2. **DVV (Dígito Verificador Vertical)**: column-based digest calculated from the values in each column across the table.

Store those values in a dedicated control table, for example `DV`, and compare them on login.

## Required components
- Authentication service or BLL
- Session manager
- Integrity checker service/BLL
- Data access layer
- Repair UI for administrators
- Bitácora / audit log

## Required data model
- Protected business tables
- A `DV` control table with columns like:
  - `Tabla`
  - `DVH`
  - `DVV`
- Optional per-row `DV` column in protected tables
- A whitelist of protected tables
- A mapping of table name to primary key column

## Login flow
1. Validate input fields.
2. Authenticate user.
3. Check user status:
   - exists
   - active
   - not blocked
4. Verify password hash.
5. Register the session.
6. Run integrity verification on protected tables.
7. If inconsistencies exist:
   - stop normal access for non-admins,
   - let admins enter repair flow.
8. If no inconsistencies exist:
   - continue to the main application.

## Integrity verification flow
For each protected table:

1. Read all rows from the database.
2. Recalculate the row-based digest (**DVH**) from current row data.
3. Recalculate the column-based digest (**DVV**) from current column data.
4. Read the stored `DVH` and `DVV` from the `DV` control table.
5. Compare recalculated vs stored values.
6. If they differ:
   - mark the table as inconsistent,
   - write an audit log entry,
   - return the table name for repair handling.

## DVH calculation rule
DVH must represent **horizontal integrity**:

- Read a row.
- Concatenate the row values in a stable order.
- Exclude control fields such as the row-level `DV` column.
- Hash the resulting string.
- Repeat for every row when row-level validation is needed.

If a row has no stored `DV`, treat it as a possible direct insert.

If the recalculated row hash differs from the stored row `DV`, treat it as a possible direct update.

## DVV calculation rule
DVV must represent **vertical integrity**:

- Read a column.
- Concatenate that column’s values across all rows in a stable order.
- Exclude control fields such as the row-level `DV` column.
- Hash the resulting string.
- Repeat for every protected column that participates in integrity verification.

If the recalculated DVV differs from the stored control value, treat it as a possible direct delete, column tampering, or structural inconsistency.

## Row-level detection
If the table has a per-row `DV` column:

- Recalculate each row hash using all columns except `DV`.
- If `DV` is empty, treat the row as **inserted directly in the DB**.
- If the recalculated hash differs from stored `DV`, treat the row as **modified directly in the DB**.

## Table-level detection
After scanning rows and columns:

- Recalculate the table-level DVH and DVV.
- Compare them with the stored `DVH` and `DVV`.
- If the values differ, treat the table as inconsistent.

Use the row-level and column-level results together to classify the issue.

## Special-case tables
For relationship tables that only need table-level validation:
- verify only the table digest values,
- do not attempt per-row repair logic if they have no meaningful row identity.

## Repair flow
If the user is an administrator:

1. Show the list of affected tables and/or rows.
2. Allow recalculation of digests.
3. Update:
   - per-row `DV`
   - table-level `DVH`
   - table-level `DVV`
4. Write an audit log entry for the repair.
5. Return to the main application.

## Security rules
- Never trust table names from user input.
- Only verify tables from a hardcoded whitelist.
- Use parameterized SQL for values.
- Treat integrity mismatches as data tampering or divergence, not as proof of malicious intent.
- Log all verification and repair events.

## Recommended structure
- `AuthenticationService.Login(...)`
- `IntegrityService.VerifyAll(...)`
- `IntegrityService.VerifyTable(...)`
- `IntegrityService.RecalculateTable(...)`
- `RepairForm`
- `AuditLogService`

## Output contract
The integrity checker should return:
- success / failure
- list of inconsistent tables
- technical error message if the database operation failed

## Example behavior
- If login succeeds and no issues are found: open the main menu.
- If login succeeds and inconsistencies are found:
  - admin sees repair UI,
  - non-admin sees a restricted warning.
- If a technical database error occurs: block access and show the error.