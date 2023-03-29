using Xpto.Core.Customers;
using Xpto.Core.Shared.Entities;
using Xpto.Core.Shared.Functions;
using Xpto.UI.Shared;

namespace Xpto.UI.Customers
{
    public partial class FrmCustomerRegister : Form
    {
        private readonly ICustomerService _customerService;
        public Customer Customer = new Customer();
        public delegate void CustomerChangeDelegate(Customer customer);
        public event CustomerChangeDelegate Change;

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

                Customer.Name = this.txtName.Text;
                Customer.Nickname = this.txtNickname.Text;
                Customer.Identity = this.txtIdentity.Text;
                Customer.Note = this.txtNote.Text;
                Customer.BirthDate = GlobalFunction.GetBrToIsoDate(this.mkdBirthDate.Text);
                Customer.PersonType = this.cboPersonType.Text;

                var msgText = "Cliente cadastrado com sucesso!";
                if (Customer.Code == 0)
                {
                    Customer = this._customerService.Create(Customer);
                }
                else
                {
                    Customer = this._customerService.Update(Customer);
                    msgText = "Cliente atualizado com sucesso!";
                }

                this.Change(Customer);

                MessageBox.Show(msgText, "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadCustomer(Customer customer)
        {
            this.Customer = customer;
            this.txtName.Text = Customer.Name;
            this.txtNickname.Text = Customer.Nickname;
            this.txtIdentity.Text = Customer.Identity;
            this.txtNote.Text = Customer.Note;
            this.mkdBirthDate.Text = Customer.BirthDate?.ToString("dd/MM/yyyy");
            this.cboPersonType.Text = Customer.PersonType;
            this.lblCode.Text = $"Código: {Customer.Code}";
            this.LoadAddresses();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("Excluir Cliente?", "Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg != DialogResult.Yes) { return; }

            this._customerService.Delete(Customer.Code);
            this.Change(Customer);
            this.Close();
            MessageBox.Show("Cliente excluído com sucesso!", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }



        private void LoadAddresses()
        {
            this.Customer.Addresses ??= new List<Address>();
            lvwAddresses.View = View.Details;
            lvwAddresses.Columns.Clear();
            lvwAddresses.Items.Clear();

            lvwAddresses.Columns.Add("Logradouro");
            lvwAddresses.Columns.Add("Número");
            lvwAddresses.Columns.Add("Complemento");
            lvwAddresses.Columns.Add("Bairro");
            lvwAddresses.Columns.Add("Cidade");
            lvwAddresses.Columns.Add("UF");
            lvwAddresses.Columns.Add("CEP");
            lvwAddresses.Columns.Add("Observação");

            foreach (var address in this.Customer.Addresses)
            {
                var item = new ListViewItem(address.Street);
                lvwAddresses.Items.Add(item);

                item.SubItems.Add(address.Number);
                item.SubItems.Add(address.Complement);
                item.SubItems.Add(address.District);
                item.SubItems.Add(address.City);
                item.SubItems.Add(address.State);
                item.SubItems.Add(address.ZipCode);
                item.SubItems.Add(address.Note);

                item.Tag = address.Id;
            }
        }



        private void btnAddAddress_Click(object sender, EventArgs e)
        {
            var frm = new FrmAddress();
            frm.Confirmed += AddAddress;
            frm.ShowDialog();
        }

        private void AddAddress(Address address)
        {
            this.Customer.Addresses.Add(address);
            this.LoadAddresses();
        }


    }
}
