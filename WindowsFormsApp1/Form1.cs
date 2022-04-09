using helperMethods;
using helperMethods.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly long FILESIZE_MAX = 1000L * 1000 * 32;
        private FileUploadResult currentRecord = null;
        private ScanValueResult currentScanResult = null;
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Upload.Enabled = false;
            try
            {
                var location = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                using (OpenFileDialog ob = new OpenFileDialog())
                {
                    ob.InitialDirectory = location;
                    ob.Multiselect = false;
                    if (ob.ShowDialog() == DialogResult.OK)
                    {
                        var fileLocation = ob.FileName;
                        if (new FileInfo(ob.FileName).Length > FILESIZE_MAX)
                        {
                            throw new Exception($"Please choose file Max size 32 MB {Environment.NewLine} We don't have access for more then 32 MB");
                        }
                        var file = await ApiHelper.PostFile(fileLocation, @"file/scan"); currentRecord = file;
                        if (file != null)
                        {
                            FileUploardText.Text = fileLocation;
                            MessageBox.Show(file.verbose_msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CheckAndFill(file);
                            currentRecord = file;
                        }
                        else
                        {
                            throw new Exception($"Unable to Upload {Environment.NewLine} please contact help desk");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Upload.Enabled = true;
        }
        private string CheckAndFill(FileUploadResult ee)
        {
            if (string.IsNullOrEmpty(ee.md5) == false)
            {
                Current_Reference.Text = $"Reference :- MD5 {ee.md5}";
                return ee.md5;
            }
            else if (string.IsNullOrEmpty(ee.sha1) == false)
            {
                Current_Reference.Text = $"Reference :- SH-1 {ee.sha1}";
                return ee.sha1;
            }
            else if (string.IsNullOrEmpty(ee.sha256) == false)
            {
                Current_Reference.Text = $"Reference :- SHA-256 {ee.sha1}";
                return ee.sha256;
            }
            else
            {
                Current_Reference.Text = "No Record";
                return "";
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            ApiHelper.BASE_API = System.Configuration.ConfigurationManager.AppSettings["BaseUrl"];
            ApiHelper.API_Key = System.Configuration.ConfigurationManager.AppSettings["ApiKey"];

        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            if (currentRecord != null)
            {
                var query = new NameValueCollection();
                query.Add("apikey", System.Configuration.ConfigurationManager.AppSettings["ApiKey"].ToString());
                query.Add("resource", CheckAndFill(currentRecord));
                currentScanResult = await ApiHelper.getClientWithQuery<ScanValueResult>(@"file/report", query);
                if (currentScanResult != null)
                {
                    ReportResult.DataSource = Utils.ConvertListToDataTable(getListFormDictonary(currentScanResult.scans));
                    JsonTextBox.Text = Newtonsoft.Json.JsonConvert.SerializeObject(currentScanResult);
                }
            }
            else
            {
                MessageBox.Show("Please Upload Document First", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private List<ScanObject_2> getListFormDictonary(Dictionary<string, ScanObject> ob)
        {
            var returnValue = new List<ScanObject_2>();
            foreach (var key in ob.Keys)
            {
                var copy = new ScanObject_2();
                copy.scan = key;
                copy.detected = ob[key].detected;
                copy.version = ob[key].version;
                copy.result = ob[key].result;
                copy.update = ob[key].update;
                returnValue.Add(copy);
            }
            return returnValue;
        }
    }
}
