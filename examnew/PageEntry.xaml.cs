using Npgsql;
using NpgsqlTypes;
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

namespace examnew
{
    public partial class PageEntry : Page
    {
        public PageEntry()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NpgsqlCommand cmd = Connection.GetCommand("select \"Id\",\"Login\",\"Password\",\"FirstName\",\"LastName\",\"Patronymic\", \"Role\" from \"User\"" +
                "where \"Login\" = @log and \"Password\" = @pass");
            cmd.Parameters.AddWithValue("@log", NpgsqlDbType.Varchar, tbLogin.Text.Trim());
            cmd.Parameters.AddWithValue("@pass", NpgsqlDbType.Varchar, tbPass.Text.Trim());
            NpgsqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                Connection.users = new ClassUser()
                {
                    Id = reader.GetInt32(0),
                    Login = reader.GetString(1),
                    Password = reader.GetString(2),
                    FirstName = reader.GetString(3),
                    LastName = reader.GetString(4),
                    Patronymic = reader.GetString(5),
                    Role = reader.GetString(6)
                };
            }
            reader.Close();

            switch (Connection.users.Role)
            {
                case "Админ":
                    NavigationService.Navigate(new PageAdmin());
                    break;
                case "Официант":
                    NavigationService.Navigate(new PageWiter());
                    break;
                case "Клиент":
                    NavigationService.Navigate(new PageClient());
                    break;
                case "Повар":
                    NavigationService.Navigate(new PagePovar());
                    break;
            }
        }
    }
}
