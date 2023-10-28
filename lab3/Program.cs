using lab3;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        using var context = new lab3Context();

        try
        {
            while (true)
            {
                var equiposList = context.equipos.ToList();
                Console.WriteLine("Equipos:");
                foreach (var equipo in equiposList)
                {
                    Console.WriteLine($"ID: {equipo.id}, Nombre: {equipo.equipo}, Puntos: {equipo.puntos}");
                }

                var newequipo = new equipos { equipo = "Nuevo Equipo", puntos = 5, jugadores = 11, representante = "Juan" };
                context.equipos.Add(newequipo);
                context.SaveChanges();
                Console.WriteLine("Nuevo equipo añadido!");

                var equipoToUpdate = context.equipos.FirstOrDefault(e => e.id == 1);
                if (equipoToUpdate != null)
                {
                    equipoToUpdate.puntos = 7;
                    context.SaveChanges();
                    Console.WriteLine("Puntos del equipo actualizados!");
                }

                Console.WriteLine("Ingrese el ID del equipo cuyo nombre desea modificar:");
                int idToModify;
                if (int.TryParse(Console.ReadLine(), out idToModify))
                {
                    var equipoToModify = context.equipos.FirstOrDefault(e => e.id == idToModify);
                    if (equipoToModify != null)
                    {
                        Console.WriteLine("Ingrese el nuevo nombre para el equipo:");
                        equipoToModify.equipo = Console.ReadLine();
                        context.SaveChanges();
                        Console.WriteLine("Nombre del equipo actualizado!");
                    }
                    else
                    {
                        Console.WriteLine("No se encontró un equipo con el ID especificado.");
                    }
                }
                else
                {
                    Console.WriteLine("ID no válido.");
                }

                Console.Write("¿Si desea agregar más estudiantes, presione (S) y si ya no desea ingresar, presione (N): ");
                var respuesta = Console.ReadLine();
                if (respuesta?.Trim().ToLower() != "s")
                {
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Se ha producido un error: {ex.Message}");
        }
    }
}
