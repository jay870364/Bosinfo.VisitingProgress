using Bosinfo.VisitingProgress.Enums.Entity;
using Bosinfo.VisitingProgress.UtilityTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bosinfo.VisitingProgress.Models.Utilitys
{
    public class ComboData
    {
        public string Display { get; set; }
        public string Value { get; set; }

        public ComboData(string text, string value)
        {
            Display = text;
            Value = value;
        }

        /// <summary>
        /// 將診別轉換成ComboData
        /// </summary>
        /// <returns></returns>
        public static List<ComboData> TimePeriodSettingData()
        {
            var timePeriodTypes = Enum.GetValues(typeof(TimePeriod)).Cast<TimePeriod>().ToList();
            List<ComboData> comboData = new List<ComboData>();
            foreach (var c in timePeriodTypes)
            {
                comboData.Add(new ComboData(c.ToString(), ((int)c).ToString()));
            }

            return comboData;
        }
    }

    public class ComboEnumsData
    {
        public string Display { get; set; }
        public int Value { get; set; }

        public ComboEnumsData(string text, int value)
        {
            Display = text;
            Value = value;
        }


        public static List<ComboEnumsData> CounerClinicSettingData()
        {
            var clinicStatusTypes = Enum.GetValues(typeof(TimePeriod)).Cast<TimePeriod>().ToList();
            List<ComboEnumsData> comboData = new List<ComboEnumsData>();
            foreach (var c in clinicStatusTypes)
            {
                comboData.Add(new ComboEnumsData(ToolLibs.GetEnumDescription(c), (int)c));
            }

            return comboData;
        }
    }
}
