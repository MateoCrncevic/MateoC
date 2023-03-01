using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp
{
    public partial class SettingsForm : Form
    {
        private static string DEL = ";";
        public SettingsForm()
        {
            InitializeComponent();
        }


        private bool FormValid(RadioButton sl)
        {
            return cbChamp.SelectedIndex != -1 && sl != null;

        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selectedLang = gbLangauge.Controls.OfType<RadioButton>()
                                         .FirstOrDefault(r => r.Checked);


            if (FormValid(selectedLang))
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(cbChamp.SelectedIndex + DEL);
                sb.Append(selectedLang.Tag.ToString() + DEL);
                sb.Append(chbIsOnline.Checked.ToString());



                Repo.WriteConfigFile(sb.ToString());
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please fill every field!");
            }
        }

        private void SettingsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(null,null);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                button2_Click(null,null);
            }
        }
    }
}
