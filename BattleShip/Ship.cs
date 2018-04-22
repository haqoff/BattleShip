using System;

namespace BattleShip
{
    public class Ship
    {
        private Block[] blocks;

        /// <summary>
        /// Позиция левой верхней клетки корабля.
        /// </summary>
        public Cell Position
        {
            get { return blocks[0]; }
        }

        /// <summary>
        /// Размер корабля.
        /// </summary>
        public int Size
        {
            get { return blocks.Length; }
        }


        public Ship(Cell position, int size, bool horizontal)
        {
            blocks = new Block[size];

            for (int i = 0; i < size; i++)
            {
                if (horizontal) blocks[i] = new Block(position.Row, position.Column + i);
                else blocks[i] = new Block(position.Row + i, position.Column);
            }
        }

        /// <summary>
        /// Проверяет является ли клетка живым блоком корабля.
        /// </summary>
        /// <param name="cell"></param>
        /// <returns>Возвращает индекс блока, если точка является живым блоком корабля и -1, если не является.</returns>
        public int GetBlockIndex(Cell cell)
        {
            for (int i = 0; i < blocks.Length; i++)
            {
                if (cell.Equals(blocks[i]) && blocks[i].Alive) return i;
            }
            return -1;
        }

        /// <summary>
        /// Убить блок корабля.
        /// </summary>
        /// <param name="blockIndex">Индекс блока.</param>
        public void Hit(int blockIndex) => blocks[blockIndex].Alive = false;

        /// <summary>
        /// Проверяет конфликтует ли расположение корабля с текущим кораблём.
        /// </summary>
        /// <param name="ship"></param>
        /// <returns>Возвращает true, если расположение кораблей конфликтует, иначе false.</returns>
        public bool IsConflict(Ship ship)
        {
            foreach (var thisBlock in blocks)
            {
                foreach (var outerBlock in ship.blocks)
                {
                    int offset_row = Math.Abs(thisBlock.Row - outerBlock.Row);
                    int offset_column = Math.Abs(thisBlock.Column - outerBlock.Column);

                    if (offset_row <= 1 && offset_column <= 1) return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Возвращает ячейки корабля.
        /// </summary>
        /// <returns></returns>
        public Cell[] GetCells() => blocks;

        /// <summary>
        /// Проверяет является ли корабль живым.
        /// </summary>
        /// <returns>Возвращает true, если в корабле остался хотя бы один живой блок, иначе false.</returns>
        public bool IsAlive()
        {
            foreach (var block in blocks)
            {
                if (block.Alive) return true;
            }

            return false;
        }

        /// <summary>
        /// Представляет собой один блок корабля.
        /// </summary>
        private class Block : Cell
        {
            public bool Alive { get; set; }
            public Block(int row, int column) : base(row, column)
            {
                Alive = true;
            }
        }
    }
}
