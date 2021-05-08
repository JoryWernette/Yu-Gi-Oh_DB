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
using System.Windows.Shapes;

namespace WpfPresentation
{
    /// <summary>
    /// Interaction logic for frmAddCard.xaml
    /// </summary>
    public partial class frmAddCard : Window
    {
        private bool _addCard = false;
        private ICardManager _cardManager = new CardManager();


        public frmAddCard()
        {
            InitializeComponent();
        }

        private void btnCancelAddCard_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
