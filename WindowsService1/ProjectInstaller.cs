using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;


namespace WindowsService1
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
        public override void Install(IDictionary stateSaver) {
            string strAssPath = "/assemblypath=\"{0}\" \"" + this.Context.Parameters["path"]+"\"";
            
            Context = new InstallContext("", new string[] { String.Format(strAssPath, System.Reflection.Assembly.GetExecutingAssembly().Location) });

            base.Install(stateSaver);
        
        }

        private void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {
             ServiceController sc = new ServiceController(serviceInstaller1.ServiceName);  
            if(sc.)
             sc.Start();        
        }
       
     }
}
