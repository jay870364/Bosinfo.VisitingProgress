using Bosinfo.VisitingProgress.ConfigServices;
using Bosinfo.VisitingProgress.DataServices;
using Bosinfo.VisitingProgress.LocalDB.Entity;
using Bosinfo.VisitingProgress.Models.Utilitys;
using Bosinfo.VisitingProgress.UtilityTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bosinfo.VisitingProgress
{
    public partial class VisitingProgressForm : Base
    {
        //


        public VisitingProgressForm()
        {
            InitializeComponent();


            //初始化LocalDB資料
            DBInitial();

            InitialCOMPort();
            InitialComboBoxClinic();
            InitialComboBoxDoctor();
            InitialComboBoxTimePeriod();

            ListenerSwitchStatus = false;
            if (false)
            {
                SwitchListen();
            }

        }

        /// <summary>
        /// 呼叫 初始化DB 的method
        /// </summary>
        private void DBInitial()
        {

            log.Info($"資料庫初始化...");
            try
            {
                var apiResult = new DataServices.DataServices().GetDataFromAPI();

                ClinicRoomService.ClearClinic();

                DoctorService.ClearDoctor();

                SystemConfigService.Init();

                ClinicRoomService.Init(apiResult.Result.ClinicRoom);

                DoctorService.Init(apiResult.Result.Doctor);
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }

            log.Info($"資料庫初始化完成...");

        }

        private void VisitingProgressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void InitialCOMPort()
        {

            Dictionary<string, string> data = new Dictionary<string, string>();
            string[] ports = SerialPort.GetPortNames();

            data.Add("請選擇", "");

            foreach (var port in ports)
            {
                data.Add(port, port);
            }

            this.comboBoxCOMPort.DisplayMember = "Key";
            this.comboBoxCOMPort.ValueMember = "Value";
            this.comboBoxCOMPort.DataSource = data.ToList();
            this.comboBoxCOMPort.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxCOMPort.SelectedValue = Config.COMPort;
            //this.comboBoxCOMPort.SelectedValue = ConfigServices.Config.COMPort;

        }

        private void InitialComboBoxClinic()
        {

            var data = from clinicData in ClinicRoomService.GetAllClinicToList()
                       select new ComboData(clinicData.Name.ToString(), clinicData.Code.ToString());

            var dataTypeList = data.ToList();

            dataTypeList.Insert(0, new ComboData("請選擇", ""));

            this.comboBoxClinic.DisplayMember = "Display";
            this.comboBoxClinic.ValueMember = "Value";
            this.comboBoxClinic.DataSource = dataTypeList;
            this.comboBoxClinic.DropDownStyle = ComboBoxStyle.DropDownList;
            //this.comboBoxClinic.SelectedValue = ConfigServices.Config.ClinicName;

            this.txtCLinic.Text = Config.ClinicName;

        }

        private void InitialComboBoxDoctor()
        {

            var data = from doctorData in DoctorService.GetAllDoctorToList()
                       select new ComboData(doctorData.Name.ToString(), doctorData.Code.ToString());

            var dataTypeList = data.ToList();

            dataTypeList.Insert(0, new ComboData("請選擇", ""));

            this.comboBoxDoctor.DisplayMember = "Display";
            this.comboBoxDoctor.ValueMember = "Value";
            this.comboBoxDoctor.DataSource = dataTypeList;
            this.comboBoxDoctor.DropDownStyle = ComboBoxStyle.DropDownList;
            //this.comboBoxDoctor.SelectedValue = ConfigServices.Config.DoctorName;
            this.txtDoctor.Text = Config.DoctorName;

        }

        private void InitialComboBoxTimePeriod()
        {
            var data = Models.Utilitys.ComboData.TimePeriodSettingData();

            data.Insert(0, new ComboData("請選擇", ""));

            this.comboBoxTimePeriod.DisplayMember = "Display";
            this.comboBoxTimePeriod.ValueMember = "Value";
            this.comboBoxTimePeriod.DataSource = data;
            this.comboBoxTimePeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            TimePeriVoidCheck();
            //this.comboBoxDoctor.SelectedValue = ConfigServices.Config.DoctorName;

        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            var message = SettingChecking();
            if (string.IsNullOrEmpty(SettingChecking()))
            {
                SwitchListen();
            }
            else
            {
                var caption = "警告";
                var button = MessageBoxButtons.OK;
                var icon = MessageBoxIcon.Error;
                Dialog(message, caption, button, icon);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SystemConfigSave())
            {
                MessageBox.Show("Succe");
            }
        }

        private void SwitchListen()
        {
            if (ListenerSwitchStatus)
            {
                btnSwitch.Text = "開診";
                btnSwitch.ForeColor = Color.Black;
                ListenerSwitchStatus = false;
                SettingLockSwitch();
                #region 註解的程式，不跳訊息
                //var message = "確定要停止監聽？";
                //var caption = "警告";
                //var button = MessageBoxButtons.OKCancel;
                //var icon = MessageBoxIcon.Question;

                //var diaResult = Dialog(message, caption, button, icon);
                //if (diaResult.Equals(DialogResult.OK))
                //{
                //    message = "停止監聽";
                //    caption = "警告";
                //    button = MessageBoxButtons.OK;
                //    icon = MessageBoxIcon.Information;
                //    Dialog(message, caption, button, icon);

                //btnSwitch.Text = "開診";
                //btnSwitch.ForeColor = Color.Black;
                //ListenerSwitchStatus = false;
                //SettingLockSwitch();
                //}
                //else
                //{

                //}
                #endregion
            }
            else
            {

                btnSwitch.Text = "休診";
                btnSwitch.ForeColor = Color.Red;
                SystemConfigSave();
                ListenerSwitchStatus = true;
                SettingLockSwitch();


            }
        }

        private void SettingLockSwitch()
        {
            #region Comboboxx
            comboBoxCOMPort.Enabled = !ListenerSwitchStatus;//Port
            comboBoxClinic.Enabled = !ListenerSwitchStatus;//診間
            comboBoxDoctor.Enabled = !ListenerSwitchStatus;//醫師姓名
            comboBoxTimePeriod.Enabled = !ListenerSwitchStatus;//診別
            #endregion

            #region TextBox
            txtCLinic.Enabled = !ListenerSwitchStatus;//診間
            txtDoctor.Enabled = !ListenerSwitchStatus;//醫師姓名
            #endregion

            #region CheckBox
            checkBoxAutoExcute.Enabled = !ListenerSwitchStatus;
            #endregion

            #region Button
            btnSave.Enabled = !ListenerSwitchStatus;
            #endregion
        }

        private string SettingChecking()
        {
            var message = string.Empty;

            if (comboBoxCOMPort.SelectedIndex.Equals(0))
            {
                message += "請選擇COM Port\n";
            }
            if (comboBoxClinic.SelectedIndex.Equals(0) || string.IsNullOrEmpty(txtCLinic.Text.Trim()))
            {
                message += "請選擇診間\n";
            }
            if (comboBoxDoctor.SelectedIndex.Equals(0) || string.IsNullOrEmpty(txtDoctor.Text.Trim()))
            {
                message += "請選擇醫師\n";
            }
            if (comboBoxTimePeriod.SelectedIndex.Equals(0))
            {
                message += "請選擇診別\n";
            }

            return message;
        }


        private bool SystemConfigSave()
        {
            var result = true;
            var message = SettingChecking();
            try
            {
                if (string.IsNullOrEmpty(message))
                {
                    var config = new Models.Entity.SystemConfig();

                    config.Code = (int)Enums.Entity.SystemConfigType.COMPort;
                    config.Value = comboBoxCOMPort.SelectedValue.ToString();
                    SystemConfigService.SaveSystemConfig(config);

                    config.Code = (int)Enums.Entity.SystemConfigType.科別代碼;
                    config.Value = comboBoxClinic.SelectedValue.ToString();
                    SystemConfigService.SaveSystemConfig(config);

                    config.Code = (int)Enums.Entity.SystemConfigType.醫師代碼;
                    config.Value = comboBoxClinic.SelectedValue.ToString();
                    SystemConfigService.SaveSystemConfig(config);
                    return result;
                }
                else
                {
                    result = false;
                    var caption = "警告";
                    var button = MessageBoxButtons.OK;
                    var icon = MessageBoxIcon.Error;
                    Dialog(message, caption, button, icon);
                    return result;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
                result = false;
                return result;
            }

        }

        private void TimePeriVoidCheck()
        {
            switch (ConfigServices.Config.TimePeriod)
            {
                case Enums.Entity.TimePeriod.上午:

                    comboBoxTimePeriod.SelectedIndex = ((int)Enums.Entity.TimePeriod.上午) - 1;
                    break;

                case Enums.Entity.TimePeriod.下午:

                    comboBoxTimePeriod.SelectedIndex = ((int)Enums.Entity.TimePeriod.下午) - 1;
                    break;

                case Enums.Entity.TimePeriod.晚上:

                    comboBoxTimePeriod.SelectedIndex = ((int)Enums.Entity.TimePeriod.晚上) - 1;
                    break;
            }
        }

        private DialogResult Dialog(string messageBoxText, string caption, MessageBoxButtons button, MessageBoxIcon icon)
        {
            DialogResult result = MessageBox.Show(messageBoxText, caption, button, icon);

            return result;
        }

        private void comboBoxClinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = comboBoxClinic.Text.Trim();
            txtCLinic.Text = text.Equals("請選擇") ? string.Empty : text;
        }

        private void comboBoxDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = comboBoxDoctor.Text.Trim();
            txtDoctor.Text = text.Equals("請選擇") ? string.Empty : text;
        }
    }
}
