using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using is_takip_proje.Entity;

namespace is_takip_proje.PersonelGorevFormlari
{
    public partial class FrmAktifGorevler : Form
    {
        public FrmAktifGorevler()
        {
            InitializeComponent();
        }

        DbisTakipEntities db=new DbisTakipEntities();
        public string mail2;
        private void FrmAktifGorevler_Load(object sender, EventArgs e)
        {
            var personelid=db.TblPersonel.Where(x=>x.Mail==mail2).Select(y=>y.ID).FirstOrDefault();
            var degerler=(from x in db.TblGorevler 
                          select new
                          {
                              x.ID,
                              x.Aciklama,
                              x.Tarih,
                              x.GorevAlan,
                              x.Durum
                          }).Where(x=>x.GorevAlan==personelid && x.Durum==true).ToList();
            
            gridControl1.DataSource= degerler;
            gridView1.Columns["GorevAlan"].Visible = false;
            gridView1.Columns["Durum"].Visible = false;
        }
    }
}
