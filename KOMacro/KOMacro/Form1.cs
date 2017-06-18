using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KOMacro
{
    public partial class frmKOmacro : Form
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

            public bool TimerActive()
            {   if (timer != null)
                    return timer.Enabled;
                else
                    return false;
            } 

            public void StartSkill()
            {
                if (SkillsRunning && skillActive)
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
                    Console.WriteLine("z button pressed. " + zTimer.Interval);
                };
                zTimer.Interval = 100;

                rTimer = new Timer();
                rTimer.Tag = "rTimer";
                rTimer.Tick += delegate
                {
                    Console.WriteLine("r button pressed. " + rTimer.Interval);
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

        #region Events

        #region Button Click Events
        private void btnStartSkills_Click(object sender, EventArgs e)
        {
            SkillsRunning = !SkillsRunning;

            if (SkillsRunning)
            {
                StartAllSkills();
                btnStartBasic.Enabled = false;
                btnStartSkills.Text = "Durdur";
            }
            else
            {
                StopAllSkills();
                btnStartBasic.Enabled = true;
                btnStartSkills.Text = "Skillerle Başlat";
            }
        }

        private void btnStartBasic_Click(object sender, EventArgs e)
        {
            ZRRunning = !ZRRunning;

            if (ZRRunning)
            {
                zrSkill.Start();
                DisableAllComponents();
                btnStartSkills.Enabled = false;
                btnStartBasic.Text = "Durdur";
            }
            else
            {
                zrSkill.Stop();
                EnableAllComponents();
                btnStartSkills.Enabled = true;
                btnStartBasic.Text = "Z-R Skillsiz Başlat";
            }
        }
        #endregion

        #region CheckBoxes Checked Events
        private void chcSkill01Active_CheckedChanged(object sender, EventArgs e)
        {
            skills[0].SetSkillActive();
        }

        private void chcSkill02Active_CheckedChanged(object sender, EventArgs e)
        {
            skills[1].SetSkillActive();
        }

        private void chcSkill03Active_CheckedChanged(object sender, EventArgs e)
        {
            skills[2].SetSkillActive();
        }

        private void chcSkill04Active_CheckedChanged(object sender, EventArgs e)
        {
            skills[3].SetSkillActive();
        }

        private void chcSkill05Active_CheckedChanged(object sender, EventArgs e)
        {
            skills[4].SetSkillActive();
        }

        private void chcSkill06Active_CheckedChanged(object sender, EventArgs e)
        {
            skills[5].SetSkillActive();
        }

        private void chcSkill07Active_CheckedChanged(object sender, EventArgs e)
        {
            skills[6].SetSkillActive();
        }
        #endregion

        #region ComboBoxes SelectedIndexChanged Events
        private void cmbMiliSpeed01_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = cmbMiliSpeed01.SelectedItem.ToString();
            int milisecond = (int)Convert.ToDouble(value);

            skills[0].SetSkillSpeed(milisecond);
        }

        private void cmbMiliSpeed02_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = cmbMiliSpeed02.SelectedItem.ToString();
            int milisecond = (int)Convert.ToDouble(value);

            skills[1].SetSkillSpeed(milisecond);
        }

        private void cmbMiliSpeed03_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = cmbMiliSpeed03.SelectedItem.ToString();
            int milisecond = (int)Convert.ToDouble(value);

            skills[2].SetSkillSpeed(milisecond);
        }

        private void cmbMiliSpeed04_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = cmbMiliSpeed04.SelectedItem.ToString();
            int milisecond = (int)Convert.ToDouble(value);

            skills[3].SetSkillSpeed(milisecond);
        }

        private void cmbSecondSpeed05_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = cmbSecondSpeed05.SelectedItem.ToString();
            int milisecond = (int) (Convert.ToDouble(value) * 1000);

            skills[4].SetSkillSpeed(milisecond);
        }

        private void cmbSecondSpeed06_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = cmbSecondSpeed06.SelectedItem.ToString();
            int milisecond = (int) (Convert.ToDouble(value) * 1000);

            skills[5].SetSkillSpeed(milisecond);
        }

        private void cmbSecondSpeed07_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = cmbSecondSpeed07.SelectedItem.ToString();
            int milisecond = (int) (Convert.ToDouble(value) * 1000);

            skills[6].SetSkillSpeed(milisecond);
        }
        #endregion

        #endregion

        #region Variables
        private List<Skill> skills = new List<Skill>();
        private ZRSkill zrSkill = new ZRSkill();

        public static bool SkillsRunning = false;
        public static bool ZRRunning = false;

        public float MiliSpeedSkill01 = 100f;
        public float MiliSpeedSkill02 = 100f;
        public float MiliSpeedSkill03 = 100f;
        public float MiliSpeedSkill04 = 100f;

        public float SecondSpeedSkill05 = 10f;
        public float SecondSpeedSkill06 = 10f;
        public float SecondSpeedSkill07 = 0.5f;
        #endregion

        public frmKOmacro()
        {
            InitializeComponent();

            CreateTimerSkills();

            InitSpeedComboboxes();
        }

        public void CreateTimerSkills()
        {
            for (int ii = 0; ii < 7; ii++)
            {
                Timer timer = new Timer();
                timer.Tag = "Skill " + (ii + 1);
                timer.Tick += delegate {
                    Console.WriteLine(timer.Tag + " used! (" + timer.Interval + ")");
                };

                Skill skill = new Skill(timer);
                skills.Add(skill);
            }
        }

        public void StartAllSkills()
        {
            foreach (var item in skills)
                item.StartSkill();
        }

        public void StopAllSkills()
        {
            foreach (var item in skills)
                item.StopSkill();
        }
        
        public void InitSpeedComboboxes()
        {
            int [] miliSpeeds = { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };
            float [] secondSpeeds = { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            for (int ii = 0; ii < miliSpeeds.Length; ii++)
            {
                cmbMiliSpeed01.Items.Add(miliSpeeds[ii]);
                cmbMiliSpeed02.Items.Add(miliSpeeds[ii]);
                cmbMiliSpeed03.Items.Add(miliSpeeds[ii]);
                cmbMiliSpeed04.Items.Add(miliSpeeds[ii]);
            }

            for (int ii = 0; ii < secondSpeeds.Length; ii++)
            {
                cmbSecondSpeed05.Items.Add(secondSpeeds[ii]);
                cmbSecondSpeed06.Items.Add(secondSpeeds[ii]);
                cmbSecondSpeed07.Items.Add(secondSpeeds[ii]);
            }

            cmbMiliSpeed01.SelectedIndex = 0;
            cmbMiliSpeed02.SelectedIndex = 0;
            cmbMiliSpeed03.SelectedIndex = 0;
            cmbMiliSpeed04.SelectedIndex = 0;

            cmbSecondSpeed05.SelectedIndex = secondSpeeds.Length - 1;
            cmbSecondSpeed06.SelectedIndex = secondSpeeds.Length - 1;
            cmbSecondSpeed07.SelectedIndex = 9;
        }

        public void DisableAllComponents()
        {
            cmbMiliSpeed01.Enabled = false;
            cmbMiliSpeed02.Enabled = false;
            cmbMiliSpeed03.Enabled = false;
            cmbMiliSpeed04.Enabled = false;
            cmbSecondSpeed05.Enabled = false;
            cmbSecondSpeed06.Enabled = false;
            cmbSecondSpeed07.Enabled = false;

            chcSkill01Active.Enabled = false;
            chcSkill02Active.Enabled = false;
            chcSkill03Active.Enabled = false;
            chcSkill04Active.Enabled = false;
            chcSkill05Active.Enabled = false;
            chcSkill06Active.Enabled = false;
            chcSkill07Active.Enabled = false;
        }

        public void EnableAllComponents()
        {
            cmbMiliSpeed01.Enabled = true;
            cmbMiliSpeed02.Enabled = true;
            cmbMiliSpeed03.Enabled = true;
            cmbMiliSpeed04.Enabled = true;
            cmbSecondSpeed05.Enabled = true;
            cmbSecondSpeed06.Enabled = true;
            cmbSecondSpeed07.Enabled = true;

            chcSkill01Active.Enabled = true;
            chcSkill02Active.Enabled = true;
            chcSkill03Active.Enabled = true;
            chcSkill04Active.Enabled = true;
            chcSkill05Active.Enabled = true;
            chcSkill06Active.Enabled = true;
            chcSkill07Active.Enabled = true;
        }
    }
}
