using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Servicios.Metodos {
    public class Mensajeria {
        private static readonly Dictionary<string, string> traducciones = new Dictionary<string, string> {
            { "No se detecta un usuario loggeado. Se debe ingresar al sistema", "No logged-in user was detected. You must log in to the system." },
            { "El nombre de usuario no existe.", "The username does not exist." },
            { "Error inesperado", "Unexpected error" },
            { "Nombre de Usuario vacío. Reingresar", "Username is empty. Please enter it again." },
            { "Uno o más campos están vacíos. Por favor, complete.", "One or more fields are empty. Please complete them." },
            { "Se ha detectado una inconsistencia en la base de datos. Por favor realice un restore.", "A database inconsistency was detected. Please restore the database." },
            { "Se han recalculado los DV's correctamente.", "The verification digits were recalculated successfully." },
            { "No hay datos", "There is no data." },
            { "Logout exitoso", "Logout successful" },
            { "El objeto fue serializado exitosamente.", "The object was serialized successfully." },
            { "El valor de las cuotas debe ser sólo numérico, múltiplo de 3, entre 1 y 12 cuotas", "The installment value must be numeric, a multiple of 3, and between 1 and 12 installments." },
            { "La transacción fue exitosa y será guardada", "The transaction was successful and will be saved." },
            { "Se debe ingresar un número de tarjeta.", "A card number must be entered." },
            { "Se debe ingresar un mes y año válidos.", "A valid month and year must be entered." },
            { "El CCV es inválido. Deben ser sólo 3 números.", "The CCV is invalid. It must contain exactly 3 digits." },
            { "Se deben ingresar solo dos dígitos para el mes/año.", "Only two digits may be entered for the month/year." },
            { "Esta seguro que desea continuar", "Are you sure you want to continue?" },
            { "ya exsite la patente indicada", "The specified permission already exists." },
            { "ya exsite la familia indicada", "The specified family already exists." },
            { "Familia guardada correctamente", "Family saved successfully." },
            { "Error al guardar la familia", "Error saving the family." },
            { "El usuario ya tiene la patente indicada", "The user already has the specified permission." },
            { "Seleccione un usuario", "Select a user." },
            { "El usuario ya tiene la familia indicada", "The user already has the specified family." },
            { "Usuario guardado correctamente", "User saved successfully." },
            { "Error al guardar el usuario", "Error saving the user." },
            { "Seleccione una orden de compra para realizar el pago.", "Select a purchase order to make the payment." },
            { "El pago de la orden de compra se ha registrado correctamente.", "The purchase order payment was registered successfully." },
            { "Seleccione un reporte.", "Select a report." },
            { "Reporte", "Report" },
            { "Confirma eliminar", "Confirm deletion" },
            { "Confirmar eliminación", "Confirm deletion" },
            { "Confirmar reemplazo", "Confirm replacement" },
            { "Se debe proporcionar nomre de usuario y/o contraseña", "A username and/or password must be provided." },
            { "Formato de JSON invalido.", "Invalid JSON format." },
            { "Error al recalcular los DV's: ", "Error recalculating the verification digits: " },
            { "Se debe proporcionar id cliente y de factura para despachar.", "A customer and invoice ID must be provided for dispatch." },
            { "Se debe seleccionar una fila de la lista", "Select a row from the list." },
            { "Debe seleccionar una fila para serializar.", "Select a row to serialize." },
            { "Orden de compra recibida y productos actualizados correctamente.", "Purchase order received and products updated successfully." },
            { "Seleccione una orden de compra.", "Select a purchase order." },
            { "No se pudo obtener la orden seleccionada.", "The selected order could not be retrieved." },
            { "Comentario guardado correctamente.", "Comment saved successfully." },
            { "Proveedor agregado con éxito.", "Provider added successfully." },
            { "El CUIT debe contener sólo números.", "The tax ID must contain only numbers." },
            { "Todos los campos deben ser completados.", "All fields must be completed." },
            { "Los campos CUIT, Email y Nombre deben ser completados.", "The tax ID, email, and name fields must be completed." },
            { "Proveedor actualizado con éxito.", "Provider updated successfully." },
            { "La cantidad deseada es inválida. Sólo números.", "The desired quantity is invalid. Numbers only." },
            { "No hay elementos en el carrito.", "There are no items in the cart." },
            { "No se ha encontrado el cliente. Se procederá a la pantalla de alta de cliente.", "The customer was not found. The customer registration screen will be opened." },
            { "Se debe introducir un número de cliente", "A customer number must be entered." },
            { "No hay productos en el carrito.", "There are no products in the cart." },
            { "Se canceló la modificación. ", "The modification was cancelled. " },
            { "Se canceló la operación.", "The operation was cancelled." },
            { "El documento fue creado exitosamente en ", "The document was created successfully at " },
            { "Se ha generado una factura con id: ", "An invoice was generated with ID: " },
            { "Se ha despachado la factura: ", "Invoice dispatched: " },
            { "El nombre de usuario es: ", "The username is: " },
            { "Intento de creacion de usuario fallido. Motivo: ", "User creation attempt failed. Reason: " },
            { "El proveedor seleccionado no cuenta con todos sus datos. ", "The selected provider does not have all of its information. " },
            { "Se debe seleccionar un proveedor.", "Select a provider." },
            { "Debe seleccionar un proveedor.", "Select a provider." },
            { "Debe agregar al menos un producto a la solicitud de cotización.", "You must add at least one product to the quote request." },
            { "El proveedor seleccionado ya se encuentra registrado. ", "The selected provider is already registered. " },
            { "El proveedor seleccionado no se encuentra registrado. ", "The selected provider is not registered. " },
            { "Registro de proveedor completado con éxito.", "Provider registration completed successfully." },
            { "Orden de compra generada con éxito.", "Purchase order generated successfully." },
            { "Idioma seleccionado: ", "Selected language: " }
        };

        public void mostrarErrorNoLogged() {
            MessageBox.Show(Traducir("No se detecta un usuario loggeado. Se debe ingresar al sistema"));
        }

        public void mostrarMensaje(string mensaje) {
            MessageBox.Show(Traducir(mensaje));
        }

        public DialogResult mostrarConfirmacion(string mensaje, string titulo, MessageBoxButtons botones, MessageBoxIcon icono) {
            return MessageBox.Show(Traducir(mensaje), Traducir(titulo), botones, icono);
        }

        public static string Traducir(string mensaje) {
            if (string.IsNullOrEmpty(mensaje) || CultureInfo.CurrentUICulture.Name.StartsWith("es", StringComparison.OrdinalIgnoreCase)) {
                return mensaje;
            }

            if (mensaje.StartsWith("Usuario ", StringComparison.Ordinal) && mensaje.EndsWith(" ha sido desbloqueado.", StringComparison.Ordinal)) {
                string usuario = mensaje.Substring("Usuario ".Length, mensaje.Length - "Usuario ".Length - " ha sido desbloqueado.".Length);
                return "User " + usuario + " was unlocked.";
            }

            if (mensaje.StartsWith("Usuario ", StringComparison.Ordinal) && mensaje.EndsWith(" modificado", StringComparison.Ordinal)) {
                string usuario = mensaje.Substring("Usuario ".Length, mensaje.Length - "Usuario ".Length - " modificado".Length);
                return "User " + usuario + " modified";
            }

            if (mensaje.StartsWith("El usuario ", StringComparison.Ordinal) && mensaje.EndsWith(" ya existe. Utilice uno distinto.", StringComparison.Ordinal)) {
                string usuario = mensaje.Substring("El usuario ".Length, mensaje.Length - "El usuario ".Length - " ya existe. Utilice uno distinto.".Length);
                return "User " + usuario + " already exists. Use a different one.";
            }

            if (mensaje.StartsWith("Se ha despachado la factura: ", StringComparison.Ordinal)) {
                return "Invoice dispatched: " + mensaje.Substring("Se ha despachado la factura: ".Length).Replace(". Podrá ser visualizada en la carpeta Facturas despachadas.", ". It can be viewed in the Dispatched Invoices folder.");
            }

            if (mensaje.StartsWith("Se ha generado una factura con id: ", StringComparison.Ordinal)) {
                return "An invoice was generated with ID: " + mensaje.Substring("Se ha generado una factura con id: ".Length);
            }

            if (mensaje.StartsWith("El documento fue creado exitosamente en ", StringComparison.Ordinal)) {
                return "The document was created successfully at " + mensaje.Substring("El documento fue creado exitosamente en ".Length);
            }

            if (mensaje.StartsWith("La cantidad deseada es inválida. Debe ser mayor a 0 y menor al stock actual (", StringComparison.Ordinal)) {
                return "The desired quantity is invalid. It must be greater than 0 and less than the current stock (" + mensaje.Substring("La cantidad deseada es inválida. Debe ser mayor a 0 y menor al stock actual (".Length);
            }

            foreach (KeyValuePair<string, string> traduccion in traducciones) {
                if (mensaje.StartsWith(traduccion.Key, StringComparison.Ordinal)) {
                    return traduccion.Value + mensaje.Substring(traduccion.Key.Length);
                }
            }

            if (mensaje.StartsWith("Error al generar PDF: ", StringComparison.Ordinal)) {
                return "Error generating PDF: " + mensaje.Substring("Error al generar PDF: ".Length);
            }

            if (mensaje.StartsWith("Se ha detectado un error de arranque. ", StringComparison.Ordinal)) {
                return "A startup error was detected. Please contact the administrator.";
            }

            return mensaje;
        }
    }
}
