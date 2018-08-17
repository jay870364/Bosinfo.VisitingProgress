using Bosinfo.VisitingProgress.UtilityTools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Bosinfo.VisitingProgress
{
    static class Program
    {

       

        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {


            try
            {
                Application.ThreadException += new ThreadExceptionEventHandler(UIThreadException);
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //監聽建立
                AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                //宣告變數，用來判斷是否重複開啟應用程式
                bool isNotDuplicateApplication = false;

                // 第一關：在同目錄執行相同程式的情況下不允許重複執行
                string mutexName1 = Process.GetCurrentProcess().MainModule.FileName
                            .Replace(Path.DirectorySeparatorChar, '_');

                //using (Mutex mutex = new Mutex(true, Application.ProductName, out isNotDuplicateApplication))
                using (Mutex mutex = new Mutex(true, "Global\\" + mutexName1, out isNotDuplicateApplication))
                {
                    //判斷是否重複，不重複則執行應用程式，重複則關閉應用程式
                    if (isNotDuplicateApplication)
                    {

                        Log log = new Log();
                        log.Info("test");
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);

                        RunAdmin();

                    }
                    else
                    {
                        Application.Exit();
                    }
                }

            }
            catch (Exception ex)
            {
                Log log = new Log();

                log.Error($"系統發生錯誤：", ex);

                MessageBox.Show($"系統發生錯誤：{ex.ToString()}", "系統訊息", MessageBoxButtons.OK);

                Application.Exit();

                return;
            }
        }

        #region Global Exception

        private static void UIThreadException(object sender, ThreadExceptionEventArgs t)
        {
            try
            {
                string errorMsg = "應用程式異常 : \n\n" + t.Exception.Message + Environment.NewLine + t.Exception.StackTrace;

                Log log = new Log();

                log.Error($"{errorMsg}");


                MessageBox.Show(errorMsg);
            }
            catch
            {
                MessageBox.Show("應用程式異常，程式即將退出!");
            }
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = (Exception)e.ExceptionObject;
                string errorMsg = "應用程式異常 : \n\n" + ex.Message + Environment.NewLine + ex.StackTrace;

                Log log = new Log();

                log.Error($"{errorMsg}");

                MessageBox.Show(errorMsg);
            }
            catch
            {
                MessageBox.Show("應用程式異常，程式即將退出!");
            }
        }

        #endregion

        private static void RunAdmin()
        {

            /**
             * 當前用户是管理員的時候，直接啟動應用進程
             * 如果不是管理員，則使用啟動對象啟動進程，以確保使用管理員身份運行
             */
            //獲得當前登錄的Windows用户標示
            System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
            //判斷當前登錄用户是否為管理員
            if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
            {
                //如果是管理員，則直接運行
                Application.Run(new VisitingProgressForm());
            }
            else
            {
                //創建啟動對象
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.UseShellExecute = true;
                startInfo.WorkingDirectory = Environment.CurrentDirectory;
                startInfo.FileName = Application.ExecutablePath;
                //設置啟動動作,確保以管理員身份運行
                startInfo.Verb = "runas";
                try
                {
                    Process.Start(startInfo);
                }
                catch
                {
                    return;
                }
                //退出
                Application.Exit();
            }
        }

    }
}
