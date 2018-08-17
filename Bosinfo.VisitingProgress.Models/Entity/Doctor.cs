using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bosinfo.VisitingProgress.Models.Entity
{
    public class Doctor
    {
        public int ID { get; set; }
        /// <summary>
        /// 醫師代碼
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 醫師姓名
        /// </summary>
        public string Name { get; set; }
    }
}
