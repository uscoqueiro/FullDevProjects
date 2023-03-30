using System;
using System.Text;
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
            this.Save();
        }

        private void Save()
        {
            if (this._customer.Code == 0)
                this.Create();
            else
                this.Update();
        }

        private void Create()
        {
            try
            {
                var msg = MessageBox.Show("Cadastrar Cliente?", "Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg != DialogResult.Yes)
                {
                    return;
                }

                var customerParams = new CustomerCreateParams(this.txtName.Text)
                {
                    Nickname = this.txtNickname.Text,
                    Identity = this.txtIdentity.Text,
                    Note = this.txtNote.Text,
                    BirthDate = GlobalFunction.GetIsoDateTime(this.dtpBirthDate.Text),
                    PersonType = this.cboPersonType.Text
                };

               var result = this._customerService.Create(customerParams);
                if (this._customerService.Messages.Count > 0)
                {
                    var sb = new StringBuilder();
                    foreach (var message in this._customerService.Messages)
                    {
                        sb.AppendLine(message);
                    }

                    MessageBox.Show(sb.ToString(), "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this._customer = result;
                    MessageBox.Show("Cliente cadastrado com sucesso!", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Update()
        {
            try
            {
                var msg = MessageBox.Show("Atualizar Cliente?", "Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg != DialogResult.Yes)
                {
                    return;
                }

                var customerParams = new CustomerUpdateParams()
                {
                    Name = this.txtName.Text,
                    Nickname = this.txtNickname.Text,
                    Identity = this.txtIdentity.Text,
                    Note = this.txtNote.Text,
                    BirthDate = GlobalFunction.GetIsoDateTime(this.dtpBirthDate.Text),
                    PersonType = this.cboPersonType.Text
                };

                _customer = this._customerService.Update(_customer.Id, customerParams);

                MessageBox.Show("Cliente atualizado com sucesso!", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
