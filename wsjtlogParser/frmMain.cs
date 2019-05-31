using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security;
using CsvHelper;

namespace wsjtlogParser
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (fdlgLog.ShowDialog() == DialogResult.OK)
                if ((txtCallsign.Text!="") && (txtGrid.Text != ""))
                {
                    try
                    {
                        var logPath = fdlgLog.FileName;
                        var adifPath = Path.GetDirectoryName(fdlgLog.FileName) + @"\wsjtx_log_parsed.adi";
                        using (var sr = new StreamReader(logPath))
                        using (var log = new CsvReader(sr))
                        {
                            log.Configuration.HasHeaderRecord = false;
                            var records = log.GetRecords<LogDetails>();
                            var sw = new StreamWriter(adifPath);
                            StringBuilder adif = new StringBuilder();
                            adif.AppendLine("WSJT-X ADIF Export<eoh>");
                            foreach (var record in records)
                            {
                                string call = record.callsign;
                                string gridsquare = record.gridSquare;
                                string mode = record.mode;
                                string rst_sent = (record.rstSent >= 0) ? ("+" + record.rstSent.ToString("D2")) : record.rstSent.ToString("D2");
                                string rst_rcvd = (record.rstRcvd >= 0) ? ("+" + record.rstRcvd.ToString("D2")) : record.rstRcvd.ToString("D2");
                                string qso_date = record.startDate.Replace("-", "");
                                string time_on = record.startTime.Replace(":", "");
                                string qso_date_off = record.endDate.Replace("-", "");
                                string time_off = record.endTime.Replace(":", "");
                                string band = "";
                                var frequency = record.freq;
                                string station_callsign = txtCallsign.Text;
                                string my_gridsquare = txtGrid.Text;
                                string tx_pwr = record.txPower;
                                string comment = record.comment;

                                if ((frequency > 0.1357) && (frequency < 0.1378)) band = "2190m";
                                if ((frequency > 0.472) && (frequency < 0.479)) band = "630m";
                                if ((frequency > 1.8) && (frequency < 2)) band = "160m";
                                if ((frequency > 3.5) && (frequency < 4)) band = "80m";
                                if ((frequency > 5.25) && (frequency < 5.45)) band = "60m";
                                if ((frequency > 7) && (frequency < 7.3)) band = "40m";
                                if ((frequency > 10.1) && (frequency < 10.15)) band = "30m";
                                if ((frequency > 14) && (frequency < 14.35)) band = "20m";
                                if ((frequency > 18.068) && (frequency < 18.168)) band = "17m";
                                if ((frequency > 21) && (frequency < 21.45)) band = "15m";
                                if ((frequency > 24.89) && (frequency < 24.99)) band = "12m";
                                if ((frequency > 28) && (frequency < 29.7)) band = "10m";
                                if ((frequency > 50) && (frequency < 54)) band = "6m";
                                if ((frequency > 144) && (frequency < 148)) band = "2m";
                                if ((frequency > 220) && (frequency < 225)) band = "1.25m";
                                if ((frequency > 420) && (frequency < 450)) band = "70cm";
                                if ((frequency > 902) && (frequency < 928)) band = "33cm";
                                if ((frequency > 1240) && (frequency < 1300)) band = "23cm";
                                if ((frequency > 2300) && (frequency < 2450)) band = "13cm";
                                if ((frequency > 3300) && (frequency < 3500)) band = "9cm";
                                if ((frequency > 5650) && (frequency < 5925)) band = "6cm";

                                var freq = frequency.ToString();

                                adif.Append(String.Format("<call:{0}>{1} ", call.Length, call));
                                adif.Append(String.Format("<gridsquare:{0}>{1} ", gridsquare.Length, gridsquare));
                                adif.Append(String.Format("<mode:{0}>{1} ", mode.Length, mode));
                                adif.Append(String.Format("<rst_sent:{0}>{1} ", rst_sent.Length, rst_sent));
                                adif.Append(String.Format("<rst_rcvd:{0}>{1} ", rst_rcvd.Length, rst_rcvd));
                                adif.Append(String.Format("<qso_date:{0}>{1} ", qso_date.Length, qso_date));
                                adif.Append(String.Format("<time_on:{0}>{1} ", time_on.Length, time_on));
                                adif.Append(String.Format("<qso_date_off:{0}>{1} ", qso_date_off.Length, qso_date_off));
                                adif.Append(String.Format("<time_off:{0}>{1} ", time_off.Length, time_off));
                                adif.Append(String.Format("<band:{0}>{1} ", band.Length, band));
                                adif.Append(String.Format("<freq:{0}>{1} ", freq.Length, freq));
                                adif.Append(String.Format("<station_callsign:{0}>{1} ", station_callsign.Length, station_callsign));
                                adif.Append(String.Format("<my_gridsquare:{0}>{1} ", my_gridsquare.Length, my_gridsquare));
                                if (tx_pwr != "") adif.Append(String.Format("<tx_pwr:{0}>{1} ", tx_pwr.Length, tx_pwr));
                                if (comment != "") adif.Append(String.Format("<comment:{0}>{1} ", comment.Length, comment));
                                adif.AppendLine("<eor>");
                                sw.Write(adif);
                                adif.Clear();
                            }
                            sw.Close();
                            MessageBox.Show("All Done!!");
                            OpenFolderAndSelectFile(adifPath);
                        }
                    }
                    catch (SecurityException ex)
                    {
                        MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" + $"Details:\n\n{ex.StackTrace}");
                    }
                }
                else
                    {
                        MessageBox.Show("Please enter callsign and gridsquare.");
                    }
        }

        private void OpenFolderAndSelectFile(String fileFullName)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + fileFullName;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
