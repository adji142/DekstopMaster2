using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ISA.DAL;
using System.Windows.Forms;

namespace ISA.Toko.Class
{
     public partial class validation
    {
         public void validateTextInteger(object sender, EventArgs e)
         {
             Exception X = new Exception();

             TextBox T = (TextBox)sender;

             try
             {
                 if (T.Text != "-")
                 {
                     int x = int.Parse(T.Text);
                 }
             }
             catch (Exception)
             {
                 try
                 {
                     int CursorIndex = T.SelectionStart - 1;
                     T.Text = T.Text.Remove(CursorIndex, 1);

                     //Align Cursor to same index
                     T.SelectionStart = CursorIndex;
                     T.SelectionLength = 0;
                 }
                 catch (Exception) { }
             }
         }
        
        public static bool error(string[,,] error)
        {
            bool valid = true;
            string pesanError = "";

            // ulang sebanyak array
            // dibagi 3 karena 3 dimensi
            for (int i = 0; i < (error.Length/3); i++) {

                //cek termasuk jenis validasi apa
                if( error[0,i,1] == "isNull" ) {
                    pesanError += isNull(error[0, i, 0], error[0, i, 2]);
                }
                else if (error[0, i, 1] == "onlyInt") { 
                    
                }
            }

            if(pesanError!="") {
                MessageBox.Show(pesanError);
                valid = false;
            }

           // MessageBox.Show(error[0, 0, 0].ToString() + error[0, 0, 1].ToString() + error[0, 0, 2].ToString());
            return valid;
            
        }

         public static string isNull( string isiData, string pesan ) {
             if(isiData=="") {
                 return "\n"+pesan;
             }
             return "";
         }

          public static string onlyInt( string isiData, string pesan ) {
              return "";
         }

    }
}
