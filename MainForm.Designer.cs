namespace RecoderAndWriter
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnRecordStart = new Button();
            btnRcordStop = new Button();
            btnSetting = new Button();
            txtAudioFilePath = new TextBox();
            label1 = new Label();
            btnReference = new Button();
            btnConvert = new Button();
            label2 = new Label();
            txtOutMessage = new TextBox();
            lblProgress = new Label();
            SuspendLayout();
            // 
            // btnRecordStart
            // 
            btnRecordStart.Location = new Point(12, 12);
            btnRecordStart.Name = "btnRecordStart";
            btnRecordStart.Size = new Size(75, 23);
            btnRecordStart.TabIndex = 0;
            btnRecordStart.Text = "録音開始";
            btnRecordStart.UseVisualStyleBackColor = true;
            btnRecordStart.Click += btnRecordStart_Click;
            // 
            // btnRcordStop
            // 
            btnRcordStop.Location = new Point(132, 12);
            btnRcordStop.Name = "btnRcordStop";
            btnRcordStop.Size = new Size(75, 23);
            btnRcordStop.TabIndex = 0;
            btnRcordStop.Text = "録音停止";
            btnRcordStop.UseVisualStyleBackColor = true;
            btnRcordStop.Click += btnRcordStop_Click;
            // 
            // btnSetting
            // 
            btnSetting.Location = new Point(602, 12);
            btnSetting.Name = "btnSetting";
            btnSetting.Size = new Size(75, 23);
            btnSetting.TabIndex = 1;
            btnSetting.Text = "設定...";
            btnSetting.UseVisualStyleBackColor = true;
            btnSetting.Click += btnSetting_Click;
            // 
            // txtAudioFilePath
            // 
            txtAudioFilePath.Location = new Point(12, 83);
            txtAudioFilePath.Name = "txtAudioFilePath";
            txtAudioFilePath.Size = new Size(624, 23);
            txtAudioFilePath.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 65);
            label1.Name = "label1";
            label1.Size = new Size(203, 15);
            label1.TabIndex = 3;
            label1.Text = "変換ファイル選択（wav形式、16kbps）";
            // 
            // btnReference
            // 
            btnReference.Location = new Point(642, 82);
            btnReference.Name = "btnReference";
            btnReference.Size = new Size(35, 23);
            btnReference.TabIndex = 4;
            btnReference.Text = "...";
            btnReference.UseVisualStyleBackColor = true;
            btnReference.Click += btnReference_Click;
            // 
            // btnConvert
            // 
            btnConvert.Location = new Point(292, 112);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(75, 23);
            btnConvert.TabIndex = 5;
            btnConvert.Text = "変換";
            btnConvert.UseVisualStyleBackColor = true;
            btnConvert.Click += btnConvert_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(319, 138);
            label2.Name = "label2";
            label2.Size = new Size(19, 15);
            label2.TabIndex = 6;
            label2.Text = "↓";
            // 
            // txtOutMessage
            // 
            txtOutMessage.Location = new Point(12, 158);
            txtOutMessage.Multiline = true;
            txtOutMessage.Name = "txtOutMessage";
            txtOutMessage.ScrollBars = ScrollBars.Vertical;
            txtOutMessage.Size = new Size(665, 280);
            txtOutMessage.TabIndex = 7;
            // 
            // lblProgress
            // 
            lblProgress.AutoSize = true;
            lblProgress.Location = new Point(411, 138);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(52, 15);
            lblProgress.TabIndex = 8;
            lblProgress.Text = "変換中...";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(689, 450);
            Controls.Add(lblProgress);
            Controls.Add(txtOutMessage);
            Controls.Add(label2);
            Controls.Add(btnConvert);
            Controls.Add(btnReference);
            Controls.Add(label1);
            Controls.Add(txtAudioFilePath);
            Controls.Add(btnSetting);
            Controls.Add(btnRcordStop);
            Controls.Add(btnRecordStart);
            Name = "MainForm";
            Text = "録音と文字起こし";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRecordStart;
        private Button btnRcordStop;
        private Button btnSetting;
        private TextBox txtAudioFilePath;
        private Label label1;
        private Button btnReference;
        private Button btnConvert;
        private Label label2;
        private TextBox txtOutMessage;
        private Label lblProgress;
    }
}
