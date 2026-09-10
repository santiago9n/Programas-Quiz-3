/*Programa 1: Cálculo de factura eléctrica según tipo de cliente
 * Desarrolle un programa en C# que solicite tres datos: nombre del cliente, cantidad de kilovatios consumidos y tipo de cliente
 * (1 = Residencial, 2 = Comercial, 3 = Industrial). Utilice if-else para validar que el consumo sea mayor que cero. 
 * Luego, use switch para aplicar una tarifa según el tipo de cliente: Residencial: $0.15 por kWh,Comercial: $0.22 por kWh,
 * Industrial: $0.30 por kWh. El programa debe realizar dos operaciones: calcular el subtotal del consumo y calcular 
 * un recargo del 7% sobre dicho subtotal. Debe mostrar dos salidas: el subtotal y el total a pagar con recargo.
 * Finalmente, guarde la respuesta en un archivo de texto llamado factura_electrica.txt, incluyendo nombre del cliente, 
 * consumo, tipo de cliente, resultados, fecha y hora de generación del reporte.
*/

using System;
using System.Numerics;
using System.IO;
class programa1
{
    static void Main(string[] args)
    {
        string nombre;
        double cantidadKWh, subtotal = 0, recargo, total = 0, tarifa=0;
        int opcionTipoCliente;

        Console.WriteLine("Ingrese su nombre:");
        nombre = Console.ReadLine();
        Console.WriteLine("Ingrese la cantidad de KWh consumidos:");
        cantidadKWh = double.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el tipo de cliente (1_Residencial, 2-Comercial, 3-Industrial):");
        opcionTipoCliente = int.Parse(Console.ReadLine());

        if (cantidadKWh <= 0)// Validar cantidad de KWh
        {
            Console.WriteLine("La cantidad de KWh consumidos debe ser mayor que cero");
            return;
        }

        string tipoCliente = ""; //almacena el tipo de cliente seleccionado

        switch (opcionTipoCliente)
        {
            case 1:
                tipoCliente = "Residencial";
                tarifa = 0.15;
                break;

            case 2:
                tipoCliente = "Comercial";
                tarifa = 0.22;
                break;

            case 3:
                tipoCliente = "Industrial";
                tarifa = 0.30;
                break;
            default:
                Console.WriteLine("Tipo de cliente invalido. Ingrese 1, 2 o 3");
                return;
        }

        
        subtotal = cantidadKWh * tarifa;// Calcular subtotal
        recargo = subtotal * 0.07;// Calcular recargo del 7%
        total = subtotal + recargo;// Calcular total
        // Mostrar resultados
        Console.WriteLine("\nSubtotal: $" + subtotal.ToString("F2"));
        Console.WriteLine("Total a pagar con recargo: $" + total.ToString("F2"));

        // Definir la ruta del archivo
        string usuario = Environment.UserName;
        string filePath = @"C:\Users\" + usuario +@"\Downloads\Programa1Energia\factura_electrica.txt";

        // Crear contenido del reporte
        string contenidoReporte =
            "-------FACTURA ELECTRICA------\n" +
            $"Fecha y hora: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n" +
            $"Nombre del cliente: {nombre}\n" +
            $"Cantidad de KWh: {cantidadKWh}\n" +
            $"Tipo de cliente: {tipoCliente}\n" +
            $"Subtotal: ${subtotal:F2}\n" +
            $"Recargo: ${recargo:F2}\n" +
            $"Total a pagar: ${total:F2}\n";
        // Guardar el reporte
        File.WriteAllText(filePath, contenidoReporte);
        Console.WriteLine("\nReporte guardado con éxito en:");
        Console.WriteLine(filePath);
    }
}