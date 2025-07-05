namespace MoodMind.GUI
{
    partial class Admin_Stats
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_Stats));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lbl_usercount = new System.Windows.Forms.Label();
            this.lbl_diarycount = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.btn_chat = new System.Windows.Forms.Button();
            this.btn_tips = new System.Windows.Forms.Button();
            this.btn_stats = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.genderChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ageChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.moodChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.menuBar = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.genderChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ageChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moodChart)).BeginInit();
            this.menuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_usercount
            // 
            this.lbl_usercount.AutoSize = true;
            this.lbl_usercount.BackColor = System.Drawing.Color.Transparent;
            this.lbl_usercount.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_usercount.Location = new System.Drawing.Point(148, 174);
            this.lbl_usercount.Name = "lbl_usercount";
            this.lbl_usercount.Size = new System.Drawing.Size(0, 42);
            this.lbl_usercount.TabIndex = 53;
            // 
            // lbl_diarycount
            // 
            this.lbl_diarycount.AutoSize = true;
            this.lbl_diarycount.BackColor = System.Drawing.Color.Transparent;
            this.lbl_diarycount.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_diarycount.Location = new System.Drawing.Point(372, 174);
            this.lbl_diarycount.Name = "lbl_diarycount";
            this.lbl_diarycount.Size = new System.Drawing.Size(0, 42);
            this.lbl_diarycount.TabIndex = 53;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(331, 529);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(55, 53);
            this.button5.TabIndex = 71;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btn_chat
            // 
            this.btn_chat.BackColor = System.Drawing.Color.Transparent;
            this.btn_chat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_chat.BackgroundImage")));
            this.btn_chat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_chat.FlatAppearance.BorderSize = 0;
            this.btn_chat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_chat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_chat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_chat.Location = new System.Drawing.Point(555, 521);
            this.btn_chat.Name = "btn_chat";
            this.btn_chat.Size = new System.Drawing.Size(63, 67);
            this.btn_chat.TabIndex = 69;
            this.btn_chat.UseVisualStyleBackColor = false;
            this.btn_chat.Click += new System.EventHandler(this.btn_chat_Click);
            // 
            // btn_tips
            // 
            this.btn_tips.BackColor = System.Drawing.Color.Transparent;
            this.btn_tips.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_tips.BackgroundImage")));
            this.btn_tips.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_tips.FlatAppearance.BorderSize = 0;
            this.btn_tips.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_tips.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_tips.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tips.Location = new System.Drawing.Point(458, 511);
            this.btn_tips.Name = "btn_tips";
            this.btn_tips.Size = new System.Drawing.Size(67, 53);
            this.btn_tips.TabIndex = 68;
            this.btn_tips.UseVisualStyleBackColor = false;
            // 
            // btn_stats
            // 
            this.btn_stats.BackColor = System.Drawing.Color.Transparent;
            this.btn_stats.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_stats.BackgroundImage")));
            this.btn_stats.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_stats.FlatAppearance.BorderSize = 0;
            this.btn_stats.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_stats.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_stats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_stats.Location = new System.Drawing.Point(388, 526);
            this.btn_stats.Name = "btn_stats";
            this.btn_stats.Size = new System.Drawing.Size(51, 62);
            this.btn_stats.TabIndex = 72;
            this.btn_stats.UseVisualStyleBackColor = false;
            this.btn_stats.Click += new System.EventHandler(this.btn_stats_Click);
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
            this.btn_close.Location = new System.Drawing.Point(933, 0);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(27, 23);
            this.btn_close.TabIndex = 73;
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // genderChart
            // 
            this.genderChart.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
            chartArea1.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.genderChart.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsTextAutoFit = false;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend1.Name = "Legend1";
            this.genderChart.Legends.Add(legend1);
            this.genderChart.Location = new System.Drawing.Point(33, 352);
            this.genderChart.Name = "genderChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.genderChart.Series.Add(series1);
            this.genderChart.Size = new System.Drawing.Size(220, 140);
            this.genderChart.TabIndex = 74;
            this.genderChart.Text = "chart1";
            // 
            // ageChart
            // 
            this.ageChart.BackColor = System.Drawing.Color.Transparent;
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
            chartArea2.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.ageChart.ChartAreas.Add(chartArea2);
            legend2.BackColor = System.Drawing.Color.Transparent;
            legend2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend2.IsTextAutoFit = false;
            legend2.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend2.Name = "Legend1";
            this.ageChart.Legends.Add(legend2);
            this.ageChart.Location = new System.Drawing.Point(259, 352);
            this.ageChart.Name = "ageChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.ageChart.Series.Add(series2);
            this.ageChart.Size = new System.Drawing.Size(220, 140);
            this.ageChart.TabIndex = 75;
            this.ageChart.Text = "chart1";
            // 
            // moodChart
            // 
            this.moodChart.BackColor = System.Drawing.Color.Transparent;
            chartArea3.BackColor = System.Drawing.Color.Transparent;
            chartArea3.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
            chartArea3.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea3.Name = "ChartArea1";
            this.moodChart.ChartAreas.Add(chartArea3);
            legend3.BackColor = System.Drawing.Color.Transparent;
            legend3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend3.IsTextAutoFit = false;
            legend3.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend3.Name = "Legend1";
            this.moodChart.Legends.Add(legend3);
            this.moodChart.Location = new System.Drawing.Point(568, 149);
            this.moodChart.Name = "moodChart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.moodChart.Series.Add(series3);
            this.moodChart.Size = new System.Drawing.Size(380, 343);
            this.moodChart.TabIndex = 76;
            this.moodChart.Text = "chart2";
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
            this.button1.Location = new System.Drawing.Point(911, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 23);
            this.button1.TabIndex = 13;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuBar
            // 
            this.menuBar.BackColor = System.Drawing.Color.Transparent;
            this.menuBar.Controls.Add(this.button1);
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(960, 24);
            this.menuBar.TabIndex = 77;
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
            this.button2.Location = new System.Drawing.Point(831, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 23);
            this.button2.TabIndex = 78;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Admin_Stats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(960, 600);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.moodChart);
            this.Controls.Add(this.ageChart);
            this.Controls.Add(this.genderChart);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_stats);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btn_chat);
            this.Controls.Add(this.btn_tips);
            this.Controls.Add(this.lbl_diarycount);
            this.Controls.Add(this.lbl_usercount);
            this.Controls.Add(this.menuBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Admin_Stats";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "f";
            this.Load += new System.EventHandler(this.Admin_Stats_Load);
            ((System.ComponentModel.ISupportInitialize)(this.genderChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ageChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moodChart)).EndInit();
            this.menuBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_diarycount;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btn_chat;
        private System.Windows.Forms.Button btn_tips;
        private System.Windows.Forms.Button btn_stats;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.DataVisualization.Charting.Chart genderChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart ageChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart moodChart;
        private System.Windows.Forms.Label lbl_usercount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel menuBar;
        private System.Windows.Forms.Button button2;
    }
}