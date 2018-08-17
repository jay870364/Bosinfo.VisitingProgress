using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bosinfo.VisitingProgress.Models.API
{
    public class Progress
    {
        /// <summary>
        /// 診間代碼
        /// </summary>
        public string RoomCode { get; set; }

        /// <summary>
        /// 診間名稱
        /// </summary>
        public string RoomName { get; set; }

        /// <summary>
        /// 醫師代碼
        /// </summary>
        //public string DocCode { get; set; }

        /// <summary>
        /// 醫師名稱
        /// </summary>
        public string DocName { get; set; }

        /// <summary>
        /// 時段: S:早上, T:下午, U:晚上
        /// </summary>
        public string Sec { get; set; }

        /// <summary>
        /// 目前叫號
        /// </summary>
        public string CurrentNumber { get; set; }

        /// <summary>
        /// 看診日期 yyyy/MM/dd
        /// </summary>
        public string RDate { get; set; }

        /// <summary>
        /// 等待人數 -1: 表示不存在, 將不會顯示
        /// </summary>
        public string RList { get; set; }

        /// <summary>
        /// 是否顯示, 1:顯示, 0:不顯示
        /// </summary>
        public string ROpen { get; set; }

        /// <summary>
        /// 醫師機構代碼
        /// </summary>
        public string Chinno { get; set; }
    }
}
