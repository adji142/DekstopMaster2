using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

/*
 * Programming by GearIntellix
 */
namespace ISA.Utility
{
    enum XNetMethod
    {
        GET,
        POST
    }

    enum XNetMode
    {
        Asynchronous,
        Synchronous
    }

    class XNet
    {
        string u;
        XNetMode o;
        XNetMethod m;
        WebHeaderCollection h;

        int tow = 15 * 60 * 1000;
        int tor = 15 * 60 * 1000;

        public string Url
        {
            get { return u; }
            set { u = value; }
        }

        public XNetMethod Method
        {
            get { return m; }
            set { m = value; }
        }

        public WebHeaderCollection Headers
        {
            get { return h; }
            set { h = value; }
        }

        public XNetMode Mode
        {
            get { return o; }
            set { o = value; }
        }

        public int ReadWriteTimeout
        {
            get { return tow; }
            set { tow = value; }
        }

        public int Timeout
        {
            get { return tor; }
            set { tor = value; }
        }

        public XNet(string url)
        {
            setDefault();

            u = url;
        }
        public XNet(string url, XNetMethod method)
        {
            setDefault();

            u = url;
            m = method;
        }
        public XNet(string url, XNetMode mode)
        {
            setDefault();

            u = url;
            o = mode;
        }
        public XNet(string url, XNetMethod method, XNetMode mode)
        {
            setDefault();

            u = url;
            o = mode;
            m = method;
        }

        private void setDefault() {
            m = XNetMethod.GET;
            h = new WebHeaderCollection();
            o = XNetMode.Asynchronous;
        }

        public XNetThread Send(JSON data)
        {
            return Send(data, new Action<XNetResult>((a) => { }));
        }
        public XNetThread Send(JSON data, Action<XNetResult> cb) {
            JSON opt = new JSON(JSONType.Object);
            opt["ReadWriteTimeout"] = new JSON(this.tow);
            opt["Timeout"] = new JSON(this.tor);

            XNetThread rx = new XNetThread(u, m, h, opt);
            rx.Data = data;
            switch (o)
            {
                case XNetMode.Asynchronous:
                    if (!rx.SendAsych(cb)) cb(new XNetResult(false));
                    break;
                case XNetMode.Synchronous:
                    cb(rx.SendSynch());
                    break;
            }
            return rx;
        }

        public XNetThread Post(JSON data)
        {
            return Post(data, new Action<XNetResult>((a) => { }));
        }
        public XNetThread Post(JSON data, Action<XNetResult> cb)
        {
            XNetThread rx = new XNetThread(u, XNetMethod.POST, h);
            rx.Data = data;
            switch (o)
            {
                case XNetMode.Asynchronous:
                    if (!rx.SendAsych(cb)) cb(new XNetResult(false));
                    break;
                case XNetMode.Synchronous:
                    cb(rx.SendSynch());
                    break;
            }
            return rx;
        }

        public XNetThread Get()
        {
            return Get(new JSON());
        }
        public XNetThread Get(JSON data)
        {
            return Get(data, new Action<XNetResult>((a) => { }));
        }
        public XNetThread Get(Action<XNetResult> cb)
        {
            return Get(new JSON(), cb);
        }
        public XNetThread Get(JSON data, Action<XNetResult> cb)
        {
            XNetThread rx = new XNetThread(u, XNetMethod.GET, h);
            rx.Data = data;
            switch (o)
            {
                case XNetMode.Asynchronous:
                    if (!rx.SendAsych(cb)) cb(new XNetResult(false));
                    break;
                case XNetMode.Synchronous:
                    cb(rx.SendSynch());
                    break;
            }
            return rx;
        }
    }

    class XNetResult
    {
        bool r;
        string m;
        string s;
        Exception e;
        HttpWebResponse p;

        public Exception Error
        {
            get { return e; }
        }

        public bool Result
        {
            get { return r; }
        }

        public string Message
        {
            get { return m; }
        }

        public string Output
        {
            get { return s; }
        }

        public HttpWebResponse Response
        {
            get { return p; }
        }

        public XNetResult(bool res)
        {
            setDefault();

            r = res;
        }
        public XNetResult(bool res, HttpWebResponse rx)
        {
            setDefault();

            r = res;
            p = rx;
        }
        public XNetResult(bool res, string msg, string str)
        {
            setDefault();

            r = res;
            m = msg;
            s = str;
        }
        public XNetResult(bool res, HttpWebResponse rx, string msg, string str)
        {
            setDefault();

            p = rx;
            r = res;
            m = msg;
            s = str;
        }
        public XNetResult(Exception ex)
        {
            setDefault();

            m = ex.Message;
            r = false;
            e = ex;
        }

        private void setDefault()
        {
            r = false;
            p = null;
            e = null;
            m = "";
            s = "";
        }
    }

    class XNetThread
    {
        WebHeaderCollection _heads;
        string _method;
        string _ctype;
        JSON _opt;
        Uri _url;

        HttpWebRequest r;
        XNetResult dn;
        bool civ;
        bool or;
        bool ow;
        JSON d;

        public XNetThread(string url)
        {
            setDefault(url);
        }

        public XNetThread(string url, XNetMethod method)
        {
            setDefault(url);

            this.Method = method;
        }

        public XNetThread(string url, XNetMethod method, WebHeaderCollection header)
        {
            setDefault(url);

            this.Method = method;
            _heads = (header != null ? header : new WebHeaderCollection());
        }

        public XNetThread(string url, XNetMethod method, WebHeaderCollection header, JSON option)
        {
            setDefault(url);

            this.Method = method;
            _heads = (header != null ? header : new WebHeaderCollection());
            _opt = JSON.Default(option, JSONType.Object);
        }

        private void setDefault(string url) {
            _url = new Uri(url);
            _heads = new WebHeaderCollection();
            _opt = new JSON(JSONType.Object);
            _ctype = "application/json";
            _method = "POST";
            d = new JSON();
        }

        public XNetMethod Method
        {
            get
            {
                switch (_method)
                {
                    case "GET": default: return XNetMethod.GET;
                    case "POST": return XNetMethod.POST;
                }
            }
            set
            {
                switch (value)
                {
                    case XNetMethod.GET: default:
                        _method = "GET";
                        break;
                    case XNetMethod.POST:
                        _method = "POST";
                        break;
                }
            }
        }

        public JSON Data
        {
            get { return d; }
            set { d = value; }
        }

        public bool OnRequest
        {
            get { return or; }
        }

        public bool OnWorking
        {
            get { return ow; }
        }

        public bool HasDone
        {
            get { return dn != null; }
        }

        public XNetResult Result
        {
            get { return dn; }
        }

        public bool Cancel()
        {
            if (ow)
            {
                civ = true;
                return true;
            }
            else return false;
        }

        private HttpWebRequest preSend(out string dstr)
        {
            dstr = "";
            try
            {
                switch (Method)
                {
                    default:
                    case XNetMethod.GET:
                        JSON dor = JSON.ParseFromURLData((_url.Query.Length > 0 ? _url.Query.Substring(1) : ""));
                        foreach (string k in d.ObjKeys)
                        {
                            if (dor.ObjExists(k)) dor[k] = d[k];
                            else dor.ObjAdd(k, d[k]);
                        }
                        string xurl = _url.GetLeftPart(UriPartial.Path);
                        xurl += (dor.Count > 0 ? "?" + dor.ToURLData() : "");

                        r = (HttpWebRequest)WebRequest.Create(xurl);
                        break;

                    case XNetMethod.POST:
                        if (_ctype == null || _ctype.Length <= 0) _ctype = "application/json";
                        r = (HttpWebRequest)WebRequest.Create(_url);
                        switch (_ctype.ToLower())
                        {
                            case "application/json":
                                dstr = d.ToString();
                                break;
                            default:
                                dstr = "Protocol data '" + _ctype + "' not supported";
                                return null;
                        }
                        r.ContentType = _ctype;
                        break;
                }
                r.Method = _method;
                return r;
            }
            catch (Exception ex)
            {
                dstr = ex.Message;
                return null;
            }
        }

        public bool SendAsych(Action<XNetResult> cb) {
            if (ow || civ || dn != null) return false;
            or = ow = true;

            string dstr = "";
            try
            {
                r = this.preSend(out dstr);
                if (r == null) throw new Exception("Error: " + dstr);
                byte[] bdata = Encoding.UTF8.GetBytes(dstr);

                string strs = "";
                BackgroundWorker bgw = new BackgroundWorker();
                bgw.DoWork += (a, b) =>
                {
                    Stream strm = null;
                    HttpWebResponse res = null;
                    bool syncDone = false;

                    r.ReadWriteTimeout = (int)_opt["ReadWriteTimeout", new JSON(1000 * 60 * 15)].NumberValue;
                    r.Timeout = (int)_opt["Timeout", new JSON(1000 * 60 * 15)].NumberValue;

                    if (dstr.Length > 0)
                    {
                        // getting stream
                        syncDone = false;
                        try
                        {
                            var ssync = r.BeginGetRequestStream(new AsyncCallback((c) =>
                            {
                                try
                                {
                                    strm = r.EndGetRequestStream(c);
                                }
                                catch (Exception ex) { b.Result = ex.Message; }
                                finally { syncDone = true; }

                            }), r);
                        }
                        catch (Exception ex) { b.Result = ex.Message; }
                        if (b.Result != null)
                        {
                            throw new Exception("Cannot get request stream, details: " + b.Result);
                        }

                        // wait until done with checking
                        while (!syncDone)
                        {
                            if (civ)
                            {
                                b.Cancel = true;
                                r.Abort();
                                return;
                            }
                        }
                        if (b.Result != null)
                        {
                            throw new Exception("Cannot get request stream, details: " + b.Result);
                        }

                        // writing stream
                        syncDone = false;
                        var wsync = strm.BeginWrite(bdata, 0, bdata.Length, new AsyncCallback((c) =>
                        {
                            try
                            {
                                strm.EndWrite(c);
                            }
                            catch (Exception ex) { b.Result = ex.Message; }
                            finally { syncDone = true; }
                        }), strm);
                        if (b.Result != null)
                        {
                            throw new Exception("Cannot sending data, details: " + b.Result);
                        }

                        // wait until done with checking
                        while (!syncDone)
                        {
                            if (civ)
                            {
                                b.Cancel = true;
                                r.Abort();
                                return;
                            }
                        }
                        if (b.Result != null)
                        {
                            throw new Exception("Cannot sending data, details: " + b.Result);
                        }
                        strm.Close();
                    }

                    // get response
                    syncDone = false;
                    var rsync = r.BeginGetResponse(new AsyncCallback((c) =>
                    {
                        try
                        {
                            res = (HttpWebResponse)r.EndGetResponse(c);
                        }
                        catch (Exception ex) { b.Result = ex.Message; }
                        finally { syncDone = true; }
                    }), r);
                    if (b.Result != null)
                    {
                        throw new Exception("Cannot getting data, details: " + b.Result);
                    }

                    // wait until done with checking
                    while (!syncDone)
                    {
                        if (civ)
                        {
                            b.Cancel = true;
                            r.Abort();
                            return;
                        }
                    }
                    if (b.Result != null)
                    {
                        throw new Exception("Cannot getting data, details: " + b.Result);
                    }

                    // reading stream
                    using (var ssr = new StreamReader(res.GetResponseStream()))
                    {
                        strs = ssr.ReadToEnd();
                    }
                    b.Result = res;
                };

                bgw.RunWorkerCompleted += (a, b) =>
                {
                    or = false;
                    if (b.Error != null) dn = new XNetResult(b.Error);
                    else if (b.Result == null || b.Cancelled) dn = new XNetResult(false);
                    else if (b.Result.Equals(true)) dn = new XNetResult(true, "No output", "");
                    else if (b.Result.GetType() == typeof(HttpWebResponse))
                    {
                        if (strs.Length > 0) dn = new XNetResult(true, (HttpWebResponse)b.Result, "", strs);
                        else dn = new XNetResult(true, (HttpWebResponse)b.Result);
                    }
                    else dn = new XNetResult(false);

                    cb(dn);
                    ow = false;
                };

                bgw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                dn = new XNetResult(ex);
                cb(dn);
            }
            return true;
        }

        public XNetResult SendSynch()
        {
            if (ow || civ || dn != null) return new XNetResult(false);
            or = ow = true;

            string dstr = "", strs = "";
            try
            {
                r = this.preSend(out dstr);
                if (r == null) throw new Exception("Error: " + dstr);
                byte[] bdata = Encoding.UTF8.GetBytes(dstr);

                Stream strm = null;
                HttpWebResponse res = null;

                r.ReadWriteTimeout = (int)_opt["ReadWriteTimeout", new JSON(1000 * 60 * 15)].NumberValue;
                r.Timeout = (int)_opt["Timeout", new JSON(1000 * 60 * 15)].NumberValue;

                if (dstr.Length > 0)
                {
                    // getting stream
                    try
                    {
                        strm = r.GetRequestStream();
                    }
                    catch (Exception ex) { throw new Exception("Cannot get request stream, details: " + ex.Message); }

                    // writing stream
                    try
                    {
                        strm.Write(bdata, 0, bdata.Length);
                    }
                    catch (Exception ex) { throw new Exception("Cannot sending data, details: " + ex.Message); }

                    strm.Close();
                }

                // get response
                try
                {
                    res = (HttpWebResponse)r.GetResponse();
                }
                catch (Exception ex) { throw new Exception("Cannot getting data, details: " + ex.Message); }

                // reading stream
                try
                {
                    using (var ssr = new StreamReader(res.GetResponseStream())) strs = ssr.ReadToEnd();
                }
                catch (Exception ex) { throw new Exception("Cannot reading data, details: " + ex.Message); }

                if (strs.Length > 0) dn = new XNetResult(true, res, "", strs);
                else dn = new XNetResult(true, res);

                ow = false;
                return dn;
            }
            catch (Exception ex)
            {
                dn = new XNetResult(ex);
                return dn;
            }
        }
    }
}
