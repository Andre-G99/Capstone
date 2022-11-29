
namespace c969.View
{
    partial class UserControlDay
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
            this.numberLabel = new System.Windows.Forms.Label();
            this.apptPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.apptList = new System.Windows.Forms.ListBox();
            this.apptPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // numberLabel
            // 
            this.numberLabel.AutoSize = true;
            this.numberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberLabel.ForeColor = System.Drawing.Color.White;
            this.numberLabel.Location = new System.Drawing.Point(3, 0);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(19, 13);
            this.numberLabel.TabIndex = 1;
            this.numberLabel.Text = "00";
            // 
            // apptPanel
            // 
            this.apptPanel.AutoScroll = true;
            this.apptPanel.Controls.Add(this.apptList);
            this.apptPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.apptPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apptPanel.ForeColor = System.Drawing.Color.White;
            this.apptPanel.Location = new System.Drawing.Point(23, -1);
            this.apptPanel.Name = "apptPanel";
            this.apptPanel.Size = new System.Drawing.Size(174, 100);
            this.apptPanel.TabIndex = 2;
            this.apptPanel.WrapContents = false;
            this.apptPanel.DoubleClick += new System.EventHandler(this.UserControlDay_Click);
            // 
            // apptList
            // 
            this.apptList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.apptList.FormattingEnabled = true;
            this.apptList.ItemHeight = 18;
            this.apptList.Location = new System.Drawing.Point(3, 3);
            this.apptList.Name = "apptList";
            this.apptList.Size = new System.Drawing.Size(120, 94);
            this.apptList.TabIndex = 0;
            this.apptList.DoubleClick += new System.EventHandler(this.UserControlDay_Click);
            // 
            // UserControlDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.apptPanel);
            this.Controls.Add(this.numberLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserControlDay";
            this.Size = new System.Drawing.Size(198, 98);
            this.Click += new System.EventHandler(this.UserControlDay_Click);
            this.apptPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.FlowLayoutPanel apptPanel;
        private System.Windows.Forms.ListBox apptList;
    }
}
