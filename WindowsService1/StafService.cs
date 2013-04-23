using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace WindowsService1
{
    public partial class StafService : ServiceBase
    {
        string location;
        public StafService(Program main)
        {
            location = main.exe_path;
            InitializeComponent();
            if (!System.Diagnostics.EventLog.SourceExists("DoDyLogSourse"))
                System.Diagnostics.EventLog.CreateEventSource("DoDyLogSourse",
                                                                      "DoDyLog");

            eventLog1.Source = "DoDyLogSourse";
            eventLog1.Log = "DoDyLog";

        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("my service started: " + location);

            System.Diagnostics.Process.Start(location + @"\startSTAFProc.bat"); 
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("my service stoped " + location);
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = location + @"\bin\STAF.exe";//需要启动的程序名       
            p.StartInfo.Arguments = "local SHUTDOWN SHUTDOWN";//启动参数       
            p.Start();//启动       
           //if (p.HasExited)//判断是否运行结束
           //    p.Kill();  
        }
        protected override void OnContinue()
        {
            eventLog1.WriteEntry("my service is continuing in working");
        }
    }
}
