namespace AptPrice_DataCenter
{
    partial class Form_Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbxDt01Type = new System.Windows.Forms.ComboBox();
            this.chkShutDown = new System.Windows.Forms.CheckBox();
            this.lblSidoCount = new System.Windows.Forms.Label();
            this.lblSigunguCount = new System.Windows.Forms.Label();
            this.btnDtEnd01Dn = new System.Windows.Forms.Button();
            this.btnDtEnd01Up = new System.Windows.Forms.Button();
            this.dtEnd01 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRun01 = new System.Windows.Forms.Button();
            this.btnDtStr01Dn = new System.Windows.Forms.Button();
            this.btnDtStr01Up = new System.Windows.Forms.Button();
            this.dtStr01 = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.lblRankUaTypeCount = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(494, 444);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblRankUaTypeCount);
            this.tabPage1.Controls.Add(this.cbxDt01Type);
            this.tabPage1.Controls.Add(this.chkShutDown);
            this.tabPage1.Controls.Add(this.lblSidoCount);
            this.tabPage1.Controls.Add(this.lblSigunguCount);
            this.tabPage1.Controls.Add(this.btnDtEnd01Dn);
            this.tabPage1.Controls.Add(this.btnDtEnd01Up);
            this.tabPage1.Controls.Add(this.dtEnd01);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnRun01);
            this.tabPage1.Controls.Add(this.btnDtStr01Dn);
            this.tabPage1.Controls.Add(this.btnDtStr01Up);
            this.tabPage1.Controls.Add(this.dtStr01);
            this.tabPage1.Controls.Add(this.lblDate);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(486, 418);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbxDt01Type
            // 
            this.cbxDt01Type.FormattingEnabled = true;
            this.cbxDt01Type.Items.AddRange(new object[] {
            "년",
            "월"});
            this.cbxDt01Type.Location = new System.Drawing.Point(38, 7);
            this.cbxDt01Type.Name = "cbxDt01Type";
            this.cbxDt01Type.Size = new System.Drawing.Size(34, 20);
            this.cbxDt01Type.TabIndex = 12;
            this.cbxDt01Type.Text = "년";
            // 
            // chkShutDown
            // 
            this.chkShutDown.AutoSize = true;
            this.chkShutDown.Location = new System.Drawing.Point(348, 35);
            this.chkShutDown.Name = "chkShutDown";
            this.chkShutDown.Size = new System.Drawing.Size(132, 16);
            this.chkShutDown.TabIndex = 11;
            this.chkShutDown.Text = "완료후, 컴퓨터 종료";
            this.chkShutDown.UseVisualStyleBackColor = true;
            // 
            // lblSidoCount
            // 
            this.lblSidoCount.AutoSize = true;
            this.lblSidoCount.Location = new System.Drawing.Point(6, 51);
            this.lblSidoCount.Name = "lblSidoCount";
            this.lblSidoCount.Size = new System.Drawing.Size(38, 12);
            this.lblSidoCount.TabIndex = 10;
            this.lblSidoCount.Text = "label3";
            // 
            // lblSigunguCount
            // 
            this.lblSigunguCount.AutoSize = true;
            this.lblSigunguCount.Location = new System.Drawing.Point(6, 30);
            this.lblSigunguCount.Name = "lblSigunguCount";
            this.lblSigunguCount.Size = new System.Drawing.Size(38, 12);
            this.lblSigunguCount.TabIndex = 9;
            this.lblSigunguCount.Text = "label2";
            // 
            // btnDtEnd01Dn
            // 
            this.btnDtEnd01Dn.Location = new System.Drawing.Point(218, 6);
            this.btnDtEnd01Dn.Name = "btnDtEnd01Dn";
            this.btnDtEnd01Dn.Size = new System.Drawing.Size(25, 21);
            this.btnDtEnd01Dn.TabIndex = 8;
            this.btnDtEnd01Dn.Text = "▼";
            this.btnDtEnd01Dn.UseVisualStyleBackColor = true;
            this.btnDtEnd01Dn.Click += new System.EventHandler(this.btnDtEnd01Dn_Click);
            // 
            // btnDtEnd01Up
            // 
            this.btnDtEnd01Up.Location = new System.Drawing.Point(311, 6);
            this.btnDtEnd01Up.Name = "btnDtEnd01Up";
            this.btnDtEnd01Up.Size = new System.Drawing.Size(25, 21);
            this.btnDtEnd01Up.TabIndex = 7;
            this.btnDtEnd01Up.Text = "▲";
            this.btnDtEnd01Up.UseVisualStyleBackColor = true;
            this.btnDtEnd01Up.Click += new System.EventHandler(this.btnDtEnd01Up_Click);
            // 
            // dtEnd01
            // 
            this.dtEnd01.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEnd01.Location = new System.Drawing.Point(243, 6);
            this.dtEnd01.Name = "dtEnd01";
            this.dtEnd01.Size = new System.Drawing.Size(67, 21);
            this.dtEnd01.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "~";
            // 
            // btnRun01
            // 
            this.btnRun01.Location = new System.Drawing.Point(375, 6);
            this.btnRun01.Name = "btnRun01";
            this.btnRun01.Size = new System.Drawing.Size(75, 23);
            this.btnRun01.TabIndex = 4;
            this.btnRun01.Text = "시작";
            this.btnRun01.UseVisualStyleBackColor = true;
            this.btnRun01.Click += new System.EventHandler(this.btnRun01_Click);
            // 
            // btnDtStr01Dn
            // 
            this.btnDtStr01Dn.Location = new System.Drawing.Point(74, 6);
            this.btnDtStr01Dn.Name = "btnDtStr01Dn";
            this.btnDtStr01Dn.Size = new System.Drawing.Size(25, 21);
            this.btnDtStr01Dn.TabIndex = 3;
            this.btnDtStr01Dn.Text = "▼";
            this.btnDtStr01Dn.UseVisualStyleBackColor = true;
            this.btnDtStr01Dn.Click += new System.EventHandler(this.btnDtStr01Dn_Click);
            // 
            // btnDtStr01Up
            // 
            this.btnDtStr01Up.Location = new System.Drawing.Point(167, 6);
            this.btnDtStr01Up.Name = "btnDtStr01Up";
            this.btnDtStr01Up.Size = new System.Drawing.Size(25, 21);
            this.btnDtStr01Up.TabIndex = 2;
            this.btnDtStr01Up.Text = "▲";
            this.btnDtStr01Up.UseVisualStyleBackColor = true;
            this.btnDtStr01Up.Click += new System.EventHandler(this.btnDtStr01Up_Click);
            // 
            // dtStr01
            // 
            this.dtStr01.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStr01.Location = new System.Drawing.Point(99, 6);
            this.dtStr01.Name = "dtStr01";
            this.dtStr01.Size = new System.Drawing.Size(67, 21);
            this.dtStr01.TabIndex = 1;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(5, 12);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(29, 12);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "기간";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(486, 418);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtLog);
            this.panel1.Controls.Add(this.btnClearLog);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(503, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 444);
            this.panel1.TabIndex = 1;
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(0, 23);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(294, 421);
            this.txtLog.TabIndex = 2;
            this.txtLog.Text = "";
            // 
            // btnClearLog
            // 
            this.btnClearLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClearLog.Location = new System.Drawing.Point(0, 0);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(294, 23);
            this.btnClearLog.TabIndex = 0;
            this.btnClearLog.Text = "clear";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // lblRankUaTypeCount
            // 
            this.lblRankUaTypeCount.AutoSize = true;
            this.lblRankUaTypeCount.Location = new System.Drawing.Point(6, 73);
            this.lblRankUaTypeCount.Name = "lblRankUaTypeCount";
            this.lblRankUaTypeCount.Size = new System.Drawing.Size(38, 12);
            this.lblRankUaTypeCount.TabIndex = 13;
            this.lblRankUaTypeCount.Text = "label3";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form_Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnDtStr01Dn;
        private System.Windows.Forms.Button btnDtStr01Up;
        private System.Windows.Forms.DateTimePicker dtStr01;
        private System.Windows.Forms.Button btnRun01;
        private System.Windows.Forms.Button btnDtEnd01Dn;
        private System.Windows.Forms.Button btnDtEnd01Up;
        private System.Windows.Forms.DateTimePicker dtEnd01;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSidoCount;
        private System.Windows.Forms.Label lblSigunguCount;
        private System.Windows.Forms.CheckBox chkShutDown;
        private System.Windows.Forms.ComboBox cbxDt01Type;
        private System.Windows.Forms.Label lblRankUaTypeCount;
    }
}

