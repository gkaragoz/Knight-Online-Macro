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

        #region TextBoxes set Input Only Number Events
        private void edtSkill01_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputOnlyNumbers(e);
        }

        private void edtSkill02_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputOnlyNumbers(e);
        }

        private void edtSkill03_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputOnlyNumbers(e);
        }

        private void edtSkill04_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputOnlyNumbers(e);
        }

        private void edtSkill05_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputOnlyNumbers(e);
        }

        private void edtSkill06_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputOnlyNumbers(e);
        }

        private void edtSkill07_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputOnlyNumbers(e);
        }

        private void edtMiliSpeedSkill01_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputOnlyNumbers(e);
        }

        private void edtMiliSpeedSkill02_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputOnlyNumbers(e);
        }

        private void edtMiliSpeedSkill03_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputOnlyNumbers(e);
        }

        private void edtMiliSpeedSkill04_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputOnlyNumbers(e);
        }

        private void edtSecondSpeedSkill05_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputOnlyNumbers(e);
        }

        private void edtSecondSpeedSkill06_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputOnlyNumbers(e);
        }

        private void edtSecondSpeedSkill07_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputOnlyNumbers(e);
        }
        #endregion

        public void InputOnlyNumbers(KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

    }
}
