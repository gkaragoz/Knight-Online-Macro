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
        #region Events

        #region CheckBoxes Checked Events
        private void chcSkill01Active_CheckedChanged(object sender, EventArgs e)
        {
            Skill01Active = !Skill01Active;
        }

        private void chcSkill02Active_CheckedChanged(object sender, EventArgs e)
        {
            Skill02Active = !Skill03Active;
        }

        private void chcSkill03Active_CheckedChanged(object sender, EventArgs e)
        {
            Skill03Active = !Skill03Active;
        }

        private void chcSkill04Active_CheckedChanged(object sender, EventArgs e)
        {
            Skill04Active = !Skill04Active;
        }

        private void chcSkill05Active_CheckedChanged(object sender, EventArgs e)
        {
            Skill05Active = !Skill05Active;
        }

        private void chcSkill06Active_CheckedChanged(object sender, EventArgs e)
        {
            Skill06Active = !Skill06Active;
        }

        private void chcSkill07Active_CheckedChanged(object sender, EventArgs e)
        {
            Skill07Active = !Skill07Active;
        }
        #endregion

        #region ComboBoxes SelectedIndexChanged Events
        private void cmbMiliSpeed01_SelectedIndexChanged(object sender, EventArgs e)
        {
            float amount = float.Parse(cmbMiliSpeed01.SelectedItem.ToString());
            SetSpeed(1, amount);
        }

        private void cmbMiliSpeed02_SelectedIndexChanged(object sender, EventArgs e)
        {
            float amount = float.Parse(cmbMiliSpeed02.SelectedItem.ToString());
            SetSpeed(2, amount);
        }

        private void cmbMiliSpeed03_SelectedIndexChanged(object sender, EventArgs e)
        {
            float amount = float.Parse(cmbMiliSpeed03.SelectedItem.ToString());
            SetSpeed(3, amount);
        }

        private void cmbMiliSpeed04_SelectedIndexChanged(object sender, EventArgs e)
        {
            float amount = float.Parse(cmbMiliSpeed04.SelectedItem.ToString());
            SetSpeed(4, amount);
        }

        private void cmbSecondSpeed05_SelectedIndexChanged(object sender, EventArgs e)
        {
            float amount = float.Parse(cmbSecondSpeed05.SelectedItem.ToString());
            SetSpeed(5, amount);
        }

        private void cmbSecondSpeed06_SelectedIndexChanged(object sender, EventArgs e)
        {
            float amount = float.Parse(cmbSecondSpeed06.SelectedItem.ToString());
            SetSpeed(6, amount);
        }

        private void cmbSecondSpeed07_SelectedIndexChanged(object sender, EventArgs e)
        {
            float amount = float.Parse(cmbSecondSpeed07.SelectedItem.ToString());
            SetSpeed(7, amount);
        }
        #endregion

        #endregion

        #region Variables
        private List<Timer> timerSkills = new List<Timer>();

        public bool SkillsRunning = false;
        public bool ZRRunning = false;

        public bool Skill01Active = false;
        public bool Skill02Active = false;
        public bool Skill03Active = false;
        public bool Skill04Active = false;
        public bool Skill05Active = false;
        public bool Skill06Active = false;
        public bool Skill07Active = false;

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
            InitSpeedComboboxes();

            CreateTimerSkills();
            SetTimerSkill(timerSkills[0], 1000);
            SetTimerSkill(timerSkills[1], 2000);
            SetTimerSkill(timerSkills[2], 1000);
            SetTimerSkill(timerSkills[3], 500);
            SetTimerSkill(timerSkills[4], 3000);
            SetTimerSkill(timerSkills[5], 5000);
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


        #region Timer Methods
        public void CreateTimerSkills()
        {
            for (int ii = 0; ii < 7; ii++)
            {
                Timer timerSkill = new Timer();
                timerSkill.Tag = "Skill " + ii;
                timerSkill.Tick += delegate {
                    Console.WriteLine(timerSkill.Tag + " used! (" + timerSkill.Interval + ")");
                };
                timerSkills.Add(timerSkill);
            }
        }

        public void StopTimerSkill(Timer timer)
        {
            if (timer != null)
                timer.Dispose();
        }

        public void SetTimerSkill(Timer timer, int miliseconds)
        {
            Timer temp = timer;

            if (timer != null)
                timer.Dispose();

            timer = temp;
            timer.Interval = miliseconds;
            timer.Start();
        }
        #endregion

        public bool IsItNumber(KeyPressEventArgs e)
        {
            bool error = true;
            char ch = e.KeyChar;

            Console.WriteLine(ch);

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;

                error = false;
                return error;
            }
            return error;
        }

        public void SetSpeed(int skillNumber, float amount)
        {
            switch (skillNumber)
            {
                case 1:
                    MiliSpeedSkill01 = amount;
                    break;
                case 2:
                    MiliSpeedSkill02 = amount;
                    break;
                case 3:
                    MiliSpeedSkill03 = amount;
                    break;
                case 4:
                    MiliSpeedSkill04 = amount;
                    break;
                case 5:
                    SecondSpeedSkill05 = amount / 1000;
                    break;
                case 6:
                    SecondSpeedSkill06 = amount / 1000;
                    break;
                case 7:
                    SecondSpeedSkill07 = amount / 1000;
                    break;
                default:
                    break;
            }
        }

        private void btnStartSkills_Click(object sender, EventArgs e)
        {
            SkillsRunning = !SkillsRunning;

            if (SkillsRunning)
            {
                btnStartBasic.Enabled = false;
                btnStartSkills.Text = "Durdur";
            }
            else
            {
                btnStartBasic.Enabled = true;
                btnStartSkills.Text = "Skillerle Başlat";
            }
        }

        private void btnStartBasic_Click(object sender, EventArgs e)
        {
            ZRRunning = !ZRRunning;

            if (ZRRunning)
            {
                btnStartSkills.Enabled = false;
                btnStartBasic.Text = "Durdur";
            }
            else
            {
                btnStartSkills.Enabled = true;
                btnStartBasic.Text = "Z-R Skillsiz Başlat";
            }
        }
    }
}
