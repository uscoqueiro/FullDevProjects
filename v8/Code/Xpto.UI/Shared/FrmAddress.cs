using System.Net;
using Xpto.Core.Shared.Entities;
using Xpto.Core.Shared.Params;

namespace Xpto.UI.Shared
{
    public partial class FrmAddress : Form
    {
        private AddressParams _address = new AddressParams();

        public delegate void AddressConfirmDelegate(AddressParams addressParams);
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
            _address = new AddressParams();

            _address.Street = this.txtStreet.Text;
            _address.Number = this.txtNumber.Text;
            _address.Complement = this.txtComplement.Text;
            _address.District = this.txtDistrict.Text;
            _address.City = this.txtCity.Text;
            _address.State = this.txtState.Text;
            _address.ZipCode = this.txtZipCode.Text;
            _address.Note = this.txtNote.Text;

            Confirmed(_address);
            this.Close();

        }
    }
}
