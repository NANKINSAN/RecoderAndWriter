namespace RecoderAndWriter
{
    partial class FilenameSettingDialog
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
            txtFilename = new TextBox();
            btnExecute = new Button();
            SuspendLayout();
            // 
            // txtFilename
            // 
            txtFilename.Location = new Point(6, 21);
            txtFilename.Name = "txtFilename";
            txtFilename.Size = new Size(333, 23);
            txtFilename.TabIndex = 0;
            // 
            // btnExecute
            // 
            btnExecute.Location = new Point(264, 58);
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new Size(75, 23);
            btnExecute.TabIndex = 1;
            btnExecute.Text = "決定";
            btnExecute.UseVisualStyleBackColor = true;
            btnExecute.Click += btnExecute_Click;
            // 
            // FilenameSettingDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(345, 93);
            Controls.Add(btnExecute);
            Controls.Add(txtFilename);
            Name = "FilenameSettingDialog";
            Text = "FilenameSettingDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFilename;
        private Button btnExecute;
    }
}