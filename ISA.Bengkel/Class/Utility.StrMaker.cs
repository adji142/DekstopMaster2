using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * Programming by GearIntellix
 */
namespace ISA.Utility
{
    static class Caster
    {
        public static bool toBoolean(object val)
        {
            return toBoolean(val, false);
        }
        public static bool toBoolean(object val, bool def)
        {
            bool r = def;
            if (val is bool) return (bool)val;
            if (!bool.TryParse(val.ToString(), out r)) r = def;
            return r;
        }

        public static double toDouble(object val)
        {
            return toDouble(val, 0);
        }
        public static double toDouble(object val, double def)
        {
            double r = def;
            if (val is double) return (double)val;
            if (!double.TryParse(val.ToString(), out r)) r = def;
            return r;
        }

        public static DateTime toDateTime(object val)
        {
            return toDateTime(val);
        }
        public static DateTime toDateTime(object val, DateTime def)
        {
            DateTime r = def;
            if (val is DateTime) return (DateTime)val;
            if (!DateTime.TryParse(val.ToString(), out r)) r = def;
            return r;
        }

        public static float toFloat(object val)
        {
            return toFloat(val, 0);
        }
        public static float toFloat(object val, float def)
        {
            float r = def;
            if (val is float) return (float)val;
            if (!float.TryParse(val.ToString(), out r)) r = def;
            return r;
        }

        public static int toInt(object val)
        {
            return toInt(val, 0);
        }
        public static int toInt(object val, int def)
        {
            int r = def;
            if (val is int) return (int)val;
            if (!int.TryParse(val.ToString(), out r)) r = def;
            return r;
        }
    }

    enum SMCType
    {
        Null,
        String,
        Int,
        Float,
        Money,
        Date,
        DateTime
    }
    enum SMCAlign
    {
        Left,
        Right,
        Center
    }
    class StrMakerColumn
    {
        Dictionary<string, object> ds;
        Dictionary<string, object> ts;
        List<int> m;
        SMCAlign a;
        SMCType t;
        string n;
        int s;

        // constructors
        public StrMakerColumn()
        {
            setDefault();
        }
        public StrMakerColumn(string name, int size)
        {
            setDefault();

            t = SMCType.String;
            n = name;
            s = size;
        }
        public StrMakerColumn(string name, int size, SMCType type)
        {
            setDefault();

            t = type;
            n = name;
            s = size;
        }
        public StrMakerColumn(string name, int size, SMCAlign align)
        {
            setDefault();

            t = SMCType.String;
            a = align;
            n = name;
            s = size;
        }
        public StrMakerColumn(string name, int size, SMCType type, SMCAlign align)
        {
            setDefault();

            a = align;
            t = type;
            n = name;
            s = size;
        }
        public StrMakerColumn(string name, int size, SMCType type, Dictionary<string, object> settings)
        {
            setDefault();

            ts = settings;
            t = type;
            n = name;
            s = size;
        }
        public StrMakerColumn(string name, int size, SMCAlign align, Dictionary<string, object> settings)
        {
            setDefault();

            t = SMCType.String;
            ts = settings;
            a = align;
            n = name;
            s = size;
        }
        public StrMakerColumn(string name, int size, SMCType type, SMCAlign align, Dictionary<string, object> settings)
        {
            setDefault();

            ts = settings;
            a = align;
            t = type;
            n = name;
            s = size;
        }

        // private fn
        void setDefault()
        {
            ts = new Dictionary<string, object>();
            m = new List<int>();
            t = SMCType.Null;
            n = "";
            s = 0;

            m.Add(0); // top
            m.Add(1); // right
            m.Add(0); // bottom
            m.Add(1); // left
        }

        object getSetting(string name)
        {
            if (ds == null)
            {
                ds = new Dictionary<string, object>();
                ds.Add("Comma", ",");
                ds.Add("Dot", ".");
                ds.Add("Space", " ");
                ds.Add("Before", "");
                ds.Add("After", "");
                ds.Add("Trim", false);
                ds.Add("FloatRound", 2);
                ds.Add("StrRound", "..");
                ds.Add("DateFormat", "dd/MM/yyyy");
                ds.Add("DateTimeFormat", "dd/MM/yyyy HH:mm:ss");
            }
            if (ts == null) ts = new Dictionary<string,object>();

            if (!ts.ContainsKey(name))
            {
                if (ds.ContainsKey(name)) return ds[name];
                else return null;
            }
            else return ts[name];
        }

        string strRepeat(string val, int count)
        {
            string r = "";
            for (var i = 0; i < count; i++) r += val;
            return r;
        }

        // properties
        public string Name
        {
            get { return n; }
            set { n = value; }
        }

        public int Size
        {
            get { return s; }
            set { s = value; }
        }

        public SMCAlign Align
        {
            get { return a; }
            set { a = value; }
        }

        public SMCType Type
        {
            get { return t; }
            set { t = value; }
        }

        // public fn
        public void SetSetting(string name, object value)
        {
            ts[name] = value;
        }

        public string Parse(object val)
        {
            return Parse(val, "", "");
        }
        public string Parse(object val, string str, string end)
        {
            string r = str;
            r += getSetting("Before").ToString();
            switch (t)
            {
                case SMCType.Null:
                    // do nothing
                    break;
                case SMCType.String:
                    r += val.ToString();
                    if (Caster.toBoolean(getSetting("Trim"))) r = r.Trim();
                    break;
                case SMCType.Int:
                    r += Caster.toInt(val).ToString();
                    break;
                case SMCType.Float:
                    float fld = Caster.toFloat(val);
                    r += Math.Round(fld, Caster.toInt(getSetting("FloatRound"))).ToString();
                    break;
                case SMCType.Money:
                    double dbl = Caster.toDouble(val);
                    r += dbl.ToString("#,###");
                    break;
                case SMCType.Date:
                    if (val == null) r += "";
                    else
                    {
                        DateTime dt = Caster.toDateTime(val, new DateTime());
                        r += dt.ToString(getSetting("DateFormat").ToString());
                    }
                    break;
                case SMCType.DateTime:
                    if (val == null) r += "";
                    else
                    {
                        DateTime dtm = Caster.toDateTime(val, new DateTime());
                        r += dtm.ToString(getSetting("DateTimeFormat").ToString());
                    }
                    break;
            }
            r += getSetting("After").ToString();
            r += end;

            if (r.Length < s)
            {
                string sp = getSetting("Space").ToString();
                if (sp.Length > 1) sp = sp.Substring(0, 1);
                else if (sp.Length <= 0) sp = " ";
                switch (a)
                {
                    case SMCAlign.Left: default:
                        return r + strRepeat(sp, s - r.Length);

                    case SMCAlign.Right:
                        return strRepeat(sp, s - r.Length) + r;

                    case SMCAlign.Center:
                        int lf = s - r.Length;
                        int rg = 0;
                        for (var i = lf; i <= 2; i -= 2)
                        {
                            lf -= 1;
                            rg += 1;
                        }
                        return strRepeat(sp, lf) + r + strRepeat(sp, rg);
                }
            }
            else if (r.Length > s)
            {
                string rnd = getSetting("Round").ToString();
                r = r.Substring(0, r.Length - rnd.Length);
                return r + rnd;
            }
            else return r;
        }
    }

    class StrMaker
    {
        List<StrMakerColumn> cols;
        Dictionary<string, object> defs;
        Dictionary<string, object> setts;

        // constructors
        public StrMaker()
        {
            setDefault();
        }
        public StrMaker(List<StrMakerColumn> columns)
        {
            setDefault();

            cols = columns;
        }
        public StrMaker(Dictionary<string, object> settings)
        {
            setDefault();

            setts = settings;
        }
        public StrMaker(List<StrMakerColumn> columns, Dictionary<string, object> settings)
        {
            setDefault();

            cols = columns;
            setts = settings;
        }

        // private fn
        void setDefault()
        {
            cols = new List<StrMakerColumn>();
            setts = new Dictionary<string, object>();
        }

        object getSetting(string name)
        {
            if (defs == null)
            {
                defs = new Dictionary<string, object>();
                defs.Add("HMargin", " ");
                defs.Add("VMargin", "\n");
                defs.Add("MarginEnd", false);
                defs.Add("Before", "");
                defs.Add("After", "");
                defs.Add("Space", " ");
                defs.Add("MoneySymbol", "Rp.");
            }
            if (setts == null) setts = new Dictionary<string, object>();

            if (!setts.ContainsKey(name))
            {
                if (defs.ContainsKey(name)) return defs[name];
                else return null;
            }
            else return setts[name];
        }

        // api
        static string StrRepeat(string val, int count)
        {
            string r = "";
            for (var i = 0; i < count; i++) r += val;
            return r;
        }
        static string ForceStr(string val, int size, string space)
        {
            if (val.Length < size) return val + StrRepeat(space, size - val.Length);
            else if (val.Length > size) return val.Substring(0, size);
            else return val;
        }

        // public fn
        public void SetSetting(string name, object value)
        {
            setts[name] = value;
        }

        public void AddColumn(StrMakerColumn val)
        {
            cols.Add(val);
        }
        public void AddColumn(StrMakerColumn[] vals)
        {
            foreach (StrMakerColumn c in vals) AddColumn(c);
        }
        public void AddColumn(List<StrMakerColumn> vals)
        {
            foreach (StrMakerColumn c in vals) AddColumn(c);
        }

        public void RemoveColumn(int idx)
        {
            cols.RemoveAt(idx);
        }
        public void RemoveColumn(string name)
        {
            foreach (StrMakerColumn c in cols) if (c.Name == name) cols.Remove(c);
        }

        public void ClearColumn()
        {
            cols.Clear();
        }

        public string Parse(object[] vals)
        {
            int i = 0;
            string r = getSetting("Before").ToString();
            foreach (StrMakerColumn c in cols)
            {
                if (r != getSetting("Before").ToString()) r += getSetting("Space").ToString();
                if (vals.Length > i)
                {
                    switch (c.Type)
                    {
                        case SMCType.Money:
                            r += c.Parse(vals[i], getSetting("MoneySymbol").ToString(), "");
                            break;

                        default:
                            r += c.Parse(vals[i]);
                            break;
                    }
                }
                else r += c.Parse(null);
                i += 1;
            }
            r += getSetting("After").ToString();
            return r;
        }
    }
}
