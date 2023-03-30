﻿using Microsoft.Extensions.DependencyInjection;
using Xpto.Core.Customers;

namespace Xpto.UI.Customers
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
            this.dgvSearch.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;

            for (int i = 0; i < this.dgvSearch.Columns.Count; i++)
            {
                this.dgvSearch.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
         
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var frm = Program.ServiceProvider.GetRequiredService<FrmCustomerRegister>();
            frm.Change += CustomerChanged;
            frm.Show(this);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            this.LoadCustomers();
        }

        private void dgvSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var code = int.Parse(this.dgvSearch.SelectedRows[0].Cells[0].Value?.ToString());

            var customer = this._customerService.Get(code);
            if (customer == null)
            {
                return;
            }

            var frm = Program.ServiceProvider.GetRequiredService<FrmCustomerRegister>();
            frm.LoadCustomer(customer);
            frm.Change += CustomerChanged;

            frm.Show(this);

        }

        private void CustomerChanged(Customer customer)
        {
            this.LoadCustomers();
        }
    }
}