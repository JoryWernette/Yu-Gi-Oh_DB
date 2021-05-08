using DataObjects;
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
    /// Interaction logic for frmViewCard.xaml
    /// </summary>
    public partial class frmViewCard : Window
    {
        private Card _card;
        public frmViewCard()
        {
            InitializeComponent();
        }
        public frmViewCard(Card selectedItem)
        {
            _card = selectedItem;

            InitializeComponent();
        }

        private void btnBuyThisCard_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.tcgplayer.com/search/all/product?q=blue%20eyes%20white%20dragon");
        }

        private void btnCloseViewCard_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
