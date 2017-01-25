namespace AutoDJ
{
    partial class frmAutoDJ
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
            this.txtCriteria = new System.Windows.Forms.TextBox();
            this.lblSong = new System.Windows.Forms.Label();
            this.btnRequest = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.txtTimer = new System.Windows.Forms.TextBox();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblRequestStatus = new System.Windows.Forms.Label();
            this.pgbStatusBar = new System.Windows.Forms.ProgressBar();
            this.pnlQueueContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPlay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCriteria
            // 
            this.txtCriteria.Location = new System.Drawing.Point(83, 23);
            this.txtCriteria.Name = "txtCriteria";
            this.txtCriteria.Size = new System.Drawing.Size(156, 20);
            this.txtCriteria.TabIndex = 0;
            // 
            // lblSong
            // 
            this.lblSong.AutoSize = true;
            this.lblSong.Location = new System.Drawing.Point(42, 26);
            this.lblSong.Name = "lblSong";
            this.lblSong.Size = new System.Drawing.Size(35, 13);
            this.lblSong.TabIndex = 1;
            this.lblSong.Text = "Song:";
            // 
            // btnRequest
            // 
            this.btnRequest.Location = new System.Drawing.Point(272, 21);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(75, 23);
            this.btnRequest.TabIndex = 2;
            this.btnRequest.Text = "Request";
            this.btnRequest.UseVisualStyleBackColor = true;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(83, 116);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(345, 20);
            this.txtName.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(39, 119);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Name:";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(353, 21);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(83, 143);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(100, 20);
            this.txtDuration.TabIndex = 6;
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(27, 146);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(50, 13);
            this.lblDuration.TabIndex = 7;
            this.lblDuration.Text = "Duration:";
            // 
            // txtTimer
            // 
            this.txtTimer.Location = new System.Drawing.Point(83, 170);
            this.txtTimer.Name = "txtTimer";
            this.txtTimer.Size = new System.Drawing.Size(100, 20);
            this.txtTimer.TabIndex = 8;
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(4, 173);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(74, 13);
            this.lblTimer.TabIndex = 9;
            this.lblTimer.Text = "Time Elapsed:";
            // 
            // lblRequestStatus
            // 
            this.lblRequestStatus.AutoSize = true;
            this.lblRequestStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestStatus.Location = new System.Drawing.Point(79, 58);
            this.lblRequestStatus.Name = "lblRequestStatus";
            this.lblRequestStatus.Size = new System.Drawing.Size(65, 20);
            this.lblRequestStatus.TabIndex = 10;
            this.lblRequestStatus.Text = "Ready!";
            // 
            // pgbStatusBar
            // 
            this.pgbStatusBar.Location = new System.Drawing.Point(272, 58);
            this.pgbStatusBar.MarqueeAnimationSpeed = 10;
            this.pgbStatusBar.Name = "pgbStatusBar";
            this.pgbStatusBar.Size = new System.Drawing.Size(156, 23);
            this.pgbStatusBar.TabIndex = 11;
            // 
            // pnlQueueContainer
            // 
            this.pnlQueueContainer.Location = new System.Drawing.Point(460, 21);
            this.pnlQueueContainer.Name = "pnlQueueContainer";
            this.pnlQueueContainer.Padding = new System.Windows.Forms.Padding(10);
            this.pnlQueueContainer.Size = new System.Drawing.Size(270, 540);
            this.pnlQueueContainer.TabIndex = 12;
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(272, 141);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 13;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // frmAutoDJ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 586);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.pnlQueueContainer);
            this.Controls.Add(this.pgbStatusBar);
            this.Controls.Add(this.lblRequestStatus);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.txtTimer);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnRequest);
            this.Controls.Add(this.lblSong);
            this.Controls.Add(this.txtCriteria);
            this.Name = "frmAutoDJ";
            this.Text = "AutoDJ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCriteria;
        private System.Windows.Forms.Label lblSong;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.TextBox txtTimer;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblRequestStatus;
        private System.Windows.Forms.ProgressBar pgbStatusBar;
        private System.Windows.Forms.FlowLayoutPanel pnlQueueContainer;
        private System.Windows.Forms.Button btnPlay;
    }
}

