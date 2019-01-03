using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko;
using ISA.Toko.DataTemplates;
using Microsoft.Reporting.WinForms;
using System.IO;
using ISA.Toko.Class;

namespace ISA.Toko
{
    public class Stock : IDisposable 
    {

        string Type = String.Empty;
        string _KodeBarang = string.Empty;
        List<ListBarang> _ListBarang = new List<ListBarang>();
        List<ListBarang> _ListBarangs = new List<ListBarang>();
      
        public void AddList(string KodeBarang_, string NamaBarang, int QtyTrans)
        {
            ListBarang lb = new ListBarang();
            lb = ChekStok(KodeBarang_, QtyTrans);
            
            if (lb.SaldoStok-QtyTrans<0)
            {
                _ListBarang.Add(lb);
                _KodeBarang = _KodeBarang + KodeBarang_ + "|";
            }

            _ListBarangs.Add(lb);
          
        }

        public void ClearList()
        {
            _ListBarang.Clear();
        }

        public void PrintOutMinus()
        {
          
            int i = 0;
            BuildString detail = new BuildString();
            detail.FontCondensed(true);
            detail.LeftMargin(3);
            foreach (ListBarang dr in _ListBarang)
            {
                i++;


                detail.PROW(true, 1, detail.PrintTopLeftCorner() + detail.PrintHorizontalLine(42) + detail.PrintTTOp() +
                    detail.PrintHorizontalLine(42) + detail.PrintTTOp() + detail.PrintHorizontalLine(42) + detail.PrintTopRightCorner());

                detail.PROW(true, 1, detail.PrintVerticalLine() + "Tanggal :".PadRight(42) + detail.PrintVerticalLine() + "No. Form :".PadRight(42)
                    + detail.PrintVerticalLine() + detail.PadCenter(42, "KODE RAK :" + dr.KodeRak) + detail.PrintVerticalLine());

                detail.PROW(true, 1, detail.PrintTLeft() + detail.PrintHorizontalLine(5) + detail.PrintTTOp() +
                    detail.PrintHorizontalLine(36) + detail.PrintTBottom() + detail.PrintHorizontalLine(42) + detail.PrintTBottom() +
                    detail.PrintHorizontalLine(20) + detail.PrintTTOp() + detail.PrintHorizontalLine(5) + detail.PrintTTOp() +
                    detail.PrintHorizontalLine(15) + detail.PrintTRight());

                detail.PROW(true, 1, detail.PrintVerticalLine() + detail.PadCenter(5, "NO.") + detail.PrintVerticalLine() + detail.PadCenter(100, "NAMA BARANG")
                    + detail.PrintVerticalLine() + detail.PadCenter(5, "SAT") + detail.PrintVerticalLine() + detail.PadCenter(15, "PENGHITUNG") + detail.PrintVerticalLine());

                detail.PROW(true, 1, detail.PrintTLeft() + detail.PrintHorizontalLine(5) + detail.PrintTMidlle() +
                    detail.PrintHorizontalLine(100) + detail.PrintTMidlle() + detail.PrintHorizontalLine(5) + detail.PrintTMidlle() +
                    detail.PrintHorizontalLine(15) + detail.PrintTRight());

                //detail.PROW(true, 1, detail.PrintVerticalLine() + detail.PadCenter(5, "") + detail.PrintVerticalLine() + detail.PadCenter(100, "")
                //   + detail.PrintVerticalLine() + detail.PadCenter(5, "") + detail.PrintVerticalLine() + detail.PadCenter(15, "") + detail.PrintVerticalLine());

                detail.PROW(true, 1, detail.PrintVerticalLine() + i.ToString().PadLeft(5) + detail.PrintVerticalLine() + dr.NamaStok.PadRight(100)
                    + detail.PrintVerticalLine() + detail.PadCenter(5, dr.SatJual) + detail.PrintVerticalLine() + detail.PadCenter(15, "") + detail.PrintVerticalLine());

                //detail.PROW(true, 1, detail.PrintVerticalLine() + detail.PadCenter(5, "") + detail.PrintVerticalLine() + detail.PadCenter(100, "")
                //    + detail.PrintVerticalLine() + detail.PadCenter(5, "") + detail.PrintVerticalLine() + detail.PadCenter(15, "") + detail.PrintVerticalLine());

                detail.PROW(true, 1, detail.PrintTLeft() + detail.PrintHorizontalLine(5) + detail.PrintTBottom() +
                    detail.PrintHorizontalLine(22) + detail.PrintTTOp() + detail.PrintHorizontalLine(28) + detail.PrintTTOp() +
                    detail.PrintHorizontalLine(28) + detail.PrintTTOp() + detail.PrintHorizontalLine(19) + detail.PrintTBottom() +
                    detail.PrintHorizontalLine(5) + detail.PrintTBottom() + detail.PrintHorizontalLine(15) + detail.PrintTRight());

                detail.PROW(true, 1, detail.PrintVerticalLine() + detail.PadCenter(28, "BAIK") + detail.PrintVerticalLine() + detail.PadCenter(28, "CACAT") + detail.PrintVerticalLine()
                    + detail.PadCenter(28, "RUSAK") + detail.PrintVerticalLine() + "Dicatat Oleh,".PadLeft(41) + detail.PrintVerticalLine());

                detail.PROW(true, 1, detail.PrintVerticalLine() + detail.PadCenter(28, "") + detail.PrintVerticalLine() + detail.PadCenter(28, "") + detail.PrintVerticalLine()
                    + detail.PadCenter(28, "") + detail.PrintVerticalLine() + "".PadLeft(41) + detail.PrintVerticalLine());
                detail.PROW(true, 1, detail.PrintVerticalLine() + detail.PadCenter(28, "") + detail.PrintVerticalLine() + detail.PadCenter(28, "") + detail.PrintVerticalLine()
                    + detail.PadCenter(28, "") + detail.PrintVerticalLine() + "".PadLeft(41) + detail.PrintVerticalLine());
                detail.PROW(true, 1, detail.PrintVerticalLine() + detail.PadCenter(28, "") + detail.PrintVerticalLine() + detail.PadCenter(28, "") + detail.PrintVerticalLine()
                    + detail.PadCenter(28, "") + detail.PrintVerticalLine() + "Bag. Adm. Persediaan".PadLeft(41) + detail.PrintVerticalLine());

                detail.PROW(true, 1, detail.PrintBottomLeftCorner() + detail.PrintHorizontalLine(28) + detail.PrintTBottom() + detail.PrintHorizontalLine(28) + detail.PrintTBottom() +
                    detail.PrintHorizontalLine(28) + detail.PrintTBottom() + detail.PrintHorizontalLine(41) + detail.PrintBottomRightCorner());


                if ((i % 2 == 0) && (i % 4 != 0))
                {
                    for (int j = 0; j < 10; j++)
                    {
                        detail.PROW(true, 1, "");
                    }
                }
                else if (i % 4 == 0)
                {
                    detail.Eject();
                }
            }
            if (i % 2 != 0)
                detail.Eject();


            detail.SendToPrinter("notaJual.txt");
        }

        public void ReportMinus()
        {

            DataSet ds = new dsStok();
            DataTable dt = ds.Tables[0];

            foreach (ListBarang dr in _ListBarang)
            {
                DataRow drw = dt.NewRow();
                drw["NamaStok"] = dr.NamaStok;
                drw["BarangID"] = dr.KodeBarang;
                drw["QtyAwal"] = dr.SaldoStok;
                drw["QtyAkhir"] = dr.QtyTrans;
                dt.Rows.Add(drw);
            }

            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            frmReportViewer ifrmReport = new frmReportViewer("rptPersedianMinus.rdlc", rptParams, dt, "dsStok_Data");
            ifrmReport.Show();

        }
       
        private ListBarang ChekStok(string KodeBarang, int QtyTrans)
        {
            DataTable dt = new DataTable();
            ListBarang lb1 = new ListBarang();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[usp_CekStokRealTime]")); // cekd
                db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, KodeBarang));
                db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
               

                dt =db.Commands[0].ExecuteDataTable();
            
            }
            lb1.KodeBarang = KodeBarang;
            lb1.NamaStok = dt.Rows[0]["NamaStok"].ToString();
            lb1.KodeRak = dt.Rows[0]["KodeRak"].ToString();
            lb1.QtyTrans = QtyTrans;
            lb1.SatJual = dt.Rows[0]["SatJual"].ToString();
            lb1.SaldoStok = Convert.ToInt32(dt.Rows[0]["QtyAkhir"].ToString());
            return lb1;
        }

        public bool Pass()
        {
            bool Minus = true;

            if (_ListBarang.Count>0)
            {
                Minus = false;
            }
            return Minus;
        }

        public void Dispose()
        {
            _ListBarang.Clear();
        }

        public Stock()
        {
            Type = "New";
            _ListBarang.Clear();

        }

        public  string KodeBarang
        {
            get { return _KodeBarang; }
        }

        public  List<ListBarang> GetListBarangs
        {
            get { return _ListBarangs; }
        }

        public ListBarang ListBarangs(int i)
        {
           return _ListBarangs[i]; 
        }

       
    }

   public class ListBarang
    {
        public string KodeBarang
        {
           get;
           set;
        }

        public string NamaStok
        {
           get;
           set;
        }

        public string SatJual
        {
           get;
           set;
        }

        public string KodeRak
        {
            get;
            set;
        }

        public  int SaldoStok
        {
            get;
            set;
        }

        public  int QtyTrans
        {
            get;
            set;
        }

        public int QtyAkhir
        {
            get {return  SaldoStok -QtyTrans;}
        }

    }
}
