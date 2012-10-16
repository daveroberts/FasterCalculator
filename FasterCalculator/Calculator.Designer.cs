namespace FasterCalculator
{
    partial class Calculator
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calculator));
			this.pnlmain = new System.Windows.Forms.Panel();
			this.pnlHistory = new System.Windows.Forms.Panel();
			this.lblHistory = new System.Windows.Forms.Label();
			this.txtHistory = new System.Windows.Forms.RichTextBox();
			this.pnlInput = new System.Windows.Forms.Panel();
			this.txtEntry = new System.Windows.Forms.TextBox();
			this.lblInput = new System.Windows.Forms.Label();
			this.pnlmain.SuspendLayout();
			this.pnlHistory.SuspendLayout();
			this.pnlInput.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlmain
			// 
			this.pnlmain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlmain.BackColor = System.Drawing.Color.White;
			this.pnlmain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlmain.Controls.Add(this.pnlHistory);
			this.pnlmain.Controls.Add(this.pnlInput);
			this.pnlmain.ForeColor = System.Drawing.SystemColors.ControlText;
			this.pnlmain.Location = new System.Drawing.Point(0, 0);
			this.pnlmain.Name = "pnlmain";
			this.pnlmain.Size = new System.Drawing.Size(226, 298);
			this.pnlmain.TabIndex = 4;
			// 
			// pnlHistory
			// 
			this.pnlHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
			this.pnlHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlHistory.Controls.Add(this.lblHistory);
			this.pnlHistory.Controls.Add(this.txtHistory);
			this.pnlHistory.Location = new System.Drawing.Point(4, 7);
			this.pnlHistory.Name = "pnlHistory";
			this.pnlHistory.Size = new System.Drawing.Size(216, 214);
			this.pnlHistory.TabIndex = 7;
			// 
			// lblHistory
			// 
			this.lblHistory.AutoSize = true;
			this.lblHistory.BackColor = System.Drawing.Color.Transparent;
			this.lblHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHistory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(111)))), ((int)(((byte)(205)))));
			this.lblHistory.Location = new System.Drawing.Point(2, 2);
			this.lblHistory.Name = "lblHistory";
			this.lblHistory.Size = new System.Drawing.Size(51, 15);
			this.lblHistory.TabIndex = 5;
			this.lblHistory.Text = "History";
			// 
			// txtHistory
			// 
			this.txtHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtHistory.BackColor = System.Drawing.Color.White;
			this.txtHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtHistory.Location = new System.Drawing.Point(0, 20);
			this.txtHistory.Name = "txtHistory";
			this.txtHistory.ReadOnly = true;
			this.txtHistory.Size = new System.Drawing.Size(213, 191);
			this.txtHistory.TabIndex = 4;
			this.txtHistory.Text = "";
			// 
			// pnlInput
			// 
			this.pnlInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
			this.pnlInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlInput.Controls.Add(this.txtEntry);
			this.pnlInput.Controls.Add(this.lblInput);
			this.pnlInput.Location = new System.Drawing.Point(4, 226);
			this.pnlInput.Name = "pnlInput";
			this.pnlInput.Size = new System.Drawing.Size(216, 66);
			this.pnlInput.TabIndex = 6;
			// 
			// txtEntry
			// 
			this.txtEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtEntry.Location = new System.Drawing.Point(2, 21);
			this.txtEntry.Name = "txtEntry";
			this.txtEntry.Size = new System.Drawing.Size(209, 31);
			this.txtEntry.TabIndex = 1;
			this.txtEntry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEntry_KeyDown);
			this.txtEntry.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtEntry_KeyUp);
			this.txtEntry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEntry_KeyPress);
			// 
			// lblInput
			// 
			this.lblInput.AutoSize = true;
			this.lblInput.BackColor = System.Drawing.Color.Transparent;
			this.lblInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(111)))), ((int)(((byte)(205)))));
			this.lblInput.Location = new System.Drawing.Point(2, 2);
			this.lblInput.Name = "lblInput";
			this.lblInput.Size = new System.Drawing.Size(39, 15);
			this.lblInput.TabIndex = 0;
			this.lblInput.Text = "Input";
			// 
			// Calculator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(226, 298);
			this.Controls.Add(this.pnlmain);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(163, 232);
			this.Name = "Calculator";
			this.Text = "Faster Calc";
			this.TopMost = true;
			this.pnlmain.ResumeLayout(false);
			this.pnlHistory.ResumeLayout(false);
			this.pnlHistory.PerformLayout();
			this.pnlInput.ResumeLayout(false);
			this.pnlInput.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.Panel pnlmain;
		private System.Windows.Forms.Panel pnlInput;
		private System.Windows.Forms.TextBox txtEntry;
		private System.Windows.Forms.Label lblInput;
		private System.Windows.Forms.Panel pnlHistory;
		private System.Windows.Forms.Label lblHistory;
		private System.Windows.Forms.RichTextBox txtHistory;
    }
}

