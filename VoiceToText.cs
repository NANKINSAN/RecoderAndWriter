using Microsoft.VisualBasic;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using System.Data;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Policy;

namespace RecoderAndWriter
{
    internal class VoiceToText
    {
        private IWaveIn captureDevice;
        private WaveFileWriter writer;
        private string outputFilename;

        private class ResType
        {
            public string message { get; set; }
        }

        private IWaveIn CreateWaveInDevice(MMDevice device)
        {
            IWaveIn newWaveIn;

            newWaveIn = new WasapiCapture(device);

            // とりあえず、サンプルレートとモノラルを設定
            var sampleRate = 16000;
            var channels = 1;
            newWaveIn.WaveFormat = new WaveFormat(sampleRate, channels);

            newWaveIn.DataAvailable += OnDataAvailable;
            newWaveIn.RecordingStopped += OnRecordingStopped;
            return newWaveIn;
        }

        public void RecordStart(string outputFilename)
        {
            var deviceEnum = new MMDeviceEnumerator();
            var devices = deviceEnum.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active).ToList();

            // サンプルではコンボボックスで一覧を取得していたが、多分１番目のやつで大丈夫
            if (devices.Count() < 1)
            {
                MessageBox.Show("マイクが見つかりません。");
                return;
            }
            MMDevice device = (MMDevice)devices[0];

            if (captureDevice == null)
            {
                captureDevice = CreateWaveInDevice(device);
            }
            // Forcibly turn on the microphone (some programs (Skype) turn it off).
            //var device = (MMDevice)comboWasapiDevices.SelectedItem;
            device.AudioEndpointVolume.Mute = false;

            //outputFilename = "./out.wav";
            writer = new WaveFileWriter("./" + outputFilename, captureDevice.WaveFormat);
            captureDevice.StartRecording();
            //SetControlStates(true);
        }

        public void StopRecording()
        {
            Debug.WriteLine("StopRecording");
            captureDevice?.StopRecording();
            writer.Close();
            writer.Dispose();
            return;
        }

        private async Task<string> Convert_text(string url)
        {

            var content = new MultipartFormDataContent();
            using (var reader = File.OpenRead("./out.wav"))
            {
                var file = new StreamContent(reader);
                file.Headers.ContentType = new MediaTypeHeaderValue("audio/wav");

                //string url = "http://localhost:8000/convert_text"; //uriを入力
                //var request = new HttpRequestMessage(HttpMethod.Post, url);
                content.Add(file, "file", "out.wav");
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

        public string RecordStopAndGetText(string url = "http://localhost:8000/convert_text")
        {
            StopRecording();
            string result = "";
            result = Task.Run(() => this.Convert_text(url)).GetAwaiter().GetResult();
            return result;
        }

        void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            //Debug.WriteLine("OnDataAvailable");
            //if (InvokeRequired)
            //{
            //    Debug.WriteLine("Data Available");
            //    BeginInvoke(new EventHandler<WaveInEventArgs>(OnDataAvailable), sender, e);
            //}
            //else
            //{
            Debug.WriteLine("Flushing Data Available");
            writer.Write(e.Buffer, 0, e.BytesRecorded);
            int secondsRecorded = (int)(writer.Length / writer.WaveFormat.AverageBytesPerSecond);
            //if (secondsRecorded >= 30)
            //{
            //    StopRecording();
            //}
            //else
            //{
            //    //progressBar1.Value = secondsRecorded;
            //}
            //}
        }

        void OnRecordingStopped(object sender, StoppedEventArgs e)
        {
            Debug.WriteLine("OnRecordingStopped");
            //if (InvokeRequired)
            //{
            //    BeginInvoke(new EventHandler<StoppedEventArgs>(OnRecordingStopped), sender, e);
            //}
            //else
            //{
            //FinalizeWaveFile();
            //progressBar1.Value = 0;
            if (e.Exception != null)
            {
                MessageBox.Show(String.Format("A problem was encountered during recording {0}",
                                              e.Exception.Message));
            }
            //int newItemIndex = listBoxRecordings.Items.Add(outputFilename);
            //listBoxRecordings.SelectedIndex = newItemIndex;
            //SetControlStates(false);
            //}

            writer.Close();
        }
    }
}
