using Xpto.UI.Customers;

namespace Xpto.UI
{
    public partial class App : Form
    {
        public App()
        {
            InitializeComponent();
        }
 
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            var frm = new CustomerSearch();
            frm.Show();
        }
    }
}