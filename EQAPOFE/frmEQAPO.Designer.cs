namespace EQAPOFE
{
    partial class frmEQAPO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEQAPO));
            this.sliderGain = new System.Windows.Forms.TrackBar();
            this.sliderBand1 = new System.Windows.Forms.TrackBar();
            this.lblPreamp = new System.Windows.Forms.Label();
            this.lblBandGain1 = new System.Windows.Forms.Label();
            this.lblBandHz1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sliderGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderBand1)).BeginInit();
            this.SuspendLayout();
            // 
            // sliderGain
            // 
            this.sliderGain.LargeChange = 10;
            this.sliderGain.Location = new System.Drawing.Point(12, 33);
            this.sliderGain.Maximum = 120;
            this.sliderGain.Minimum = -120;
            this.sliderGain.Name = "sliderGain";
            this.sliderGain.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.sliderGain.Size = new System.Drawing.Size(45, 250);
            this.sliderGain.TabIndex = 0;
            this.sliderGain.TickFrequency = 10;
            this.sliderGain.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.sliderGain.Scroll += new System.EventHandler(this.sliderGain_Scroll);
            // 
            // sliderBand1
            // 
            this.sliderBand1.LargeChange = 10;
            this.sliderBand1.Location = new System.Drawing.Point(90, 33);
            this.sliderBand1.Maximum = 120;
            this.sliderBand1.Minimum = -120;
            this.sliderBand1.Name = "sliderBand1";
            this.sliderBand1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.sliderBand1.Size = new System.Drawing.Size(45, 250);
            this.sliderBand1.TabIndex = 0;
            this.sliderBand1.TickFrequency = 10;
            this.sliderBand1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.sliderBand1.Scroll += new System.EventHandler(this.Slider_Scroll);
            // 
            // lblPreamp
            // 
            this.lblPreamp.AutoSize = true;
            this.lblPreamp.Location = new System.Drawing.Point(9, 286);
            this.lblPreamp.Name = "lblPreamp";
            this.lblPreamp.Size = new System.Drawing.Size(35, 13);
            this.lblPreamp.TabIndex = 1;
            this.lblPreamp.Text = "label1";
            // 
            // lblBandGain1
            // 
            this.lblBandGain1.AutoSize = true;
            this.lblBandGain1.Location = new System.Drawing.Point(87, 286);
            this.lblBandGain1.Name = "lblBandGain1";
            this.lblBandGain1.Size = new System.Drawing.Size(35, 13);
            this.lblBandGain1.TabIndex = 1;
            this.lblBandGain1.Text = "label1";
            // 
            // lblBandHz1
            // 
            this.lblBandHz1.AutoSize = true;
            this.lblBandHz1.Location = new System.Drawing.Point(87, 17);
            this.lblBandHz1.Name = "lblBandHz1";
            this.lblBandHz1.Size = new System.Drawing.Size(35, 13);
            this.lblBandHz1.TabIndex = 2;
            this.lblBandHz1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Preamp";
            // 
            // frmEQAPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(147, 309);
            this.Controls.Add(this.lblBandHz1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblBandGain1);
            this.Controls.Add(this.lblPreamp);
            this.Controls.Add(this.sliderBand1);
            this.Controls.Add(this.sliderGain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEQAPO";
            this.Text = "Equalizer APO";
            this.Load += new System.EventHandler(this.frmEQAPO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sliderGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderBand1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar sliderGain;
        private System.Windows.Forms.TrackBar sliderBand1;
        private System.Windows.Forms.Label lblPreamp;
        private System.Windows.Forms.Label lblBandGain1;
        private System.Windows.Forms.Label lblBandHz1;
        private System.Windows.Forms.Label label2;
    }
}

