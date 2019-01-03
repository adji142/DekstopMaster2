using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA;
using ISA.Common;
using ISA.DAL;


namespace ISA.Toko.Kasir
{
    public partial class frmKasOpnameUpdate : ISA.Toko.BaseForm
    {
        private Guid _rowID;

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
            result = double.Parse(lbl100rb.Text) +
                double.Parse(lbl50rb.Text) +
                double.Parse(lbl20rb.Text) +
                double.Parse(lbl10rb.Text) +
                double.Parse(lbl5rb.Text) +
                double.Parse(lbl2rb.Text) +
                double.Parse(lbl1rb.Text) +
                double.Parse(lbl5rts.Text) +
                double.Parse(lbl2rts.Text) +
                double.Parse(lbl1rts.Text) +
                double.Parse(lbl50.Text) +
                double.Parse(label25.Text);

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
            _rowID = Guid.NewGuid();

            try
            {
                using (Database db = new Database(GlobalVar.DBFinance))
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
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();

                    //db.Commands.Add(db.CreateCommand("usp_KasOpname_INSERT"));
                    //db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    //db.Commands[0].Parameters.Add(new Parameter("@TglOpname", SqlDbType.DateTime, DateTime.Now.Date));
                    //db.Commands[0].Parameters.Add(new Parameter("@Kasir", SqlDbType.VarChar, SecurityManager.UserID));
                    //db.Commands[0].Parameters.Add(new Parameter("@K100000", SqlDbType.Int, int.Parse(txtK100rb.Text)));
                    //db.Commands[0].Parameters.Add(new Parameter("@K50000", SqlDbType.Int, int.Parse(txtK50rb.Text)));
                    //db.Commands[0].Parameters.Add(new Parameter("@K20000", SqlDbType.Int, int.Parse(txtK20rb.Text)));
                    //db.Commands[0].Parameters.Add(new Parameter("@K10000", SqlDbType.Int, int.Parse(txt10rb.Text)));
                    //db.Commands[0].Parameters.Add(new Parameter("@K5000", SqlDbType.Int, int.Parse(txt5rb.Text)));
                    //db.Commands[0].Parameters.Add(new Parameter("@K2000", SqlDbType.Int, int.Parse(txtK2rb.Text)));
                    //db.Commands[0].Parameters.Add(new Parameter("@K1000", SqlDbType.Int, int.Parse(txtK1rb.Text)));
                    //db.Commands[0].Parameters.Add(new Parameter("@K500", SqlDbType.Int, int.Parse(txtK5rts.Text)));
                    //db.Commands[0].Parameters.Add(new Parameter("@K100", SqlDbType.Int, int.Parse(txtK1rts.Text)));
                    //db.Commands[0].Parameters.Add(new Parameter("@L1000", SqlDbType.Int, int.Parse(txtL1rb.Text)));
                    //db.Commands[0].Parameters.Add(new Parameter("@L500", SqlDbType.Int, int.Parse(txtL5rts.Text)));
                    //db.Commands[0].Parameters.Add(new Parameter("@L200", SqlDbType.Int, int.Parse(txtL2rts.Text)));
                    //db.Commands[0].Parameters.Add(new Parameter("@L100", SqlDbType.Int, int.Parse(txtL1rts.Text)));
                    //db.Commands[0].Parameters.Add(new Parameter("@L50", SqlDbType.Int, int.Parse(txtL50.Text)));
                    //db.Commands[0].Parameters.Add(new Parameter("@L25", SqlDbType.Int, int.Parse(txtL25.Text)));
                    //db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    //db.Commands[0].ExecuteNonQuery();
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }

            finally
            {
                MessageBox.Show(Messages.Confirm.UpdateSuccess);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
           
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

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



























        
    }
}
