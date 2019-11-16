using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace CH3mculator.Shared.Logic.Logging
{
    public sealed class Logger
    {
        #region Singleton Implementation
        private static Logger _instance = null;
        private static readonly object padlock = new object();

        private Logger() { }

        public static Logger Log
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                    return _instance;
                }
            }
        }
        #endregion

        #region Properties / Constants
        const string LOG_FILE_NAME = "log.txt";
        const string EXCEPTION_FOLDER_NAME = "Exceptions";
        public string LogPath { get; } = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        public bool IsTraceLogEnabled { get; } = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("EnableTraceLog")); 
        #endregion

        public void Info(string message, [CallerMemberName] string methodName = "", [CallerLineNumber] int lineNumber = -1)
            => WriteLog(string.Concat(methodName, ":", lineNumber, " -> ", message));

        public void Warning(string message, [CallerMemberName] string methodName = "", [CallerLineNumber] int lineNumber = -1)
            => WriteLog(string.Concat(methodName, ":", lineNumber, " -> ", message));

        private void WriteLog(string completeMessage, [CallerMemberName] string logType = "")
        {
            string logMessage = string.Concat(logType, " in ", completeMessage);

            #if DEBUG
            Console.WriteLine(logMessage);
            #endif

            if (!IsTraceLogEnabled)
                return;

            using (var writer = File.CreateText(Path.Combine(LogPath, LOG_FILE_NAME)))
            {
                writer.WriteLine(logMessage);
            }
        }

        public void Exception(string exception, [CallerMemberName] string methodName = "", [CallerLineNumber] int lineNumber = -1)
        {
            string exceptionFileName = string.Concat("Exception_", DateTime.Now.ToString("yyyyMMddhhmmssffff"), ".txt");
            string exceptionFolder = Path.Combine(LogPath, EXCEPTION_FOLDER_NAME);

            Directory.CreateDirectory(exceptionFolder);
            File.WriteAllText(Path.Combine(exceptionFolder, exceptionFileName), exception);
        }

        public void Exception(Exception exception, [CallerMemberName] string methodName = "", [CallerLineNumber] int lineNumber = -1)
            => Exception(ExceptionMessageBuilder.BuildExceptionMessage(exception, methodName, lineNumber.ToString()), methodName, lineNumber);

     

    }
}