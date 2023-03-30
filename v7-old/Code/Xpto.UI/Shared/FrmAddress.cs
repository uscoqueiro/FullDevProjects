using Xpto.Core.Shared.Entities;

namespace Xpto.UI.Shared
{
    public partial class FrmAddress : Form
    {
        private Address _address = new Address();

        public delegate void AddressConfirmDelegate(Address address);
        public event AddressConfirmDelegate Confirmed;

        public FrmAddress()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            _address = new Address();

            _address.Street = this.txtStreet.Text;
            _address.Number = this.txtNumber.Text;
            _address.Complement = this.txtComplement.Text;
            _address.District = this.txtDistrict.Text;
            _address.City = this.txtCity.Text;
            _address.State = this.txtState.Text;
            _address.ZipCode = this.txtZipCode.Text;
            _address.Note = this.txtNote.Text;

            this.OnConfirmed(_address);
            this.Close();

        }

        protected virtual void OnConfirmed(Address address)
        {
            Confirmed?.Invoke(address);
        }
    }
}
