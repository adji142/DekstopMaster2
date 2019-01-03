using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;

namespace ISA.Finance
{
    public partial class frmDebug : ISA.Finance.BaseForm
    {
        DataTable dt = new DataTable();
        List<string> files = new List<string>();
        int _countTable = 0;
        int _countRow = 0;

        public frmDebug()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] fileList = Directory.GetFiles(Application.StartupPath + "\\UPLIND");
            if (fileList.Length > 0)
            {
                foreach (string file in fileList)
                {
                    FileInfo finfo = new FileInfo(file);
                    File.Copy(file, GlobalVar.DbfUpload + "\\" + finfo.Name, true);
                }
            }

        }

        private void tempmethod()
        {
            string TableName = "Inden";
            string FileName = "TMPHIND";
            string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";
            string Indexing = GlobalVar.DbfUpload + "\\" + FileName + ".cdx";

            files.Add(Physical);
            files.Add(Indexing);

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            //Foxpro.CopyStructureTo2XX(Application.StartupPath + "\\UPLIND", FileName + ".dbf", GlobalVar.DbfUpload);                
        }

        private void CopyStructure()
        {
            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("idtr", "idtr", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("no_bukti", "no_bukti", Foxpro.enFoxproTypes.Char, 17));
            fields.Add(new Foxpro.DataStruct("collector", "collector", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("nm_coll", "nm_coll", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("rp_cash", "rp_cash", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("rp_giro", "rp_giro", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("rp_trf", "rp_trf", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("lbr_giro", "lbr_giro", Foxpro.enFoxproTypes.Numeric, 4));
            fields.Add(new Foxpro.DataStruct("tgl_kasir", "tgl_kasir", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("kasir", "kasir", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("acc", "acc", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            //fields.Add(new Foxpro.DataStruct("rp_crd", "rp_crd", Foxpro.enFoxproTypes.Numeric, 14));
            //fields.Add(new Foxpro.DataStruct("rp_dbt", "rp_dbt", Foxpro.enFoxproTypes.Numeric, 14));

            List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
            index.Add(new Foxpro.IndexStruct("idtr", "IDTR"));
        }
    }
}
