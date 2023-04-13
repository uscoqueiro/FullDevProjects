using System.Text;
using Xpto.Core.Customers;
using Xpto.Core.Shared.Entities;
using Xpto.Core.Shared.Functions;
using Xpto.Core.Shared.Params;
using Xpto.Core.Shared.Results;
using Xpto.UI.Customers.Delegates;
using Xpto.UI.Shared;

namespace Xpto.UI.Customers
{
    public partial class FrmCustomerRegister : Form
    {
        private readonly ICustomerService _customerService;
        public Customer _customer = new();


        public event CustomerChangeDelegate Change;
        public event CustomerMessageDelegate Success;


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
                    BirthDate = GlobalFunction.GetBrToIsoDate(this.mkdBirthDate.Text),
                    PersonType = this.cboPersonType.Text,
                    Addresses = new List<AddressParams>()
                };

                _customer.Addresses ??= new List<Address>();
                foreach (var item in _customer.Addresses)
                {
                    customerParams.Addresses.Add(item.ToParams());
                }

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
                    BirthDate = GlobalFunction.GetBrToIsoDate(this.mkdBirthDate.Text),
                    PersonType = this.cboPersonType.Text,
                    Addresses = new List<AddressParams>()
                };

                _customer.Addresses ??= new List<Address>();
                foreach (var item in _customer.Addresses)
                {
                    customerParams.Addresses.Add(item.ToParams());
                }

                _customer = this._customerService.Update(_customer.Id, customerParams);

                this.Change.Invoke(_customer);
                var msgText = "Cliente atualizado com sucesso!";

                if (this.Success != null)
                    this.Success(msgText);

                MessageBox.Show(msgText, "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadCustomer(Customer customer)
        {
            this._customer = customer;
            this.txtName.Text = _customer.Name;
            this.txtNickname.Text = _customer.Nickname;
            this.txtIdentity.Text = _customer.Identity;
            this.txtNote.Text = _customer.Note;
            this.mkdBirthDate.Text = _customer.BirthDate?.ToString("dd/MM/yyyy");
            this.cboPersonType.Text = _customer.PersonType;
            this.lblCode.Text = $"Código: {_customer.Code}";
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

            this._customerService.Delete(_customer.Id);
            this.Change(_customer);
            this.Close();
            MessageBox.Show("Cliente excluído com sucesso!", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void LoadAddresses()
        {
            this._customer.Addresses ??= new List<Address>();
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

            foreach (var address in this._customer.Addresses)
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

        private void AddAddress(AddressParams addressParams)
        {
            var resultService = new ResultService();
            this._customer.AddAddress(addressParams, resultService);
            if (resultService.Messages.Count > 0)
                MessageBox.Show(resultService.Messages[0]);

            this.LoadAddresses();
        }


    }
}
