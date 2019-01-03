using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Controls;

namespace ISA.Bengkel.Library
{
    public class FormTools
    {
        public enum enumFormMode { New, Update };
        public enum detailIndex { header, detail1, detail2, detail3 };

        public static bool IsRowSelected(DataGridView dg)
        {
            bool cek = true;

            if (dg.SelectedCells.Count == 0)
            {
               
                cek = false;                
            }
            
            return cek;
        }

        public static bool IsDataExist(string spName, string paramName, SqlDbType dataType, string val)
        {
            bool cek = false;

            using (Database db = new Database())
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand(spName));
                db.Commands[0].Parameters.Add(new Parameter(paramName, dataType, val));
                dt = db.Commands[0].ExecuteDataTable();

                if (dt.Rows.Count > 0)
                {
                    cek = true;
                    MessageBox.Show("Data sudah didefinisikan di database");
                }
            }

            return cek;
        }


        public static bool IsLinkData()
        {
            throw new NotImplementedException();
        }

        public static bool IsBlank(CommonTextBox txt)
        {
            bool cek = false;

            if (string.IsNullOrEmpty(txt.Text))
            {
                MessageBox.Show(txt.Name.Substring(txt.Name.Length-3) + " belum diisi");
                txt.Focus();
                cek = true;
            }

            return cek;
        }

    }
}
