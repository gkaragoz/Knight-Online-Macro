using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KOMacro
{
    public class Skill
    {
        private bool skillActive;
        private Timer timer;

        public Skill(Timer timer)
        {
            this.skillActive = false;
            this.timer = timer;
        }

        public void StartSkill()
        {
            if (frmKOmacro.instance.SkillsRunning && skillActive)
            {
                timer.Start();
                Console.WriteLine(timer.Tag + " started.");
            }
        }

        public void StopSkill()
        {
            timer.Stop();
            Console.WriteLine(timer.Tag + " stopped.");
        }

        public void SetSkillSpeed(int miliseconds)
        {
            Timer temp = timer;

            if (timer != null)
                timer.Dispose();

            timer = temp;
            timer.Interval = miliseconds;
            StartSkill();

            Console.WriteLine(timer.Tag + " speed set: " + timer.Interval);
        }

        public void SetSkillActive()
        {
            skillActive = !skillActive;

            if (skillActive)
                StartSkill();
            else
                StopSkill();
        }
    }
}
