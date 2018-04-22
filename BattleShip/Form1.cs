using BattleShip.Player;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BattleShip
{
    public partial class BattleShipForm : Form
    {
        private DataGridViewPlayer player1;
        private DataGridViewPlayer player2;

        public BattleShipForm()
        {
            InitializeComponent();
        }

        private void BattleShipForm_Load(object sender, EventArgs e) => StartGame();

        private void StartGame()
        {
            var settings = new PlayerGameSettings()
            {
                LeftBottom = new Cell(0, 0),
                PlaceRightBottom = new Cell(9, 9),
                ShipsSizesPattern = new int[] { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 }
            };

            var colorParam = new ColorParameters()
            {
                empty = Color.White,
                aliveBlockShip = Color.Green,
                damagedBlock = Color.HotPink,
                diedShip = Color.Red,
                missedShot = Color.WhiteSmoke

            };

            player1 = new DataGridViewPlayer(dgvPlayer1Place, dgvPlayer1Shots, colorParam, settings);
            player2 = new DataGridViewPlayer(dgvPlayer2Place, dgvPlayer2Shots, colorParam, settings);

            player1.AllShipsDied += OnPlayerLose;
            player2.AllShipsDied += OnPlayerLose;

            player1.ShipAdded += OnPlayer1AddShip;
            player2.ShipAdded += OnPlayer2AddShip;

            UpdateNextShipSize(player1, lblPlayer1NextShip, cbPlayer1Horizontal);
            UpdateNextShipSize(player2, lblPlayer2NextShip, cbPlayer2Horizontal);

            player1.EnemyPlayer = player2;
            player2.EnemyPlayer = player1;

            player1.BindStep();
        }
       
        private void OnPlayer1AddShip(BasePlayer player, Ship ship) => UpdateNextShipSize(player, lblPlayer1NextShip, cbPlayer1Horizontal);

        private void OnPlayer2AddShip(BasePlayer player, Ship ship) => UpdateNextShipSize(player, lblPlayer2NextShip,cbPlayer2Horizontal);

        private void UpdateNextShipSize(BasePlayer player, Label label, CheckBox cb)
        {
            int[] pattern = player.GetLeftShipsSizesPattern();
            if (pattern.Length == 0)
            {
                label.Visible = false;
                cb.Visible = false;
            }
            else
            {
                label.Text = "Следующий размер корабля: " + pattern[0];
                if (pattern[0] == 1) cb.Visible = false;
            }
        }

        private void OnPlayerLose(BasePlayer player)
        {
            MessageBox.Show("Игра окончена.");
            StartGame();
        }

        private void cbPlayer1Horizontal_CheckedChanged(object sender, EventArgs e)
        {
            player1.AddHorisontalShip = cbPlayer1Horizontal.Checked;
        }

        private void cbPlayer2Horizontal_CheckedChanged(object sender, EventArgs e)
        {
            player2.AddHorisontalShip = cbPlayer2Horizontal.Checked;
        }
    }
}
