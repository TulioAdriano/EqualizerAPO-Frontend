using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EQAPOFE
{
    public partial class frmEQAPO : Form
    {
        List<string> eqLines = new List<string>();
        string[] eqItems;

#if DEBUG
        string configPath = $@"C:\Program Files\EqualizerAPO\config\config.txt";
#else
        string configPath = $@"{Application.StartupPath}\config.txt";
#endif

        public frmEQAPO()
        {
            InitializeComponent();
        }

        private void frmEQAPO_Load(object sender, EventArgs e)
        {
            if (!File.Exists(configPath))
            {
                MessageBox.Show("Cannot find configuration file. Please place this program on the same folder as config.txt.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            using (StreamReader eqFile = new StreamReader(File.OpenRead(configPath)))
            {
                while (!eqFile.EndOfStream)
                {
                    eqLines.Add(eqFile.ReadLine());
                }
            }

            string gainLine = eqLines.Where(c => c.StartsWith("Preamp:")).FirstOrDefault();
            sliderGain.Value = Convert.ToInt32(gainLine.Split(' ')[1]) * 10;
            lblPreamp.Text = $"{gainLine.Split(' ')[1]} dB";


            string graphEqLine = eqLines.Where(c => c.StartsWith("GraphicEQ:")).FirstOrDefault();

            eqItems = graphEqLine.Substring(graphEqLine.IndexOf(":") + 1).Split(';');
            for (int i = 0; i < eqItems.Length; i++)
            {
                string[] bandData = eqItems[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (i > 0)
                {
                    TrackBar newSlider = new TrackBar()
                    {
                        Name = $"sliderBand{i + 1}",
                        Maximum = sliderBand1.Maximum,
                        Minimum = sliderBand1.Minimum,
                        LargeChange = sliderBand1.LargeChange,
                        TickFrequency = sliderBand1.TickFrequency,
                        Orientation = sliderBand1.Orientation,
                        TickStyle = sliderBand1.TickStyle,
                        Height = sliderBand1.Height,
                        Top = sliderBand1.Top,
                        Left = sliderBand1.Left + (sliderBand1.Width * i),
                        Visible = true
                    };
                    Label newLblHz = new Label()
                    {
                        Name = $"lblBandHz{i + 1}",
                        AutoSize = true,
                        Size = lblBandHz1.Size,
                        Top = lblBandHz1.Top,
                        Left = newSlider.Left,
                        Visible = true
                    };
                    Label newLblGain = new Label()
                    {
                        Name = $"lblBandGain{i + 1}",
                        AutoSize = true,
                        Size = lblBandGain1.Size,
                        Top = lblBandGain1.Top,
                        Left = newSlider.Left,
                        Visible = true
                    };
                    this.Width += sliderBand1.Width;

                    newSlider.Scroll += Slider_Scroll;

                    this.Controls.Add(newSlider);
                    this.Controls.Add(newLblHz);
                    this.Controls.Add(newLblGain);
                }

                TrackBar slider = this.Controls.Find($"sliderBand{i + 1}", true)[0] as TrackBar;
                Label lblHz = this.Controls.Find($"lblBandHz{i + 1}", true)[0] as Label;
                Label lblGain = this.Controls.Find($"lblBandGain{i + 1}", true)[0] as Label;

                slider.Value = (int)(Convert.ToDouble(bandData[1]) * 10);
                lblHz.Text = (Convert.ToDouble(bandData[0]) >= 1000 ? $"{Convert.ToDouble(bandData[0]) / 1000.0} KHz" : $"{bandData[0]} Hz");
                lblGain.Text = $"{bandData[1]} dB";

            }

        }

        private void Slider_Scroll(object sender, EventArgs e)
        {
            TrackBar sliderBand = sender as TrackBar;
            int sliderNumber = Convert.ToInt32(sliderBand.Name.Replace("sliderBand", ""));
            Label lblGain = this.Controls.Find($"lblBandGain{sliderNumber}", true)[0] as Label;

            lblGain.Text = $"{sliderBand.Value / 10.0} dB";
            string[] bandData = eqItems[sliderNumber - 1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            bandData[1] = (sliderBand.Value / 10.0).ToString();
            eqItems[sliderNumber - 1] = string.Join(" ", bandData);

            StringBuilder configText = new StringBuilder();
            for (int i =0; i<eqLines.Count;i++)
            {
                if (eqLines[i].StartsWith("GraphicEQ:"))
                {
                    eqLines[i] = $"GraphicEQ: {string.Join("; ", eqItems)}";
                }
                configText.AppendLine(eqLines[i]);
            }

            try
            {
                File.WriteAllText(configPath, configText.ToString());
            }
            catch { }
        }

        private void sliderGain_Scroll(object sender, EventArgs e)
        {
            lblPreamp.Text = $"{sliderGain.Value / 10.0} dB";

            StringBuilder configText = new StringBuilder();
            for (int i = 0; i < eqLines.Count; i++)
            {
                if (eqLines[i].StartsWith("Preamp:"))
                {
                    eqLines[i] = $"Preamp: {sliderGain.Value / 10.0} dB";
                }
                configText.AppendLine(eqLines[i]);
            }

            try
            {
                File.WriteAllText(configPath, configText.ToString());
            }
            catch { }

        }
    }
}
