namespace Rasterization
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel6 = new TableLayoutPanel();
            textBoxGreen = new TextBox();
            textBoxRed = new TextBox();
            textBoxBlue = new TextBox();
            tableLayoutPanel5 = new TableLayoutPanel();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            buttonRemove = new Button();
            buttonAntiAl = new Button();
            buttonSave = new Button();
            buttonLoad = new Button();
            buttonCapsule = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel7 = new TableLayoutPanel();
            buttonDelete = new Button();
            numericUpDownThickness = new NumericUpDown();
            buttonMove = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            buttonPolygon = new Button();
            buttonCircle = new Button();
            buttonLine = new Button();
            buttonEdit = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBoxSheet = new PictureBox();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownThickness).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSheet).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.2331619F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64.76684F));
            tableLayoutPanel4.Controls.Add(tableLayoutPanel6, 1, 0);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel5, 0, 0);
            tableLayoutPanel4.Controls.Add(buttonRemove, 1, 1);
            tableLayoutPanel4.Controls.Add(buttonAntiAl, 1, 2);
            tableLayoutPanel4.Controls.Add(buttonSave, 0, 1);
            tableLayoutPanel4.Controls.Add(buttonLoad, 0, 2);
            tableLayoutPanel4.Controls.Add(buttonCapsule, 1, 3);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(671, 4);
            tableLayoutPanel4.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 4;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 25.3829327F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 24.507658F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel4.Size = new Size(222, 609);
            tableLayoutPanel4.TabIndex = 6;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 1;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Controls.Add(textBoxGreen, 0, 1);
            tableLayoutPanel6.Controls.Add(textBoxRed, 0, 0);
            tableLayoutPanel6.Controls.Add(textBoxBlue, 0, 2);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(81, 4);
            tableLayoutPanel6.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 3;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel6.Size = new Size(138, 146);
            tableLayoutPanel6.TabIndex = 1;
            // 
            // textBoxGreen
            // 
            textBoxGreen.Dock = DockStyle.Fill;
            textBoxGreen.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxGreen.Location = new Point(3, 52);
            textBoxGreen.Margin = new Padding(3, 4, 3, 4);
            textBoxGreen.Name = "textBoxGreen";
            textBoxGreen.Size = new Size(132, 34);
            textBoxGreen.TabIndex = 2;
            textBoxGreen.Text = "0";
            textBoxGreen.TextChanged += textBoxGreen_TextChanged;
            // 
            // textBoxRed
            // 
            textBoxRed.Dock = DockStyle.Fill;
            textBoxRed.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxRed.Location = new Point(3, 4);
            textBoxRed.Margin = new Padding(3, 4, 3, 4);
            textBoxRed.Name = "textBoxRed";
            textBoxRed.Size = new Size(132, 34);
            textBoxRed.TabIndex = 1;
            textBoxRed.Text = "0";
            textBoxRed.TextChanged += textBoxRed_TextChanged;
            // 
            // textBoxBlue
            // 
            textBoxBlue.Dock = DockStyle.Fill;
            textBoxBlue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxBlue.Location = new Point(3, 100);
            textBoxBlue.Margin = new Padding(3, 4, 3, 4);
            textBoxBlue.Name = "textBoxBlue";
            textBoxBlue.Size = new Size(132, 34);
            textBoxBlue.TabIndex = 0;
            textBoxBlue.Text = "0";
            textBoxBlue.TextChanged += textBoxBlue_TextChanged;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Controls.Add(label3, 0, 2);
            tableLayoutPanel5.Controls.Add(label2, 0, 1);
            tableLayoutPanel5.Controls.Add(label1, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 4);
            tableLayoutPanel5.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 3;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel5.Size = new Size(72, 146);
            tableLayoutPanel5.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Right;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(16, 96);
            label3.Name = "label3";
            label3.Size = new Size(53, 50);
            label3.TabIndex = 2;
            label3.Text = "BLUE:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Right;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(6, 48);
            label2.Name = "label2";
            label2.Size = new Size(63, 48);
            label2.TabIndex = 1;
            label2.Text = "GREEN:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Right;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(24, 0);
            label1.Name = "label1";
            label1.Size = new Size(45, 48);
            label1.TabIndex = 0;
            label1.Text = "RED:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonRemove
            // 
            buttonRemove.Dock = DockStyle.Fill;
            buttonRemove.Location = new Point(81, 158);
            buttonRemove.Margin = new Padding(3, 4, 3, 4);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(138, 141);
            buttonRemove.TabIndex = 2;
            buttonRemove.Text = "Remove All";
            buttonRemove.UseVisualStyleBackColor = true;
            buttonRemove.Click += buttonRemove_Click;
            // 
            // buttonAntiAl
            // 
            buttonAntiAl.Dock = DockStyle.Fill;
            buttonAntiAl.Location = new Point(81, 307);
            buttonAntiAl.Margin = new Padding(3, 4, 3, 4);
            buttonAntiAl.Name = "buttonAntiAl";
            buttonAntiAl.Size = new Size(138, 144);
            buttonAntiAl.TabIndex = 3;
            buttonAntiAl.Text = "Antialiasing";
            buttonAntiAl.UseVisualStyleBackColor = true;
            buttonAntiAl.Click += buttonAntiAl_Click;
            // 
            // buttonSave
            // 
            buttonSave.Dock = DockStyle.Fill;
            buttonSave.Location = new Point(3, 158);
            buttonSave.Margin = new Padding(3, 4, 3, 4);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(72, 141);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonLoad
            // 
            buttonLoad.Dock = DockStyle.Fill;
            buttonLoad.Location = new Point(3, 307);
            buttonLoad.Margin = new Padding(3, 4, 3, 4);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(72, 144);
            buttonLoad.TabIndex = 5;
            buttonLoad.Text = "Load";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // buttonCapsule
            // 
            buttonCapsule.Dock = DockStyle.Fill;
            buttonCapsule.Location = new Point(81, 458);
            buttonCapsule.Name = "buttonCapsule";
            buttonCapsule.Size = new Size(138, 148);
            buttonCapsule.TabIndex = 6;
            buttonCapsule.Text = "Capsule";
            buttonCapsule.UseVisualStyleBackColor = true;
            buttonCapsule.Click += buttonCapsule_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(tableLayoutPanel7, 1, 0);
            tableLayoutPanel3.Controls.Add(buttonMove, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(671, 621);
            tableLayoutPanel3.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(222, 123);
            tableLayoutPanel3.TabIndex = 5;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 1;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Controls.Add(buttonDelete, 0, 0);
            tableLayoutPanel7.Controls.Add(numericUpDownThickness, 0, 1);
            tableLayoutPanel7.Location = new Point(114, 4);
            tableLayoutPanel7.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 2;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Size = new Size(104, 115);
            tableLayoutPanel7.TabIndex = 0;
            // 
            // buttonDelete
            // 
            buttonDelete.Dock = DockStyle.Fill;
            buttonDelete.Location = new Point(3, 4);
            buttonDelete.Margin = new Padding(3, 4, 3, 4);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(98, 49);
            buttonDelete.TabIndex = 5;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // numericUpDownThickness
            // 
            numericUpDownThickness.Dock = DockStyle.Fill;
            numericUpDownThickness.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            numericUpDownThickness.Location = new Point(3, 61);
            numericUpDownThickness.Margin = new Padding(3, 4, 3, 4);
            numericUpDownThickness.Name = "numericUpDownThickness";
            numericUpDownThickness.Size = new Size(98, 42);
            numericUpDownThickness.TabIndex = 4;
            numericUpDownThickness.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownThickness.ValueChanged += numericUpDownThickness_ValueChanged;
            // 
            // buttonMove
            // 
            buttonMove.Dock = DockStyle.Fill;
            buttonMove.Location = new Point(3, 4);
            buttonMove.Margin = new Padding(3, 4, 3, 4);
            buttonMove.Name = "buttonMove";
            buttonMove.Size = new Size(105, 115);
            buttonMove.TabIndex = 1;
            buttonMove.Text = "Move";
            buttonMove.UseVisualStyleBackColor = true;
            buttonMove.Click += buttonMove_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Controls.Add(buttonPolygon, 0, 0);
            tableLayoutPanel2.Controls.Add(buttonCircle, 1, 0);
            tableLayoutPanel2.Controls.Add(buttonLine, 2, 0);
            tableLayoutPanel2.Controls.Add(buttonEdit, 3, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 621);
            tableLayoutPanel2.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(662, 123);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // buttonPolygon
            // 
            buttonPolygon.Dock = DockStyle.Fill;
            buttonPolygon.Location = new Point(3, 4);
            buttonPolygon.Margin = new Padding(3, 4, 3, 4);
            buttonPolygon.Name = "buttonPolygon";
            buttonPolygon.Size = new Size(159, 115);
            buttonPolygon.TabIndex = 3;
            buttonPolygon.Text = "Polygon";
            buttonPolygon.UseVisualStyleBackColor = true;
            buttonPolygon.Click += buttonPolygon_Click;
            // 
            // buttonCircle
            // 
            buttonCircle.Dock = DockStyle.Fill;
            buttonCircle.Location = new Point(168, 4);
            buttonCircle.Margin = new Padding(3, 4, 3, 4);
            buttonCircle.Name = "buttonCircle";
            buttonCircle.Size = new Size(159, 115);
            buttonCircle.TabIndex = 2;
            buttonCircle.Text = "Circle";
            buttonCircle.UseVisualStyleBackColor = true;
            buttonCircle.Click += buttonCircle_Click;
            // 
            // buttonLine
            // 
            buttonLine.Dock = DockStyle.Fill;
            buttonLine.Location = new Point(333, 4);
            buttonLine.Margin = new Padding(3, 4, 3, 4);
            buttonLine.Name = "buttonLine";
            buttonLine.Size = new Size(159, 115);
            buttonLine.TabIndex = 1;
            buttonLine.Text = "Line";
            buttonLine.UseVisualStyleBackColor = true;
            buttonLine.Click += buttonLine_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Dock = DockStyle.Fill;
            buttonEdit.Location = new Point(498, 4);
            buttonEdit.Margin = new Padding(3, 4, 3, 4);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(161, 115);
            buttonEdit.TabIndex = 4;
            buttonEdit.Text = "Edit";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 74.61735F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.3826523F));
            tableLayoutPanel1.Controls.Add(pictureBoxSheet, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 82.5312F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17.4688053F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel1.Size = new Size(896, 748);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBoxSheet
            // 
            pictureBoxSheet.BackColor = Color.White;
            pictureBoxSheet.Dock = DockStyle.Fill;
            pictureBoxSheet.Location = new Point(3, 4);
            pictureBoxSheet.Margin = new Padding(3, 4, 3, 4);
            pictureBoxSheet.Name = "pictureBoxSheet";
            pictureBoxSheet.Size = new Size(662, 609);
            pictureBoxSheet.TabIndex = 0;
            pictureBoxSheet.TabStop = false;
            pictureBoxSheet.MouseClick += pictureBoxSheet_MouseClick;
            pictureBoxSheet.MouseDown += pictureBoxSheet_MouseDown;
            pictureBoxSheet.MouseMove += pictureBoxSheet_MouseMove;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 748);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDownThickness).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxSheet).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel6;
        private TextBox textBoxGreen;
        private TextBox textBoxRed;
        private TextBox textBoxBlue;
        private TableLayoutPanel tableLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel3;
        private NumericUpDown numericUpDownThickness;
        private Button buttonDelete;
        private TableLayoutPanel tableLayoutPanel2;
        private Button buttonPolygon;
        private Button buttonCircle;
        private Button buttonLine;
        private Button buttonEdit;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBoxSheet;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button buttonRemove;
        private Button buttonAntiAl;
        private Button buttonSave;
        private Button buttonLoad;
        private TableLayoutPanel tableLayoutPanel7;
        private Button buttonMove;
        private Button buttonCapsule;
    }
}