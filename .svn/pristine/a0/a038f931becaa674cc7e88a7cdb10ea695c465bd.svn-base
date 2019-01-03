using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Master
{
    public partial class frmTargetTokoAddEdit : ISA.Toko.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;
        DataRow dr;//cursor toko
        DataRow drDetail; //cursorTarget

        public frmTargetTokoAddEdit()
        {
            InitializeComponent();
        }
 
        

        /// <summary>
        /// Buat insert
        /// </summary>
        /// <param name="caller">Form Pemanggil</param>
        /// <param name="drr">Cursor toko</param>
        public frmTargetTokoAddEdit(Form caller,  DataRow drr)
        {
            InitializeComponent();
            dr = drr;
            formMode = enumFormMode.New;
            this.Caller = caller;

        }

        /// <summary>
        /// Buat insert
        /// </summary>
        /// <param name="caller">Form Pemanggil</param>
        /// <param name="drr">Cursor toko</param>
        /// <param name="drDetail">Cursor target</param>
        public frmTargetTokoAddEdit(Form caller, DataRow drr, DataRow drrDetail)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            dr = drr;
            drDetail = drrDetail;
            this.Caller = caller;
        }
        
        

        private void frmTargetTokoAddEdit_Load(object sender, EventArgs e)
        {
            TextBoxTMT.DateValue = DateTime.Now;
            //TextBoxTMT.Text = DateTime.Today.ToString("dd/MM/yyyy");

            txtNamaToko.Text = dr["NamaToko"].ToString();
            textBoxAlamat.Text = dr["Alamat"].ToString();
            textBoxIdWil.Text = dr["WilID"].ToString();

            try
            {
                if (formMode == enumFormMode.Update)
                {
                    TextBoxTMT.DateValue = (DateTime)drDetail["TMT"];
                    TextBoxOmsetFBR2.Text = drDetail["OmsetFBR2"].ToString();
                    TextBoxOmsetFBR4.Text = drDetail["OmsetFBR4"].ToString();
                    TextBoxOmsetFER2.Text = drDetail["OmsetFER2"].ToString();
                    TextBoxOmsetFER4.Text = drDetail["OmsetFER4"].ToString();
                    TextBoxOmsetAgen.Text = drDetail["OmsetAgen"].ToString();
                    TextBoxSKUFBR2.Text = drDetail["SKUFBR2"].ToString();
                    TextBoxSKUFBR4.Text = drDetail["SKUFBR4"].ToString();
                    TextBoxSKUFER2.Text = drDetail["SKUFER2"].ToString();
                    TextBoxSKUFER4.Text = drDetail["SKUFER4"].ToString();
                    TextBoxSKUagen.Text = drDetail["SKUagen"].ToString();
                    TextBoxTMT.Enabled = false;

                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }


        }

        private void commandButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBoxTMT.DateValue <= GlobalVar.LastClosingDate)
                {
                    throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                }
                switch (formMode)
                {
                    case enumFormMode.New:
                        using (Database db = new Database())
                        {
                            _rowID = Guid.NewGuid();
                            Guid _RowIDToko = (Guid)dr["RowID"];
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_HistoryTargetToko_Insert"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@RowIDToko", SqlDbType.UniqueIdentifier,_RowIDToko));
                            db.Commands[0].Parameters.Add(new Parameter("@Tmt", SqlDbType.DateTime, TextBoxTMT.DateValue.Value));
                            db.Commands[0].Parameters.Add(new Parameter("@OmsetFBR2", SqlDbType.Money,TextBoxOmsetFBR2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@OmsetFBR4", SqlDbType.Money, TextBoxOmsetFBR4.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@OmsetFER2", SqlDbType.Money, TextBoxOmsetFER2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@OmsetFER4", SqlDbType.Money, TextBoxOmsetFER4.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@OmsetAgen", SqlDbType.Money, TextBoxOmsetAgen.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@SKUFBR2", SqlDbType.Int, TextBoxSKUFBR2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@SKUFBR4", SqlDbType.Int, TextBoxSKUFBR2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@SKUFER2", SqlDbType.Int, TextBoxSKUFER2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@SKUFER4", SqlDbType.Int, TextBoxSKUFER4.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@SKUagen", SqlDbType.Int, TextBoxSKUagen.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();
                            db.Close();
                            db.Dispose();
                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("TMT " + TextBoxTMT.Text + " sudah sudah ada");
                                TextBoxTMT.Focus();
                                return;
                            }
                        }
                        break;

                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {

                            Guid _RowID = (Guid)drDetail["RowID"];
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_HistoryTargetToko_Update"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@OmsetFBR2", SqlDbType.Money, TextBoxOmsetFBR2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@OmsetFBR4", SqlDbType.Money, TextBoxOmsetFBR4.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@OmsetFER2", SqlDbType.Money, TextBoxOmsetFER2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@OmsetFER4", SqlDbType.Money, TextBoxOmsetFER4.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@OmsetAgen", SqlDbType.Money, TextBoxOmsetAgen.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@SKUFBR2", SqlDbType.Int, TextBoxSKUFBR2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@SKUFBR4", SqlDbType.Int, TextBoxSKUFBR4.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@SKUFER2", SqlDbType.Int, TextBoxSKUFER2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@SKUFER4", SqlDbType.Int, TextBoxSKUFER4.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@SKUagen", SqlDbType.Int, TextBoxSKUagen.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();
                            db.Close();
                            db.Dispose();


                        }
                        break;

                }
                this.DialogResult = DialogResult.OK;
                frmTargetToko frmCaller = (frmTargetToko)this.Caller;
                frmCaller.BrowseTargetTokoDetail();
                this.Close();

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
