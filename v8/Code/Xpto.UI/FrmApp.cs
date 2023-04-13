using Microsoft.Extensions.DependencyInjection;
using Xpto.UI.Customers;

namespace Xpto.UI
{
    public partial class FrmApp : Form
    {
        public FrmApp()
        {
            InitializeComponent();
        }
 
        private void tsmCustomerSearch_Click(object sender, EventArgs e)
        {
            //var frm = new FrmCustomerSearch();
            //frm.Show(this);

            var frm = Program.ServiceProvider.GetRequiredService<FrmCustomerSearch>();
            frm.Show(this);
            frm.Success += this.Frm_Success;

            //this._frmSearch.Show();
        }

        private void Frm_Success(string message)
        {
           this.lblMessage.Text = message;
        }
    }



}