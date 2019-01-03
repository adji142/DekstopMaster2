using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Finance.Setoran
{
    public partial class frmPreferenceSetoran : ISA.Finance.BaseForm
    {
        public frmPreferenceSetoran()
        {
            InitializeComponent();
        }

        private void frmPreferenceSetoran_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            monthYearBox1.Year = Setorans.Year;
            monthYearBox1.Month = Setorans.Month;
            NumericMin.Text = Setorans.Min.ToString("#,##0");
            ChkMin.Checked = Setorans.LMin;
            if (Setorans.TActual)
            {
                cboActual.Checked = true;
            }else
            {
                cboNonActual.Checked = true;
            }
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Setorans.Year = monthYearBox1.Year;
                Setorans.Month = monthYearBox1.Month;
                Setorans.Min = NumericMin.GetDoubleValue;
                Setorans.LMin = ChkMin.Checked ? true : false;
                Setorans.TActual = cboNonActual.Checked ? false : true;
                Setorans.SetoranSave();
                MessageBox.Show("Data Has Been Save ", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
          
        }
    }
}
