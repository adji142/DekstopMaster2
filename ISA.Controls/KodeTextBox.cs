using System;
using System.Collections.Generic;

using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using ISA.DAL;
using System.Data;

namespace ISA.Controls
{
    class KodeTextBox:TextBox
    {
        ErrorProvider err = new ErrorProvider();
        public enum enCodeType         
        {             
            KodeBarang,
            KodeCabang,
            KodeDO
        }

        enCodeType _codeType;

        [Browsable (true)]
        public enCodeType CodeType
        {
            get
            {
                return _codeType;
            }

            set
            {
                _codeType = value;
                SetControl();
            }
        }

        private void SetControl()
        {

                switch (_codeType)
                {
                    case enCodeType.KodeBarang :
                        this.MaxLength = 12;
                        this.Width = 200;
                        break;
                    case enCodeType.KodeCabang:
                        this.Width = 23;
                        this.MaxLength = 2;
                        break;                        
                    case enCodeType.KodeDO :
                        this.Width = 250;
                        this.MaxLength = 15;                        
                        break;
                }

        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            SetControl();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            switch (_codeType)
            {
                case enCodeType.KodeCabang:
                    if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                    break;
            }
        }


        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);
            err.Clear();
            if (this.Text != "")
            {
                switch (_codeType)
                {
                    case enCodeType.KodeCabang:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Cabang_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@cabangID", SqlDbType.VarChar, this.Text));
                            dt = db.Commands[0].ExecuteDataTable();
                            if (dt.Rows.Count == 0)
                            {
                                err.SetError(this, Messages.Error.NotFound);
                                e.Cancel = true;
                            }
                            
                        }
                        break;
                }
            }
        }
    }
}
