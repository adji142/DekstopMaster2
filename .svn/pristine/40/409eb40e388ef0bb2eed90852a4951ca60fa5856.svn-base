using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.DataTemplates;
using Microsoft.Reporting.WinForms;

namespace ISA.Trading.Persediaan
{
    public partial class frmRptStandarStokTipis : ISA.Trading.BaseForm
    {
#region "var & Procedure"
        bool LinkPBO;
        string _NoRQ;
        string docNoDO = "NOMOR_RQ_PB0";
        int iNomor, lebar;

        private void ReloadCBOKel()
            {
            try
                {
                    this.Cursor=Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        DataTable dt=new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_KelompokBarang_LIST"));
                        dt=db.Commands[0].ExecuteDataTable();

                        object[] obj = { "",""};
                        dt.Rows.Add(obj);

                        cboKel.ValueMember="kelompokBrgID";
                        cboKel.DisplayMember="kelompokBrgID";
                        cboKel.DataSource=dt;
                        cboKel.SelectedValue = "";
                    }
                }
            catch(Exception ex)
                {
                Error.LogError(ex);
                }
            finally
                {
                this.Cursor=Cursors.Default;
                }
            }

        private void ReloadCBOSup()
        {
            try
            {
            this.Cursor=Cursors.WaitCursor;
                using (Database db = new Database())
                {
                DataTable dt=new DataTable();
                db.Commands.Add(db.CreateCommand("usp_Pemasok_LIST"));
                dt=db.Commands[0].ExecuteDataTable();

                cboSup.ValueMember="Nama";
                cboSup.DisplayMember="Nama";
                cboSup.DataSource=dt;
                }
            }
            catch(Exception ex)
            {
            Error.LogError(ex);
            }
            finally
            {
            this.Cursor=Cursors.Default;
            }
        }

        private void SettingMenu()
        {
        switch (LinkPBO)
        {
        case true:
            TglRequest.Enabled=true;
            txtNoRequest.Enabled=true;
            cboSup.Enabled=true;
            txtNoRequest.Text = _NoRQ;
        	break;
        case false:
            TglRequest.Enabled=false;
            txtNoRequest.Enabled=false;
            cboSup.Enabled=false;
            txtNoRequest.Text = "";
        	break;
        }
        }

        private void OKLink()
        {
        try
            {
           
                this.Cursor = Cursors.WaitCursor;

                DataTable dtNum = Tools.GetGeneralNumerator(docNoDO);
                int lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
                iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
                string depan = Tools.GeneralInitial();
                string belakang = Tools.isNull(dtNum.Rows[0]["Belakang"],"").ToString();
                iNomor++;
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, docNoDO));
                    db.Commands[0].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, depan));
                    db.Commands[0].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, belakang));
                    db.Commands[0].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, iNomor));
                    db.Commands[0].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebar));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                    db.Commands[0].ExecuteNonQuery();

                }

               
                _NoRQ = Tools.FormatNumerator(iNomor, lebar, depan, belakang);
                txtNoRequest.Text = _NoRQ;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("[rsp_StandarStok_Tipis]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID",SqlDbType.UniqueIdentifier,Guid.NewGuid()));
                    db.Commands[0].Parameters.Add(new Parameter("@Link",SqlDbType.Bit,1));
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID",SqlDbType.VarChar,Tools.CreateFingerPrint()));
                    db.Commands[0].Parameters.Add(new Parameter("@NoRequest",SqlDbType.VarChar,_NoRQ));
                    db.Commands[0].Parameters.Add(new Parameter("@TglRequest",SqlDbType.DateTime,TglRequest.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Pemasok",SqlDbType.VarChar,cboSup.Text));

                    db.Commands[0].Parameters.Add(new Parameter("@Tgl",SqlDbType.DateTime,tglForm.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@InitGudang",SqlDbType.VarChar,GlobalVar.Gudang));
                    db.Commands[0].Parameters.Add(new Parameter("@KelompokBarang", SqlDbType.VarChar, cboKel.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpDatedBy",SqlDbType.VarChar,SecurityManager.UserID));


                    dt = db.Commands[0].ExecuteDataTable();
                    DisplayReport(dt);
                }
            }
        catch (Exception ex)
            {
        		Error.LogError(ex);
            }
        finally
            {
               this.Cursor = Cursors.Default;
            }
        }

        private void NoLink()
        {
            try
            {
           
            this.Cursor=Cursors.WaitCursor;
            using (Database db = new Database())
                {
                DataTable dt=new DataTable();
                db.Commands.Add(db.CreateCommand("rsp_StandarStok_Tipis"));
                db.Commands[0].Parameters.Add(new Parameter("@Link",SqlDbType.Bit,0));

                db.Commands[0].Parameters.Add(new Parameter("@Tgl",SqlDbType.DateTime,tglForm.DateValue));
                db.Commands[0].Parameters.Add(new Parameter("@InitGudang",SqlDbType.VarChar,GlobalVar.Gudang));
                
                if (!string.IsNullOrEmpty(cboKel.Text))
                {
                    db.Commands[0].Parameters.Add(new Parameter("@KelompokBarang", SqlDbType.VarChar, cboKel.Text));
                }
              
                dt=db.Commands[0].ExecuteDataTable();
                DisplayReport(dt);
                }
            }
            catch(Exception ex)
            {
            Error.LogError(ex);
            }
            finally
            {
            this.Cursor=Cursors.Default;
            }
        }

        private void Increament()
         {
             try
             {
                 DataTable dtNum = Tools.GetGeneralNumerator(docNoDO);
                 int lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
                 //int iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
                 string depan = Tools.GeneralInitial();
                 string belakang = dtNum.Rows[0]["Belakang"].ToString();
                 this.Cursor = Cursors.WaitCursor;
                 using (Database db = new Database())
                 {

                     db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE"));
                     db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, docNoDO));
                     db.Commands[0].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, depan));
                     db.Commands[0].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, belakang));
                     db.Commands[0].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, iNomor));
                     db.Commands[0].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebar));
                     db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                     db.Commands[0].ExecuteNonQuery();

                     iNomor++;
                 }
             }
             catch (Exception ex)
             {
                 Error.LogError(ex);
             }
             finally
             {
                 this.Cursor = Cursors.Default;
             }
         }

        private void DisplayReport(DataTable dt)
        {

        //construct parameter
      
        List<ReportParameter> rptParams=new List<ReportParameter>();
        rptParams.Add(new ReportParameter("Periode",tglForm.DateValue.ToString()));
        rptParams.Add(new ReportParameter("UserID",SecurityManager.UserID));
        rptParams.Add(new ReportParameter("Kelompok",cboKel.Text));

        //call report viewer
        frmReportViewer ifrmReport=new frmReportViewer("Persediaan.rptStandarStokTipis.rdlc",rptParams,dt,"dsStandarStok_Data");
        ifrmReport.Show();

        }
#endregion

        public frmRptStandarStokTipis()
        {
        InitializeComponent();
        }

        private void cmdNo_Click(object sender,EventArgs e)
        {
        this.Close();
        }

        private void frmRptStandarStokTipis_Load(object sender,EventArgs e)
        {
            _NoRQ="";
            tglForm.DateValue=DateTime.Now;
            TglRequest.DateValue=DateTime.Now;
            cboLink.SelectedIndex=1;
            LinkPBO=false;
            txtNoRequest.ReadOnly=true;
            ReloadCBOKel();
            SettingMenu();
            ReloadCBOSup();

            DataTable dtNum=Tools.GetGeneralNumerator(docNoDO);
            int lebar=int.Parse(dtNum.Rows[0]["Lebar"].ToString());
            iNomor=int.Parse(dtNum.Rows[0]["Nomor"].ToString());
            string depan=Tools.GeneralInitial();
            string belakang=dtNum.Rows[0]["Belakang"].ToString();
            iNomor++;

            _NoRQ=Tools.FormatNumerator(iNomor, lebar, depan, belakang);
        }

        private void cboLink_TextChanged(object sender,EventArgs e)
        {
        if(cboLink.Text=="Ya")
        {
        LinkPBO=true;
        }

        if(cboLink.Text=="Tidak")
        {
        LinkPBO=false;
        }
        SettingMenu();
        }

        private void cmdYes_Click(object sender,EventArgs e)
        {
            
            //switch (LinkPBO)
            //{
            //case true:
                OKLink();
             //   Increament();
            //    break;
            //case false:
            //    NoLink();
            //    break;
            //}

            
        }

        private void cboLink_Leave(object sender, EventArgs e)
        {
             if(cboLink.Text=="Ya")
        {
        LinkPBO=true;
        }

        if(cboLink.Text=="Tidak")
        {
        LinkPBO=false;
        }
        SettingMenu();
        

        }

      

    }
}
