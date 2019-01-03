using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISA.Pin.Class
{
    class SASPin
    {
        string key, hasil;
        int i, key1, key2, key3, key0, keyJml;
       
        public string commandButton1_Click(string _key)
        {
            keyJml = 0;
            key = _key;
            for (i = 0; i < 4; i++)
            {
                keyJml = keyJml + Convert.ToInt32(key.Substring(i, 1));

            }
            key0 = Convert.ToInt32(key.Substring(0, 1)) + Convert.ToInt32(key.Substring(1, 1)) + keyJml;
            key1 = Convert.ToInt32(key.Substring(1, 1)) + Convert.ToInt32(key.Substring(2, 1)) + keyJml;
            key2 = Convert.ToInt32(key.Substring(2, 1)) + Convert.ToInt32(key.Substring(3, 1)) + keyJml;
            key3 = Convert.ToInt32(key.Substring(3, 1)) + Convert.ToInt32(key.Substring(0, 1)) + keyJml;

            key0 = getOne(key0);
            key1 = getOne(key1);
            key2 = getOne(key2);
            key3 = getOne(key3);
            //MessageBox.Show(DateTime.Now.ToString("hmm"));
            //MessageBox.Show(key0.ToString()+key1.ToString()+key2.ToString()+key3.ToString());
            //txtPin.Text = key0.ToString() + key1.ToString() + key2.ToString() + key3.ToString() + ;
            int jam = Convert.ToInt32(DateTime.Now.AddHours(1).ToString("HH")) + key0 + key1 + key2 + key3;
            int menit = Convert.ToInt32(DateTime.Now.AddHours(1).ToString("mm")) + key0 + key1 + key2 + key3;

       

            hasil = key0.ToString() + key1.ToString() + key2.ToString() + key3.ToString() + jam.ToString() + menit.ToString();
            return hasil;
        }

        public int getOne(int keyOri)
        {
            int xx;
            int keyNew = 0;
            //MessageBox.Show(keyOri.ToString().Length.ToString());
            if (keyOri.ToString().Length == 1)
            {
                return keyOri;
            }
            else
            {
                for (xx = 0; xx < keyOri.ToString().Length; xx++)
                {
                    keyNew = keyNew + Convert.ToInt32(keyOri.ToString().Substring(xx, 1));


                }
                //MessageBox.Show(keyNew.ToString());
                return getOne(keyNew);

            }
        }
    }
}
