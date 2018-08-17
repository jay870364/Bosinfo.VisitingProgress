using Bosinfo.VisitingProgress.ConfigServices;
using Bosinfo.VisitingProgress.Enums.API;
using Bosinfo.VisitingProgress.Models.API;
using Bosinfo.VisitingProgress.UtilityTools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;

namespace Bosinfo.VisitingProgress.DataServices
{
    public class DataServices
    {
        Log log = new Log();

        private string Url
        {
            get
            {
                return Config.ApiUrl;
            }
            set
            {
            }
        }

        private string GetData(string runUrl, NameValueCollection nc)
        {
            string result = string.Empty;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"輸出資料：");
            sb.AppendLine($"{runUrl}");


            foreach (string key in nc)
            {
                sb.AppendLine($"{key}={nc[key]}");
            }


            log.Trace(sb.ToString());

            using (var wc = new WebClient())
            {
                wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                byte[] bResult = wc.UploadValues(runUrl, nc);


                result = Encoding.UTF8.GetString(bResult);

            }

            sb = new StringBuilder();

            sb.AppendLine($"回傳資料：{result}");

            log.Trace(sb.ToString());

            return result;
        }

        public WebRegJsonResult GetDataFromAPI()
        {
            var result = new WebRegJsonResult();
            if (!string.IsNullOrWhiteSpace(this.Url))
            {
                try
                {
                    NameValueCollection nc = new NameValueCollection();

                    string runUrl = $"{this.Url}/ClinicAndDoctorInfo/GetClinicAndDoctorInfo";

                    nc["comp"] = Config.CompaniesCode.ToString();
                    
                    var resultJsonString = GetData(runUrl, nc);

                    result = JsonConvert.DeserializeObject<WebRegJsonResult>(resultJsonString);

                    if (result.Code == "1")
                    {
                        result.Code = ((int)MessageCodeType.成功).ToString();
                    }
                    else
                    {
                        result.Code = ((int)MessageCodeType.Web例外訊息).ToString();
                    }
                }
                catch (Exception ex)
                {
                    //string msg = BossinfoException.GetMessage(ex);

                    result = new WebRegJsonResult
                    {
                        Code = ((int)MessageCodeType.例外訊息).ToString(),
                        Message = ex.ToString()
                    };

                    log.Error($"更新看診進度錯誤：{""}");

                }
            }
            else
            {
                log.Warn("不執行 更新看診進度的API呼叫, 原因: 參數「CallClinicProgressRateUrl」 尚未設定");
            }
            return result;
        }

        /// <summary>
        /// 更新看診進度資訊
        /// </summary>
        /// <param name="progress"></param>
        /// <returns></returns>
        public WebRegJsonResult UpdateProgressInfo(Models.API.Progress progress)
        {
            var result = new WebRegJsonResult();
            if (!string.IsNullOrWhiteSpace(this.Url))
            {
                try
                {
                    NameValueCollection nc = new NameValueCollection();

                    string runUrl = $"{this.Url}/Vision/GetClinic";

                    nc["Chinno"] = progress.Chinno;
                    nc["VID"] = progress.RoomCode;
                    nc["RName"] = progress.RoomName;
                    nc["RDName"] = progress.DocName;
                    nc["Sec"] = progress.Sec;
                    nc["TTime"] = progress.CurrentNumber;
                    nc["RDate"] = progress.RDate;
                    nc["RList"] = progress.RList;
                    nc["ROpen"] = progress.ROpen;
                    nc["Source"] = "caller";

                    var resultJsonString = GetData(runUrl, nc);

                    result = JsonConvert.DeserializeObject<WebRegJsonResult>(resultJsonString);

                    if (result.Code == "0000")
                    {
                        result.Code = ((int)MessageCodeType.成功).ToString();
                    }
                    else
                    {
                        result.Code = ((int)MessageCodeType.Web例外訊息).ToString();
                    }
                }
                catch (Exception ex)
                {
                    //string msg = BossinfoException.GetMessage(ex);

                    result = new WebRegJsonResult
                    {
                        Code = ((int)MessageCodeType.例外訊息).ToString(),
                        Message = ex.ToString()
                    };

                    log.Error($"更新看診進度錯誤：{ex.ToString()}");

                }
            }
            else
            {
                log.Warn("不執行 更新看診進度的API呼叫, 原因: 參數「CallClinicProgressRateUrl」 尚未設定");
            }
            return result;
        }

    }
}
