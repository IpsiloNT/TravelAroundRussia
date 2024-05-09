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
using TravelAroundRussia.Entities;

namespace TravelAroundRussia.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            LV_Tours.ItemsSource = DataBase.entities.Tours.OrderBy(tours => tours.NameTour).ToList();

            List<Entities.Type> types = new List<Entities.Type>();
            types.Add(new Entities.Type(){ NameType = "Все типы" });
            types.AddRange(DataBase.entities.Types.OrderBy(type => type.NameType));

            CB_Filter.ItemsSource = types;
        }

        private void CHB_Is_Actual_Checked(object sender, RoutedEventArgs e)
        {
            LV_Tours.ItemsSource = DataBase.entities.Tours.OrderBy(t => t.NameTour).Where(t => t.IsActual == true).ToList();
        }

        private void CHB_Is_Actual_Unchecked(object sender, RoutedEventArgs e)
        {
            LV_Tours.ItemsSource = DataBase.entities.Tours.OrderBy(t => t.NameTour).ToList();
        }

        private void CB_Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CB_Filter.SelectedItem != null || ((Entities.Type)CB_Filter.SelectedItem).IDType == 0)
            {
                LV_Tours.ItemsSource = DataBase.entities.Tours.OrderBy(t => t.NameTour).ToList();
                return;
            }
            else
            {
                int selectedTypeId = ((Entities.Type)CB_Filter.SelectedItem).IDType;
                var filteredType = DataBase.entities.Types.OrderBy(t => t.NameType).Where(t => t.IDType == selectedTypeId).ToList();
                LV_Tours.ItemsSource = filteredType;
            }
        }

        private void TB_Find_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TB_Find.Text != "")
            {
                LV_Tours.ItemsSource = DataBase.entities.Tours.OrderBy(t => t.NameTour).Where(c => c.NameTour.ToLower().Contains(TB_Find.Text)).ToList();
            }
            else if (TB_Find.Text == "")
            {
                LV_Tours.ItemsSource = DataBase.entities.Tours.OrderBy(t => t.NameTour).ToList();
                return;
            }
        }

        private void RefreshTours()
        {

        }
    }
}
