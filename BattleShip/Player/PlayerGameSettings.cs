using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Player
{
    public struct PlayerGameSettings
    {
        /// <summary>
        /// Самая левая верхняя ячейка.
        /// </summary>
        public Cell LeftBottom { get; set; }

        /// <summary>
        /// Самая правая нижняя ячейка игрового поля.
        /// </summary>
        public Cell PlaceRightBottom { get; set; }

        /// <summary>
        /// Паттерн размеров кораблей.
        /// </summary>
        public int[] ShipsSizesPattern{ get; set; }
    }
}
