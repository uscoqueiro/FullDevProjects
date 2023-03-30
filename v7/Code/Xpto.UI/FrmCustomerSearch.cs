using Microsoft.Extensions.DependencyInjection;
using System.Data;
using Xpto.Core.Customers;
using Xpto.Services.Customers;

namespace Xpto.UI
{
    public partial class FrmCustomerSearch : Form
    {
        private readonly ICustomerService _customerService;

        public FrmCustomerSearch(ICustomerService customerService)
        {
            _customerService = customerService;
            InitializeComponent();
        }

        private void FrmCustomerSearch_Load(object sender, EventArgs e)
        {
            this.LoadCustomers();
        }

        private void LoadCustomers()
        {
            var dt = this._customerService.LoadDataTable();
            this.dgvSearch.DataSource = dt;

            lvwSearch.Columns.Clear();
            lvwSearch.Items.Clear();

            foreach (var col in dt.Columns)
            {
                lvwSearch.Columns.Add(col.ToString());
            }

            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());

                lvwSearch.Items.Add(item);

                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    item.SubItems.Add(row[i].ToString());
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var frm = Program.ServiceProvider.GetRequiredService<FrmCustomerRegister>();
            frm.Show(this);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            this.LoadCustomers();
        }
    }
}
