using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Логика взаимодействия для PAuth.xaml
    /// </summary>
    public partial class PAuth : Page
    {
        public PAuth()
        {
            InitializeComponent();
        }

        private void BTN_Log_In_Click(object sender, RoutedEventArgs e)
        {
            string login = TB_Login.Text;
            string password = PB_Password.Password;

            if(string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                ShowError("Пожалуйста, введите все поля!");
                return;
            }

            Client loginClient = DataBase.entities.Clients.FirstOrDefault(x => x.LoginClient == login
            && x.PasswordClient == password);

            Employee loginEmployee = DataBase.entities.Employees.FirstOrDefault(x => x.LoginEmployee == login
            && x.PasswordEmployee == password);

            if (loginClient == null && loginEmployee == null)
            {
                ShowError("Неверные данные!");
            }
            else if (loginClient != null)
            {
                NavigationService.Navigate(new MainPage());
                MessageBox.Show($"Вы вошли как клиент");
            }
            else if (loginEmployee != null)
            {
                NavigationService.Navigate(new MainPage());
                MessageBox.Show($"Вы вошли как сотрудник: {loginEmployee.SurnameEmployee} " +
                    $"{loginEmployee.NameEmployee[0]}.{loginEmployee.MiddleNameEmployee[0]}.");
            }
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
