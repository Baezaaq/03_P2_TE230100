namespace E03_TEMPERATURA_DE_MOTOR
{
    // 1. CLASE PRUEBA TEMPERATURA
    public class PruebaTemperatura
    {

        // PROPIEDADES DE LA CLASE
        public double[] Temperaturas { get; private set; }
        public double Promedio { get; private set; }
        public string Estado { get; private set; }

        // MÉTODO CONSTRUCTOR
        public PruebaTemperatura()
        {
            Temperaturas = new double[5];
            Promedio = 0;
            Estado = "";
        }

        // MÉTODO PARA AGREGAR LECTURA DE TEMPERATURA
        public void AgregarTemperatura(int indice, double valor)
        {
            if (indice >= 0 && indice < 5)
            {
                Temperaturas[indice] = valor;
            }
        }

        // MÉTODO PARA CALCULAR EL PROMEDIO DE LECTURAS
        public double CalcularPromedio()
        {
            double suma = 0;
            for (int i = 0; i < Temperaturas.Length; i++)
            {
                suma += Temperaturas[i];
            }
            Promedio = suma / Temperaturas.Length;
            return Promedio;
        }

        // MÉTODO PARA DETERMINAR EL ESTADO DEL MOTOR
        public string DeterminarEstado()
        {
            if (Promedio <= 70.0)
            {
                Estado = "NORMAL";
            }
            else
            {
                Estado = "ALERTA DE TEMPERATURA";
            }
            return Estado;
        }
    }

    // 2. CLASE PRINCIPAL DE EJECUCIÓN
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=================================================");
            Console.WriteLine("   PRUEBA DE CONSUMO TÉRMICO DE MOTOR DE CD     ");
            Console.WriteLine("=================================================\n");

            PruebaTemperatura prueba = new PruebaTemperatura();

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Ingrese la lectura de temperatura {i + 1} (°C): ");

                double lectura;
                while (!double.TryParse(Console.ReadLine(), out lectura))
                {
                    Console.Write("Entrada inválida. Ingrese un valor numérico (°C): ");
                }

                prueba.AgregarTemperatura(i, lectura);
            }

            double promedio = prueba.CalcularPromedio();
            string estado = prueba.DeterminarEstado();

            Console.WriteLine("\n-------------------------------------------------");
            Console.WriteLine("RESULTADOS DE LA EVALUACIÓN:");
            Console.WriteLine($"Promedio de Temperatura: {promedio:F2} °C");
            Console.WriteLine($"Estado del Motor:        {estado}");
            Console.WriteLine("-------------------------------------------------");

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
