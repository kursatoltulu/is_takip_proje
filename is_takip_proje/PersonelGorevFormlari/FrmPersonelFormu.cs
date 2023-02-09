using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace is_takip_proje.PersonelGorevFormlari
{
    public partial class FrmPersonelFormu : Form
    {
        public FrmPersonelFormu()
        {
            InitializeComponent();
        }
        public string mail;
        private void BtnAktifGorevler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PersonelGorevFormlari.FrmAktifGorevler frm = new PersonelGorevFormlari.FrmAktifGorevler();
            frm.MdiParent = this;
            frm.mail2= mail;
            frm.Show();
        }

        private void BtnPasifGorevler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PersonelGorevFormlari.FrmPasifGorevler frm = new PersonelGorevFormlari.FrmPasifGorevler();
            frm.MdiParent = this;
            frm.mail2= mail;
            frm.Show();
        }

        private void BtnCagriListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PersonelGorevFormlari.FrmCagriListesi frm = new PersonelGorevFormlari.FrmCagriListesi();
            frm.MdiParent = this;
            frm.mail2= mail;
            frm.Show();
        }

        private void FrmPersonelFormu_Load(object sender, EventArgs e)
        {
            // this.Text=mail.ToString();
            this.Text = "Personel Paneli";
        }
    }
}
