using Bosinfo.VisitingProgress.Enums.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bosinfo.VisitingProgress.Models.API
{
    public class WebRegJsonResult : JsonResult
    {
        public string Code { get; set; }

        /// <summary>
        /// 是否成功有效
        /// </summary>
        public bool IsEffective
        {
            get
            {
                try
                {
                    var result    = int.Parse(Code);

                    MessageCodeType codeType = (MessageCodeType)result;

                    if (codeType == MessageCodeType.成功)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
