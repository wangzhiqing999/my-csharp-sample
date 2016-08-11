using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;


using System.ServiceProcess;
using System.Diagnostics;



namespace I0002_Test.WindowsService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }


        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
        }


        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);

            // 启动.
            try
            {
                ServiceController serviceController = new ServiceController( this.serviceInstaller1.ServiceName );
                serviceController.Start();
            }
            catch (System.InvalidOperationException)
            {

            }
        }


        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
        }



        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Uninstall(IDictionary savedState)
        {

            // 停止服务.
            try
            {
                ServiceController serviceController = new ServiceController(this.serviceInstaller1.ServiceName);
                if (serviceController.CanStop)
                {
                    serviceController.Stop();
                }
            }
            catch (System.InvalidOperationException)
            {
            }


            base.Uninstall(savedState);
        }


    }
}
