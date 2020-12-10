namespace ConnorGilliom_Final
{
    partial class Setup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStripTabs = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupStartGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.Button();
            this.cbxBoardSize = new System.Windows.Forms.ComboBox();
            this.lblBoardSizeHeader = new System.Windows.Forms.Label();
            this.groupBoxColorSets = new System.Windows.Forms.GroupBox();
            this.rbtnColorSetThree = new System.Windows.Forms.RadioButton();
            this.rbtnColorSetTwo = new System.Windows.Forms.RadioButton();
            this.rbtnColorSetOne = new System.Windows.Forms.RadioButton();
            this.lblDeadColor = new System.Windows.Forms.Label();
            this.txtDeadColorInput = new System.Windows.Forms.TextBox();
            this.lblColorFormat = new System.Windows.Forms.Label();
            this.chkbxLoadFromFile = new System.Windows.Forms.CheckBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.menuStripTabs.SuspendLayout();
            this.groupBoxColorSets.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripTabs
            // 
            this.menuStripTabs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripTabs.Location = new System.Drawing.Point(0, 0);
            this.menuStripTabs.Name = "menuStripTabs";
            this.menuStripTabs.Size = new System.Drawing.Size(202, 24);
            this.menuStripTabs.TabIndex = 0;
            this.menuStripTabs.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupStartGridToolStripMenuItem,
            this.startGameToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // setupStartGridToolStripMenuItem
            // 
            this.setupStartGridToolStripMenuItem.Name = "setupStartGridToolStripMenuItem";
            this.setupStartGridToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.setupStartGridToolStripMenuItem.Text = "Setup Start Grid";
            this.setupStartGridToolStripMenuItem.Click += new System.EventHandler(this.setupStartGridToolStripMenuItem_Click);
            // 
            // startGameToolStripMenuItem
            // 
            this.startGameToolStripMenuItem.Name = "startGameToolStripMenuItem";
            this.startGameToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.startGameToolStripMenuItem.Text = "Start Game";
            this.startGameToolStripMenuItem.Click += new System.EventHandler(this.startGameToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(12, 334);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cbxBoardSize
            // 
            this.cbxBoardSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBoardSize.FormattingEnabled = true;
            this.cbxBoardSize.Items.AddRange(new object[] {
            "64x64",
            "32x32",
            "16x16"});
            this.cbxBoardSize.Location = new System.Drawing.Point(79, 39);
            this.cbxBoardSize.Name = "cbxBoardSize";
            this.cbxBoardSize.Size = new System.Drawing.Size(109, 21);
            this.cbxBoardSize.TabIndex = 3;
            this.cbxBoardSize.SelectedIndexChanged += new System.EventHandler(this.cbxBoardSize_SelectedIndexChanged);
            // 
            // lblBoardSizeHeader
            // 
            this.lblBoardSizeHeader.AutoSize = true;
            this.lblBoardSizeHeader.Location = new System.Drawing.Point(12, 42);
            this.lblBoardSizeHeader.Name = "lblBoardSizeHeader";
            this.lblBoardSizeHeader.Size = new System.Drawing.Size(61, 13);
            this.lblBoardSizeHeader.TabIndex = 4;
            this.lblBoardSizeHeader.Text = "Board Size:";
            // 
            // groupBoxColorSets
            // 
            this.groupBoxColorSets.Controls.Add(this.rbtnColorSetThree);
            this.groupBoxColorSets.Controls.Add(this.rbtnColorSetTwo);
            this.groupBoxColorSets.Controls.Add(this.rbtnColorSetOne);
            this.groupBoxColorSets.Location = new System.Drawing.Point(15, 66);
            this.groupBoxColorSets.Name = "groupBoxColorSets";
            this.groupBoxColorSets.Size = new System.Drawing.Size(173, 92);
            this.groupBoxColorSets.TabIndex = 5;
            this.groupBoxColorSets.TabStop = false;
            this.groupBoxColorSets.Text = "Living Colors";
            // 
            // rbtnColorSetThree
            // 
            this.rbtnColorSetThree.AutoSize = true;
            this.rbtnColorSetThree.Location = new System.Drawing.Point(23, 65);
            this.rbtnColorSetThree.Name = "rbtnColorSetThree";
            this.rbtnColorSetThree.Size = new System.Drawing.Size(56, 17);
            this.rbtnColorSetThree.TabIndex = 2;
            this.rbtnColorSetThree.TabStop = true;
            this.rbtnColorSetThree.Text = "Yellow";
            this.rbtnColorSetThree.UseVisualStyleBackColor = true;
            // 
            // rbtnColorSetTwo
            // 
            this.rbtnColorSetTwo.AutoSize = true;
            this.rbtnColorSetTwo.Location = new System.Drawing.Point(23, 42);
            this.rbtnColorSetTwo.Name = "rbtnColorSetTwo";
            this.rbtnColorSetTwo.Size = new System.Drawing.Size(46, 17);
            this.rbtnColorSetTwo.TabIndex = 1;
            this.rbtnColorSetTwo.TabStop = true;
            this.rbtnColorSetTwo.Text = "Blue";
            this.rbtnColorSetTwo.UseVisualStyleBackColor = true;
            // 
            // rbtnColorSetOne
            // 
            this.rbtnColorSetOne.AutoSize = true;
            this.rbtnColorSetOne.Location = new System.Drawing.Point(23, 19);
            this.rbtnColorSetOne.Name = "rbtnColorSetOne";
            this.rbtnColorSetOne.Size = new System.Drawing.Size(45, 17);
            this.rbtnColorSetOne.TabIndex = 0;
            this.rbtnColorSetOne.TabStop = true;
            this.rbtnColorSetOne.Text = "Red";
            this.rbtnColorSetOne.UseVisualStyleBackColor = true;
            // 
            // lblDeadColor
            // 
            this.lblDeadColor.AutoSize = true;
            this.lblDeadColor.Location = new System.Drawing.Point(12, 168);
            this.lblDeadColor.Name = "lblDeadColor";
            this.lblDeadColor.Size = new System.Drawing.Size(66, 13);
            this.lblDeadColor.TabIndex = 6;
            this.lblDeadColor.Text = "Dead Color: ";
            // 
            // txtDeadColorInput
            // 
            this.txtDeadColorInput.Location = new System.Drawing.Point(79, 165);
            this.txtDeadColorInput.Name = "txtDeadColorInput";
            this.txtDeadColorInput.Size = new System.Drawing.Size(109, 20);
            this.txtDeadColorInput.TabIndex = 7;
            // 
            // lblColorFormat
            // 
            this.lblColorFormat.AutoSize = true;
            this.lblColorFormat.Location = new System.Drawing.Point(76, 188);
            this.lblColorFormat.Name = "lblColorFormat";
            this.lblColorFormat.Size = new System.Drawing.Size(87, 13);
            this.lblColorFormat.TabIndex = 8;
            this.lblColorFormat.Text = "(Format: 123123)";
            // 
            // chkbxLoadFromFile
            // 
            this.chkbxLoadFromFile.AutoSize = true;
            this.chkbxLoadFromFile.Location = new System.Drawing.Point(12, 237);
            this.chkbxLoadFromFile.Name = "chkbxLoadFromFile";
            this.chkbxLoadFromFile.Size = new System.Drawing.Size(136, 17);
            this.chkbxLoadFromFile.TabIndex = 9;
            this.chkbxLoadFromFile.Text = "Load Settings From File";
            this.chkbxLoadFromFile.UseVisualStyleBackColor = true;
            this.chkbxLoadFromFile.CheckedChanged += new System.EventHandler(this.chkbxLoadFromFile_CheckedChanged);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(113, 260);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 10;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Visible = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 260);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Setup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 369);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.chkbxLoadFromFile);
            this.Controls.Add(this.lblColorFormat);
            this.Controls.Add(this.txtDeadColorInput);
            this.Controls.Add(this.lblDeadColor);
            this.Controls.Add(this.groupBoxColorSets);
            this.Controls.Add(this.lblBoardSizeHeader);
            this.Controls.Add(this.cbxBoardSize);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.menuStripTabs);
            this.MainMenuStrip = this.menuStripTabs;
            this.Name = "Setup";
            this.Text = "Setup";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Setup_FormClosed);
            this.menuStripTabs.ResumeLayout(false);
            this.menuStripTabs.PerformLayout();
            this.groupBoxColorSets.ResumeLayout(false);
            this.groupBoxColorSets.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripTabs;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupStartGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startGameToolStripMenuItem;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cbxBoardSize;
        private System.Windows.Forms.Label lblBoardSizeHeader;
        private System.Windows.Forms.GroupBox groupBoxColorSets;
        private System.Windows.Forms.RadioButton rbtnColorSetThree;
        private System.Windows.Forms.RadioButton rbtnColorSetTwo;
        private System.Windows.Forms.RadioButton rbtnColorSetOne;
        private System.Windows.Forms.Label lblDeadColor;
        private System.Windows.Forms.TextBox txtDeadColorInput;
        private System.Windows.Forms.Label lblColorFormat;
        private System.Windows.Forms.CheckBox chkbxLoadFromFile;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
    }
}

