namespace RecoderAndWriter
{
    partial class SettingForm
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
            txtConverApiUrl = new TextBox();
            label1 = new Label();
            btnExecute = new Button();
            SuspendLayout();
            // 
            // txtConverApiUrl
            // 
            txtConverApiUrl.Location = new Point(12, 36);
            txtConverApiUrl.Name = "txtConverApiUrl";
            txtConverApiUrl.Size = new Size(346, 23);
            txtConverApiUrl.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 1;
            label1.Text = "変換API";
            // 
            // btnExecute
            // 
            btnExecute.Location = new Point(283, 70);
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new Size(75, 23);
            btnExecute.TabIndex = 2;
            btnExecute.Text = "実行";
            btnExecute.UseVisualStyleBackColor = true;
            btnExecute.Click += btnExecute_Click;
            // 
            // SettingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(369, 103);
            Controls.Add(btnExecute);
            Controls.Add(label1);
            Controls.Add(txtConverApiUrl);
            Name = "SettingForm";
            Text = "SettingForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtConverApiUrl;
        private Label label1;
        private Button btnExecute;
    }
}