using SpaceShuttleCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SpaceShuttle spaceShuttle = new SpaceShuttle("Буран", 2400.0, 48.0, 100); //экземпляр(объект) челнока с исходными параметрами: Имя: "Буран-Next". Топливо: 2400.0 кг. Кислород: 48.0 часов. Корпус: 100 %.

            Console.WriteLine("Стартовая телеметрия через PrintTelemetry:");
            spaceShuttle.PrintTelemetry();

            Console.WriteLine("Маневровый импульс ExecuteOrbitalBurn(15, 8.0):");
            spaceShuttle.ExecuteOrbitalBurn(15, 8.0);

            Console.WriteLine("Запуск проверки CheckSystems():");
            spaceShuttle.CheckSystems();

            Console.WriteLine("Длительный разгонный прожиг ExecuteOrbitalBurn(60, 15.0):");
            spaceShuttle.ExecuteOrbitalBurn(60, 15.0);

            Console.WriteLine("Вход в атмосферу PerformAtmosphericEntry():");
            spaceShuttle.PerformAtmosphericEntry();

            Console.WriteLine("Повторная диагностика CheckSystems():");
            spaceShuttle.CheckSystems();

            Console.WriteLine("Финальное состояние шаттла через PrintTelemetry():");
            spaceShuttle.PrintTelemetry();
        }
    }
}
