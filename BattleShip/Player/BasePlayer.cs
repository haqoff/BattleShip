using System.Collections.Generic;

namespace BattleShip.Player
{
    public class BasePlayer
    {
        private PlayerGameSettings gameSettings;
        private bool waitingForStep;

        private List<int> leftShipsSizesPattern;
        private List<Ship> ships;
        private List<Cell> steps;

        public Stage StageType { get; private set; }
        public virtual BasePlayer EnemyPlayer { get; set; }

        public delegate void PlayerShipEventHandler(BasePlayer player, Ship ship);
        public delegate void PlayerCellEventHandler(BasePlayer player, Cell cell);
        public delegate void PlayerEventHandler(BasePlayer player);

        /// <summary>
        /// Происходит, когда был убит последний корабль игрока.
        /// </summary>
        public event PlayerEventHandler AllShipsDied;

        /// <summary>
        /// Происходит, когда по этому игроку промахнулись.
        /// </summary>
        public event PlayerCellEventHandler ShotMissed;

        /// <summary>
        /// Происходит, когда блок корабля был уничтожен.
        /// </summary>
        public event PlayerCellEventHandler ShipBlockDamaged;

        /// <summary>
        /// Происходит, когда был добавлен новый корабль.
        /// </summary>
        public event PlayerShipEventHandler ShipAdded;

        /// <summary>
        /// Происходит, когда корабль был уничтожен полностью.
        /// </summary>
        public event PlayerShipEventHandler ShipDied;


        /// <summary>
        /// Инициализирует новый экземпляр класса BasePlayer.
        /// </summary>
        /// <param name="gameSettings">Настройки для игрока.</param>
        public BasePlayer(PlayerGameSettings gameSettings)
        {
            this.gameSettings = gameSettings;
            waitingForStep = false;

            ships = new List<Ship>();
            steps = new List<Cell>();
            leftShipsSizesPattern = new List<int>(gameSettings.ShipsSizesPattern);

            StageType = Stage.Arrangement;
        }


        /// <summary>
        /// Пытается добавить корабль.
        /// </summary>
        /// <param name="ship"></param>
        public void AddShip(Ship ship)
        {
            if (StageType != Stage.Arrangement || !leftShipsSizesPattern.Contains(ship.Size)) return;

            foreach (var cell in ship.GetCells())
            {
                //Если какая-то ячейка корабля не внутри поля, выходим. 
                if (!cell.IsInside(gameSettings.LeftBottom, gameSettings.PlaceRightBottom)) return;
            }

            foreach (var s in ships)
            {
                //Если какой-то корабль конфликтует с этим кораблём, выходим.
                if (s.IsConflict(ship)) return;
            }

            ships.Add(ship);

            leftShipsSizesPattern.Remove(ship.Size);
            //Если в паттерне размеров больше не осталось, значит все корабли расставлены!
            if (leftShipsSizesPattern.Count == 0) StageType = Stage.Game;
            ShipAdded?.Invoke(this, ship);
        }

        /// <summary>
        /// Сказать, что от этого игрока ожидается ход.
        /// </summary>
        public virtual void BindStep() => waitingForStep = true;

        /// <summary>
        /// Сделать ход. Попытаться попасть в соперника. 
        /// </summary>
        /// <param name="cell"></param>
        public void MakeStep(Cell cell)
        {
            if (!waitingForStep || EnemyPlayer == null || EnemyPlayer.StageType != Stage.Game || steps.Contains(cell)
                || !cell.IsInside(EnemyPlayer.gameSettings.LeftBottom, EnemyPlayer.gameSettings.PlaceRightBottom)) return;

            steps.Add(cell);
            waitingForStep = false;
            EnemyPlayer.Hit(cell);
        }

        /// <summary>
        /// Выстрелить по этому игроку.
        /// </summary>
        /// <param name="cell"></param>
        protected virtual void Hit(Cell cell)
        {
            bool missedShot = true;
            foreach (var ship in ships)
            {
                int damagedBlock = ship.GetBlockIndex(cell);
                if (damagedBlock > -1)
                {
                    ship.Hit(damagedBlock);
                    missedShot = false;
                    if (ship.IsAlive()) ShipBlockDamaged?.Invoke(this, cell);
                    else
                    {
                        ships.Remove(ship);
                        ShipDied?.Invoke(this, ship);
                        if (GetCountAliveShips() == 0) AllShipsDied?.Invoke(this);
                    }

                    break;
                }
            }
            if (missedShot)
            {
                ShotMissed?.Invoke(this, cell);
                BindStep();
            }
            else
            {
                EnemyPlayer.BindStep();
            }
        }

        /// <summary>
        /// Возвращает количество живых кораблей.
        /// </summary>
        /// <returns></returns>
        public int GetCountAliveShips() => ships.Count;

        /// <summary>
        /// Возвращает паттерн оставшихся нераставленных кораблей. 
        /// </summary>
        /// <returns></returns>
        public int[] GetLeftShipsSizesPattern() => leftShipsSizesPattern.ToArray();

        /// <summary>
        /// Тип состояния.
        /// </summary>
        public enum Stage
        {
            Arrangement,    //Расстановка кораблей.
            Game            //Игра.            
        }
    }
}
