using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShuttleCore
{
    public partial class SpaceShuttle
    {
        /// <summary>
        /// моделирует работу маршевого двигателя: Расход топлива вычисляется по формуле: burnTimeSeconds * thrustPower * 2.5. Если топлива недостаточно, маневр прерывается с выводом ошибки в консоль. При успешном прожиге топливо списывается, а износ корпуса увеличивается на 1% за каждые 10 секунд работы.
        /// </summary>
        /// <param name="burnTimeSeconds">время работы двигателя</param>
        /// <param name="thrustPower">тяга(сила вырабатываемая двигателем)</param>
        public void ExecuteOrbitalBurn(double burnTimeSeconds, double thrustPower)
        {
            double expenseFuel = burnTimeSeconds * thrustPower * 2.5; //расход топлива

            //хватает ли топлива в баке?
            if (expenseFuel > _fuelKg) //не хватило
            {
                Console.WriteLine("Топливо недостаточно!");
                return;
            }
            else //хватило
            {
                FuelKg = FuelKg - expenseFuel;
                int wear = (int)(burnTimeSeconds / 10);
                HullIntegrity = HullIntegrity - wear;
                Console.WriteLine($"Манёвр удался! Сожжено: {FuelKg} топлива. Износ корпуса: {wear}%.");
            }
        }
        /// <summary>
        /// маневр входа в плотные слои атмосферы: Снижает прочность корпуса _hullIntegrity на случайную величину от 10% до 25%. Списывает 1.5 часа запаса кислорода.
        /// </summary>
        /// <param name="hullIntegrity">прочность корпуса</param>
        /// <param name="oxygenHours">запас кислорода</param>
        /// <returns></returns>
        public void PerformAtmosphericEntry()
        {
            Random rnd = new Random();

            int damagehullIntegrity = rnd.Next(10, 26);
            _hullIntegrity = _hullIntegrity - damagehullIntegrity;

            _oxygenHours = _oxygenHours - 1.5;
            if (_oxygenHours <= 0) //не ушел ли кислород в минус?
            {
                _oxygenHours = 0;
            }
            Console.WriteLine($"Вход в атмосферу выполнен: износ корпуса {damagehullIntegrity}%, а так же кислород -1.5 ч.");
        }
    }
}
