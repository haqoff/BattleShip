using System;
using System.Drawing;
using System.Windows.Forms;

namespace BattleShip.Player
{
    class DataGridViewPlayer : BasePlayer
    {
        public bool AddHorisontalShip { get; set; }
        private DataGridView place;
        private DataGridView shots;

        public override BasePlayer EnemyPlayer
        {
            get => base.EnemyPlayer;
            set
            {
                base.EnemyPlayer = value;

                EnemyPlayer.ShipBlockDamaged += OnEnemyBlockDamaged;
                EnemyPlayer.ShipDied += OnEnemyShipDied;
                EnemyPlayer.ShotMissed += OnMissedShotToEnemy;
            }
        }

        private ColorParameters parameters;


        public DataGridViewPlayer(DataGridView place, DataGridView shots, ColorParameters parameters, PlayerGameSettings settings)
            : base(settings)
        {
            this.place = place;
            this.shots = shots;
            this.parameters = parameters;

            PreparePlace(place);
            PreparePlace(shots);

            place.CellDoubleClick += OnPlaceDoubleClick;
            shots.CellDoubleClick += OnShotsDoubleClick;

            ShipAdded += OnShipAdded;
            ShipBlockDamaged += OnShipBlockDamaged;
            ShipDied += OnShipDied;
            ShotMissed += OnMissedShot;
        }

        /// <summary>
        /// Метод-слушатель, выполняется когда корабль противника уничтожен.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="ship"></param>
        public void OnEnemyShipDied(BasePlayer player, Ship ship)
        {
            foreach (var cell in ship.GetCells())
            {
                shots[cell.Column, cell.Row].Style.BackColor = parameters.diedShip;
                shots[cell.Column, cell.Row].Style.SelectionBackColor = parameters.diedShip;
            }
        }

        /// <summary>
        /// Метод-соушатель, выполняется когда корабль противника был ранен.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="cell"></param>
        public void OnEnemyBlockDamaged(BasePlayer player, Cell cell)
        {
            shots[cell.Column, cell.Row].Style.BackColor = parameters.damagedBlock;
            shots[cell.Column, cell.Row].Style.SelectionBackColor = parameters.damagedBlock;
        }

        /// <summary>
        /// Метод-слушатель, выполняется когда по противнику совершён промах.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="cell"></param>
        public void OnMissedShotToEnemy(BasePlayer player, Cell cell)
        {
            shots[cell.Column, cell.Row].Style.BackColor = parameters.missedShot;
            shots[cell.Column, cell.Row].Style.SelectionBackColor = parameters.missedShot;
        }

        /// <summary>
        /// Метод-слушатель, выполняется когда этот игрок потерял корабль.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="ship"></param>
        private void OnShipDied(BasePlayer player, Ship ship)
        {
            foreach (var cell in ship.GetCells())
            {
                place[cell.Column, cell.Row].Style.BackColor = parameters.diedShip;
                place[cell.Column, cell.Row].Style.SelectionBackColor = parameters.diedShip;
            }
        }

        /// <summary>
        /// Метод-слушатель, выполняется когда по этому игроку промахнулись.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="cell"></param>
        private void OnMissedShot(BasePlayer player, Cell cell)
        {
            place[cell.Column, cell.Row].Style.BackColor = parameters.missedShot;
            place[cell.Column, cell.Row].Style.SelectionBackColor = parameters.missedShot;
        }

        /// <summary>
        /// Метод-слушатель, выполняется когда какой-то блок корабля этого игрока получил урон.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="cell"></param>
        private void OnShipBlockDamaged(BasePlayer player, Cell cell)
        {
            place[cell.Column, cell.Row].Style.BackColor = parameters.damagedBlock;
            place[cell.Column, cell.Row].Style.SelectionBackColor = parameters.damagedBlock;
        }

        /// <summary>
        /// Метод-слушатель, выполняется когда для этого игрока был добавлен корабль
        /// </summary>
        /// <param name="player"></param>
        /// <param name="ship"></param>
        private void OnShipAdded(BasePlayer player, Ship ship)
        {
            foreach (var c in ship.GetCells())
            {
                place[c.Column, c.Row].Style.BackColor = parameters.aliveBlockShip;
                place[c.Column, c.Row].Style.SelectionBackColor = parameters.aliveBlockShip;
            }
        }

        /// <summary>
        /// Выполняется при двойном клике на ячейку на DataGridView для выстрелов по противнику.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnShotsDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var hitCell = new Cell(e.RowIndex, e.ColumnIndex);
            MakeStep(hitCell);
        }

        /// <summary>
        /// Выполняется при двойном клике на ячейку на DataGridView поля игрока.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPlaceDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (StageType != Stage.Arrangement) return;

            var pos = new Cell(e.RowIndex, e.ColumnIndex);
            var ship = new Ship(pos, GetLeftShipsSizesPattern()[0], AddHorisontalShip);
            AddShip(ship);
        }


        /// <summary>
        /// Подготавливает DataGridView для игры.
        /// </summary>
        /// <param name="dgv"></param>
        private void PreparePlace(DataGridView dgv)
        {
            char[] columnsHeaders = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И' };

            dgv.Rows.Clear();
            dgv.Columns.Clear();
            dgv.DefaultCellStyle.BackColor = parameters.empty;
            dgv.DefaultCellStyle.SelectionBackColor = parameters.empty;
            dgv.RowHeadersWidth = 48;
            //Добавляем строки и столбцы.
            for (int i = 0; i < 10; i++)
            {
                dgv.Columns.Add(i.ToString(), columnsHeaders[i].ToString());
                dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgv.Rows.Add();
                dgv.Rows[i].ReadOnly = true;
                dgv.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }

            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToOrderColumns = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.MultiSelect = false;
        }
    }


    public struct ColorParameters
    {
        /// <summary>
        /// Цвет пустой ячейки.
        /// </summary>
        public Color empty;

        /// <summary>
        /// Цвет блока живого корабля.
        /// </summary>
        public Color aliveBlockShip;

        /// <summary>
        /// Цвет ячейки пораженного блока корабля.
        /// </summary>
        public Color damagedBlock;

        /// <summary>
        /// Цвет ячеек полного мёртвого корабля.
        /// </summary>
        public Color diedShip;

        /// <summary>
        /// Цвет ячейки выстрела при промахе.
        /// </summary>
        public Color missedShot;
    }
}
