using System.Windows;
using TheBulletin.Data;
using TheBulletin.Models;
using TheBulletin.Services;

namespace TheBulletin
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            User nUser = new()
            {
                Name = tbName.Text,
                Password = pbPassword.Password,
                IsAdmin = false
            };

            using (AppDbContext context = new())
            {
                UnitOfWork uow = new(context);
                uow.UserRepo.AddUser(nUser);
                uow.SaveChanges();
                this.Owner.Show();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}
