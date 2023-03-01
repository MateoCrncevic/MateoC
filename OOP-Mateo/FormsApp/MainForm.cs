using DataLayer;
using DataLayer.Models;
using FormsApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp
{
    public partial class MainForm : Form
    {
        bool IsMale = new bool();
        bool IsOnline = new bool();
        bool PrintTable = new bool();
        List<PlayerDisplay> selectedPlayers = new List<PlayerDisplay>();
        List<PlayerDisplay> favPlayers = new List<PlayerDisplay>();
        List<Match> loadedMatches = new List<Match>();
        Dictionary<string, string> CountriesAndCodes = new Dictionary<string, string>();
        List<StartingEleven> Players = new List<StartingEleven>();

        List<PlayerData> PlayerTableData = new List<PlayerData>();


        public MainForm()
        {
            LoadSettings();
            InitializeComponent();
            AsyncMatches();

        }

        private void init()
        {
            LoadComboBox();
            LoadFavouriteTeamInComboBox();
        }

        private void LoadFavouriteTeamInComboBox()
        {
            try
            {

                string s = Repo.readFavTeam();
                var testCase = cbTeams.Items.Cast<KeyValuePair<string, string>>().ToList().FindAll(t => t.Key == s);
                if (testCase.Count != 0)
                {
                    cbTeams.SelectedValue = s;
                    loadPlayers();

                }

            }
            catch (Exception)
            {

                MessageBox.Show("Error reading favourite team");
            }
        }

        private void loadFavPlayers()
        {
            var FavPlayers = Repo.readFavPlayers();

            pnlAll.Controls.Cast<PlayerDisplay>().ToList().ForEach(pd =>
            {

                FavPlayers.ForEach(str =>
                {
                    if (pd.PlayerName == str)
                    {
                        pd.setFavourite(true);
                        pd.Selected = false;
                        pnlFav.Controls.Add(pd);
                    }

                });

            });

        }

        private void LoadComboBox()
        {
            
            cbTeams.DataSource = new BindingSource(CountriesAndCodes, null);
            cbTeams.DisplayMember = "Value";
            cbTeams.ValueMember = "Key";

        }

        private async void AsyncMatches() //Asinkrona funkcija, 
        {
            var lf = new LoadingGif();
            lf.Show();
            await Task.Run(() => { CountriesAndCodes = Repo.getCountriesAndCodes(IsMale, IsOnline); }); 
            lf.Close();
            init();

        }

        private void LoadSettings()
        {
            if (Repo.ConfigExists())
            {
                ImportConfig();
            }
            else
            {
                var f = new EntryForm();
                f.ShowDialog();
                LoadSettings();
            }
        }

        private void ImportConfig()
        {
            List<string> settings = Repo.ReadConfigFile();

            IsMale = settings[0] == "0";
            string lang = settings[1];
            IsOnline = settings[2] == "True";


            SetLocalisation(lang);


        }

        private void SetLocalisation(string lang)
        {

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);

            Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);

        }

        private void btnSaveSelection_Click(object sender, EventArgs e)
        {
            pnlAll.Controls.Clear();
            pnlFav.Controls.Clear();
            pnlRankings.Controls.Clear();
            loadPlayers();
          
        }

        private void loadPlayers()
        {

            AsyncPlayer(cbTeams.SelectedValue.ToString());

        }

        private async void AsyncPlayer(string code) //Asinkrona funkcija
        {
            var lf = new LoadingGif();
            lf.Show();
            await Task.Run(() => { Players = Repo.getAllPlayers(IsMale, IsOnline, code); });
            foreach (var player in Players)
            {

                    var l = new PlayerDisplay(player, false);
                    pnlAll.Controls.Add(l);

            }
            lf.Close();
            loadFavPlayers();
            AsyncMatches(cbTeams.SelectedValue.ToString());
        }



        private async void AsyncMatches(string code) //Asinkrona funkcija
        {
            var lf = new LoadingGif();
            lf.Show();
            await Task.Run(() => { loadedMatches = Repo.getMatchData(IsOnline, IsMale, code); });
            lf.Close();


        }

        private void saveFavouriteTeam()
        {
            

            Repo.writeFavTeam(cbTeams.SelectedValue.ToString());
        }



        private void addToFavouritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddToFavouritesPanel();
        }

        private void removeFromFavouritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveFromFavouritesPanel();
        }

        private void AddToFavouritesPanel() {

            selectedPlayers = pnlAll.Controls.Cast<PlayerDisplay>().ToList().FindAll(pd => pd.Selected);
            selectedPlayers.ForEach(p =>
            {
                p.Selected = false;
                if (pnlFav.Controls.Count < 3)
                {
                    p.setFavourite(true);
                    pnlFav.Controls.Add(p);
                }

            });
        }
        private void RemoveFromFavouritesPanel() {

            favPlayers = pnlFav.Controls.Cast<PlayerDisplay>().ToList().FindAll(pd => pd.Selected);
            favPlayers.ForEach(p =>
            {

                p.setFavourite(false);
                p.Selected = false;
                pnlAll.Controls.Add(p);

            });
        }
        private void btnSaveFavourites_Click(object sender, EventArgs e)
        {
            saveFavouriteTeam();
            saveFavouritePlayers();
        }

        private void saveFavouritePlayers()
        {
            List<string> players = new List<string>();
            pnlFav.Controls.Cast<PlayerDisplay>().ToList().ForEach(pd =>
            {

                players.Add(pd.PlayerName);

            });
            Repo.writeFavPlayers(players);
        }

        private void pnlFav_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;

        }

        private void pnlFav_DragDrop(object sender, DragEventArgs e)
        {
            var v = (PlayerDisplay)e.Data.GetData(typeof(PlayerDisplay));
           
            if (!pnlFav.Controls.Contains(v) && pnlFav.Controls.Count < 3)
            {
                v.Selected = false;
                v.setFavourite(!v.Favourite);
                pnlFav.Controls.Add(v);
            }
            AddToFavouritesPanel();
        }

        private void pnlAll_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void pnlAll_DragDrop(object sender, DragEventArgs e)
        {
            var v = (PlayerDisplay)e.Data.GetData(typeof(PlayerDisplay));
            if (!pnlAll.Controls.Contains(v))
            {
                v.Selected = false;
                v.setFavourite(!v.Favourite);
                pnlAll.Controls.Add(v);

            }
            RemoveFromFavouritesPanel();
        }

        private void btnTopScorers_Click(object sender, EventArgs e)
        {
            pnlRankings.Controls.Clear();
            loadPlayerResults('g');
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            pnlRankings.Controls.Clear();
            loadAttendance();
        }

        private void btnYellowCards_Click(object sender, EventArgs e)
        {

            pnlRankings.Controls.Clear();
            loadPlayerResults('y');
        }

        private void loadAttendance()
        {
            ListBox lbTableDisplay = new ListBox();
            loadedMatches.Sort();
            List<string> formattedMatches = new List<string>();
            loadedMatches.ForEach(m => formattedMatches.Add($"{m.Venue} - {m.HomeTeamCountry} VS {m.AwayTeamCountry} - Viewers:{m.Attendance}"));
            lbTableDisplay.DataSource = formattedMatches;
            lbTableDisplay.Width = 280;
            PrintTable = false;
            pnlRankings.Controls.Add(lbTableDisplay);
        }

        private void loadPlayerResults(char wantedEvent)
        {
            var PlayerList = pnlAll.Controls.Cast<PlayerDisplay>().ToList();
            PlayerList.AddRange(pnlFav.Controls.Cast<PlayerDisplay>().ToList());
            PlayerTableData.Clear();

            PlayerList.ForEach(pd =>
            {

                PlayerTableData.Add(new PlayerData(pd.getPlayerName(), pd.imgPath));


            });

            PlayerTableData.ForEach(p =>
            {

                switch (wantedEvent)
                {
                    case 'g':
                        loadedMatches.ForEach(match => p.Result += match.getGoalsScoredByPlayer(p.PlayerName));
                        break;
                    case 'y':
                        loadedMatches.ForEach(match => p.Result += match.getYellowCardsByPlayer(p.PlayerName));
                        break;
                }


            });

            PlayerTableData.Sort();
            PlayerTableData.ForEach(p =>
            {

                PlayerRanking pr = new PlayerRanking(p);
                pnlRankings.Controls.Add(pr);

            });
            PrintTable = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (printDialog.ShowDialog() != DialogResult.Cancel)
            {
                printDocument.Print();

            }

        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        { 
            int y = 0;
            var font = new Font("Arial", 22, FontStyle.Regular, GraphicsUnit.Pixel);
            if (PrintTable)
            {
                PlayerTableData.ForEach(data =>
                {
                    e.Graphics.DrawString(data.ToString(), font, Brushes.Black, new PointF(e.MarginBounds.X, e.MarginBounds.Y + y));
                    y += 22;

                });
            }
            else
            {
                var lb = pnlRankings.Controls.OfType<ListBox>();
                for (int i = 0; i < lb.First().Items.Count; i++)
                {
                    e.Graphics.DrawString(lb.First().Items[i].ToString(), font, Brushes.Green, new PointF(e.MarginBounds.X, e.MarginBounds.Y + y));
                    y += 22;

                }
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var setForm = new SettingsForm();
            if (setForm.ShowDialog() == DialogResult.OK)
            {
                this.Controls.Clear();

                LoadSettings();
                this.FormClosing -= new FormClosingEventHandler(this.MainForm_FormClosing);
                InitializeComponent();
                AsyncMatches();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            var ocf = new ClosingForm();
            ocf.StartPosition = FormStartPosition.CenterScreen;
            if (ocf.ShowDialog() == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var setForm = new SettingsForm();
            if (setForm.ShowDialog() == DialogResult.OK)
            {
                this.Controls.Clear();

                LoadSettings();
                this.FormClosing -= new FormClosingEventHandler(this.MainForm_FormClosing);
                InitializeComponent();
                AsyncMatches();
            }
        }
    }
}
