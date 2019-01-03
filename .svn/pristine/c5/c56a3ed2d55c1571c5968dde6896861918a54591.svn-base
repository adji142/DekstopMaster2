using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.DataTemplates;
using Microsoft.Reporting.WinForms;
using ISA.Toko.Class;
using ISA.Toko;
using ISA.Toko.Master;
using System.Data.SqlTypes;

namespace ISA.Toko.xpdc
{
    public partial class Penyelesaian_Pengiriman_xpdc : ISA.Controls.BaseForm
    {
        Guid _rowID = Guid.Empty;

        public Penyelesaian_Pengiriman_xpdc(Form Caller, Guid rowID)
        {
            InitializeComponent();
            _rowID = rowID;
            this.Caller = Caller;
        }

        private void Penyelesaian_Pengiriman_xpdc_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PengirimanXpdc_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                dt = db.Commands[0].ExecuteDataTable();
            }
            TglKembali.Text = string.Format("{0:dd/MM/yyyy}",dt.Rows[0]["TglKembali"]);
            KmKembali.Text = string.Format("{0:#,##0}", dt.Rows[0]["KMKirim"]);
            JamKembali.Text = Tools.isNull(dt.Rows[0]["JamKembali"], "").ToString();
            Tarikan.Text = string.Format("{0:#,##0}", dt.Rows[0]["Tarikan"]);
            KasBon.Text = string.Format("{0:#,##0}", dt.Rows[0]["KasBon"]);
            BBMLtr.Text = string.Format("{0:#,##0}", dt.Rows[0]["BBMLtr"]);
            BBMRp.Text = string.Format("{0:#,##0}", dt.Rows[0]["BBMRp"]);
            UMSopir.Text = string.Format("{0:#,##0}", dt.Rows[0]["UMSopir"]);
            UMKernet.Text = string.Format("{0:#,##0}", dt.Rows[0]["UMKernet"]);
            Parkir.Text = string.Format("{0:#,##0}", dt.Rows[0]["Parkir"]);
            Tol.Text = string.Format("{0:#,##0}", dt.Rows[0]["Tol"]);
            IzinMasuk.Text = string.Format("{0:#,##0}", dt.Rows[0]["IzinMasuk"]);
            Timbangan.Text = string.Format("{0:#,##0}", dt.Rows[0]["Timbangan"]);
            InTepatWaktu.Text = string.Format("{0:#,##0}", dt.Rows[0]["InTepatWaktu"]);
            InPengiriman.Text = string.Format("{0:#,##0}", dt.Rows[0]["InPengiriman"]);
            Lain.Text = string.Format("{0:#,##0}", dt.Rows[0]["Lain"]);
            TotalBiaya.Text = string.Format("{0:#,##0}", dt.Rows[0]["TotalBiaya"]);
            PlusMinus.Text = string.Format("{0:#,##0}", dt.Rows[0]["PlusMinus"]);
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HitungTotalBiaya(object sender, CancelEventArgs e)
        {
            double _KasBon,_Bbm,_Umsopir,_Umkernet,_Parkir,_Tol,_Kuli,_IzinMasuk,_Timbangan,_Intw,_Inkrm,_Lain,_Total;
            _KasBon=_Bbm=_Umsopir=_Umkernet=_Parkir=_Tol=_Kuli=_IzinMasuk=_Timbangan=_Intw=_Inkrm=_Lain=_Total=0;

            if (KasBon.Text != null && KasBon.Text != "" && KasBon.Text != "0.00")
                _KasBon = Convert.ToDouble(KasBon.Text);
            if (BBMRp.Text != null && BBMRp.Text != "" && BBMRp.Text != "0.00")
                _Bbm = Convert.ToDouble(BBMRp.Text);
            if (UMSopir.Text != null && UMSopir.Text != "" && UMSopir.Text != "0.00")
                _Umsopir = Convert.ToDouble(UMSopir.Text);
            if (UMKernet.Text != null && UMKernet.Text != "" && UMKernet.Text != "0.00")
                _Umkernet = Convert.ToDouble(UMKernet.Text);
            if (Parkir.Text != null && Parkir.Text != "" && Parkir.Text != "0.00")
                _Parkir = Convert.ToDouble(Parkir.Text);
            if (Tol.Text != null && Tol.Text != "" && Tol.Text != "0.00")
                _Tol = Convert.ToDouble(Tol.Text);
            if (IzinMasuk.Text != null && IzinMasuk.Text != "" && IzinMasuk.Text != "0.00")
                _IzinMasuk = Convert.ToDouble(IzinMasuk.Text);
            if (Timbangan.Text != null && Timbangan.Text != "" && Timbangan.Text != "0.00")
                _Timbangan = Convert.ToDouble(Timbangan.Text);
            if (InTepatWaktu.Text != null && InTepatWaktu.Text != "" && InTepatWaktu.Text != "0.00")
                _Intw = Convert.ToDouble(InTepatWaktu.Text);
            if (InPengiriman.Text != null && InPengiriman.Text != "" && InPengiriman.Text != "0.00")
                _Inkrm = Convert.ToDouble(InPengiriman.Text);
            if (Lain.Text != null && Lain.Text != "" && Lain.Text != "0.00")
                _Lain = Convert.ToDouble(Lain.Text);

            _Total = _Bbm + _Umsopir + _Umkernet + _Parkir + _Tol + _Kuli + _IzinMasuk + _Timbangan + _Intw + _Inkrm + _Lain;

            TotalBiaya.Text = string.Format("{0:N}",_Total);
            PlusMinus.Text = string.Format("{0:N}", _KasBon - _Total);
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();
                try
                {
                    db.Commands.Add(db.CreateCommand("usp_PengirimanXpdc_PenyelesaianKirim_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@TglKembali", SqlDbType.DateTime, TglKembali.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@KMKirim", SqlDbType.Money, KmKembali.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@JamKembali", SqlDbType.VarChar, JamKembali.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Tarikan", SqlDbType.Money, Tarikan.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@KasBon", SqlDbType.Money, KasBon.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@BBMLtr", SqlDbType.Money, BBMLtr.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@BBMRp", SqlDbType.Money, BBMRp.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@UMSopir", SqlDbType.Money, UMSopir.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@UMKernet", SqlDbType.Money, UMKernet.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Parkir", SqlDbType.Money, Parkir.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Tol", SqlDbType.Money, Tol.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Kuli", SqlDbType.Money, PlusMinus.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@IzinMasuk", SqlDbType.Money, IzinMasuk.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Timbangan", SqlDbType.Money, Timbangan.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@InTepatWaktu", SqlDbType.Money, InTepatWaktu.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@InPengiriman", SqlDbType.Money, InPengiriman.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Lain", SqlDbType.Money, Lain.Text));

                    db.Commands[0].ExecuteNonQuery();
                    MessageBox.Show(Messages.Confirm.UpdateSuccess);

                    if (this.Caller is frm_kirim)
                    {
                        frm_kirim frmCaller = (frm_kirim)this.Caller;
                        frmCaller.RefreshDataXpdc();
                    }
                    this.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    db.RollbackTransaction();
                    MessageBox.Show("Gagal Menyimpan Data");
                }
            }

        }
    }
}
