using Bosinfo.VisitingProgress.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Bosinfo.VisitingProgress.LocalDB.Entity
{
    public class LocalDBContext:DbContext
    {
        public LocalDBContext() : base("name=LocalDBContext")
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory;
            string DataBaseName = Database.Connection.ConnectionString.Replace("Data Source=", "");


            string savePath = $@"{path}Data\";
            string sourcePath = $@"{path}Data\{DataBaseName}";
            string saveFilePath = $@"{savePath}{DataBaseName}";

            string versionFilePath = $@"{savePath}\{FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion.ToString()}.txt";

            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            if (!File.Exists(versionFilePath))
            {
               

                if (!File.Exists(saveFilePath))
                {
                    File.Copy(sourcePath, saveFilePath);
                }

                File.Create(versionFilePath);
            }


            string dataBasePath = $@"Data Source={saveFilePath}";

            Database.Connection.ConnectionString = dataBasePath;

            //Disable initializer
            Database.SetInitializer<LocalDBContext>(null);

        }

        public DbSet<SystemConfig> SystemConfigs { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<ClinicRoom> ClinicRooms { get; set; }
    }
}
