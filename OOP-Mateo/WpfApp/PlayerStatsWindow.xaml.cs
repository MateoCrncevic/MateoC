using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp.Models;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for PlayerShowcaseWindow.xaml
    /// </summary>
    public partial class PlayerShowcaseWindow : Window
    {
       
        public PlayerShowcaseWindow(StartingEleven player, PlayerMatchStatistics stats, ImageSource path)
        {
            InitializeComponent();
            init(player,stats,path);
            
        }

        private void init(StartingEleven Player, PlayerMatchStatistics Stats, ImageSource path)
        {
            lblPlayerName.Content = Player.Name;
            lblPosition.Content = Player.Position;
            lblShirtNumber.Content = Player.ShirtNumber;
            lblCaptaincy.Content = Player.Captain ? "CAP" : "";
            lblGoals.Content = Stats.GoalsScored;
            lblCards.Content = Stats.YellowCards;
            imgPlayerImage.Source = path;
        }
    }
}
