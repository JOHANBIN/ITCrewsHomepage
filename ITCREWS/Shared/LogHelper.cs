using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class LogHelper
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public static void Debug(string logMessage)
        {
            logger.Debug(logMessage);
        }
        public static void Info(string logMessage)
        {
            logger.Info(logMessage);
        }
        public static void Error(string logMessage)
        {
            logger.Error(logMessage);
        }

    }
}
