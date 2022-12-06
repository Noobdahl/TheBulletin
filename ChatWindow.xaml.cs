using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TheBulletin.Data;
using TheBulletin.Models;
using TheBulletin.Services;

namespace TheBulletin
{
    /// <summary>
    /// Interaction logic for ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        User? cUser;
        int cRoomId;
        public ChatWindow(int userId)
        {
            InitializeComponent();
            tbMessageBox.Text += "You are not currently in any room!";
            UpdateUi();

            using (AppDbContext context = new())
            {
                UnitOfWork uow = new(context);
                cUser = uow.UserRepo.GetUserById(userId);
            }
            lblUserLoggedIn.Content += "\n" + cUser?.Name;
        }

        private void UpdateUi()
        {
            lvChatRooms.Items.Clear();

            //Loading list of chatrooms
            using (AppDbContext context = new())
            {
                UnitOfWork uow = new(context);

                List<Room> rooms = uow.ChatRepo.GetAllRooms();
                foreach (Room room in rooms)
                {
                    lvChatRooms.Items.Add(new ListViewItem() { Tag = room, Content = room.Name });
                }
            }



        }

        private void tbMessage_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string msg = tbMessage.Text.Trim();
            if (msg.Count() <= 0)
            {
                btnSendMsg.IsDefault = false;
                btnSendMsg.Visibility = Visibility.Hidden;
            }
            else
            {
                btnSendMsg.IsDefault = true;
                btnSendMsg.Visibility = Visibility.Visible;
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void btnSendMsg_Click(object sender, RoutedEventArgs e)
        {
            string msg = tbMessage.Text.Trim();
            if (cRoomId == 0)
            {
                AddMsgToBox("Failed to deliver message: '" + msg + "'\n\nJoin a room to start chatting ->");
                tbMessage.Text = "";
                return;
            }
            Message message = new()
            {
                UserId = cUser.UserId,
                Msg = msg,
                RoomId = cRoomId,
                Time = DateTime.Now
            };

            using (AppDbContext context = new())
            {
                UnitOfWork uow = new(context);
                uow.ChatRepo.AddMessage(message);
                uow.SaveChanges();
            }
            AddMsgToBox($"({message.Time.ToString("HH:mm:ss")}) {cUser.Name}: {msg}");
            tbMessage.Text = "";
        }

        private void lvChatRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Room cRoom = ((Room)((ListViewItem)lvChatRooms.SelectedItem).Tag);
            AddMsgToBox("\nYou have joined: " + cRoom.Name);
            cRoomId = cRoom.RoomId;

            using (AppDbContext context = new())
            {
                UnitOfWork uow = new(context);
                List<Message> messages = uow.ChatRepo.GetAllMessagesByRoom(cRoomId);
                foreach (Message msg in messages)
                {
                    User? author = uow.UserRepo.GetUserById(msg.UserId);
                    AddMsgToBox($"({msg.Time.ToString("HH:mm:ss")}) {author.Name}: {msg.Msg}");
                }
            }

        }
        private void AddMsgToBox(string msg)
        {
            //Ny text överst:
            //tbMessageBox.Text = msg + "\n" + tbMessageBox.Text;

            //Ny text underst:
            tbMessageBox.Text += "\n" + msg;
        }

        private void tbMessageBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbMessageBox.ScrollToEnd();
        }
    }
}
