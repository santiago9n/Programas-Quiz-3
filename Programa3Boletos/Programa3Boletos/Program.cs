/*Programa 3: Venta de boletos para un evento
 * Desarrolle un programa en C# que solicite tres datos: nombre del comprador, cantidad de boletos y categoría seleccionada 
 * (1 = General, 2 = Preferencial, 3 = VIP).Utilice if-else para validar que la cantidad de boletos esté entre 1 y 10. 
 * Luego, use switch para determinar el precio unitario: General: $15.00,Preferencial: $30.00, VIP: $50.00.El programa 
 * debe realizar dos operaciones: calcular el subtotal de la compra y calcular un descuento del 12% cuando se compren 5
 * o más boletos. Debe mostrar dos salidas: subtotal y total final a pagar.El programa debe guardar los datos del comprador, 
 * categoría, boletos, resultados, fecha y hora de generación en un archivo de texto llamado reporte_boletos.txt.
*/


using System;
using System.IO;

class programa3
{
    static void Main(string[] args)
    {
        string nombreComprador;
        int cantidadBoletos=0,opcionCategoria=0;
        double precioUnitario = 0, subtotal = 0,descuento = 0,total = 0;

        // Solicitar datos
        Console.WriteLine("Ingrese el nombre del comprador:");
        nombreComprador = Console.ReadLine();

        Console.WriteLine("Ingrese la cantidad de boletos:");
        cantidadBoletos = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese la categoría (1-General, 2-Preferencial, 3-VIP):");
        opcionCategoria = int.Parse(Console.ReadLine());

        // Validar cantidad de boletos
        if (cantidadBoletos < 1 || cantidadBoletos > 10)
        {
            Console.WriteLine("Error: la cantidad de boletos debe estar entre 1 y 10.");
            return;
        }

        string categoria = "";//almacenar tipo de categoria

        switch (opcionCategoria)
        {
            case 1:
                categoria = "General";
                precioUnitario = 15.00;
                break;

            case 2:
                categoria = "Preferencial";
                precioUnitario = 30.00;
                break;

            case 3:
                categoria = "VIP";
                precioUnitario = 50.00;
                break;

            default:
                Console.WriteLine("Categoría inválida, ingrese 1, 2 o 3.");
                return;
        }

        subtotal = cantidadBoletos * precioUnitario;// Calcular subtotal

        if (cantidadBoletos >= 5)// Aplicar descuento
        {
            descuento = subtotal * 0.12;
        }
        else
        {
            descuento = 0;
            Console.WriteLine("No aplica descuento.");
        }

        total = subtotal - descuento;// Calcular total

        // Mostrar resultados
        Console.WriteLine("\nSubtotal: $" + subtotal.ToString("F2"));
        Console.WriteLine("Total final a pagar: $" + total.ToString("F2"));

        // establecer la ruta del archivo
        string usuario = Environment.UserName;
        string carpetaDestino = @"C:\Users\" + usuario +@"\Downloads\Programa3Boletos";
        string filePath = carpetaDestino +@"\reporte_boletos.txt";
        Directory.CreateDirectory(carpetaDestino);

        // Crear contenido del reporte
        string contenidoReporte =
            "------REPORTE DE BOLETOS-----\n" +
            $"Fecha y hora: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n" +
            $"Nombre del comprador: {nombreComprador}\n" +
            $"Cantidad de boletos: {cantidadBoletos}\n" +
            $"Categoría: {categoria}\n" +
            $"Subtotal: ${subtotal:F2}\n" +
            $"Descuento: ${descuento:F2}\n" +
            $"Total final a pagar: ${total:F2}\n";

        // Guardar el reporte
        File.WriteAllText(filePath, contenidoReporte);
        Console.WriteLine("\nReporte guardado con éxito en:");
        Console.WriteLine(filePath);
    }
}