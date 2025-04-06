using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecoderAndWriter
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
            this.showConfig();
        }

        private void showConfig()
        {
            var json = File.ReadAllText("./config.json");
            Dictionary<string, string> dict = JsonSerializer.Deserialize<Dictionary<string, string>>(json, SettingForm.GetOption());
            //return dict;
            if (dict != null)
            {
                this.txtConverApiUrl.Text = dict["convertApiUrl"];
            }
           
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            string url = this.txtConverApiUrl.Text;
            Dictionary<string,string> dict = new Dictionary<string,string>();
            dict.Add("convertApiUrl", url);

            var json = JsonSerializer.Serialize(dict, SettingForm.GetOption());
            File.WriteAllText("./config.json", json);

            this.Close();
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
    }
}
