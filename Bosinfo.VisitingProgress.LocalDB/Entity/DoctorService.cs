using Bosinfo.VisitingProgress.LocalDB.Entity;
using Bosinfo.VisitingProgress.Models.Entity;
using Bosinfo.VisitingProgress.UtilityTools;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace Bosinfo.VisitingProgress.LocalDB.Entity
{
    public class DoctorService
    {
        /// <summary>
        /// 建立初始化醫生資訊
        /// </summary>
        /// <returns></returns>
        private static List<Doctor> InitData()
        {
            List<Doctor> list = new List<Doctor>();

            Doctor doctor = new Doctor
            {
                Code = "1",
                Name = "BlackJack"
            };
            list.Add(doctor);

            return list;
        }

        /// <summary>
        /// 新增初始化醫生資訊
        /// </summary>
        public static void Init(List<Doctor> listData)
        {
            using (var db = new LocalDBContext())
            {
                try
                {
                    if (db.Doctors.Count() == 0)
                    {

                        db.Doctors.AddRange(listData);

                        db.SaveChanges();
                    }
                    else
                    {
                        //foreach (var obj in InitData())
                        //{
                        //    //不存在的列舉新增
                        //    if (!db.Doctor.Where(x => x.DoctorName.Equals(obj.DoctorName)).Any())
                        //    {
                        //        db.Doctor.Add(obj);
                        //        db.SaveChanges();
                        //    }
                        //    else
                        //    {
                        //        ////已存在更新
                        //        //var dbData = db.Doctor.Where(x => x.ID.Equals(obj.ID)).FirstOrDefault();
                        //        //if (dbData != null)
                        //        //{
                        //        //    dbData.DoctorName = obj.DoctorName;
                        //        //    dbData.LastModifiedTime = DateTime.Now;
                        //        //    dbData.LastModifiedBy = "admin";
                        //        //    db.SaveChanges();
                        //        //}
                        //    }
                        //}
                    }
                }
                catch (DbEntityValidationException ex)
                {
                    new Log().Error(ex.ToString());
                }
            }
        }

        public static bool ClearDoctor()
        {
            using (var db = new LocalDBContext())
            {
                db.Database.ExecuteSqlCommand("DELETE FROM Doctors; update sqlite_sequence set seq = '0' where name = 'Doctors'");
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 取得LocalDB
        /// </summary>
        /// <param name="doctor">醫生資訊</param>
        /// <returns></returns>
        public static Doctor GetSystemDoctor(Doctor doctor)
        {
            using (var db = new LocalDBContext())
            {
                return db.Doctors.Where(x => x.Name == doctor.Name).FirstOrDefault();
            }
        }

        public static List<Doctor> GetAllDoctorToList()
        {
            using (var db = new LocalDBContext())
            {
                return db.Doctors.ToList();
            }
        }
        /// <summary>
        /// 儲存LocalDB
        /// </summary>
        /// <param name="doctor">醫生資訊</param>
        public static void SaveDoctor(Doctor doctor)
        {
            using (var db = new LocalDBContext())
            {
                var obj = db.Doctors.Where(x => x.Name == doctor.Name).FirstOrDefault();

                obj.Name = doctor.Name;

                db.SaveChanges();
            }
        }
    }
}
