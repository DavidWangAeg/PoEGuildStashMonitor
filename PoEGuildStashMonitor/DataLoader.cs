using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoEGuildStashMonitor
{
    public partial class DataLoader : Form
    {
        private const string SaveDataFileName = "GuildStashMonitorData.json";
        private string saveDataDirectoryPath;
        private string saveDataFilePath;

        private const string RequestFormat = "https://www.pathofexile.com/api/guild/{0}/stash/history?from={1}&fromid={2}";

        private string[] statusLabelText = new[]
        {
            "Reading Cached Data...",
            "Fetching Data for the last 7 days..."
        };

        private int currStatus = 0;

        private HttpClient httpClient;

        public DataLoader()
        {
            InitializeComponent();

            saveDataDirectoryPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "GuildStashMonitor");

            if (!Directory.Exists(saveDataDirectoryPath))
            {
                Directory.CreateDirectory(saveDataDirectoryPath);
            }

            saveDataFilePath = Path.Combine(
                saveDataDirectoryPath, 
                SaveDataFileName);

            httpClient = new HttpClient();
        }

        private async void DataLoader_Load(object sender, EventArgs e)
        {
            ReadCachedData();
            DisplayNextState();
            long epoch = (DateTimeOffset.Now - TimeSpan.FromDays(2)).ToUnixTimeSeconds();

            // await FetchDataAsync((DateTimeOffset.Now - TimeSpan.FromDays(2)).ToUnixTimeSeconds());
            FetchDataWeb(epoch);
        }

        private void ReadCachedData()
        {
            if (File.Exists(saveDataDirectoryPath))
            {
                UserDataCache.Instance.LoadData(saveDataFilePath);
            }
        }

        private async Task FetchDataAsync(long fromEpochTime)
        {
            HttpRequestMessage msg = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(string.Format(RequestFormat, Login.GuildID, fromEpochTime, ""))
            };

            msg.Headers.Add("POESESSID", Login.PoeSessID);

            HttpResponseMessage value = await httpClient.SendAsync(msg);

            StatusLabel.Text = await value.Content.ReadAsStringAsync();
        }

        private void FetchDataWeb(long fromEpochTime)
        {
            using (var webClient = new WebClient())
            {
                var uri = new Uri(string.Format(RequestFormat, Login.GuildID, fromEpochTime, ""));
                var webReq = HttpWebRequest.Create(uri) as HttpWebRequest;
                webReq.CookieContainer = new CookieContainer();
                webReq.CookieContainer.Add(new Cookie("POESESSID", Login.PoeSessID, "/", uri.Host));

                var response = webReq.GetResponse();
                var receiveStream = response.GetResponseStream();
                var readStream = new StreamReader(receiveStream, Encoding.UTF8);
                var htmlCode = readStream.ReadToEnd();

                StatusLabel.Text = htmlCode;
            }
        }

        private void DisplayNextState()
        {
            StatusLabel.Text = statusLabelText[++currStatus];
        }
    }
}
