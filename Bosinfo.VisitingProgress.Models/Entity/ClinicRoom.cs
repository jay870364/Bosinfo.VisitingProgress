using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bosinfo.VisitingProgress.Models.Entity
{
    public class ClinicRoom
    {
        public int ID { get; set; }
        /// <summary>
        /// 科別ID
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 科別名稱
        /// </summary>
        public string Name { get; set; }
    }
}
