using System;
using System.ComponentModel;
using System.Configuration;
using System.ServiceProcess;
using System.Timers;

namespace WindowsService1
{
    [RunInstaller(true)]
    public partial class Service1 : ServiceBase
    {
        #region variables
        private Timer timer;
        private int interval;
        private int NumberConverter;
        private bool Checker;
        #endregion
        public Service1()
        {
            InitializeComponent();
            interval = int.Parse(ConfigurationManager.AppSettings["IntervelTime"]);
        }
    
        protected override void OnStart(string[] args)
        {
            NumberConverter = int.Parse(ConfigurationManager.AppSettings["CheckCondition"]);
            Checker = Convert.ToBoolean(NumberConverter);

            if (Checker)
            {
                timer = new Timer(interval);
                timer.Elapsed += TimerElapsed;
                timer.Start();
            }
    }
        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            
            Working();
        }
        public void Working()
        {
            SendMails mails = new SendMails();  
        }
        protected override void OnStop()
        {
            timer.Stop();
            timer.Dispose();

        }
    }
}
