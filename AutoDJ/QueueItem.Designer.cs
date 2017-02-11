namespace AutoDJ
{
    partial class QueueItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.btnVote = new System.Windows.Forms.Button();
            this.lblPosition = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoEllipsis = true;
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(26, 0);
            this.lblName.MaximumSize = new System.Drawing.Size(200, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(26, 50);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(47, 13);
            this.lblDuration.TabIndex = 1;
            this.lblDuration.Text = "Duration";
            // 
            // btnVote
            // 
            this.btnVote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVote.Location = new System.Drawing.Point(149, 43);
            this.btnVote.Name = "btnVote";
            this.btnVote.Size = new System.Drawing.Size(95, 27);
            this.btnVote.TabIndex = 3;
            this.btnVote.Text = "Vote (0)";
            this.btnVote.UseVisualStyleBackColor = true;
            this.btnVote.Click += new System.EventHandler(this.btnVote_Click);
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(4, 0);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(16, 13);
            this.lblPosition.TabIndex = 4;
            this.lblPosition.Text = "1.";
            // 
            // QueueItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.btnVote);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblName);
            this.Name = "QueueItem";
            this.Size = new System.Drawing.Size(270, 75);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblName;
        public System.Windows.Forms.Label lblDuration;
        public System.Windows.Forms.Button btnVote;
        public System.Windows.Forms.Label lblPosition;
    }
}
