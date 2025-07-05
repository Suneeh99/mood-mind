namespace MoodMind.GUI
{
    partial class Mood_Stats
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mood_Stats));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.chart_month = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lbl_fifth = new System.Windows.Forms.Label();
            this.lbl_4per = new System.Windows.Forms.Label();
            this.lbl_5per = new System.Windows.Forms.Label();
            this.lbl_3per = new System.Windows.Forms.Label();
            this.lbl_fourth = new System.Windows.Forms.Label();
            this.lbl_2per = new System.Windows.Forms.Label();
            this.lbl_1per = new System.Windows.Forms.Label();
            this.lbl_third = new System.Windows.Forms.Label();
            this.lbl_second = new System.Windows.Forms.Label();
            this.lbl_first = new System.Windows.Forms.Label();
            this.chart_week = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuBar = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart_month)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_week)).BeginInit();
            this.menuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(420, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "\'s Mood Stats";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.BackColor = System.Drawing.Color.Transparent;
            this.lbl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbl_name.Location = new System.Drawing.Point(259, 62);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_name.Size = new System.Drawing.Size(0, 46);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.Transparent;
            this.btn_close.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_close.BackgroundImage")));
            this.btn_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Location = new System.Drawing.Point(692, 54);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(58, 55);
            this.btn_close.TabIndex = 54;
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(933, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 23);
            this.button1.TabIndex = 55;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chart_month
            // 
            this.chart_month.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
            chartArea1.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart_month.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsTextAutoFit = false;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend1.Name = "Legend1";
            this.chart_month.Legends.Add(legend1);
            this.chart_month.Location = new System.Drawing.Point(664, 278);
            this.chart_month.Name = "chart_month";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart_month.Series.Add(series1);
            this.chart_month.Size = new System.Drawing.Size(244, 180);
            this.chart_month.TabIndex = 67;
            this.chart_month.Text = "chart2";
            // 
            // lbl_fifth
            // 
            this.lbl_fifth.AutoSize = true;
            this.lbl_fifth.BackColor = System.Drawing.Color.Transparent;
            this.lbl_fifth.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fifth.Location = new System.Drawing.Point(102, 410);
            this.lbl_fifth.Name = "lbl_fifth";
            this.lbl_fifth.Size = new System.Drawing.Size(0, 24);
            this.lbl_fifth.TabIndex = 57;
            // 
            // lbl_4per
            // 
            this.lbl_4per.AutoSize = true;
            this.lbl_4per.BackColor = System.Drawing.Color.Transparent;
            this.lbl_4per.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_4per.Location = new System.Drawing.Point(244, 373);
            this.lbl_4per.Name = "lbl_4per";
            this.lbl_4per.Size = new System.Drawing.Size(0, 24);
            this.lbl_4per.TabIndex = 58;
            // 
            // lbl_5per
            // 
            this.lbl_5per.AutoSize = true;
            this.lbl_5per.BackColor = System.Drawing.Color.Transparent;
            this.lbl_5per.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_5per.Location = new System.Drawing.Point(244, 410);
            this.lbl_5per.Name = "lbl_5per";
            this.lbl_5per.Size = new System.Drawing.Size(0, 24);
            this.lbl_5per.TabIndex = 59;
            // 
            // lbl_3per
            // 
            this.lbl_3per.AutoSize = true;
            this.lbl_3per.BackColor = System.Drawing.Color.Transparent;
            this.lbl_3per.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_3per.Location = new System.Drawing.Point(244, 334);
            this.lbl_3per.Name = "lbl_3per";
            this.lbl_3per.Size = new System.Drawing.Size(0, 24);
            this.lbl_3per.TabIndex = 60;
            // 
            // lbl_fourth
            // 
            this.lbl_fourth.AutoSize = true;
            this.lbl_fourth.BackColor = System.Drawing.Color.Transparent;
            this.lbl_fourth.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fourth.Location = new System.Drawing.Point(102, 373);
            this.lbl_fourth.Name = "lbl_fourth";
            this.lbl_fourth.Size = new System.Drawing.Size(0, 24);
            this.lbl_fourth.TabIndex = 61;
            // 
            // lbl_2per
            // 
            this.lbl_2per.AutoSize = true;
            this.lbl_2per.BackColor = System.Drawing.Color.Transparent;
            this.lbl_2per.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_2per.Location = new System.Drawing.Point(244, 294);
            this.lbl_2per.Name = "lbl_2per";
            this.lbl_2per.Size = new System.Drawing.Size(0, 24);
            this.lbl_2per.TabIndex = 62;
            // 
            // lbl_1per
            // 
            this.lbl_1per.AutoSize = true;
            this.lbl_1per.BackColor = System.Drawing.Color.Transparent;
            this.lbl_1per.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_1per.Location = new System.Drawing.Point(244, 255);
            this.lbl_1per.Name = "lbl_1per";
            this.lbl_1per.Size = new System.Drawing.Size(0, 24);
            this.lbl_1per.TabIndex = 63;
            // 
            // lbl_third
            // 
            this.lbl_third.AutoSize = true;
            this.lbl_third.BackColor = System.Drawing.Color.Transparent;
            this.lbl_third.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_third.Location = new System.Drawing.Point(102, 334);
            this.lbl_third.Name = "lbl_third";
            this.lbl_third.Size = new System.Drawing.Size(0, 24);
            this.lbl_third.TabIndex = 64;
            // 
            // lbl_second
            // 
            this.lbl_second.AutoSize = true;
            this.lbl_second.BackColor = System.Drawing.Color.Transparent;
            this.lbl_second.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_second.Location = new System.Drawing.Point(102, 294);
            this.lbl_second.Name = "lbl_second";
            this.lbl_second.Size = new System.Drawing.Size(0, 24);
            this.lbl_second.TabIndex = 65;
            // 
            // lbl_first
            // 
            this.lbl_first.AutoSize = true;
            this.lbl_first.BackColor = System.Drawing.Color.Transparent;
            this.lbl_first.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_first.Location = new System.Drawing.Point(102, 255);
            this.lbl_first.Name = "lbl_first";
            this.lbl_first.Size = new System.Drawing.Size(0, 24);
            this.lbl_first.TabIndex = 66;
            // 
            // chart_week
            // 
            this.chart_week.BackColor = System.Drawing.Color.Transparent;
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
            chartArea2.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.chart_week.ChartAreas.Add(chartArea2);
            legend2.BackColor = System.Drawing.Color.Transparent;
            legend2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend2.IsTextAutoFit = false;
            legend2.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend2.Name = "Legend1";
            this.chart_week.Legends.Add(legend2);
            this.chart_week.Location = new System.Drawing.Point(387, 278);
            this.chart_week.Name = "chart_week";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart_week.Series.Add(series2);
            this.chart_week.Size = new System.Drawing.Size(244, 180);
            this.chart_week.TabIndex = 56;
            this.chart_week.Text = "chart1";
            // 
            // menuBar
            // 
            this.menuBar.BackColor = System.Drawing.Color.Transparent;
            this.menuBar.Controls.Add(this.button2);
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(960, 24);
            this.menuBar.TabIndex = 69;
            this.menuBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuBar_MouseDown);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(911, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(20, 23);
            this.button2.TabIndex = 13;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(831, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(65, 23);
            this.button3.TabIndex = 70;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Mood_Stats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(960, 600);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuBar);
            this.Controls.Add(this.chart_month);
            this.Controls.Add(this.lbl_fifth);
            this.Controls.Add(this.lbl_4per);
            this.Controls.Add(this.lbl_5per);
            this.Controls.Add(this.lbl_3per);
            this.Controls.Add(this.lbl_fourth);
            this.Controls.Add(this.lbl_2per);
            this.Controls.Add(this.lbl_1per);
            this.Controls.Add(this.lbl_third);
            this.Controls.Add(this.lbl_second);
            this.Controls.Add(this.lbl_first);
            this.Controls.Add(this.chart_week);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Mood_Stats";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.Mood_Stats_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart_month)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_week)).EndInit();
            this.menuBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_month;
        private System.Windows.Forms.Label lbl_fifth;
        private System.Windows.Forms.Label lbl_4per;
        private System.Windows.Forms.Label lbl_5per;
        private System.Windows.Forms.Label lbl_3per;
        private System.Windows.Forms.Label lbl_fourth;
        private System.Windows.Forms.Label lbl_2per;
        private System.Windows.Forms.Label lbl_1per;
        private System.Windows.Forms.Label lbl_third;
        private System.Windows.Forms.Label lbl_second;
        private System.Windows.Forms.Label lbl_first;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_week;
        private System.Windows.Forms.Panel menuBar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}