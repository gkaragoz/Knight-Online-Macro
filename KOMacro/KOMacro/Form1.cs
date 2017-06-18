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

        public frmKOmacro()
        {
            InitializeComponent();
        }

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
    }
}
