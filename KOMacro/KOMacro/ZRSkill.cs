using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KOMacro
{
    public class ZRSkill
    {
        private Timer zTimer;
        private Timer rTimer;

        public ZRSkill()
        {
            zTimer = new Timer();
            zTimer.Tag = "zTimer";
            zTimer.Tick += delegate
            {
                SendKeys.Send("z");
                //Console.WriteLine("z button pressed. " + zTimer.Interval);
            };
            zTimer.Interval = 100;

            rTimer = new Timer();
            rTimer.Tag = "rTimer";
            rTimer.Tick += delegate
            {
                SendKeys.Send("r");
                //Console.WriteLine("r button pressed. " + rTimer.Interval);
            };
            rTimer.Interval = 1000;
        }

        public void Start()
        {
            if (zTimer != null && rTimer != null)
            {
                zTimer.Start();
                rTimer.Start();
            }
        }

        public void Stop()
        {
            if (zTimer != null && rTimer != null)
            {
                zTimer.Stop();
                rTimer.Stop();
            }
        }
    }
}
