using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bosinfo.VisitingProgress.Models.Entity
{
    public class SystemConfig
    {
        /// <summary>
        /// 系統參數
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 系統設定代碼
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 系統設定名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 數值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 建立日期
        /// </summary>
        public DateTime? CreatedTime { get; set; }

        /// <summary>
        /// 建立者
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// 最後異動日期
        /// </summary>
        public DateTime? LastModifiedTime { get; set; }

        /// <summary>
        /// 異動者
        /// </summary>
        public string LastModifiedBy { get; set; }
    }
}
