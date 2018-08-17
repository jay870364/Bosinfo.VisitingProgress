namespace Bosinfo.VisitingProgress
{
    partial class VisitingProgressForm
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
            this.gbLEDInfo = new System.Windows.Forms.GroupBox();
            this.checkBoxAutoExcute = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSwitch = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCOMPort = new System.Windows.Forms.Label();
            this.lblClinic = new System.Windows.Forms.Label();
            this.comboBoxClinic = new System.Windows.Forms.ComboBox();
            this.comboBoxDoctor = new System.Windows.Forms.ComboBox();
            this.lblTimePeriod = new System.Windows.Forms.Label();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.txtCLinic = new System.Windows.Forms.TextBox();
            this.txtDoctor = new System.Windows.Forms.TextBox();
            this.comboBoxCOMPort = new System.Windows.Forms.ComboBox();
            this.comboBoxTimePeriod = new System.Windows.Forms.ComboBox();
            this.gbLEDInfo.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLEDInfo
            // 
            this.gbLEDInfo.Controls.Add(this.checkBoxAutoExcute);
            this.gbLEDInfo.Controls.Add(this.btnSave);
            this.gbLEDInfo.Controls.Add(this.btnSwitch);
            this.gbLEDInfo.Controls.Add(this.tableLayoutPanel1);
            this.gbLEDInfo.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gbLEDInfo.Location = new System.Drawing.Point(12, 12);
            this.gbLEDInfo.Name = "gbLEDInfo";
            this.gbLEDInfo.Size = new System.Drawing.Size(485, 191);
            this.gbLEDInfo.TabIndex = 0;
            this.gbLEDInfo.TabStop = false;
            this.gbLEDInfo.Text = "LED資訊";
            // 
            // checkBoxAutoExcute
            // 
            this.checkBoxAutoExcute.AutoSize = true;
            this.checkBoxAutoExcute.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBoxAutoExcute.Location = new System.Drawing.Point(34, 158);
            this.checkBoxAutoExcute.Name = "checkBoxAutoExcute";
            this.checkBoxAutoExcute.Size = new System.Drawing.Size(102, 16);
            this.checkBoxAutoExcute.TabIndex = 7;
            this.checkBoxAutoExcute.Text = "開幾自動啟動";
            this.checkBoxAutoExcute.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(277, 154);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "儲存設定";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSwitch
            // 
            this.btnSwitch.Location = new System.Drawing.Point(383, 154);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(75, 23);
            this.btnSwitch.TabIndex = 0;
            this.btnSwitch.Text = "啟動";
            this.btnSwitch.UseVisualStyleBackColor = true;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.lblCOMPort, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblClinic, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxClinic, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxDoctor, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblTimePeriod, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblDoctor, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtCLinic, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtDoctor, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxCOMPort, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxTimePeriod, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(18, 30);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(337, 112);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // lblCOMPort
            // 
            this.lblCOMPort.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblCOMPort.AutoSize = true;
            this.lblCOMPort.BackColor = System.Drawing.SystemColors.Control;
            this.lblCOMPort.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblCOMPort.Location = new System.Drawing.Point(3, 7);
            this.lblCOMPort.Name = "lblCOMPort";
            this.lblCOMPort.Size = new System.Drawing.Size(61, 12);
            this.lblCOMPort.TabIndex = 0;
            this.lblCOMPort.Text = "COM Port";
            // 
            // lblClinic
            // 
            this.lblClinic.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblClinic.AutoSize = true;
            this.lblClinic.BackColor = System.Drawing.SystemColors.Control;
            this.lblClinic.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblClinic.Location = new System.Drawing.Point(33, 34);
            this.lblClinic.Name = "lblClinic";
            this.lblClinic.Size = new System.Drawing.Size(31, 12);
            this.lblClinic.TabIndex = 0;
            this.lblClinic.Text = "診間";
            // 
            // comboBoxClinic
            // 
            this.comboBoxClinic.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxClinic.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBoxClinic.FormattingEnabled = true;
            this.comboBoxClinic.Location = new System.Drawing.Point(204, 30);
            this.comboBoxClinic.Name = "comboBoxClinic";
            this.comboBoxClinic.Size = new System.Drawing.Size(130, 20);
            this.comboBoxClinic.TabIndex = 2;
            this.comboBoxClinic.SelectedIndexChanged += new System.EventHandler(this.comboBoxClinic_SelectedIndexChanged);
            // 
            // comboBoxDoctor
            // 
            this.comboBoxDoctor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxDoctor.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBoxDoctor.FormattingEnabled = true;
            this.comboBoxDoctor.Location = new System.Drawing.Point(204, 58);
            this.comboBoxDoctor.Name = "comboBoxDoctor";
            this.comboBoxDoctor.Size = new System.Drawing.Size(130, 20);
            this.comboBoxDoctor.TabIndex = 3;
            this.comboBoxDoctor.SelectedIndexChanged += new System.EventHandler(this.comboBoxDoctor_SelectedIndexChanged);
            // 
            // lblTimePeriod
            // 
            this.lblTimePeriod.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTimePeriod.AutoSize = true;
            this.lblTimePeriod.BackColor = System.Drawing.SystemColors.Control;
            this.lblTimePeriod.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTimePeriod.Location = new System.Drawing.Point(33, 91);
            this.lblTimePeriod.Name = "lblTimePeriod";
            this.lblTimePeriod.Size = new System.Drawing.Size(31, 12);
            this.lblTimePeriod.TabIndex = 0;
            this.lblTimePeriod.Text = "診別";
            // 
            // lblDoctor
            // 
            this.lblDoctor.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.BackColor = System.Drawing.SystemColors.Control;
            this.lblDoctor.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblDoctor.Location = new System.Drawing.Point(33, 62);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(31, 12);
            this.lblDoctor.TabIndex = 0;
            this.lblDoctor.Text = "醫師";
            // 
            // txtCLinic
            // 
            this.txtCLinic.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCLinic.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtCLinic.Location = new System.Drawing.Point(70, 29);
            this.txtCLinic.Name = "txtCLinic";
            this.txtCLinic.Size = new System.Drawing.Size(128, 22);
            this.txtCLinic.TabIndex = 5;
            // 
            // txtDoctor
            // 
            this.txtDoctor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDoctor.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtDoctor.Location = new System.Drawing.Point(70, 57);
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.Size = new System.Drawing.Size(128, 22);
            this.txtDoctor.TabIndex = 6;
            // 
            // comboBoxCOMPort
            // 
            this.comboBoxCOMPort.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.comboBoxCOMPort, 2);
            this.comboBoxCOMPort.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBoxCOMPort.FormattingEnabled = true;
            this.comboBoxCOMPort.Location = new System.Drawing.Point(70, 3);
            this.comboBoxCOMPort.Name = "comboBoxCOMPort";
            this.comboBoxCOMPort.Size = new System.Drawing.Size(264, 20);
            this.comboBoxCOMPort.TabIndex = 999;
            // 
            // comboBoxTimePeriod
            // 
            this.comboBoxTimePeriod.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.comboBoxTimePeriod, 2);
            this.comboBoxTimePeriod.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBoxTimePeriod.FormattingEnabled = true;
            this.comboBoxTimePeriod.Location = new System.Drawing.Point(70, 87);
            this.comboBoxTimePeriod.Name = "comboBoxTimePeriod";
            this.comboBoxTimePeriod.Size = new System.Drawing.Size(264, 20);
            this.comboBoxTimePeriod.TabIndex = 4;
            // 
            // VisitingProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 212);
            this.Controls.Add(this.gbLEDInfo);
            this.Name = "VisitingProgressForm";
            this.Text = "VisitingProgressForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VisitingProgressForm_FormClosing);
            this.gbLEDInfo.ResumeLayout(false);
            this.gbLEDInfo.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLEDInfo;
        private System.Windows.Forms.ComboBox comboBoxTimePeriod;
        private System.Windows.Forms.ComboBox comboBoxDoctor;
        private System.Windows.Forms.ComboBox comboBoxClinic;
        private System.Windows.Forms.ComboBox comboBoxCOMPort;
        private System.Windows.Forms.Label lblTimePeriod;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.Label lblClinic;
        private System.Windows.Forms.Label lblCOMPort;
        private System.Windows.Forms.CheckBox checkBoxAutoExcute;
        private System.Windows.Forms.Button btnSwitch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtCLinic;
        private System.Windows.Forms.TextBox txtDoctor;
        private System.Windows.Forms.Button btnSave;
    }
}