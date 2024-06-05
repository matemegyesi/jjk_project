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
using System.Windows.Navigation;
using System.Windows.Shapes;
using jjkLib;
using System.IO;
using System.Diagnostics;

namespace jjkWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] sLines;
        string[] cLines;
        string[] bLines;
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            sLines = File.ReadAllLines("sorcerers.csv");
            cLines = File.ReadAllLines("curses.csv");
            bLines = File.ReadAllLines("battles.csv");

            Jujutsu.InitSorceres(Sorcerers());
            Jujutsu.InitCurses(Curses());
            Jujutsu.InitBattles(Battles());
        }
        IEnumerable<Sorcerer> Sorcerers()
        {
            foreach (var line in sLines)
                yield return Factory.CreateSorcerer(line);
        }
        IEnumerable<Curse> Curses()
        {
            foreach (var line in cLines)
                yield return Factory.CreateCurse(line);
        }
        IEnumerable<Battle> Battles()
        {
            foreach (var line in bLines)
                yield return Factory.CreateBattle(line);
        }
        private void LoadCurses()
        {
            secondBox.Items.Clear();
            foreach (var n in Jujutsu.CurseNames)
                secondBox.Items.Add(new ComboBoxItem() { Content = n });
        }
        private void LoadSorcerers()
        {
            secondBox.Items.Clear();
            foreach (var n in Jujutsu.SorcererNames)
                secondBox.Items.Add(new ComboBoxItem() { Content = n });
        }

        private void firstBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string choise = (firstBox.SelectedValue as ComboBoxItem).Content.ToString();
            if (choise == "Sorcerer")
                LoadSorcerers();
            else if(choise == "Curse")
                LoadCurses();
            /*name.Content = "";
            grade.Content = "";
            age.Content = "";
            ct.Content = "";
            cea.Content = "";
            cude.Content = "";
            domain.Content = "";*/
        }

        private void secondBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (secondBox.SelectedValue == null) return;
            string choise = (secondBox.SelectedValue as ComboBoxItem).Content.ToString();
            if((firstBox.SelectedValue as ComboBoxItem).Content.ToString() == "Sorcerer")
            {
                Sorcerer character = (Sorcerer)Jujutsu.Get(choise);
                name.Content = "Name: " + character.Name;
                grade.Content = "Grade: " + character.Grade.ToString();
                age.Content = "Age: " + character.Age.ToString();
                ct.Content = "Cursed technique: " + character.CursedTechnique;
                cea.Content = "Cursed energy amount: " + character.CursedEnergyAmount.ToString();
                cude.Content = "Can use domain expansion? " + (character.CanUseDomainExpansion ? "Yes" : "No");
                domain.Content = "Domain name: " + (character.CanUseDomainExpansion ? character.DomainName : "Has no domain");
                Debug.WriteLine("Sorc---------");
            }
            else
            {
                Curse character = (Curse)Jujutsu.Get(choise);
                name.Content = "Name: " + character.Name;
                grade.Content = "Grade: " + character.Grade.ToString();
                age.Content = "Birth emotion: " + character.BirthEmotion.ToString();
                ct.Content = "Cursed technique: " + character.CursedTechnique;
                cea.Content = "Cursed energy amount: " + character.CursedEnergyAmount.ToString();
                cude.Content = "Can use domain expansion? " + (character.CanUseDomainExpansion ? "Yes" : "No");
                domain.Content = "Domain name: " + (character.CanUseDomainExpansion ? character.DomainName : "Has no domain");
                Debug.WriteLine("Curs++++++++");
            }
        }
    }
}
