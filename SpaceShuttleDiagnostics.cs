using SpaceShuttleCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShuttleCore
{
    #region Частичный метод
    public partial class SpaceShuttle
    {
        partial void OnCriticalSystemAlert(string systemName, string message);
        /// <summary>
        /// выводит в консоль красным цветом штамп тревоги бортового компьютера.
        /// </summary>
        /// <param name="systemName">Имя системы</param>
        /// <param name="message">сообщение</param>
        partial void OnCriticalSystemAlert(string systemName, string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Тревога! {systemName}: {message}");
            Console.ResetColor();
        }
        #endregion

        #region Методы
        /// <summary>
        /// проверяет показатели шаттла.
        /// </summary>
        public void CheckSystems()
        {
            if (_fuelKg < 500)
            {
                OnCriticalSystemAlert("Топливная система", "Критический остаток топлива!");
            }

            if (_hullIntegrity < 25)
            {
                OnCriticalSystemAlert("Контур обшивки", "Опасность разрушения корпуса!");
            }
        }
        /// <summary>
        /// аккуратно форматирует и выводит в консоль сводную таблицу всех текущих параметров корабля.
        /// </summary>
        public void PrintTelemetry()
        {
            Console.WriteLine($"Имя: {ShuttleName}.");
            Console.WriteLine($"Топливо: {_fuelKg}.");
            Console.WriteLine($"Кислород: {_oxygenHours}.");
            Console.WriteLine($"Корпус: {_hullIntegrity}.");
        }
        #endregion
    }
}
