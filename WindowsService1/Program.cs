using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace WindowsService1
{
    public class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        public string exe_path;
        static void Main(System.String[] args)
        {
            Program main = new Program();
            main.exe_path= args[0];           
            ServiceBase.Run(new StafService(main));
        }
    }
}
