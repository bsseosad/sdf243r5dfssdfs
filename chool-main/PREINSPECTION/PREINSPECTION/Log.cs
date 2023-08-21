using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PREINSPECTION
{
    internal class Log
    {
        static public void writeLog(string strContent)
        {
            DirectoryInfo di = new DirectoryInfo(".\\log");
            if (di.Exists == false)
                di.Create();

            string logFileName = "";

            logFileName = DateTime.Now.ToString("yyyyMMdd") + ".log";

            string logline = null;

            logline = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "," + strContent + "\r\n";

            StreamWriter writeData = null;

            try
            {
                writeData = new StreamWriter(".\\log\\" + logFileName, true); //파일이 존재하면 기존데이터 뒤에 이어쓰기
                writeData.WriteLine(logline);
            }
            catch (Exception ex)
            {
                writeLog(ex.ToString());
                return;
            }
            finally
            {
                writeData.Dispose();
            }
        }
    }
}
