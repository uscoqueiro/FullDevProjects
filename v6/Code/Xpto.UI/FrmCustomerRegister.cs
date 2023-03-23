using System;
using Xpto.Core.Customers;
using Xpto.Core.Shared.Functions;

namespace Xpto.UI
{
    public partial class FrmCustomerRegister : Form
    {
        private readonly ICustomerService _customerService;
        private Customer _customer = new Customer();

        public FrmCustomerRegister(ICustomerService customerService)
        {
            _customerService = customerService;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var msg = MessageBox.Show("Salvar Cliente?", "Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg != DialogResult.Yes) { return; }

                _customer.Name = this.txtName.Text;
                _customer.Nickname = this.txtNickname.Text;
                _customer.Identity = this.txtIdentity.Text;
                _customer.Note = this.txtNote.Text;
                _customer.BirthDate = GlobalFunction.GetIsoDateTime(this.dtpBirthDate.Text);
                _customer.PersonType = this.cboPersonType.Text;


                if (_customer.Code == 0)
                {
                    _customer = this._customerService.Create(_customer);
                }
                else
                {
                    _customer = this._customerService.Update(_customer);
                }
 

                MessageBox.Show("Cliente cadastrado com sucesso!", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
