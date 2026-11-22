using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShuttleCore
{
    public partial class SpaceShuttle
    {
        #region Поля
        private double _fuelKg; //масса топлива
        private double _oxygenHours; //запас кислорода
        private int _hullIntegrity; //прочность корпуса
        #endregion

        #region Свойства
        public string ShuttleName { get; set; }

        public double FuelKg
        {
            get { return _fuelKg; }
            set
            {
                if (value <= 0) _fuelKg = 0;
                else _fuelKg = value;
            }
        }

        public int HullIntegrity
        {
            get { return _hullIntegrity; }
            set
            {
                if (value <= 0) _hullIntegrity = 0;
                else if (value >= 100) _hullIntegrity = 100;
                else _hullIntegrity = value;
            }
        }
        public bool IsOperational => _hullIntegrity > 15 && _oxygenHours > 0;
        #endregion

        #region Конструктор
        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="shuttleName">Имя</param>
        /// <param name="fuelKg">Топливо</param>
        /// <param name="oxygenHours">Кислород</param>
        /// <param name="hullIntegrity">Корпус</param>
        public SpaceShuttle(string shuttleName, double fuelKg, double oxygenHours, int hullIntegrity)
        {
            this.ShuttleName = shuttleName;
            this.FuelKg = fuelKg;
            this._oxygenHours = oxygenHours;
            this.HullIntegrity = hullIntegrity;
        }
        #endregion
    }
}
