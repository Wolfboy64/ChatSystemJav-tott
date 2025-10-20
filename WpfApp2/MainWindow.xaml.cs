using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.RightsManagement;
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
using WpfApp2.Commands;
using WpfApp2.Users;


namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    //A profiledata panelt és a textblockot fel kell tölteni a Useres.User.Act adataival 2025.10.10 --> kész

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnReg.Content = "Regisztráció";
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            List<Control> controls = new List<Control>() { txtboxPwd, txtboxUsrname, lblUsr, lblPwd, btnLogin, btnReg };
            ShowOrHide(controls, false);
            RegPanel.Visibility = Visibility.Visible;
        }

        bool logged = false;

        private void Chat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && Chat.Text != null && logged)
            {
                //ha a beírt szöveg a labelen nagyobb mint this.Height akkor a label tartalmát töröljük
                if (ChatLbl.ActualHeight > this.Height - 100) { ChatLbl.Content = ""; }
                ChatLbl.Content += $"\n{Users.User.Act.ToString()}: {Chat.Text}";
                if (Chat.Text == command.help.Name)
                {
                    ChatLbl.Content += $"\n{command.help.Description}";
                    Logs.logs.SaveLog(command.help.ToString(), Users.User.Act.Name);
                }
            }
        }



        private void Btn1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {

        }
        
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            List<Control> ctr2 = new List<Control> { ChatLbl, Chat, Btn1, Btn2, Btn3 }; //logged page
            List<Control> ctr = new List<Control>() { txtboxPwd, txtboxUsrname, lblUsr, lblPwd, btnLogin, btnReg }; //login page
            if (txtboxPwd != null && txtboxUsrname != null)
            {
                // Find user by username
                Users.User existingUser = Users.User.users.FirstOrDefault(a_ => a_.Name == txtboxUsrname.Text);
                if (existingUser != null && existingUser.Password == txtboxPwd.Text)
                {
                    // Successful login
                    Users.User.Act = existingUser;
                    Users.User.RoleCheck();



                    ShowOrHide(ctr, false);
                    ShowOrHide(ctr2, true);



                    logged = true;
                    Panelprofiledata.Visibility = Visibility.Visible;
                    Hud();

                    
                }
                else
                {
                    // Invalid login
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
        
        private void Hud()
        {
            Hudlbl.Content = $"Név: {Users.User.Act.Name}\nID: {Users.User.Act.Id}\nRang: {Users.User.Act.Roll}" +
                $"\nUtoljára küldött üzenet: "; //+ utolsó üzenet szövege
        }
        private void ShowOrHide(List<Control> s, bool IsShow) 
        {
            if (s.Count > 0) 
            {
                if (IsShow == false)
                {
                    for (int i = 0; i < s.Count; i++)
                    {
                        s[i].Visibility = Visibility.Hidden;
                    }
                }
                else if (IsShow == true) 
                {
                    for (int i = 0; i < s.Count; i++)
                    {
                        s[i].Visibility = Visibility.Visible;
                    }
                }
            }
        }
        private void btnRegPan_Click(object sender, RoutedEventArgs e) 
        {
            
            List<Control> ctr = new List<Control>() { txtboxPwd, txtboxUsrname, lblUsr, lblPwd, btnLogin, btnReg };
            string x = txtRegPanUsr.Text;
            string y = txtRegPanPwd1.Text;
            string z = txtRegPanPwd2.Text;
            if ((x != null && y != null && z != null) && (y == z))
            {
                Users.User newUser = new Users.User(User.users.Count + 1, x, y, Roles.Role.r2);


                Users.User.users.Add(newUser);
                MessageBox.Show("Sikeres regisztráció!");
                Logs.logs.SaveLog("Regisztráció", newUser.Name);
                ShowOrHide(ctr, true);
                RegPanel.Visibility = Visibility.Hidden;
                Users.User.SaveUsersToFile();

                Panel1();
            }
            
            
        }
        
        private async void Panel1() 
        {   
            
            NotiPanel.Visibility = Visibility.Visible;
            NotiPanel.Background = new SolidColorBrush(Colors.Green);
            NotiLbl.Content = Users.notific.Noti.SearchNoti(3);
            //NotiImg.Source = new BitmapImage(new Uri($"C:\\Users\\Richárd\\source\\repos\\WpfApp2\\WpfApp2\\Users\\notific\\Notipic\\error.png", UriKind.Relative));
            BitmapImage img = new BitmapImage();
            string relativePath = System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                @"C:\Users\Richárd\source\repos\WpfApp2\WpfApp2\Users\notific\Notipic\checkmark.png"
            );
            NotiImg.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath(relativePath)));
            await Task.Delay(1000);
            Panel2();
        }
        private async void Panel2() 
        {
            await Task.Delay(5000); // 5 másodperc késleltetés
            NotiPanel.Visibility = Visibility.Hidden;
            
        }
    }
}
