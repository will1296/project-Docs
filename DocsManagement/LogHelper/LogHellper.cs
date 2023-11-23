using System.Runtime.CompilerServices;

namespace DocsManagement.LogHelper
{
    public class LogHellper
    {
        public static log4net.ILog GetLogger([CallerFilePath]string filename = "")
        {
            return log4net.LogManager.GetLogger(filename);
        }
    }
}