using System;

namespace BattleShip
{
    /// <summary>
    /// Представляет собой одну ячейку.
    /// </summary>
    public class Cell
    {
        public int Row { get; private set; }
        public int Column { get; private set; }

        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
        }

        /// <summary>
        /// Проверяет находится ли данная ячейка в диапазоне между c1 и c2, включая c1 и c2
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns>Возвращает true, если эта ячейка находится в диапазоне между c1 и c2, иначе false.</returns>
        public bool IsInside(Cell c1, Cell c2)
        {
            if ((Row >= c1.Row && Row <= c2.Row) || (Row >= c2.Row && Row <= c1.Row))
                if ((Column >= c1.Column && Column <= c2.Column) || (Column >= c2.Column && Column <= c1.Column)) return true;

            return false;
        }

        /// <summary>
        /// Проверяет имеет ли этот обьект такие же значения Row и Column, что и заданный object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Cell cell)
            {
                if (Row == cell.Row && Column == cell.Column) return true;
            }
            return false;
        }
    }
}
