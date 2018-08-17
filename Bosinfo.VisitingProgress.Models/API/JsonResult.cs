using Bosinfo.VisitingProgress.Enums.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bosinfo.VisitingProgress.Models.API
{
    /// <summary>
    /// JSON結果
    /// </summary>
    public class JsonResult
    {
        /// <summary>
        /// 結果
        /// </summary>
        public Result Result { get; set; }
        /// <summary>
        /// 訊息
        /// </summary>
        public string Message { get; set; }

       


    }
}
