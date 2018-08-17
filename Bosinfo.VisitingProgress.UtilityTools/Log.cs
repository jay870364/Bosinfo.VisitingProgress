using Newtonsoft.Json;
using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bosinfo.VisitingProgress.UtilityTools
{
    public class Log
    {
        public static NLog.Logger log;

        public Log()
        {
            if (log == null)
            {
                // Step 1. Create configuration object
                LoggingConfiguration logConfig = new LoggingConfiguration();

                // Step 2. Create targets and add them to the configuration

                FileTarget fileTarget = new FileTarget();
                logConfig.AddTarget("file", fileTarget);

                // Step 3. Set target properties

                //fileTarget.FileName = "${basedir}/${date}_log.txt";
                fileTarget.Layout = "${longdate} ${uppercase:${level}} ${message}";
                fileTarget.Encoding = Encoding.UTF8;

                fileTarget.FileName = "${basedir}/logs/log.log";
                fileTarget.ArchiveFileName = "${basedir}/logs/archives/log.{#}.log";

                fileTarget.ArchiveEvery = FileArchivePeriod.Day;
                fileTarget.ArchiveNumbering = ArchiveNumberingMode.Date;
                fileTarget.ArchiveDateFormat = "yyyyMMdd";
                fileTarget.MaxArchiveFiles = 30;

                // Step 4. Define rules

                LoggingRule rule = new LoggingRule("*", LogLevel.Trace, fileTarget);
                logConfig.LoggingRules.Add(rule);

                //if (Config.GetIsOpenLogForm())
                if (false)
                {
                    RichTextBoxTarget richTextBoxInfoTarget = new RichTextBoxTarget();
                    richTextBoxInfoTarget.Name = "info";
                    richTextBoxInfoTarget.AutoScroll = true;
                    richTextBoxInfoTarget.MaxLines = 10000;
                    richTextBoxInfoTarget.FormName = "LogForm";
                    richTextBoxInfoTarget.ToolWindow = true;
                    richTextBoxInfoTarget.ControlName = "richTextBoxInfo";
                    richTextBoxInfoTarget.UseDefaultRowColoringRules = true;
                    richTextBoxInfoTarget.Layout = "${longdate} ${uppercase:${level}} ${message}";
                    logConfig.AddTarget("richTextBoxInfoTarget", richTextBoxInfoTarget);

                    RichTextBoxTarget richTextBoxTraceTarget = new RichTextBoxTarget();
                    richTextBoxTraceTarget.Name = "trace";
                    richTextBoxTraceTarget.AutoScroll = true;
                    richTextBoxTraceTarget.MaxLines = 10000;
                    richTextBoxTraceTarget.FormName = "LogForm";
                    richTextBoxTraceTarget.ToolWindow = true;
                    richTextBoxTraceTarget.ControlName = "richTextBoxTrace";
                    richTextBoxTraceTarget.UseDefaultRowColoringRules = true;
                    richTextBoxTraceTarget.Layout = "${longdate} ${uppercase:${level}} ${message}";
                    logConfig.AddTarget("richTextBoxTraceTarget", richTextBoxTraceTarget);

                    rule = new LoggingRule("*", LogLevel.Debug, richTextBoxInfoTarget);
                    logConfig.LoggingRules.Add(rule);

                    rule = new LoggingRule("*", LogLevel.Trace, LogLevel.Trace, richTextBoxTraceTarget);
                    logConfig.LoggingRules.Add(rule);
                }

                // Step 5. Activate the configuration
                LogManager.Configuration = logConfig;

                log = LogManager.GetLogger("Example");

                //log = NLog.LogManager.GetCurrentClassLogger();
            }
        }

        public void Trace(string message)
        {
            Trace(message, null);
        }

        public void Trace(string message, object obj)
        {
            string msg = string.Empty;

            if (obj != null)
            {
                msg = $"{message} 資料：{JsonConvert.SerializeObject(obj)}";
            }
            else
            {
                msg = $"{message}";
            }

            msg += System.Environment.NewLine;
            msg += "--------------------------------------------";
            msg += System.Environment.NewLine;

            log.Trace(msg);

            System.Diagnostics.Debug.WriteLine(msg);
        }

        public void Error(string message)
        {
            log.Error(message);
        }

        public void Error(string message, object obj)
        {
            string msg = string.Empty;

            if (obj != null)
            {
                msg = $"{message} 資料：{JsonConvert.SerializeObject(obj)}";
            }
            else
            {
                msg = $"{message}";
            }

            log.Error(msg);

            System.Diagnostics.Debug.WriteLine($"{DateTime.Now}:{msg}");
        }

        public void Warn(string message)
        {
            log.Warn(message);
        }

        public void Info(string message)
        {
            Info(message, null);
        }

        public void Info(string message, object obj)
        {
            string msg = string.Empty;

            if (obj != null)
            {
                msg = $"{message} 資料：{JsonConvert.SerializeObject(obj)}";
            }
            else
            {
                msg = $"{message}";
            }

            log.Info(msg);

            System.Diagnostics.Debug.WriteLine($"{DateTime.Now}:{msg}");
        }
    }
}
