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
using System.Windows.Shapes;
using DataObjects;
using LogicLayer;

namespace WpfPresentation
{
    /// <summary>
    /// Interaction logic for frmPlayerDetailAddEdit.xaml
    /// </summary>
    public partial class frmPlayerDetailAddEdit : Window
    {
        // these two fields preserve the player's original state
        private PlayerViewModel _player;
        private List<string> _originalUnassignedRoles = new List<string>();


        private bool _addUser = false;
        private IPlayerManager _playerManager = new PlayerManager();
        
        // these two fields hold changes from the original state
        private List<string> _assignedRoles;
        private List<string> _unassignedRoles;

        public frmPlayerDetailAddEdit()
        {
            _player = new PlayerViewModel();
            _addUser = true;

            InitializeComponent();
        }
        public frmPlayerDetailAddEdit(PlayerViewModel player)
        {
            _player = player;

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (_addUser)
            {
                // display blank user
                //txtPlayerID.Text = "";
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtEmail.Text ="";
                txtPhoneNumber.Text = "";
                chkActive.IsChecked = true;
                
                try     // set up the roles boxes
                {
                    // this sets the roles for the listbox items source (starts with none)
                    _assignedRoles = new List<string>();
                    // this holds the unassigned roles (starts with all roles)
                    _unassignedRoles = _playerManager.RetrieveAllRoles();

                    lstAssignedRoles.ItemsSource = _assignedRoles;
                    lstUnassignedRoles.ItemsSource = _unassignedRoles;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }
                setupEdit();
                chkActive.IsEnabled = false;

            }
            else // display existing user
            {
                txtKonamiID.Text = _player.KonamiID.ToString();
                txtFirstName.Text = _player.FirstName;
                txtLastName.Text = _player.LastName;
                txtEmail.Text = _player.Email;
                txtPhoneNumber.Text = _player.PhoneNumber;
                chkActive.IsChecked = _player.Active;

                resetRoles();
            }
        }

        private void resetRoles()
        {
            try
            {
                // this sets the roles for the listbox items source
                _assignedRoles = _playerManager.RetreiveRolesByKonamiID(_player.KonamiID);
                // this preserves the original roles for the player being edited
                _player.Roles = new List<string>();
                foreach (var r in _assignedRoles)
                {
                    _player.Roles.Add(r);
                }

                _unassignedRoles = _playerManager.RetrieveAllRoles();

                // this preserves the unassigned roles for convenience
                foreach (var role in _assignedRoles)
                {
                    _unassignedRoles.Remove(role);
                }
                foreach (var r in _unassignedRoles)
                {
                    _originalUnassignedRoles.Add(r);
                }

                lstAssignedRoles.ItemsSource = _assignedRoles;
                lstUnassignedRoles.ItemsSource = _unassignedRoles;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        private void btnEditSave_Click(object sender, RoutedEventArgs e)
        {
            if (((string)btnEditSave.Content) == "Edit")
            {
                setupEdit();
            }
            else // save
            {
                // are we saving an edited player, or a new one
                if (_addUser == false)
                {

                    if (!txtFirstName.Text.IsValidFirstName())
                    {
                        MessageBox.Show("Invalid First Name.");
                        txtFirstName.Focus();
                        txtFirstName.SelectAll();
                        return;
                    }
                    if (!txtLastName.Text.IsValidLastName())
                    {
                        MessageBox.Show("Invalid Last Name.");
                        txtLastName.Focus();
                        txtLastName.SelectAll();
                        return;
                    }
                    if (!txtEmail.Text.IsValidEmail())
                    {
                        MessageBox.Show("Bad email address.");
                        txtEmail.Focus();
                        txtEmail.SelectAll();
                        return;
                    }
                    if (!txtPhoneNumber.Text.IsValidPhoneNumber())
                    {
                        MessageBox.Show("Invalid Phone Number.");
                        txtPhoneNumber.Focus();
                        txtPhoneNumber.SelectAll();
                        return;
                    }

                    var newPlayer = new PlayerViewModel()
                    {
                        Email = txtEmail.Text,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        PhoneNumber = txtPhoneNumber.Text,
                        Active = (bool)chkActive.IsChecked
                    };
                    List<string> roles = new List<string>();
                    foreach (var item in lstAssignedRoles.Items)
                    {
                        roles.Add((string)item);
                    }
                    newPlayer.Roles = roles;

                    try
                    {
                        _playerManager.EditPlayerProfile(_player, newPlayer,
                            _originalUnassignedRoles, _unassignedRoles);
                        this.DialogResult = true;
                    }
                    catch (Exception ex)
                    {
                        resetRoles();
                        if (ex.InnerException.Message.Contains("deactivated"))
                        {
                            chkActive.IsChecked = true;
                        }
                        MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                    }
                }
                else // _addUser == true, so this needs to invoke an add method
                {
                    if (!txtFirstName.Text.IsValidFirstName())
                    {
                        MessageBox.Show("Invalid First Name.");
                        txtFirstName.Focus();
                        txtFirstName.SelectAll();
                        return;
                    }
                    if (!txtLastName.Text.IsValidLastName())
                    {
                        MessageBox.Show("Invalid Last Name.");
                        txtLastName.Focus();
                        txtLastName.SelectAll();
                        return;
                    }
                    if (!txtEmail.Text.IsValidEmail())
                    {
                        MessageBox.Show("Bad email address.");
                        txtEmail.Focus();
                        txtEmail.SelectAll();
                        return;
                    }
                    if (!txtPhoneNumber.Text.IsValidPhoneNumber())
                    {
                        MessageBox.Show("Invalid Phone Number.");
                        txtPhoneNumber.Focus();
                        txtPhoneNumber.SelectAll();
                        return;
                    }

                    var newPlayer = new PlayerViewModel()
                    {
                        //KonamiID = txtKonamiID.ToString().Text,
                        Email = txtEmail.Text,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        PhoneNumber = txtPhoneNumber.Text,
                        Active = (bool)chkActive.IsChecked
                    };
                    List<string> roles = new List<string>();
                    foreach (var item in lstAssignedRoles.Items)
                    {
                        roles.Add((string)item);
                    }
                    newPlayer.Roles = roles;

                    try
                    {
                        _playerManager.AddNewPlayer(newPlayer);
                        this.DialogResult = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                    }
                }
            }
        }

        private void setupEdit()
        {
            btnEditSave.Content = "Save";
            txtFirstName.IsReadOnly = false;
            txtLastName.IsReadOnly = false;
            txtEmail.IsReadOnly = false;
            txtPhoneNumber.IsReadOnly = false;
            chkActive.IsEnabled = true;
            lstAssignedRoles.IsEnabled = true;
            lstUnassignedRoles.IsEnabled = true;
            txtFirstName.BorderBrush = Brushes.Black;
            txtLastName.BorderBrush = Brushes.Black;
            txtEmail.BorderBrush = Brushes.Black;
            txtPhoneNumber.BorderBrush = Brushes.Black;
            txtFirstName.Focus();
        }

        private void lstAssignedRoles_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedRole = lstAssignedRoles.SelectedItem;
            _assignedRoles.Remove((string)selectedRole);
            _unassignedRoles.Add((string)selectedRole);

            lstAssignedRoles.ItemsSource = null;
            lstUnassignedRoles.ItemsSource = null;

            lstAssignedRoles.ItemsSource = _assignedRoles;
            lstUnassignedRoles.ItemsSource = _unassignedRoles;
        }

        private void lstUnassignedRoles_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedRole = lstUnassignedRoles.SelectedItem;
            _unassignedRoles.Remove((string)selectedRole);
            _assignedRoles.Add((string)selectedRole);

            lstAssignedRoles.ItemsSource = null;
            lstUnassignedRoles.ItemsSource = null;

            lstAssignedRoles.ItemsSource = _assignedRoles;
            lstUnassignedRoles.ItemsSource = _unassignedRoles;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
