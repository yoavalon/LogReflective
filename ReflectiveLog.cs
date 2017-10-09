using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefInTest
{
    class Calculations
    {
        public void Divide(int a, int b)
        {
            try
            {
                Console.WriteLine(a / b);                
            }
            catch (Exception ex)
            {
                Log(ex);
            }
        }

        public static void Log(Exception ex)
        {
            try
            {
                string TimeStamp = $"{DateTime.Now.ToShortDateString()}-{DateTime.Now.ToLongTimeString()}:";
                var Msg = $"{TimeStamp} {ex?.TargetSite.ReflectedType.Name}-{ex?.TargetSite.Name}(): {ex?.Message} {ex?.InnerException?.Message}";

                string m_LocalFolder = "D:\\Logs\\";  //Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\FMR\\PackageSurveillance\\Logs\\";

                string LogPath = m_LocalFolder + "Log" + String.Format("{0:yyyyMMdd}", DateTime.Today) + ".txt";
                Directory.CreateDirectory(m_LocalFolder);

                using (StreamWriter w = File.AppendText(LogPath))
                {
                    w.WriteLine(Msg);
                }
            }
            catch { }
        }

    }
}
