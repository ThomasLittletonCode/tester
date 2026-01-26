namespace MindMaster
{
    partial class Form1
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
            this.onePlayerBut = new System.Windows.Forms.Button();
            this.twoPlayerBut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // onePlayerBut
            // 
            this.onePlayerBut.Location = new System.Drawing.Point(43, 138);
            this.onePlayerBut.Name = "onePlayerBut";
            this.onePlayerBut.Size = new System.Drawing.Size(117, 64);
            this.onePlayerBut.TabIndex = 0;
            this.onePlayerBut.Text = "One Player";
            this.onePlayerBut.UseVisualStyleBackColor = true;
            this.onePlayerBut.Click += new System.EventHandler(this.onePlayerBut_Click);
            // 
            // twoPlayerBut
            // 
            this.twoPlayerBut.Location = new System.Drawing.Point(264, 138);
            this.twoPlayerBut.Name = "twoPlayerBut";
            this.twoPlayerBut.Size = new System.Drawing.Size(117, 64);
            this.twoPlayerBut.TabIndex = 1;
            this.twoPlayerBut.Text = "Two Player";
            this.twoPlayerBut.UseVisualStyleBackColor = true;
            this.twoPlayerBut.Click += new System.EventHandler(this.twoPlayerBut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome to mastermind.  Please select either one player or two players";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 295);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.twoPlayerBut);
            this.Controls.Add(this.onePlayerBut);
            this.Name = "Form1";
            this.Text = "Player Select";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button onePlayerBut;
        private System.Windows.Forms.Button twoPlayerBut;
        private System.Windows.Forms.Label label1;
    }
}

