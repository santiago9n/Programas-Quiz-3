/*Programa 2:Desarrolle un programa en C# que solicite tres datos: placa del vehículo, cantidad de horas estacionado y tipo de 
 * vehículo (1 = Moto, 2 = Auto, 3 = Camioneta).Utilice if-else para comprobar que las horas estén entre 1 y 24. 
 * Emplee switch para definir la tarifa por hora: Moto: $0.75 por hora. Auto: $1.50 por hora. Camioneta: $2.25 por hora
 * El programa debe realizar dos operaciones: calcular el costo base según las horas y aplicar un descuento del 10% si el 
 * vehículo permaneció más de 8 horas. Debe mostrar dos salidas: costo base y total a pagar después del posible descuento.
 * Guarde todos los datos y resultados en un archivo llamado reporte_estacionamiento.txt, incluyendo la fecha y hora en que se generó cada reporte.
 */

using System;
using System.Numerics;
using System.IO;

class Program2
{
    static void Main(string[] args)
    {
        string placaVeiculo;
        double tarifaHora = 0, costoBase = 0, descuento = 0, total = 0;
        int horasEstacionado;
        int tipoVeiculo;

        // Solicitar datos al usuario
        Console.WriteLine("Ingrese la placa del vehiculo:");
        placaVeiculo = Console.ReadLine();
        Console.WriteLine("Ingrese la cantidad de horas estacionado:");
        horasEstacionado = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el tipo de vehiculo (1-Moto, 2-Carro,3-Camioneta)");
        tipoVeiculo = int.Parse(Console.ReadLine());

        //validar horas
        if (horasEstacionado < 1 || horasEstacionado > 24)
        {
            Console.WriteLine("Error: la cantidad de horas debe estar entre 1 y 24");
            return;
        }
        //asignar tarifa por hora segun el tipo de vehiculo
        string Vehiculo = "";
        switch (tipoVeiculo)
        {
            case 1:
                Vehiculo = "Moto";
                tarifaHora = 0.75;
                break;

            case 2:
                Vehiculo = "Carro";
                tarifaHora = 1.50;
                break;

            case 3:
                Vehiculo = "Camioneta";
                tarifaHora = 2.25;
                break;

            default:
                Console.WriteLine("Tipo de vehiculo invalido. Ingrese 1, 2 o 3");
                break;
        }

        costoBase = horasEstacionado * tarifaHora;//calcular costo base

        if (horasEstacionado > 8)//aplicar descuento del 10% si el vehiculo permanecio mas de 8 horas
        {
            descuento = costoBase * 0.10;
        }
        else
        {
            descuento = 0;
            Console.WriteLine("No aplica descuento");
        }

        // Calcular total a pagar
        total = costoBase - descuento;

        // Mostrar resultados
        Console.WriteLine("\nCosto base: $" + costoBase.ToString("F2"));
        Console.WriteLine("Total a pagar: $" + total.ToString("F2"));

        // Definir la ruta del archivo
        string usuario = Environment.UserName;
        string filePath = @"C:\Users\" + usuario + @"\D\Programa2Vehiculos\reporte_estacionamiento.txt";

        // Crear el contenido del reporte
        string contenidoReporte =
            "-------REPORTE DE ESTACIONAMIENTO----------\n" +
            $"Fecha y hora: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n" +
            $"Placa: {placaVeiculo}\n" +
            $"Horas estacionado: {horasEstacionado}\n" +
            $"Tipo de vehiculo: {Vehiculo}\n" +
            $"Tarifa por hora: ${tarifaHora:F2}\n" +
            $"Costo base: ${costoBase:F2}\n" +
            $"Descuento aplicado: ${descuento:F2}\n" +
            $"Total a pagar: ${total:F2}\n";

        // Guardar el reporte
        File.AppendAllText(filePath, contenidoReporte + "\n");

        Console.WriteLine("\nReporte guardado en:");
        Console.WriteLine(filePath);
    }
}