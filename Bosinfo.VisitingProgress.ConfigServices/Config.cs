using Bosinfo.VisitingProgress.Enums.Entity;
using Bosinfo.VisitingProgress.LocalDB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bosinfo.VisitingProgress.ConfigServices
{
    public class Config
    {
        /// <summary>
        /// 讀取configAPPSettings
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConfig(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// 讀取config連線
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConn(string key)
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings[key].ToString();
        }

        /// <summary>
        /// COM Port
        /// </summary>
        public static string COMPort
        {
            get
            {
                return SystemConfigService.GetSystemConfig(SystemConfigType.COMPort)?.Value ?? "";
            }
        }

        /// <summary>
        /// 科別代碼
        /// </summary>
        public static string ClinicCode
        {
            get
            {
                return SystemConfigService.GetSystemConfig(SystemConfigType.科別代碼)?.Value ?? "";
            }
        }

        /// <summary>
        /// 科別名稱
        /// </summary>
        public static string ClinicName
        {
            get
            {
                return SystemConfigService.GetSystemConfig(SystemConfigType.科別代碼)?.Value ?? "";
            }
        }


        /// <summary>
        /// 醫師代碼
        /// </summary>
        public static string DoctorCode
        {
            get
            {
                return SystemConfigService.GetSystemConfig(SystemConfigType.醫師代碼)?.Value ?? "";
            }
        }

        /// <summary>
        /// 醫師姓名
        /// </summary>
        public static string DoctorName
        {
            get
            {
                return SystemConfigService.GetSystemConfig(SystemConfigType.醫師姓名)?.Value ?? "";
            }
        }


        /// <summary>
        /// 開機自動執行
        /// </summary>
        public static string AutoStart
        {
            get
            {
                return SystemConfigService.GetSystemConfig(SystemConfigType.開機自動執行)?.Value ?? "";
            }
        }

        public static string MorningTime
        {
            get
            {
                return GetConfig("MorningTime");
            }
        }

        public static string AfternoonTime
        {
            get
            {
                return GetConfig("AfternoonTime");
            }
        }

        public static string NightTime
        {
            get
            {
                return GetConfig("NightTime");
            }
        }

        public static TimePeriod TimePeriod
        {
            get
            {
                if (Convert.ToDateTime(MorningTime) <= DateTime.Now && Convert.ToDateTime(AfternoonTime) > DateTime.Now)
                {
                    return TimePeriod.上午;
                }
                else if (Convert.ToDateTime(AfternoonTime) <= DateTime.Now && Convert.ToDateTime(NightTime) > DateTime.Now)
                {
                    return TimePeriod.下午;
                }
                else
                {
                    return TimePeriod.晚上;
                }
            }
        }

        public static int CompaniesCode
        {
            get
            {
                var x = GetConfig("CompaniesCode");
                return (int)UtilityTools.ToolLibs.GetEnum<Enums.API.Companies>(x);
            }
        }


        public static string ApiUrl
        {
            get
            {
                return GetConfig("ApiBaseUrl");
            }
        }
    }
}
