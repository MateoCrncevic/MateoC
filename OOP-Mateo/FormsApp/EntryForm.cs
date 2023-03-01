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
    public partial class EntryForm : Form
    {
        private static string DEL = ";";
        public EntryForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
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
                MainForm mf = new MainForm();
                mf.Show();
                
            }
            else
            {
                MessageBox.Show("Please fill all fields!");
            }
        }

        private bool FormValid(RadioButton sl)
        {
            return cbChamp.SelectedIndex != -1 && sl != null;
           
        }
    }
}
