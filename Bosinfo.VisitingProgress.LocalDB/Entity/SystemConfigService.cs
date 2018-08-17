using Bosinfo.VisitingProgress.Enums.Entity;
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
    public class SystemConfigService
    {
        /// <summary>
        /// 建立初始化資料
        /// </summary>
        /// <returns></returns>
        private static List<SystemConfig> InitData()
        {
            List<SystemConfig> list = new List<SystemConfig>();


            SystemConfig config = new SystemConfig
            {
                Code = (int)SystemConfigType.COMPort,
                Name = SystemConfigType.COMPort.ToString(),
                Value = string.Empty,
                CreatedBy = "system",
                CreatedTime = DateTime.Now,
                LastModifiedBy = "system",
                LastModifiedTime = DateTime.Now
            };
            list.Add(config);

            config = new SystemConfig
            {
                Code = (int)SystemConfigType.科別代碼,
                Name = SystemConfigType.科別代碼.ToString(),
                Value = string.Empty,
                CreatedBy = "system",
                CreatedTime = DateTime.Now,
                LastModifiedBy = "system",
                LastModifiedTime = DateTime.Now
            };
            list.Add(config);

            config = new SystemConfig
            {
                Code = (int)SystemConfigType.科別名稱,
                Name = SystemConfigType.科別名稱.ToString(),
                Value = string.Empty,
                CreatedBy = "system",
                CreatedTime = DateTime.Now,
                LastModifiedBy = "system",
                LastModifiedTime = DateTime.Now
            };
            list.Add(config);

            config = new SystemConfig
            {
                Code = (int)SystemConfigType.醫師代碼,
                Name = SystemConfigType.醫師代碼.ToString(),
                Value = string.Empty,
                CreatedBy = "system",
                CreatedTime = DateTime.Now,
                LastModifiedBy = "system",
                LastModifiedTime = DateTime.Now
            };
            list.Add(config);

            config = new SystemConfig
            {
                Code = (int)SystemConfigType.醫師姓名,
                Name = SystemConfigType.醫師姓名.ToString(),
                Value = string.Empty,
                CreatedBy = "system",
                CreatedTime = DateTime.Now,
                LastModifiedBy = "system",
                LastModifiedTime = DateTime.Now
            };
            list.Add(config);

            config = new SystemConfig
            {
                Code = (int)SystemConfigType.開機自動執行,
                Name = SystemConfigType.開機自動執行.ToString(),
                Value = string.Empty,
                CreatedBy = "system",
                CreatedTime = DateTime.Now,
                LastModifiedBy = "system",
                LastModifiedTime = DateTime.Now
            };
            list.Add(config);

            return list;
        }

        /// <summary>
        /// 新增初始化資料
        /// </summary>
        public static void Init()
        {
            using (var db = new LocalDBContext())
            {
                try
                {
                    if (db.SystemConfigs.Count() == 0)
                    {

                        db.SystemConfigs.AddRange(InitData());

                        db.SaveChanges();
                    }
                    else
                    {
                        foreach (var obj in InitData())
                        {
                            //不存在的列舉新增
                            if (!db.SystemConfigs.Where(x => x.Code.Equals(obj.Code)).Any())
                            {
                                db.SystemConfigs.Add(obj);
                                db.SaveChanges();
                            }
                            else
                            {
                                //已存在更新
                                var dbData = db.SystemConfigs.Where(x => x.Code.Equals(obj.Code)).FirstOrDefault();
                                if (dbData != null)
                                {
                                    dbData.Name = obj.Name;
                                    dbData.LastModifiedTime = DateTime.Now;
                                    dbData.LastModifiedBy = "admin";
                                    db.SaveChanges();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    new Log().Error(ex.ToString());
                }
            }
        }

        /// <summary>
        /// 取得LocalDB
        /// </summary>
        /// <param name="systemConfigType">傳入所定義的列舉參數</param>
        /// <returns></returns>
        public static SystemConfig GetSystemConfig(SystemConfigType systemConfigType)
        {
            using (var db = new LocalDBContext())
            {
                return db.SystemConfigs.Where(x => x.Code == (int)systemConfigType).FirstOrDefault();
            }
        }

        /// <summary>
        /// 儲存LocalDB
        /// </summary>
        /// <param name="systemConfig">每次必定會儲存所有參數</param>
        public static void SaveSystemConfig(SystemConfig systemConfig)
        {
            using (var db = new LocalDBContext())
            {
                var obj = db.SystemConfigs.Where(x => x.Code == systemConfig.Code).FirstOrDefault();

                obj.Value = systemConfig.Value;

                db.SaveChanges();
            }
        }
    }
}
