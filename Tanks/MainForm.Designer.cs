namespace View
{
    partial class MainForm
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
            this.pictureBoxGame = new System.Windows.Forms.PictureBox();
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.labelScore = new System.Windows.Forms.Label();
            this.dataGridViewGameObjects = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelWidth = new System.Windows.Forms.Label();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelTanks = new System.Windows.Forms.Label();
            this.labelApples = new System.Windows.Forms.Label();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTanks = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownApples = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDelay = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGameObjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTanks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownApples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxGame
            // 
            this.pictureBoxGame.BackColor = System.Drawing.SystemColors.Desktop;
            this.pictureBoxGame.Location = new System.Drawing.Point(12, 36);
            this.pictureBoxGame.Name = "pictureBoxGame";
            this.pictureBoxGame.Size = new System.Drawing.Size(512, 312);
            this.pictureBoxGame.TabIndex = 0;
            this.pictureBoxGame.TabStop = false;
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewGame.Location = new System.Drawing.Point(186, 290);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(130, 43);
            this.buttonNewGame.TabIndex = 1;
            this.buttonNewGame.Text = "New game";
            this.buttonNewGame.UseVisualStyleBackColor = true;
            this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click);
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore.Location = new System.Drawing.Point(80, 9);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(57, 18);
            this.labelScore.TabIndex = 2;
            this.labelScore.Text = "Score: 0";
            // 
            // dataGridViewGameObjects
            // 
            this.dataGridViewGameObjects.AllowUserToAddRows = false;
            this.dataGridViewGameObjects.AllowUserToDeleteRows = false;
            this.dataGridViewGameObjects.AllowUserToResizeColumns = false;
            this.dataGridViewGameObjects.AllowUserToResizeRows = false;
            this.dataGridViewGameObjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGameObjects.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnX,
            this.ColumnY});
            this.dataGridViewGameObjects.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridViewGameObjects.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewGameObjects.Enabled = false;
            this.dataGridViewGameObjects.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridViewGameObjects.Location = new System.Drawing.Point(629, 0);
            this.dataGridViewGameObjects.MultiSelect = false;
            this.dataGridViewGameObjects.Name = "dataGridViewGameObjects";
            this.dataGridViewGameObjects.ReadOnly = true;
            this.dataGridViewGameObjects.RowHeadersVisible = false;
            this.dataGridViewGameObjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGameObjects.Size = new System.Drawing.Size(258, 387);
            this.dataGridViewGameObjects.TabIndex = 3;
            // 
            // ColumnName
            // 
            this.ColumnName.DataPropertyName = "Name";
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Width = 80;
            // 
            // ColumnX
            // 
            this.ColumnX.DataPropertyName = "X";
            this.ColumnX.HeaderText = "X";
            this.ColumnX.Name = "ColumnX";
            this.ColumnX.Width = 60;
            // 
            // ColumnY
            // 
            this.ColumnY.DataPropertyName = "Y";
            this.ColumnY.HeaderText = "Y";
            this.ColumnY.Name = "ColumnY";
            this.ColumnY.Width = 60;
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWidth.Location = new System.Drawing.Point(56, 66);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(81, 20);
            this.labelWidth.TabIndex = 4;
            this.labelWidth.Text = "Map width";
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHeight.Location = new System.Drawing.Point(56, 102);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(88, 20);
            this.labelHeight.TabIndex = 5;
            this.labelHeight.Text = "Map height";
            // 
            // labelTanks
            // 
            this.labelTanks.AutoSize = true;
            this.labelTanks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTanks.Location = new System.Drawing.Point(56, 140);
            this.labelTanks.Name = "labelTanks";
            this.labelTanks.Size = new System.Drawing.Size(96, 20);
            this.labelTanks.TabIndex = 6;
            this.labelTanks.Text = "Tanks count";
            // 
            // labelApples
            // 
            this.labelApples.AutoSize = true;
            this.labelApples.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelApples.Location = new System.Drawing.Point(56, 178);
            this.labelApples.Name = "labelApples";
            this.labelApples.Size = new System.Drawing.Size(102, 20);
            this.labelApples.TabIndex = 7;
            this.labelApples.Text = "Apples count";
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSpeed.Location = new System.Drawing.Point(56, 214);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(83, 20);
            this.labelSpeed.TabIndex = 8;
            this.labelSpeed.Text = "Delay time";
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownWidth.Location = new System.Drawing.Point(175, 60);
            this.numericUpDownWidth.Maximum = new decimal(new int[] {
            700,
            0,
            0,
            0});
            this.numericUpDownWidth.Minimum = new decimal(new int[] {
            380,
            0,
            0,
            0});
            this.numericUpDownWidth.Name = "numericUpDownWidth";
            this.numericUpDownWidth.Size = new System.Drawing.Size(86, 26);
            this.numericUpDownWidth.TabIndex = 9;
            this.numericUpDownWidth.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownHeight.Location = new System.Drawing.Point(175, 96);
            this.numericUpDownHeight.Maximum = new decimal(new int[] {
            700,
            0,
            0,
            0});
            this.numericUpDownHeight.Minimum = new decimal(new int[] {
            290,
            0,
            0,
            0});
            this.numericUpDownHeight.Name = "numericUpDownHeight";
            this.numericUpDownHeight.Size = new System.Drawing.Size(86, 26);
            this.numericUpDownHeight.TabIndex = 10;
            this.numericUpDownHeight.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // numericUpDownTanks
            // 
            this.numericUpDownTanks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownTanks.Location = new System.Drawing.Point(175, 134);
            this.numericUpDownTanks.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDownTanks.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTanks.Name = "numericUpDownTanks";
            this.numericUpDownTanks.Size = new System.Drawing.Size(86, 26);
            this.numericUpDownTanks.TabIndex = 11;
            this.numericUpDownTanks.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numericUpDownApples
            // 
            this.numericUpDownApples.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownApples.Location = new System.Drawing.Point(175, 172);
            this.numericUpDownApples.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDownApples.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownApples.Name = "numericUpDownApples";
            this.numericUpDownApples.Size = new System.Drawing.Size(86, 26);
            this.numericUpDownApples.TabIndex = 12;
            this.numericUpDownApples.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numericUpDownDelay
            // 
            this.numericUpDownDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownDelay.Location = new System.Drawing.Point(175, 208);
            this.numericUpDownDelay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDelay.Name = "numericUpDownDelay";
            this.numericUpDownDelay.Size = new System.Drawing.Size(86, 26);
            this.numericUpDownDelay.TabIndex = 13;
            this.numericUpDownDelay.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 387);
            this.Controls.Add(this.numericUpDownDelay);
            this.Controls.Add(this.numericUpDownApples);
            this.Controls.Add(this.numericUpDownTanks);
            this.Controls.Add(this.numericUpDownHeight);
            this.Controls.Add(this.numericUpDownWidth);
            this.Controls.Add(this.labelSpeed);
            this.Controls.Add(this.labelApples);
            this.Controls.Add(this.labelTanks);
            this.Controls.Add(this.labelHeight);
            this.Controls.Add(this.labelWidth);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.buttonNewGame);
            this.Controls.Add(this.pictureBoxGame);
            this.Controls.Add(this.dataGridViewGameObjects);
            this.Name = "MainForm";
            this.Text = "Tanks";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGameObjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTanks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownApples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxGame;
        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.DataGridView dataGridViewGameObjects;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnX;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnY;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelTanks;
        private System.Windows.Forms.Label labelApples;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
        private System.Windows.Forms.NumericUpDown numericUpDownTanks;
        private System.Windows.Forms.NumericUpDown numericUpDownApples;
        private System.Windows.Forms.NumericUpDown numericUpDownDelay;
    }
}

