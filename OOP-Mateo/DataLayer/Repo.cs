using DataLayer.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DataLayer
{
    public class Repo
    {
        private const string MaleTeamUrl = "https://world-cup-json-2018.herokuapp.com/teams/results"; //API ENDPOINT
        private const string FemaleTeamUrl = "http://worldcup.sfg.io/teams/results"; //API ENDPOINT
        private const string MaleMatchUrl = "https://world-cup-json-2018.herokuapp.com/matches"; //API ENDPOINT
        private const string FemaleMatchUrl = "http://worldcup.sfg.io/matches/"; //API ENDPOINT
        private const string MaleMatchPerCountryUrl = "https://world-cup-json-2018.herokuapp.com/matches/country?fifa_code="; //API ENDPOINT
        private const string FemaleMatchPerCountryUrl = "http://worldcup.sfg.io/matches/country?fifa_code="; //API ENDPOINT

        private const string MaleMatchFilePath = @"../../../Config/worldcup.sfg.io\men\matches.json"; //JSON DATOTEKE
        private const string FemaleMatchFilePath = @"../../../Config/worldcup.sfg.io\women\matches.json"; //JSON DATOTEKE
        private const string MaleTeamFilePath = @"../../../Config/worldcup.sfg.io\men\results.json"; //JSON DATOTEKE
        private const string FemaleTeamFilePath = @"../../../Config/worldcup.sfg.io\women\results.json"; //JSON DATOTEKE

        private const char DEL = ';';

        private const string ConfigPath = @"../../../Config/config.txt";
        private const string FavTeamPath = @"../../../Config/favteam.txt";
        private const string ResolutionPath = @"../../../Config/screenres.txt";
        private const string FavPlayersPath = @"../../../Config/favplayers.txt";
        

        public static void writeFavPlayers(List<string> players) 
        {
            File.WriteAllLines(FavPlayersPath, players);
        }
        public static List<string> readFavPlayers()
        {
            try
            {
                return File.ReadAllLines(FavPlayersPath).ToList();
            }
            catch (Exception)
            {

                return new List<string>();
            }
        }

        public static List<StartingEleven> getAllPlayers(bool IsMale, bool IsOnline, string code) 
        {
            List<StartingEleven> players = new List<StartingEleven>();

            var match = getMatchData(IsOnline, IsMale, code).First();

            if (match.HomeTeam.Code == code)
            {
                players = match.HomeTeamStatistics.StartingEleven;
                players.AddRange(match.HomeTeamStatistics.Substitutes);
            }
            else
            {
                players = match.AwayTeamStatistics.StartingEleven;
                players.AddRange(match.AwayTeamStatistics.Substitutes);
            }

            return players;
        }

        public static Dictionary<string, string> getCountriesAndCodes(bool IsMale, bool IsOnline) 
        {
            Dictionary<string, string> d = new Dictionary<string, string>();

            List<Team> tempTeams = IsMale ? getTeamData(IsOnline, true) : getTeamData(IsOnline, false);

            foreach (var team in tempTeams)
            {
                d.Add(team.FifaCode, $"{team.Country} ({team.FifaCode})");
            }
            return d;
        }


        public static List<Match> getMatchesByCountryCode(string url, string countryCode) //root funkcija
        {
            var apiClient = new RestClient(url + countryCode);

            var apiResult = apiClient.Execute<List<Match>>(new RestRequest());

            return JsonConvert.DeserializeObject<List<Match>>(apiResult.Content);
        }


        public static List<Match> getMatchData(bool isOnline, bool isMale) 
        {
            List<Match> matches;

            if (isOnline)
            {
                matches = isMale ? getMatchesFromApi(MaleMatchUrl) : getMatchesFromApi(FemaleMatchUrl);
            }
            else
            {
                matches = isMale ? getMatchesFromFile(MaleMatchFilePath) : getMatchesFromFile(FemaleMatchFilePath);
            }

            return matches;
        }

        public static List<Match> getMatchData(bool isOnline, bool isMale, string code) 
        {
            List<Match> matches;

            if (isOnline)
            {
                matches = isMale ? getMatchesByCountryCode(MaleMatchPerCountryUrl, code) : getMatchesByCountryCode(FemaleMatchPerCountryUrl, code);
            }
            else
            {
                matches = isMale ? getMatchesFromFile(MaleMatchFilePath) : getMatchesFromFile(FemaleMatchFilePath);

                List<Match> filteredMatches = matches.FindAll(m => m.HomeTeam.Code == code || m.AwayTeam.Code == code);

                return filteredMatches;
            }

            return matches;
        }

        public static List<Match> getMatchesFromApi(string url) //root funkcija
        {
            var apiClient = new RestClient(url);

            var apiResult = apiClient.Execute<List<Match>>(new RestRequest());

            return JsonConvert.DeserializeObject<List<Match>>(apiResult.Content);
        }

        private static List<Match> getMatchesFromFile(string path) //root funkcija
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                List<Match> items = JsonConvert.DeserializeObject<List<Match>>(json);
                return items;
            }
        }

        public static List<Team> getTeamData(bool isOnline, bool isMale) 
        {
            List<Team> teams;

            if (isOnline)
            {
                teams = isMale ? getTeamsFromApi(MaleTeamUrl) : getTeamsFromApi(FemaleTeamUrl);
            }
            else
            {
                teams = isMale ? getTeamsFromFile(MaleTeamFilePath) : getTeamsFromFile(FemaleTeamFilePath);
            }

            return teams;
        }

        public static void writeFavTeam(string code) 
        {
            File.WriteAllText(FavTeamPath, code);
        }

        public static string readFavTeam() 
        {
            try
            {

                return File.ReadAllText(FavTeamPath);
            }
            catch (Exception)
            {

                throw new Exception("Error loading favourite team");
            }
        }

        private static List<Team> getTeamsFromApi(string url) //root funkcija
        {
            var apiClient = new RestClient(url);

            var apiResult = apiClient.Execute<List<Team>>(new RestRequest());

            return JsonConvert.DeserializeObject<List<Team>>(apiResult.Content);
        }

        private static List<Team> getTeamsFromFile(string path) //root funkcija
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                List<Team> items = JsonConvert.DeserializeObject<List<Team>>(json);
                return items;
            }
        }

        public static void WriteConfigFile(string configString) //Configuration
        {
            File.WriteAllText(ConfigPath, configString);
        }

        public static bool ConfigExists() //Configuration
        {
            try
            {
                var s = File.ReadAllLines(ConfigPath);

                return s[0] != "";
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<string> ReadConfigFile() //Configuration
        {
            List<string> data = new List<string>();

            var line = File.ReadAllText(ConfigPath);

            var s = line.Split(DEL);

            for (int i = 0; i < s.Length; i++)
            {
                data.Add(s[i]);
            }
            return data;
        }

        public static bool SelectedResolutionExists() { //WPFConfigScreen

            try
            {
                File.ReadAllText(ResolutionPath);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        
        }

        public static void WriteSelectedResolution(string v) //Configuration
        {
            File.WriteAllText(ResolutionPath, v);
        }

        public static string ReadSelectedResolution() //Configuration
        {
            return File.ReadAllText(ResolutionPath);
        }
    }
}