using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ISA.Toko.CommunicatorISA
{
    public partial class frmDataViewerDetail : ISA.Toko.BaseForm
    {
        DataSet ds = new DataSet();
        
        public frmDataViewerDetail(string xmlData)
        {
            InitializeComponent();
            StringReader sr = new StringReader(xmlData);
            ds.ReadXml(sr);            
        }

        private void frmDataViewerDetail_Load(object sender, EventArgs e)
        {
            customGridView1.AutoGenerateColumns = true;            
            customGridView1.DataSource = ds.Tables[0];
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
