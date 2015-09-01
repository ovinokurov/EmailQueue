using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Img.EmailQueue.Core.Services;

namespace Img.EmailQueue.EmailService
{
    public partial class SendAll : ServiceBase
    {
        private System.Timers.Timer _timer = null;

        public SendAll()
        {
            InitializeComponent();
        }

        public void onDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            _timer = new System.Timers.Timer();
            _timer.Enabled = true;
            // _timer.Interval = 300000; // 5 min
            _timer.Interval = 3000; // 5 min
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(SendQueue);
        }

        private void SendQueue(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timer.Stop();


            var messageIds = SmtpFactory.GetAllMessageIds();

            foreach (Guid item in messageIds)
            {
                var _message = SmtpFactory.GetMessage(item);
                SmtpFactory.SendMessage(_message);
            }

            _timer.Start();
        }

        protected override void OnStop()
        {
        }
    }
}
