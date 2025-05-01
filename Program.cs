using System;
using System.Collections.Generic;
using Dsw2025Ej8.Domain;


namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 10. Instanciar 4 cuentas (dos de cada tipo)
            var cuentas = new List<CuentaBancaria>
            {
                new CuentaCorriente("CC1001",  500m, new[] { "Juan"   }),
                new CuentaCorriente("CC1002",  200m, new[] { "María"  }),
                new CajaAhorro    ("CA2001", 1000m, new[] { "Luis"   }),
                new CajaAhorro    ("CA2002",  150m, new[] { "Marta"  })
            };

            // Para probar excepciones de estado
            cuentas[1].Estado = Estado.Inactiva;   // CC1002 -> Inactiva
            cuentas[3].Estado = Estado.Suspendida; // CA2002 -> Suspendida

            // 10. Realizar operaciones que cubran todos los casos
            foreach (var cuenta in cuentas)
            {
                Console.WriteLine($"\n--- Cuenta {cuenta.Numero} ({cuenta.GetType().Name}), Estado: {cuenta.Estado}");

                SafeAction(() => cuenta.Depositar(300m), "[Depósito 300]");
                SafeAction(() => cuenta.Retirar(100m), "[Retiro 100]");
                SafeAction(() => cuenta.Depositar(0m), "[Depósito 0 (inválido)]");
                SafeAction(() => cuenta.Retirar(cuenta.Saldo + 500m),
                           $"[Retiro {cuenta.Saldo + 500m} (excede)]");

                if (cuenta is CajaAhorro caja)
                {
                    SafeAction(() => caja.AplicarInteres(), "[Aplicar interés]");
                }
            }

            // 11. Mostrar resumen final con clase anónima
            Console.WriteLine("\n=== Resumen de Cuentas ===");
            foreach (var c in cuentas)
            {
                var resumen = new
                {
                    Número = c.Numero,
                    Tipo = c.GetType().Name,
                    Saldo = c.Saldo,
                    Estado = c.Estado
                };
                Console.WriteLine(
                  $"Nro: {resumen.Número} | Tipo: {resumen.Tipo} | Saldo: {resumen.Saldo:F2} | Estado: {resumen.Estado}"
                );
            }
        }

        // Método auxiliar para ejecutar sin interrumpir si hay excepción
        static void SafeAction(Action operación, string etiqueta)
        {
            try
            {
                operación();
                Console.WriteLine($"{etiqueta} ✔");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{etiqueta} ✖ {ex.Message}");
            }



        }
    }
}
