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
            this.btnLike = new System.Windows.Forms.Button();
            this.btnDislike = new System.Windows.Forms.Button();
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
            // btnLike
            // 
            this.btnLike.Location = new System.Drawing.Point(120, 43);
            this.btnLike.Name = "btnLike";
            this.btnLike.Size = new System.Drawing.Size(59, 27);
            this.btnLike.TabIndex = 2;
            this.btnLike.Text = "Like (0)";
            this.btnLike.UseVisualStyleBackColor = true;
            // 
            // btnDislike
            // 
            this.btnDislike.Location = new System.Drawing.Point(185, 43);
            this.btnDislike.Name = "btnDislike";
            this.btnDislike.Size = new System.Drawing.Size(59, 27);
            this.btnDislike.TabIndex = 3;
            this.btnDislike.Text = "Disike (0)";
            this.btnDislike.UseVisualStyleBackColor = true;
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
            this.Controls.Add(this.btnDislike);
            this.Controls.Add(this.btnLike);
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
        public System.Windows.Forms.Button btnLike;
        public System.Windows.Forms.Button btnDislike;
        public System.Windows.Forms.Label lblPosition;
    }
}
