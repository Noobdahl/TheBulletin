using System.Windows;
using TheBulletin.Data;
using TheBulletin.Models;
using TheBulletin.Services;

namespace TheBulletin
{
    /// <summary>
    /// Interaction logic for SignInWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        public SignInWindow()
        {
            InitializeComponent();
            tbName.Text = "Micke";
            pbPassword.Password = "asd";
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            using (AppDbContext context = new())
            {
                UnitOfWork uow = new(context);

                //User? cUser = uow.UserRepo.LoginAuth(tbName.Text, pbPassword.Password);

                //if (cUser != null)
                //{
                //    ChatWindow chatWindow = new(cUser.UserId);
                //    chatWindow.Owner = this;
                //    chatWindow.Show();
                //    this.Hide();
                //}
                //else
                //    MessageBox.Show("User or password incorrecto!");


                User? cUser = uow.UserRepo.GetUserByName(tbName.Text);
                if (cUser != null)
                    if (cUser.Password == pbPassword.Password)
                    {
                        ChatWindow chatWindow = new(cUser.UserId);
                        chatWindow.Owner = this;
                        chatWindow.Show();
                        this.Hide();
                    }
                    else
                        MessageBox.Show("Wrong password!");
                else
                    MessageBox.Show("User not found!");
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new();
            registerWindow.Owner = this;
            registerWindow.Show();
            this.Hide();
        }
    }
}
