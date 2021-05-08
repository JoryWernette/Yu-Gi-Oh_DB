using DataObjects;
using LogicLayer;
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

namespace WpfPresentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IUserManager _userManager = new UserManager();
        private ICardManager _cardManager = new CardManager();
        private User _user = null;
        private bool _cardUpdated = false;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnLogin_Click_1(object sender, RoutedEventArgs e)
        { // logic to check whether this is a login or logout
            if ((string)btnLogin.Content == "Login")
            {
                try
                {
                    _user = _userManager.AuthenticateUser(txtUserName.Text, pwdPassword.Password);
                    //  MessageBox.Show(_user.FirstName + " logged in successfully.");

                    btnLogin.Content = "Logout";
                    txtUserName.Text = "";

                    if (pwdPassword.Password == "newuser")
                    {
                        var updatePassword = new frmUpdatePassword(_user, _userManager, true);

                        // if the person doesn't change the password, log them out
                        if (!updatePassword.ShowDialog() == true)
                        {
                            resetWindow();
                            _user = null;
                            return;
                        }
                    }

                    btnLogin.IsDefault = false;
                    pwdPassword.Password = "";
                    txtUserName.Visibility = Visibility.Hidden;
                    lblUserName.Visibility = Visibility.Hidden;
                    pwdPassword.Visibility = Visibility.Hidden;
                    lblPassword.Visibility = Visibility.Hidden;
                    sbarItemMessage.Content = "";


                    mnuMain.IsEnabled = true;
                    showUserTabs();


                    lblGreeting.Content = "Welcome back, " + _user.FirstName + " "
                        + _user.LastName;
                    if (_user.Roles.Count > 0)
                    {
                        var roleString = _user.Roles[0];
                        for (int i = 1; i < _user.Roles.Count; i++)
                        {
                            roleString += ", " + _user.Roles[i];
                        }

                        lblRoles.Content = "You are logged in as a: " + roleString;
                    }
                    else
                    {
                        lblRoles.Content = "You have not yet been assigned a role.";
                    }
                }
                catch (Exception ex)
                {
                    pwdPassword.Clear();
                    txtUserName.Clear();
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                    txtUserName.Focus();
                }
            }
            else // button says Logout
            {
                _user = null;

                resetWindow();
                btnLogin.IsDefault = true;


            }

        }
        private void hideAllTabs()
        {
            foreach (TabItem t in tabSetMain.Items)
            {
                t.Visibility = Visibility.Collapsed;
            }
            grdJudge.Visibility = Visibility.Hidden;
            grdPlayer.Visibility = Visibility.Hidden;
        }
        private void showUserTabs()
        {
            // loop through the user's roles
            foreach (var r in _user.Roles)
            {
                switch (r)
                {
                    case "Player":
                        grdPlayer.Visibility = Visibility.Visible;
                        tabPlayer.Visibility = Visibility.Visible;
                        //btnAddCard.Visibility = Visibility.Hidden;
                        //btnEditCard.Visibility = Visibility.Hidden;
                        tabPlayer.IsSelected = true;
                        break;
                    case "Judge":
                        grdJudge.Visibility = Visibility.Visible;
                        tabJudge.Visibility = Visibility.Visible;
                        //btnAddCard.Visibility = Visibility.Visible;
                        //btnEditCard.Visibility = Visibility.Visible;
                        tabJudge.IsSelected = true;
                        break;
                    default:
                        break;
                }
            }
        }
        private void resetWindow()
        {
            btnLogin.IsDefault = true;
            hideAllTabs();
            mnuMain.IsEnabled = false;
            txtUserName.Text = "";
            pwdPassword.Password = "";
            btnLogin.Content = "Login";
            lblGreeting.Content = "Hello Duelist.";
            lblRoles.Content = "You are not logged in.";
            txtUserName.Visibility = Visibility.Visible;
            lblUserName.Visibility = Visibility.Visible;
            pwdPassword.Visibility = Visibility.Visible;
            lblPassword.Visibility = Visibility.Visible;
            sbarItemMessage.Content = "Please login to continue.";

            // new closeout code
            dgUserList.ItemsSource = null;

            txtUserName.Focus();
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            resetWindow();
        }
        private void mnuItemUpdatePassword_Click(object sender, RoutedEventArgs e)
        {
            if (_user != null)
            {
                var updatePassword = new frmUpdatePassword(_user, _userManager);
                updatePassword.ShowDialog();
            }
            else
            {
                MessageBox.Show("You are not logged in.");
            }
        }
        private void tabJudge_GotFocus_1(object sender, RoutedEventArgs e)
        {
            if (((TabItem)sender).Visibility == Visibility.Visible)
            {
                try
                {
                    var playerManager = new PlayerManager();

                    if (dgUserList.ItemsSource == null)
                    {
                        dgUserList.ItemsSource = playerManager.RetrievePlayersByActive();

                        dgUserList.Columns.Remove(dgUserList.Columns[0]);
                        dgUserList.Columns[0].Header = "Konami ID";
                        dgUserList.Columns[1].Header = "Email Address";
                        dgUserList.Columns[2].Header = "First Name";
                        dgUserList.Columns[3].Header = "Last Name";
                        dgUserList.Columns[4].Header = "Phone Number";
                        dgUserList.Columns.Remove(dgUserList.Columns[5]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }
            }

        }
        private void dgUserList_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            editPlayer();
        }

        private void editPlayer()
        {
            var selectedItem = (PlayerViewModel)dgUserList.SelectedItem;
            if (selectedItem == null)
            {
                return;
            }

            // test to see if this is working
            // MessageBox.Show(selectedItem.KonamiID.ToString());

            var addEditWindow = new frmPlayerDetailAddEdit(selectedItem);
            if (addEditWindow.ShowDialog() == true)
            {
                var playerManager = new PlayerManager();
                dgUserList.ItemsSource =
                    playerManager.RetrievePlayersByActive((bool)chkShowActive.IsChecked);

                dgUserList.Columns.Remove(dgUserList.Columns[0]);
                dgUserList.Columns[0].Header = "Konami ID";
                dgUserList.Columns[1].Header = "Email Address";
                dgUserList.Columns[2].Header = "First Name";
                dgUserList.Columns[3].Header = "Last Name";
                dgUserList.Columns[4].Header = "Phone Number";
                dgUserList.Columns.Remove(dgUserList.Columns[5]);
            }
        }
        private void chkShowActive_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var playerManager = new PlayerManager();
                dgUserList.ItemsSource =
                    playerManager.RetrievePlayersByActive((bool)chkShowActive.IsChecked);

                dgUserList.Columns.Remove(dgUserList.Columns[0]);
                dgUserList.Columns[0].Header = "Konami ID";
                dgUserList.Columns[1].Header = "Email Address";
                dgUserList.Columns[2].Header = "First Name";
                dgUserList.Columns[3].Header = "Last Name";
                dgUserList.Columns[4].Header = "Phone Number";
                dgUserList.Columns.Remove(dgUserList.Columns[5]);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }
        private void btnEdit_Click_1(object sender, RoutedEventArgs e)
        {
            var selectedItem = (PlayerViewModel)dgUserList.SelectedItem;
            if (selectedItem == null)
            {
                MessageBox.Show("You need to select a player to edit!", "Invalid Operation",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            editPlayer();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var addEditWindow = new frmPlayerDetailAddEdit();
            if (addEditWindow.ShowDialog() == true)
            {
                var playerManager = new PlayerManager();
                dgUserList.ItemsSource =
                    playerManager.RetrievePlayersByActive((bool)chkShowActive.IsChecked);

                dgUserList.Columns.Remove(dgUserList.Columns[0]);
                dgUserList.Columns[0].Header = "Konami ID";
                dgUserList.Columns[1].Header = "Email Address";
                dgUserList.Columns[2].Header = "First Name";
                dgUserList.Columns[3].Header = "Last Name";
                dgUserList.Columns[4].Header = "Phone Number";
                dgUserList.Columns.Remove(dgUserList.Columns[5]);
            }
        }
        private void tabPlayer_GotFocus(object sender, RoutedEventArgs e)
        {
            if (((TabItem)sender).Visibility == Visibility.Visible)
            {

                try
                {
                    if (dgCardsAvailable.ItemsSource == null || _cardUpdated == true)
                    {
                        dgCardsAvailable.ItemsSource = _cardManager.RetreiveAllCards();

                        dgCardsAvailable.Columns[0].Header = "Card ID";
                        dgCardsAvailable.Columns[1].Header = "Card Name";
                        dgCardsAvailable.Columns[2].Header = "Card Category";
                        dgCardsAvailable.Columns[3].Header = "Card Type";
                        dgCardsAvailable.Columns[4].Header = "Monster Type";
                        dgCardsAvailable.Columns[5].Header = "Monster SubType";
                        dgCardsAvailable.Columns[6].Header = "Monster Attribute";
                        dgCardsAvailable.Columns[7].Header = "Level / Rank";
                        dgCardsAvailable.Columns[8].Header = "Attack";
                        dgCardsAvailable.Columns[9].Header = "Defense";
                        dgCardsAvailable.Columns[10].Header = "Pendulum Scale";
                        dgCardsAvailable.Columns[11].Header = "Link Number";
                        dgCardsAvailable.Columns[12].Header = "Banlist Placement";
                        dgCardsAvailable.Columns[13].Header = "Card Text";
                        _cardUpdated = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }
            }
        }
        private void dgCardsAvailable_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            viewCard();
        }

        private void viewCard()
        {

            var viewCardWindow = new frmViewCard();
            viewCardWindow.Show();
            /*
            if (addEditWindow.ShowDialog() == true)
            {
                var playerManager = new PlayerManager();
                dgUserList.ItemsSource =
                    playerManager.RetrievePlayersByActive((bool)chkShowActive.IsChecked);

                dgUserList.Columns.Remove(dgUserList.Columns[0]);
                dgUserList.Columns[0].Header = "Konami ID";
                dgUserList.Columns[1].Header = "Email Address";
                dgUserList.Columns[2].Header = "First Name";
                dgUserList.Columns[3].Header = "Last Name";
                dgUserList.Columns[4].Header = "Phone Number";
                dgUserList.Columns.Remove(dgUserList.Columns[5]);
            }
            /*
            var selectedItem = (Card)dgUserList.SelectedItem;
            if (selectedItem == null)
            {
                return;
            }

            // test to see if this is working
            // MessageBox.Show(selectedItem.EmployeeID.ToString());

            var viewCardWindow = new frmViewCard(selectedItem);
            if (viewCardWindow.ShowDialog() == true)
            {
                /*
                Uri resourceUri = new Uri("/images/Blank_Normal_Monster.jpg", UriKind.Relative);
                imgDynamic.Source = new BitmapImage(resourceUri);

                
                var img = new Image { Width = 100, Height = 300 };
                var bitmapImage = new BitmapImage
                    (new Uri("C:/Users/jorya/OneDrive/Desktop/Kirkwood/NET DEV 2/ygo_db_project/Yu-Gi-Oh_DB/Yu-Gi-Oh_DB/Blank_Normal_Monster_NamePlate.jpg"));
                img.Source = bitmapImage;
                img.SetValue(Grid.RowProperty, 1);
                img.SetValue(Grid.ColumnProperty, 1);
                grdViewImage.Children.Add(img);
                

            }
        */
        }

    private void UpdateACardsBanlistPlacement(string newBanlistPlacement, string oldBanlistPlacement, Card card)
        {
           string message = "Mark card " + card.CardName.ToString() + " '" +
               newBanlistPlacement + ".' Are you sure?";

           MessageBoxResult result = MessageBox.Show(message, "Update Banlist Placement",
               MessageBoxButton.YesNo, MessageBoxImage.Question);

           if (result == MessageBoxResult.Yes)
           {
               try
               {
                   _cardManager.EditCardBanlistPlacement(card.CardID, oldBanlistPlacement, newBanlistPlacement);
                   _cardUpdated = true;
               }
               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
               }
           }
        }

        private void btnAddCard_Click(object sender, RoutedEventArgs e)
        {
            var addCardWindow = new frmAddCard();
            addCardWindow.Show();
        }

        private void btnDeleteCard_Click(object sender, RoutedEventArgs e)
        {
            var checkDeleteCardWindow = new frmDeleteCard();
            checkDeleteCardWindow.Show();
        }
    }
}

