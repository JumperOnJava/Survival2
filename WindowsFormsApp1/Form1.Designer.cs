namespace Survival
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timerMovement = new System.Windows.Forms.Timer(this.components);
            this.timerSpawnMonster = new System.Windows.Forms.Timer(this.components);
            this.timerDeadMonster = new System.Windows.Forms.Timer(this.components);
            this.labelPause = new System.Windows.Forms.Label();
            this.labelNoPause = new System.Windows.Forms.Label();
            this.labelExit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelPause
            // 
            this.labelPause.BackColor = System.Drawing.Color.Maroon;
            this.labelPause.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold);
            this.labelPause.Location = new System.Drawing.Point(660, 9);
            this.labelPause.Name = "labelPause";
            this.labelPause.Size = new System.Drawing.Size(167, 50);
            this.labelPause.TabIndex = 1;
            this.labelPause.Text = "Pause";
            this.labelPause.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelPause.Click += new System.EventHandler(this.labelPause_Click);
            // 
            // labelNoPause
            // 
            this.labelNoPause.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNoPause.BackColor = System.Drawing.Color.Maroon;
            this.labelNoPause.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold);
            this.labelNoPause.Image = ((System.Drawing.Image)(resources.GetObject("labelNoPause.Image")));
            this.labelNoPause.Location = new System.Drawing.Point(301, 144);
            this.labelNoPause.Name = "labelNoPause";
            this.labelNoPause.Size = new System.Drawing.Size(242, 52);
            this.labelNoPause.TabIndex = 2;
            this.labelNoPause.Text = "Go ";
            this.labelNoPause.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelNoPause.Visible = false;
            this.labelNoPause.Click += new System.EventHandler(this.labelNoPause_Click);
            // 
            // labelExit
            // 
            this.labelExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelExit.BackColor = System.Drawing.Color.Maroon;
            this.labelExit.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExit.ForeColor = System.Drawing.Color.Black;
            this.labelExit.Image = ((System.Drawing.Image)(resources.GetObject("labelExit.Image")));
            this.labelExit.Location = new System.Drawing.Point(301, 215);
            this.labelExit.Name = "labelExit";
            this.labelExit.Size = new System.Drawing.Size(241, 52);
            this.labelExit.TabIndex = 5;
            this.labelExit.Text = "Exit ";
            this.labelExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelExit.Visible = false;
            this.labelExit.Click += new System.EventHandler(this.labelExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 778);
            this.Controls.Add(this.labelExit);
            this.Controls.Add(this.labelNoPause);
            this.Controls.Add(this.labelPause);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(870, 825);
            this.MinimumSize = new System.Drawing.Size(870, 825);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ratopia";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerMovement;
        private System.Windows.Forms.Timer timerSpawnMonster;
        private System.Windows.Forms.Timer timerDeadMonster;
        private System.Windows.Forms.Label labelPause;
        private System.Windows.Forms.Label labelNoPause;
        private System.Windows.Forms.Label labelExit;
    }
}

