using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using static System.Net.WebRequestMethods;

namespace RecoderAndWriter
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.voiceToText = new VoiceToText();
            this.btnRcordStop.Enabled = false;
            this.makeDefaultConfig();
            this.lblProgress.Text = string.Empty;
        }

        private class ResType
        {
            public string message { get; set; }
        }

        VoiceToText voiceToText;

        private void makeDefaultConfig()
        {
            if (System.IO.File.Exists("./config.json"))
            {
                string url = "http://localhost:8000/convert_text";
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("convertApiUrl", url);

                var json = JsonSerializer.Serialize(dict, MainForm.GetOption());
                System.IO.File.WriteAllText("./config.json", json);
        
            }
        }

        private void btnRecordStart_Click(object sender, EventArgs e)
        {
            FilenameSettingDialog filenameSettingDialog = new FilenameSettingDialog();
            filenameSettingDialog.ShowDialog();
            string filename = filenameSettingDialog.Filename;
            this.btnRcordStop.Enabled = true;
            this.btnRecordStart.Enabled = false;
            this.voiceToText.RecordStart(filename);
        }

        private string loadConvertUrl()
        {
            var json = System.IO.File.ReadAllText("./config.json");
            Dictionary<string, string> dict = JsonSerializer.Deserialize<Dictionary<string, string>>(json, MainForm.GetOption());
            //return dict;
            if (dict != null)
            {
                return dict["convertApiUrl"];
            }
            else
            {
                return "";
            }
        }

        // <summary>
        /// オプションを設定します。内部メソッドです。
        /// </summary>
        /// <returns>JsonSerializerOptions型のオプション</returns>
        private static JsonSerializerOptions GetOption()
        {
            // ユニコードのレンジ指定で日本語も正しく表示、インデントされるように指定
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true,
            };
            return options;
        }

        private void btnRcordStop_Click(object sender, EventArgs e)
        {
            this.btnRcordStop.Enabled = false;
            this.btnRecordStart.Enabled = true;
            this.voiceToText.StopRecording();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm();
            settingForm.ShowDialog();
        }

        private async Task<string> Convert_text(string url, string audioFilePath)
        {
            var content = new MultipartFormDataContent();
            using (var reader = System.IO.File.OpenRead(audioFilePath))
            {
                var file = new StreamContent(reader);
                file.Headers.ContentType = new MediaTypeHeaderValue("audio/wav");

                //string url = "http://localhost:8000/convert_text"; //uriを入力
                //var request = new HttpRequestMessage(HttpMethod.Post, url);
                string filename = Path.GetFileName(audioFilePath);
                content.Add(file, "file", filename);
                content.Headers.ContentDisposition = file.Headers.ContentDisposition;
                //request.Content = content;

                HttpClient httpclient = new HttpClient();
                HttpResponseMessage response = await httpclient.PostAsync(url, content);

                //HttpResponseMessage response
                //    = await httpclient.SendAsync(request);
                ResType msg = await response.Content.ReadFromJsonAsync<ResType>(); //レスポンスのContentをstring型として読み込む
                Console.WriteLine(msg.message);

                return await Task.Run(() => { return msg.message ?? ""; });
            }
        }

        private void btnReference_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
                dialog.Filter = "wav files(*.wav)|*.wav";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.txtAudioFilePath.Text = dialog.FileName;
                }
            }
        }

        private async void btnConvert_Click(object sender, EventArgs e)
        {
            this.lblProgress.Text = "変換中...";
            string url = this.loadConvertUrl();
            string message = await this.Convert_text(url, this.txtAudioFilePath.Text);
            this.txtOutMessage.Text = message;
            this.lblProgress.Text = "変換完了";
        }
    }
}
