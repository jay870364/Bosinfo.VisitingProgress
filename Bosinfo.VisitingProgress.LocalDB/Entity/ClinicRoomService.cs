using Bosinfo.VisitingProgress.LocalDB.Entity;
using Bosinfo.VisitingProgress.Models.Entity;
using Bosinfo.VisitingProgress.UtilityTools;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace Bosinfo.VisitingProgress.LocalDB.Entity
{
    public class ClinicRoomService
    {
        /// <summary>
        /// 建立初始化科別資訊
        /// </summary>
        /// <returns></returns>
        private static List<ClinicRoom> InitData()
        {
            List<ClinicRoom> list = new List<ClinicRoom>();

            ClinicRoom clinicRoom = new ClinicRoom
            {
                
                Code = "1",
                Name = "黑傑克診間"
            };
            list.Add(clinicRoom);

            return list;
        }

        /// <summary>
        /// 新增初始化科別資訊
        /// </summary>
        public static void Init(List<ClinicRoom> dataList)
        {
            using (var db = new LocalDBContext())
            {
                try
                {
                        db.ClinicRooms.AddRange(dataList);

                        db.SaveChanges();
                   
                }
                catch (DbEntityValidationException ex)
                {
                    new Log().Error(ex.ToString());
                }
            }
        }

        public static bool ClearClinic()
        {
            using (var db = new LocalDBContext())
            {
                db.Database.ExecuteSqlCommand("DELETE FROM ClinicRooms; update sqlite_sequence set seq = '0' where name = 'ClinicRooms'");
                return db.SaveChanges() > 0;
            }
        }


        /// <summary>
        /// 取得LocalDB
        /// </summary>
        /// <param name="clinic">科別資訊</param>
        /// <returns></returns>
        public static ClinicRoom GetClinic(ClinicRoom clinic)
        {
            using (var db = new LocalDBContext())
            {
                return db.ClinicRooms.Where(x => x.Code == clinic.Code).FirstOrDefault();
            }
        }

        /// <summary>
        /// 取得所有的Clinic
        /// </summary>
        /// <returns></returns>
        public static List<ClinicRoom> GetAllClinicToList()
        {
            using (var db = new LocalDBContext())
            {
                return db.ClinicRooms.ToList();
            }
        }

        /// <summary>
        /// 儲存LocalDB
        /// </summary>
        /// <param name="clinic">科別資訊</param>
        public static void SaveClinic(ClinicRoom clinic)
        {
            using (var db = new LocalDBContext())
            {
                var obj = db.ClinicRooms.Where(x => x.Code == clinic.Code).FirstOrDefault();

                obj.Name = clinic.Name;

                db.SaveChanges();
            }
        }
    }
}
