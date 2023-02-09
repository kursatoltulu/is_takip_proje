using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using is_takip_proje.Entity;

namespace is_takip_proje.Formlar
{
    public partial class FrmPersoneller : Form
    {
        public FrmPersoneller()
        {
            InitializeComponent();
        }

        DbisTakipEntities db = new DbisTakipEntities(); 

        //personel tablosunun listelenmesi
        void personeller()
        {
            var degerler = from x in db.TblPersonel
                           select new
                           {
                               x.ID,
                               x.Ad,
                               x.Soyad,
                               x.Mail,
                               x.Telefon,
                               Departman=x.TblDepartmanlar.Ad,
                               x.Durum
                           };
            gridControl1.DataSource = degerler.Where(x=>x.Durum==true).ToList();
        }


        //departmanlari listelemek icin
        private void FrmPersoneller_Load(object sender, EventArgs e)
        {
            personeller();

            var departmanlar = (from x in db.TblDepartmanlar
                                select new
                                {
                                    x.ID,
                                    x.Ad,
                                }).ToList();
            LookUpEdit1.Properties.ValueMember = "ID";
            LookUpEdit1.Properties.DisplayMember = "Ad";
            LookUpEdit1.Properties.DataSource = departmanlar;


        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            personeller();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            TblPersonel t = new TblPersonel();
            t.Ad = txtAd.Text;
            t.Soyad=TxtSoyad.Text;
            t.Mail=TxtMail.Text;
            t.Departman = int.Parse(LookUpEdit1.EditValue.ToString());
            db.TblPersonel.Add(t);
            t.Durum = true;
            db.SaveChanges();
            XtraMessageBox.Show("Yeni personel kaydi başarılı bir şekilde gerçekleşti",
            "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            personeller();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            var x = int.Parse(txtID.Text);
            var deger = db.TblPersonel.Find(x);
            deger.Durum = false;
            db.SaveChanges();
            XtraMessageBox.Show("Personel silme işlemi başarılı bir şekilde gerçekleşti",
            "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            personeller();
        }

        //griddeki bilgileri label kismina aktarmak
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtAd.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
            TxtSoyad.Text = gridView1.GetFocusedRowCellValue("Soyad").ToString();
            TxtMail.Text = gridView1.GetFocusedRowCellValue("Mail").ToString();
            // TxtGorsel.Text = gridView1.GetFocusedRowCellValue("Gorsel").ToString();
            LookUpEdit1.Text = gridView1.GetFocusedRowCellValue("Departman").ToString();

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = int.Parse(txtID.Text);
            var deger = db.TblPersonel.Find(x);
            deger.Ad = txtAd.Text;
            deger.Soyad = TxtSoyad.Text;
            deger.Mail = TxtMail.Text;
            deger.Departman = int.Parse(LookUpEdit1.EditValue.ToString());
            db.SaveChanges();
            XtraMessageBox.Show("Personel başarılı bir şekilde güncellendi.",
            "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Question);
            personeller();
            
        }
    }
}
