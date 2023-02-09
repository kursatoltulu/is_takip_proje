using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using is_takip_proje.Entity;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace is_takip_proje.Formlar
{
    public partial class FrmDepartmanlar : Form
    {
        public FrmDepartmanlar()
        {
            InitializeComponent();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }
        //departman bolumunde departmanlarin listelenmesi

        DbisTakipEntities db = new DbisTakipEntities();
        void Listele()
        {
            var degerler = (from x in db.TblDepartmanlar
                            select new
                            {
                                x.ID,
                                x.Ad,

                            }).ToList();
            gridControl1.DataSource= degerler;   
        }
        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        // yenı departman ekleme butonu
        private void BtnEkle_Click(object sender, EventArgs e)
        {
            TblDepartmanlar t = new TblDepartmanlar();
            
            t.Ad = txtAd.Text;
            db.TblDepartmanlar.Add(t); // veriyi kaydetme
            db.SaveChanges();  //degisiklikleri kaydet
            XtraMessageBox.Show("Departman başarılı bir şekilde sisteme kaydedildi.",
            "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();  //devexpressin mesaj kutusu
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int x = int.Parse(txtID.Text);
            var deger = db.TblDepartmanlar.Find(x);
            db.TblDepartmanlar.Remove(deger);
            db.SaveChanges();
            XtraMessageBox.Show("Departman silme işlemi başarılı bir şekilde gerçekleşti", 
            "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            Listele();  
        }

        // Departman listelemede veriye tiklandiginda veriyi labela yazma
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtAd.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
        }

        // Tablodan seçılen bılgılerı guncelleme
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = int.Parse(txtID.Text);
            var deger = db.TblDepartmanlar.Find(x);
            deger.Ad = txtAd.Text;
            db.SaveChanges();
            XtraMessageBox.Show("Departman güncelleme işlemi başarılı bir şekilde gerçekleşti",
            "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Listele();
        }
    }
}
