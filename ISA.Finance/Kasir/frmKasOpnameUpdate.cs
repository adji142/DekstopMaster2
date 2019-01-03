using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA;
using ISA.Common;
using ISA.DAL;


namespace ISA.Finance.Kasir
{
    public partial class frmKasOpnameUpdate : ISA.Finance.BaseForm
    {
        private Guid _rowID;
        DateTime dTglOpaname;
        int start = 0;
        string imgBase;

        public frmKasOpnameUpdate()
        {
            InitializeComponent();
        }


        private int HitungKertas(int nom, int nKertas)
        {

            int result = 0;

            result = nom * nKertas;

            return result;
        }

        private int HitungKertasLogam (int nom,int nLogam, int nKertas)
        {
            int result = 0;

            int ttlKertas = nom * nKertas;
            int ttlLogam = nom * nLogam;

            result = ttlKertas + ttlLogam;

            return result;
        }

        private double Total()
        {
            double result = 0;
            result = double.Parse(Tools.isNull(lbl100rb.Text,"0").ToString()) +
                     double.Parse(Tools.isNull(lbl50rb.Text,"0").ToString()) +
                     double.Parse(Tools.isNull(lbl20rb.Text,"0").ToString()) +
                     double.Parse(Tools.isNull(lbl10rb.Text,"0").ToString()) +
                     double.Parse(Tools.isNull(lbl5rb.Text,"0").ToString()) +
                     double.Parse(Tools.isNull(lbl2rb.Text,"0").ToString()) +
                     double.Parse(Tools.isNull(lbl1rb.Text,"0").ToString()) +
                     double.Parse(Tools.isNull(lbl5rts.Text,"0").ToString()) +
                     double.Parse(Tools.isNull(lbl2rts.Text,"0").ToString()) +
                     double.Parse(Tools.isNull(lbl1rts.Text,"0").ToString()) +
                     double.Parse(Tools.isNull(lbl50.Text,"0").ToString()) +
                     double.Parse(Tools.isNull(label25.Text,"0").ToString());
            return result;
        }

        private void txtK100rb_TextChanged(object sender, EventArgs e)
        {
                        
            int jmlKertas = 0;
            

            if (txtK100rb.Text != string.Empty)
            {
                jmlKertas = txtK100rb.GetIntValue;

                lbl100rb.Text = HitungKertas(100000, jmlKertas).ToString("#,##0");

                lblTotal.Text = Total().ToString("#,##0");
            }
            else
            {
                txtK100rb.Text = "0";
                
            }
        }

        private void txtK50rb_TextChanged(object sender, EventArgs e)
        {
            
            int jmlKertas = 0;


            if (txtK50rb.Text != string.Empty)
            {
                jmlKertas = txtK50rb.GetIntValue;

                lbl50rb.Text = HitungKertas(50000, jmlKertas).ToString("#,##0");

                lblTotal.Text = Total().ToString("#,##0");
            }
            else
            {
                txtK50rb.Text = "0";
            }
        }

        private void txtK20rb_TextChanged(object sender, EventArgs e)
        {
            
            int jmlKertas = 0;
            

            if (txtK20rb.Text != string.Empty)
            {
                jmlKertas = txtK20rb.GetIntValue;

                lbl20rb.Text = HitungKertas(20000, jmlKertas).ToString("#,##0");

                lblTotal.Text = Total().ToString("#,##0");
            }
            else
            {
                txtK20rb.Text = "0";
            }
        }

        private void txt10rb_TextChanged(object sender, EventArgs e)
        {
            
            int jmlKertas = 0;
           

            if (txt10rb.Text != string.Empty)
            {
                jmlKertas = txt10rb.GetIntValue;

                lbl10rb.Text = HitungKertas(10000, jmlKertas).ToString("#,##0");

                lblTotal.Text = Total().ToString("#,##0");
            }
            else
            {
                txt10rb.Text = "0";
            }
        }

        private void txt5rb_TextChanged(object sender, EventArgs e)
        {
            
            int jmlKertas = 0;
            

            if (txt5rb.Text != string.Empty)
            {
                jmlKertas = txt5rb.GetIntValue;

                lbl5rb.Text = HitungKertas(5000, jmlKertas).ToString("#,##0");

                lblTotal.Text = Total().ToString("#,##0");
            }
            else
            {
                txt5rb.Text = "0";
            }
        }

        private void txtK2rb_TextChanged(object sender, EventArgs e)
        {
            
            int jmlKertas = 0;
            

            if (txtK2rb.Text != string.Empty)
            {
                jmlKertas = txtK2rb.GetIntValue;

                lbl2rb.Text = HitungKertas(2000, jmlKertas).ToString("#,##0");

                lblTotal.Text = Total().ToString("#,##0");
            }
            else
            {
                txtK2rb.Text = "0";
            }
        }

        private void txtK1rb_TextChanged(object sender, EventArgs e)
        {
          
            int jmlKertas = 0;
            int jmlLogam = 0;
            

            if (txtK1rb.Text != string.Empty)
            {
                jmlKertas = txtK1rb.GetIntValue;
                jmlLogam = txtL1rb.GetIntValue;

                lbl1rb.Text = HitungKertasLogam(1000, jmlLogam, jmlKertas).ToString("#,##0");

                lblTotal.Text = Total().ToString("#,##0");
            }
            else
            {
                txtK1rb.Text = "0";
            }
        }

        private void txtK5rts_TextChanged(object sender, EventArgs e)
        {
           
            int jmlKertas = 0;
            int jmlLogam = 0;
            

            if (txtK5rts.Text != string.Empty)
            {
                jmlKertas = txtK5rts.GetIntValue;
                jmlLogam = txtL5rts.GetIntValue;

                lbl5rts.Text = HitungKertasLogam(500, jmlLogam, jmlKertas).ToString("#,##0");

                lblTotal.Text = Total().ToString("#,##0");
            }
            else
            {
                txtK5rts.Text = "0";
            }
        }

        private void txtK1rts_TextChanged(object sender, EventArgs e)
        {
            
            int jmlKertas = 0;
            int jmlLogam = 0;
            

            if (txtK1rts.Text != string.Empty)
            {
                jmlKertas = txtK1rts.GetIntValue;

                jmlLogam = txtL1rts.GetIntValue;

                lbl1rts.Text = HitungKertasLogam(100, jmlLogam, jmlKertas).ToString("#,##0");

                lblTotal.Text = Total().ToString("#,##0");
            }
            else
            {
                txtK1rts.Text = "0";
            }
        }

        private void txtL1rb_TextChanged(object sender, EventArgs e)
        {
            
            int jmlKertas = 0;
            int jmlLogam = 0;
           

            if (txtL1rb.Text != string.Empty)
            {
                jmlLogam = txtL1rb.GetIntValue;
                jmlKertas = txtK1rb.GetIntValue;

                lbl1rb.Text = HitungKertasLogam(1000, jmlLogam, jmlKertas).ToString("#,##0");

                lblTotal.Text = Total().ToString("#,##0");
            }
            else
            {
                txtL1rb.Text = "0";
            }
        }

        private void txtL5rts_TextChanged(object sender, EventArgs e)
        {
            
            int jmlKertas = 0;
            int jmlLogam = 0;
          

            if (txtL5rts.Text != string.Empty)
            {
                jmlLogam = txtL5rts.GetIntValue;
                jmlKertas = txtK5rts.GetIntValue;

                lbl5rts.Text = HitungKertasLogam(500, jmlLogam, jmlKertas).ToString("#,##0");

                lblTotal.Text = Total().ToString("#,##0");
            }
            else
            {
                txtL5rts.Text = "0";
            }
        }

        private void txtL2rts_TextChanged(object sender, EventArgs e)
        {                   
            int jmlLogam = 0;
          

            if (txtL2rts.Text != string.Empty)
            {
                jmlLogam = txtL2rts.GetIntValue;

                lbl2rts.Text = HitungKertas(200, jmlLogam).ToString("#,##0");

                lblTotal.Text = Total().ToString("#,##0");
            }
            else
            {
                txtL2rts.Text = "0";
            }
        }

        private void txtL1rts_TextChanged(object sender, EventArgs e)
        {
            
            int jmlKertas = 0;
            int jmlLogam = 0;            

            if (txtL1rts.Text != string.Empty)
            {
                jmlLogam = txtL1rts.GetIntValue;
                jmlKertas = txtK1rts.GetIntValue;

                lbl1rts.Text = HitungKertasLogam(100, jmlLogam, jmlKertas).ToString("#,##0");

                lblTotal.Text = Total().ToString("#,##0");
            }
            else
            {
                txtL1rts.Text = "0";
            }
        }

        private void txtL50_TextChanged(object sender, EventArgs e)
        {
            
            int jmlLogam = 0;
           

            if (txtL50.Text != string.Empty)
            {
                jmlLogam = txtL50.GetIntValue;

                lbl50.Text = HitungKertas(50, jmlLogam).ToString("#,##0");

                lblTotal.Text = Total().ToString("#,##0");
            }
            else
            {
                txtL50.Text = "0";
            }
        }

        private void txtL25_TextChanged(object sender, EventArgs e)
        {            

            int jmlLogam = 0;           

            if (txtL25.Text != string.Empty)
            {
                jmlLogam = txtL25.GetIntValue;

                label25.Text = HitungKertas(25, jmlLogam).ToString("#,##0");

                lblTotal.Text = Total().ToString("#,##0");
            }
            else
            {
                txtL25.Text = "0";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            double _KasOpname = 0, _KasKasirlog = 0, _GiroOpname = 0, _GiroKasirLog = 0;
            DateTime Tanggal = (DateTime)txtTanggal.DateValue;
            DataTable dtKasLog = new DataTable(GlobalVar.DBName);

            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_CekKasOpname"));
                db.Commands[0].Parameters.Add(new Parameter("@TglOpname", SqlDbType.DateTime,  Tanggal));
                dt = db.Commands[0].ExecuteDataTable();
            }

            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_KasirLogPrev_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglOpname", SqlDbType.DateTime, Tanggal));
                    dtKasLog = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            if (dtKasLog.Rows.Count > 0)
            {
                _KasKasirlog = Convert.ToDouble(Tools.isNull(dtKasLog.Rows[0]["KasAkhir"], "0").ToString());
                _KasOpname = Convert.ToDouble(Tools.isNull(lblTotal.Text, "0").ToString());
                _GiroKasirLog = Convert.ToDouble(Tools.isNull(dtKasLog.Rows[0]["GiroAkhir"], "0").ToString());
                _GiroOpname = Convert.ToDouble(Tools.isNull(txtRpGiro.Text, "0").ToString());
            }

            lblLKH.Text = _KasKasirlog.ToString("#,##0");

            if (_KasKasirlog != _KasOpname)
            {
                MessageBox.Show("Kas LKH : Rp." + _KasKasirlog.ToString() + "   beda dengan   Kas Opname : Rp." + _KasOpname.ToString());
                start = 1;
                txtTanggal.Enabled = true;
                txtTanggal.Focus();
                return;
            }
            else if (_GiroKasirLog != _GiroOpname)
            {
                MessageBox.Show("Giro ditangan : Rp." + _GiroKasirLog.ToString() + "   beda dengan   Opname Giro : Rp." + _GiroOpname.ToString());
                start = 1;
                txtTanggal.Enabled = true;
                txtTanggal.Focus();
                return;
            }

            _rowID = Guid.NewGuid();
            try
            {
                if (imgBase == null) //untuk mendeteksi kalau gambar sudah ditambahkan kemudian data bisa masuk ke database.
                {
                    MessageBox.Show("Image belum ditambahkan!");
                    return;
                }
                else
                {
                    if (dt.Rows.Count == 0)
                    {
                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            db.Commands.Add(db.CreateCommand("usp_KasOpname_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@TglOpname", SqlDbType.DateTime, DateTime.Now.Date));
                            db.Commands[0].Parameters.Add(new Parameter("@Kasir", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@K100000", SqlDbType.Int, txtK100rb.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@K50000", SqlDbType.Int, txtK50rb.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@K20000", SqlDbType.Int, txtK20rb.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@K10000", SqlDbType.Int, txt10rb.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@K5000", SqlDbType.Int, txt5rb.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@K2000", SqlDbType.Int, txtK2rb.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@K1000", SqlDbType.Int, txtK1rb.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@K500", SqlDbType.Int, txtK5rts.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@K100", SqlDbType.Int, txtK1rts.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@L1000", SqlDbType.Int, txtL1rb.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@L500", SqlDbType.Int, txtL5rts.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@L200", SqlDbType.Int, txtL2rts.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@L100", SqlDbType.Int, txtL1rts.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@L50", SqlDbType.Int, txtL50.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@L25", SqlDbType.Int, txtL25.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@RpGiro", SqlDbType.Money, txtRpGiro.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@LembarGiro", SqlDbType.Int, txtLembarGiro.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@AttachmentKas", SqlDbType.VarChar, imgBase));
                            db.Commands[0].ExecuteNonQuery();

                            MessageBox.Show(Messages.Confirm.ProcessFinished);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    else
                    {
                        String RowIDz = (dt.Rows[0]["RowID"].ToString());

                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            db.Commands.Add(db.CreateCommand("usp_KasOpname_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, new Guid(RowIDz)));
                            db.Commands[0].Parameters.Add(new Parameter("@TglOpname", SqlDbType.DateTime, txtTanggal.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@Kasir", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@K100000", SqlDbType.Int, txtK100rb.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@K50000", SqlDbType.Int, txtK50rb.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@K20000", SqlDbType.Int, txtK20rb.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@K10000", SqlDbType.Int, txt10rb.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@K5000", SqlDbType.Int, txt5rb.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@K2000", SqlDbType.Int, txtK2rb.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@K1000", SqlDbType.Int, txtK1rb.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@K500", SqlDbType.Int, txtK5rts.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@K100", SqlDbType.Int, txtK1rts.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@L1000", SqlDbType.Int, txtL1rb.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@L500", SqlDbType.Int, txtL5rts.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@L200", SqlDbType.Int, txtL2rts.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@L100", SqlDbType.Int, txtL1rts.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@L50", SqlDbType.Int, txtL50.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@L25", SqlDbType.Int, txtL25.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@RpGiro", SqlDbType.Money, txtRpGiro.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@LembarGiro", SqlDbType.Int, txtLembarGiro.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@AttachmentKas", SqlDbType.VarChar, imgBase));
                            db.Commands[0].ExecuteNonQuery();

                            MessageBox.Show(Messages.Confirm.ProcessFinished);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }

            /*finally
            {
                MessageBox.Show(Messages.Confirm.ProcessFinished);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }*/        
        }

        public void RefreshTextBox()
        {
            txtK100rb.Text = "0";
            txtK50rb.Text = "0";
            txtK20rb.Text = "0";
            txt10rb.Text = "0";
            txt5rb.Text = "0";
            txtK2rb.Text = "0";
            txtK1rb.Text = "0";
            txtK5rts.Text = "0";
            txtK1rts.Text = "0";
            txtL1rb.Text = "0";
            txtL5rts.Text = "0";
            txtL2rts.Text = "0";
            txtL1rts.Text = "0";
            txtL50.Text = "0";
            txtL25.Text = "0";
        }

        private void frmKasOpnameUpdate_Load(object sender, EventArgs e)
        {
            double _Kas = 0;
            txtTanggal.Text = GlobalVar.DateOfServer.ToString("dd/MM/yyyy");
            txtTanggal.Focus();
            DateTime Tanggal = (DateTime)txtTanggal.DateValue;
            frmKasirOpname();
        }

        private double GetKasirLog()
        {
            double result = 0;
            DateTime Tanggal = (DateTime)txtTanggal.DateValue;
            DataTable dtk = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_KasirLogPrev_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@TglOpname", SqlDbType.DateTime, Tanggal));
                dtk = db.Commands[0].ExecuteDataTable();
            }
            if (dtk.Rows.Count > 0)
            {
                result = Convert.ToDouble(Tools.isNull(dtk.Rows[0]["KasAkhir"], "0").ToString());
            }
            return result;
        }
        
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void disablemenu()
        {
            txtK100rb.Enabled = false;
            txtK50rb.Enabled = false;
            txtK20rb.Enabled = false;
            txt10rb.Enabled = false;
            txt5rb.Enabled = false;
            txtK2rb.Enabled = false;
            txtK1rb.Enabled = false;
            txtK5rts.Enabled = false;
            txtK1rts.Enabled = false;
            txtL1rb.Enabled = false;
            txtL5rts.Enabled = false;
            txtL2rts.Enabled = false;
            txtL1rts.Enabled = false;
            txtL50.Enabled = false;
            txtL25.Enabled = false;
            txtRpGiro.Enabled = false;
            txtLembarGiro.Enabled = false;
        }

        private void enabledmenu()
        {
            txtK100rb.Enabled = true;
            txtK50rb.Enabled = true;
            txtK20rb.Enabled = true;
            txt10rb.Enabled = true;
            txt5rb.Enabled = true;
            txtK2rb.Enabled = true;
            txtK1rb.Enabled = true;
            txtK5rts.Enabled = true;
            txtK1rts.Enabled = true;
            txtL1rb.Enabled = true;
            txtL5rts.Enabled = true;
            txtL2rts.Enabled = true;
            txtL1rts.Enabled = true;
            txtL50.Enabled = true;
            txtL25.Enabled = true;
            txtRpGiro.Enabled = true;
            txtLembarGiro.Enabled = true;
        }

        private void frmKasirOpname()
        {
            DateTime Tanggal = (DateTime)txtTanggal.DateValue;
            if (Tanggal > GlobalVar.DateOfServer)
            {
                txtTanggal.Focus();
                return;
            }
            txtTanggal.Focus();

            try
            {
                //Untuk Menambah kolom Attachment apabila kolom tersebut belum ada
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_KasOpname_ADDCOLUMN"));
                    db.Commands[0].ExecuteDataTable();
                }

                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_CekKasOpname"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglOpname", SqlDbType.DateTime, Tanggal));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count != 0) //|| Tanggal < GlobalVar.DateOfServer)
                {
                    if (Tanggal < GlobalVar.DateOfServer)
                    {
                        disablemenu();
                        //txtTanggal.Enabled = false;
                        btnSave.Enabled = false;
                        cmdClose.Focus();
                    }
                    else
                    {
                        enabledmenu();
                        //txtTanggal.Enabled = false;
                        btnSave.Enabled = true;
                        txtK100rb.Focus();
                    }
                }
                else
                {
                    enabledmenu();
                    //txtTanggal.Enabled = false;
                    btnSave.Enabled = true;
                    txtK100rb.Focus();
                }

                if (dt.Rows.Count > 0)
                {
                    txtK100rb.Text = dt.DefaultView.ToTable().Rows[0]["K100000"].ToString();
                    txtK50rb.Text = dt.DefaultView.ToTable().Rows[0]["K50000"].ToString();
                    txtK20rb.Text = dt.DefaultView.ToTable().Rows[0]["K20000"].ToString();
                    txt10rb.Text = dt.DefaultView.ToTable().Rows[0]["K10000"].ToString();
                    txt5rb.Text = dt.DefaultView.ToTable().Rows[0]["K5000"].ToString();
                    txtK2rb.Text = dt.DefaultView.ToTable().Rows[0]["K2000"].ToString();
                    txtK1rb.Text = dt.DefaultView.ToTable().Rows[0]["K1000"].ToString();
                    txtK5rts.Text = dt.DefaultView.ToTable().Rows[0]["K500"].ToString();
                    txtK1rts.Text = dt.DefaultView.ToTable().Rows[0]["K100"].ToString();
                    txtL1rb.Text = dt.DefaultView.ToTable().Rows[0]["L1000"].ToString();
                    txtL5rts.Text = dt.DefaultView.ToTable().Rows[0]["L500"].ToString();
                    txtL2rts.Text = dt.DefaultView.ToTable().Rows[0]["L200"].ToString();
                    txtL1rts.Text = dt.DefaultView.ToTable().Rows[0]["L100"].ToString();
                    txtL50.Text = dt.DefaultView.ToTable().Rows[0]["L50"].ToString();
                    txtL25.Text = dt.DefaultView.ToTable().Rows[0]["L25"].ToString();
                    txtRpGiro.Text = dt.DefaultView.ToTable().Rows[0]["RpGiro"].ToString();
                    txtLembarGiro.Text = dt.DefaultView.ToTable().Rows[0]["LembarGiro"].ToString();
                    lblTotal.Text = Total().ToString("#,##0");
                    lblLKH.Text = GetKasirLog().ToString("#,##0");
                    imgBase = dt.DefaultView.ToTable().Rows[0]["AttachmentKas"].ToString();
                    Image img = Base64ToImage(imgBase);
                    if(imgBase != null)
                    {
                        picPreview1.Image = img;
                        lblMessage.Visible = false;
                    }
                }
                else
                {
                    if (start == 0)
                    {
                        txtK100rb.Text = "0";
                        txtK50rb.Text = "0";
                        txtK20rb.Text = "0";
                        txt10rb.Text = "0";
                        txt5rb.Text = "0";
                        txtK2rb.Text = "0";
                        txtK1rb.Text = "0";
                        txtK5rts.Text = "0";
                        txtK1rts.Text = "0";
                        txtL1rb.Text = "0";
                        txtL5rts.Text = "0";
                        txtL2rts.Text = "0";
                        txtL1rts.Text = "0";
                        txtL50.Text = "0";
                        txtL25.Text = "0";
                        txtRpGiro.Text = "0";
                        txtLembarGiro.Text = "0";
                        lblTotal.Text = Total().ToString("#,##0");
                        lblLKH.Text = GetKasirLog().ToString("#,##0");
                        lblMessage.Visible = true;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void txtTanggal_Validated(object sender, EventArgs e)
        {
            frmKasirOpname();
        }

        private void btn_Upload_Click(object sender, EventArgs e)
        {
            fileUpload.Filter = "Images Only. | *.jpg; *.jpeg; *.png; "; //FILTER FILE
            if (fileUpload.ShowDialog() == DialogResult.OK) {
                var size = new System.IO.FileInfo(fileUpload.FileName).Length;

                if (size < 1024000) // limitasi ukuran gambar
                {
                    byte[] bytes = File.ReadAllBytes(fileUpload.FileName);
                    imgBase = Convert.ToBase64String(bytes);
                    Image img = Base64ToImage(imgBase);
                    picPreview1.Image = img;
                    lblMessage.Visible = false;
                    imgLabel.ForeColor = Color.Black;
                    imgLabel.Text = fileUpload.FileName;
                }
                else { // peringatan jika gambar melebihi 1MB
                    MessageBox.Show("Gunakan Image dengan ukuran kurang 1MB!");
                    imgBase = null;
                    imgLabel.ForeColor = Color.Red;
                    imgLabel.Text = "Pilih Gambar dengan ukuran kurang dari 1MB";
                }
            }
        }

        public Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
    }
}
