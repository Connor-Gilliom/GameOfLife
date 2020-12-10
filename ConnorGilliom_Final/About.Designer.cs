namespace ConnorGilliom_Final
{
    partial class About
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
            this.lblMadeBy = new System.Windows.Forms.Label();
            this.lblMadeFor = new System.Windows.Forms.Label();
            this.lblMadeWhen = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMadeBy
            // 
            this.lblMadeBy.AutoSize = true;
            this.lblMadeBy.Location = new System.Drawing.Point(12, 9);
            this.lblMadeBy.Name = "lblMadeBy";
            this.lblMadeBy.Size = new System.Drawing.Size(118, 13);
            this.lblMadeBy.TabIndex = 0;
            this.lblMadeBy.Text = "Made by Connor Gilliom";
            // 
            // lblMadeFor
            // 
            this.lblMadeFor.AutoSize = true;
            this.lblMadeFor.Location = new System.Drawing.Point(12, 34);
            this.lblMadeFor.Name = "lblMadeFor";
            this.lblMadeFor.Size = new System.Drawing.Size(87, 13);
            this.lblMadeFor.TabIndex = 1;
            this.lblMadeFor.Text = "For CS 114 2020";
            // 
            // lblMadeWhen
            // 
            this.lblMadeWhen.AutoSize = true;
            this.lblMadeWhen.Location = new System.Drawing.Point(12, 59);
            this.lblMadeWhen.Name = "lblMadeWhen";
            this.lblMadeWhen.Size = new System.Drawing.Size(82, 13);
            this.lblMadeWhen.TabIndex = 2;
            this.lblMadeWhen.Text = "On 11/10/2020";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(173, 82);
            this.Controls.Add(this.lblMadeWhen);
            this.Controls.Add(this.lblMadeFor);
            this.Controls.Add(this.lblMadeBy);
            this.Name = "About";
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMadeBy;
        private System.Windows.Forms.Label lblMadeFor;
        private System.Windows.Forms.Label lblMadeWhen;

    }
}