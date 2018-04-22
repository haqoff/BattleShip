namespace BattleShip
{
    partial class BattleShipForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pPlayer1 = new System.Windows.Forms.Panel();
            this.dgvPlayer1Shots = new System.Windows.Forms.DataGridView();
            this.dgvPlayer1Place = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvPlayer2Shots = new System.Windows.Forms.DataGridView();
            this.dgvPlayer2Place = new System.Windows.Forms.DataGridView();
            this.lblPlayer1NextShip = new System.Windows.Forms.Label();
            this.lblPlayer2NextShip = new System.Windows.Forms.Label();
            this.cbPlayer1Horizontal = new System.Windows.Forms.CheckBox();
            this.cbPlayer2Horizontal = new System.Windows.Forms.CheckBox();
            this.pPlayer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayer1Shots)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayer1Place)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayer2Shots)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayer2Place)).BeginInit();
            this.SuspendLayout();
            // 
            // pPlayer1
            // 
            this.pPlayer1.Controls.Add(this.cbPlayer1Horizontal);
            this.pPlayer1.Controls.Add(this.lblPlayer1NextShip);
            this.pPlayer1.Controls.Add(this.dgvPlayer1Shots);
            this.pPlayer1.Controls.Add(this.dgvPlayer1Place);
            this.pPlayer1.Location = new System.Drawing.Point(16, 114);
            this.pPlayer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pPlayer1.Name = "pPlayer1";
            this.pPlayer1.Size = new System.Drawing.Size(683, 379);
            this.pPlayer1.TabIndex = 0;
            // 
            // dgvPlayer1Shots
            // 
            this.dgvPlayer1Shots.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlayer1Shots.Location = new System.Drawing.Point(345, 4);
            this.dgvPlayer1Shots.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvPlayer1Shots.Name = "dgvPlayer1Shots";
            this.dgvPlayer1Shots.Size = new System.Drawing.Size(333, 308);
            this.dgvPlayer1Shots.TabIndex = 1;
            // 
            // dgvPlayer1Place
            // 
            this.dgvPlayer1Place.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlayer1Place.Location = new System.Drawing.Point(4, 4);
            this.dgvPlayer1Place.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvPlayer1Place.Name = "dgvPlayer1Place";
            this.dgvPlayer1Place.Size = new System.Drawing.Size(333, 308);
            this.dgvPlayer1Place.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbPlayer2Horizontal);
            this.panel1.Controls.Add(this.lblPlayer2NextShip);
            this.panel1.Controls.Add(this.dgvPlayer2Shots);
            this.panel1.Controls.Add(this.dgvPlayer2Place);
            this.panel1.Location = new System.Drawing.Point(747, 114);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(683, 379);
            this.panel1.TabIndex = 2;
            // 
            // dgvPlayer2Shots
            // 
            this.dgvPlayer2Shots.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlayer2Shots.Location = new System.Drawing.Point(345, 4);
            this.dgvPlayer2Shots.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvPlayer2Shots.Name = "dgvPlayer2Shots";
            this.dgvPlayer2Shots.Size = new System.Drawing.Size(333, 308);
            this.dgvPlayer2Shots.TabIndex = 1;
            // 
            // dgvPlayer2Place
            // 
            this.dgvPlayer2Place.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlayer2Place.Location = new System.Drawing.Point(0, 4);
            this.dgvPlayer2Place.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvPlayer2Place.Name = "dgvPlayer2Place";
            this.dgvPlayer2Place.Size = new System.Drawing.Size(337, 308);
            this.dgvPlayer2Place.TabIndex = 0;
            // 
            // lblPlayer1NextShip
            // 
            this.lblPlayer1NextShip.AutoSize = true;
            this.lblPlayer1NextShip.Location = new System.Drawing.Point(13, 316);
            this.lblPlayer1NextShip.Name = "lblPlayer1NextShip";
            this.lblPlayer1NextShip.Size = new System.Drawing.Size(200, 17);
            this.lblPlayer1NextShip.TabIndex = 3;
            this.lblPlayer1NextShip.Text = "Следующий размер корабля:";
            // 
            // lblPlayer2NextShip
            // 
            this.lblPlayer2NextShip.AutoSize = true;
            this.lblPlayer2NextShip.Location = new System.Drawing.Point(13, 316);
            this.lblPlayer2NextShip.Name = "lblPlayer2NextShip";
            this.lblPlayer2NextShip.Size = new System.Drawing.Size(200, 17);
            this.lblPlayer2NextShip.TabIndex = 4;
            this.lblPlayer2NextShip.Text = "Следующий размер корабля:";
            // 
            // cbPlayer1Horizontal
            // 
            this.cbPlayer1Horizontal.AutoSize = true;
            this.cbPlayer1Horizontal.Location = new System.Drawing.Point(241, 337);
            this.cbPlayer1Horizontal.Name = "cbPlayer1Horizontal";
            this.cbPlayer1Horizontal.Size = new System.Drawing.Size(185, 21);
            this.cbPlayer1Horizontal.TabIndex = 4;
            this.cbPlayer1Horizontal.Text = "Ставить горизонтально";
            this.cbPlayer1Horizontal.UseVisualStyleBackColor = true;
            this.cbPlayer1Horizontal.CheckedChanged += new System.EventHandler(this.cbPlayer1Horizontal_CheckedChanged);
            // 
            // cbPlayer2Horizontal
            // 
            this.cbPlayer2Horizontal.AutoSize = true;
            this.cbPlayer2Horizontal.Location = new System.Drawing.Point(257, 355);
            this.cbPlayer2Horizontal.Name = "cbPlayer2Horizontal";
            this.cbPlayer2Horizontal.Size = new System.Drawing.Size(185, 21);
            this.cbPlayer2Horizontal.TabIndex = 5;
            this.cbPlayer2Horizontal.Text = "Ставить горизонтально";
            this.cbPlayer2Horizontal.UseVisualStyleBackColor = true;
            this.cbPlayer2Horizontal.CheckedChanged += new System.EventHandler(this.cbPlayer2Horizontal_CheckedChanged);
            // 
            // BattleShipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1445, 523);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pPlayer1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BattleShipForm";
            this.Text = "Морской бой";
            this.Load += new System.EventHandler(this.BattleShipForm_Load);
            this.pPlayer1.ResumeLayout(false);
            this.pPlayer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayer1Shots)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayer1Place)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayer2Shots)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayer2Place)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pPlayer1;
        private System.Windows.Forms.DataGridView dgvPlayer1Place;
        private System.Windows.Forms.DataGridView dgvPlayer1Shots;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvPlayer2Shots;
        private System.Windows.Forms.DataGridView dgvPlayer2Place;
        private System.Windows.Forms.Label lblPlayer1NextShip;
        private System.Windows.Forms.Label lblPlayer2NextShip;
        private System.Windows.Forms.CheckBox cbPlayer1Horizontal;
        private System.Windows.Forms.CheckBox cbPlayer2Horizontal;
    }
}

