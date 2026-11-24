param(
	[string]$SqlServer = ".\SQLEXPRESS",
	[string]$Database = "ComercializAR",
	[string]$SqlScript,
	[string]$ExeConfig
)

$ErrorActionPreference = "Stop"

function Escape-SqlIdentifier([string]$Value) {
	return $Value.Replace("]", "]]")
}

if ([string]::IsNullOrWhiteSpace($SqlScript) -or -not (Test-Path -LiteralPath $SqlScript)) {
	throw "SQL script not found: $SqlScript"
}

$masterBuilder = New-Object System.Data.SqlClient.SqlConnectionStringBuilder
$masterBuilder["Data Source"] = $SqlServer
$masterBuilder["Initial Catalog"] = "master"
$masterBuilder["Integrated Security"] = $true

$master = New-Object System.Data.SqlClient.SqlConnection($masterBuilder.ConnectionString)
$master.Open()

$databaseCreated = $false
try {
	$check = New-Object System.Data.SqlClient.SqlCommand(
		"SELECT COUNT(*) FROM sys.databases WHERE name = @name",
		$master)
	$check.Parameters.AddWithValue("@name", $Database) | Out-Null

	if ([int]$check.ExecuteScalar() -eq 0) {
		$databaseName = Escape-SqlIdentifier $Database
		$create = New-Object System.Data.SqlClient.SqlCommand(
			"CREATE DATABASE [$databaseName]",
			$master)
		$create.CommandTimeout = 300
		$create.ExecuteNonQuery() | Out-Null
		$databaseCreated = $true
	}

	$loginCheck = New-Object System.Data.SqlClient.SqlCommand(
		"SELECT COUNT(*) FROM sys.server_principals WHERE name = @name",
		$master)
	$loginCheck.Parameters.AddWithValue("@name", "BUILTIN\Users") | Out-Null
	if ([int]$loginCheck.ExecuteScalar() -eq 0) {
		$createLogin = New-Object System.Data.SqlClient.SqlCommand(
			"CREATE LOGIN [BUILTIN\Users] FROM WINDOWS",
			$master)
		$createLogin.ExecuteNonQuery() | Out-Null
	}

	$databaseName = Escape-SqlIdentifier $Database
	$grantBatch = @"
USE [$databaseName]
DECLARE @principalSid varbinary(85) = SUSER_SID(N'BUILTIN\Users')

IF @principalSid IS NOT NULL
BEGIN
	IF NOT EXISTS (
		SELECT 1
		FROM sys.database_principals
		WHERE sid = @principalSid
	)
	BEGIN
		CREATE USER [BUILTIN\Users] FOR LOGIN [BUILTIN\Users]
	END

	DECLARE @principalName sysname
	SELECT @principalName = name
	FROM sys.database_principals
	WHERE sid = @principalSid

	IF @principalName IS NOT NULL AND IS_ROLEMEMBER(N'db_owner', @principalName) = 0
	BEGIN
		DECLARE @grantSql nvarchar(max) = N'ALTER ROLE [db_owner] ADD MEMBER [' +
			REPLACE(@principalName, N']', N']]') + N']'
		EXEC(@grantSql)
	END
END
"@
	$grant = New-Object System.Data.SqlClient.SqlCommand($grantBatch, $master)
	$grant.CommandTimeout = 300
	$grant.ExecuteNonQuery() | Out-Null
}
finally {
	$master.Close()
}

$databaseBuilder = New-Object System.Data.SqlClient.SqlConnectionStringBuilder
$databaseBuilder["Data Source"] = $SqlServer
$databaseBuilder["Initial Catalog"] = $Database
$databaseBuilder["Integrated Security"] = $true

$connection = New-Object System.Data.SqlClient.SqlConnection($databaseBuilder.ConnectionString)
$connection.Open()

try {
	$objectCheck = New-Object System.Data.SqlClient.SqlCommand(
		"SELECT COUNT(*) FROM sys.objects WHERE type IN ('U','P')",
		$connection)
	$objectCount = [int]$objectCheck.ExecuteScalar()

	if ($objectCount -eq 0) {
		$script = [System.IO.File]::ReadAllText($SqlScript)
		$useDatabase = $script.IndexOf("USE [ComercializAR]", [System.StringComparison]::OrdinalIgnoreCase)
		if ($useDatabase -ge 0) {
			$script = $script.Substring($useDatabase)
		}

		$batches = [regex]::Split($script, "(?im)^\s*GO\s*$")
		foreach ($batch in $batches) {
			if (-not [string]::IsNullOrWhiteSpace($batch)) {
				$command = New-Object System.Data.SqlClient.SqlCommand($batch, $connection)
				$command.CommandTimeout = 300
				$command.ExecuteNonQuery() | Out-Null
				$command.Dispose()
			}
		}
	}
}
finally {
	$connection.Close()
}
