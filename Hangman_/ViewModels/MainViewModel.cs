using Hangman_.Commands;
using Hangman_.DAL;
using Hangman_.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hangman_.ViewModels
{
    public class MainViewModel : BaseViewModel 
    {
        private static MainViewModel _instance;

        public BaseViewModel CurrentViewModel { get; set; } = new StartViewModel();

        public static MainViewModel Instance { get => _instance ?? (_instance = new MainViewModel()); }

        public ICommand StartGameCommand { get; set; }

        DbRepository db = new();

        public string RandomWord { get; set; }

        public List<string> WordsByTheme { get; private set; }


        public MainViewModel()
        {
            StartGameCommand = new RelayCommand(chosenTheme => StartGame(chosenTheme));
        }

        public void StartGame(object chosenTheme)
        {
            GetRandomWordByTheme(chosenTheme.ToString());
            MainViewModel.Instance.CurrentViewModel = new GameViewModel(RandomWord);
        }


        public async void GetRandomWordByTheme(string chosenTheme)
        {
            WordsByTheme = (List<string>)await db.GetListFromChosenTheme(chosenTheme);

            Random random = new Random();
            int randomIndex = random.Next(0, WordsByTheme.Count());
            RandomWord = WordsByTheme[randomIndex];
        }
    }
}
