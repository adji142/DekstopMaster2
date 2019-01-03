namespace ISA.Finance.VWil
{
    partial class frmRiwayatIDWilBrowse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRiwayatIDWilBrowse));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView2 = new ISA.Controls.CustomGridView();
            this.Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdWilBaru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdWilLama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upd = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Row = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new ISA.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TokoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alamat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoTelp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WilID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Penanggungjawab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PiutangB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PiutangJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plafon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToJual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToRetPot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JangkaWaktuKredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cabang2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tgl1st = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Catatan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HariKirim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodePos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plafon1st = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bentrok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusAktif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HariSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Daerah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Propinsi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlamatRumah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pengelola = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglLahir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThnBerdiri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusRuko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JmlCabang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JmlSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kinerja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BidangUsaha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefCollector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefSupervisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlafonSurvey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdAdd = new ISA.Controls.CommandButton();
            this.cmdEdit = new ISA.Controls.CommandButton();
            this.cmdDelete = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 26);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1280, 238);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tanggal,
            this.IdWilBaru,
            this.IdWilLama,
            this.Keterangan,
            this.upd,
            this.Row});
            this.dataGridView2.Location = new System.Drawing.Point(3, 133);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView2.Size = new System.Drawing.Size(1274, 102);
            this.dataGridView2.StandardTab = true;
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.Enter += new System.EventHandler(this.dataGridView2_Enter);
            this.dataGridView2.SelectionChanged += new System.EventHandler(this.dataGridView2_SelectionChanged);
            // 
            // Tanggal
            // 
            this.Tanggal.DataPropertyName = "Tanggal";
            dataGridViewCellStyle1.Format = "dd-MM-yyyy";
            this.Tanggal.DefaultCellStyle = dataGridViewCellStyle1;
            this.Tanggal.HeaderText = "Tanggal";
            this.Tanggal.Name = "Tanggal";
            this.Tanggal.ReadOnly = true;
            // 
            // IdWilBaru
            // 
            this.IdWilBaru.DataPropertyName = "WilID";
            this.IdWilBaru.HeaderText = "ID Wil Baru";
            this.IdWilBaru.Name = "IdWilBaru";
            this.IdWilBaru.ReadOnly = true;
            this.IdWilBaru.Width = 150;
            // 
            // IdWilLama
            // 
            this.IdWilLama.DataPropertyName = "WilIDOld";
            this.IdWilLama.HeaderText = "ID Wil Lama";
            this.IdWilLama.Name = "IdWilLama";
            this.IdWilLama.ReadOnly = true;
            this.IdWilLama.Width = 150;
            // 
            // Keterangan
            // 
            this.Keterangan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Keterangan.DataPropertyName = "Keterangan";
            this.Keterangan.HeaderText = "Keterangan";
            this.Keterangan.Name = "Keterangan";
            this.Keterangan.ReadOnly = true;
            // 
            // upd
            // 
            this.upd.DataPropertyName = "upd";
            this.upd.HeaderText = "upd";
            this.upd.Name = "upd";
            this.upd.ReadOnly = true;
            this.upd.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.upd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.upd.Width = 40;
            // 
            // Row
            // 
            this.Row.DataPropertyName = "RowID";
            this.Row.HeaderText = "Row";
            this.Row.Name = "Row";
            this.Row.ReadOnly = true;
            this.Row.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.TokoID,
            this.NamaToko,
            this.Alamat,
            this.Kota,
            this.NoTelp,
            this.WilID,
            this.Penanggungjawab,
            this.KodeToko,
            this.PiutangB,
            this.PiutangJ,
            this.Plafon,
            this.ToJual,
            this.ToRetPot,
            this.JangkaWaktuKredit,
            this.Cabang2,
            this.Tgl1st,
            this.Exist,
            this.ClassID,
            this.Catatan,
            this.SyncFlag,
            this.HariKirim,
            this.KodePos,
            this.Grade,
            this.Plafon1st,
            this.Flag,
            this.Bentrok,
            this.StatusAktif,
            this.HariSales,
            this.Daerah,
            this.Propinsi,
            this.AlamatRumah,
            this.Pengelola,
            this.TglLahir,
            this.Hp,
            this.Status,
            this.ThnBerdiri,
            this.StatusRuko,
            this.JmlCabang,
            this.JmlSales,
            this.Kinerja,
            this.BidangUsaha,
            this.RefSales,
            this.RefCollector,
            this.RefSupervisor,
            this.PlafonSurvey,
            this.LastUpdatedBy,
            this.LastUpdatedTime});
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1274, 102);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // TokoID
            // 
            this.TokoID.DataPropertyName = "TokoID";
            this.TokoID.HeaderText = "TokoID";
            this.TokoID.Name = "TokoID";
            this.TokoID.ReadOnly = true;
            // 
            // NamaToko
            // 
            this.NamaToko.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NamaToko.DataPropertyName = "NamaToko";
            this.NamaToko.HeaderText = "NamaToko";
            this.NamaToko.Name = "NamaToko";
            this.NamaToko.ReadOnly = true;
            // 
            // Alamat
            // 
            this.Alamat.DataPropertyName = "Alamat";
            this.Alamat.HeaderText = "Alamat";
            this.Alamat.Name = "Alamat";
            this.Alamat.ReadOnly = true;
            this.Alamat.Visible = false;
            // 
            // Kota
            // 
            this.Kota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Kota.DataPropertyName = "Kota";
            this.Kota.HeaderText = "Kota";
            this.Kota.Name = "Kota";
            this.Kota.ReadOnly = true;
            // 
            // NoTelp
            // 
            this.NoTelp.DataPropertyName = "Telp";
            this.NoTelp.HeaderText = "No.Telp";
            this.NoTelp.Name = "NoTelp";
            this.NoTelp.ReadOnly = true;
            // 
            // WilID
            // 
            this.WilID.DataPropertyName = "WilID";
            this.WilID.HeaderText = "IdWil";
            this.WilID.Name = "WilID";
            this.WilID.ReadOnly = true;
            // 
            // Penanggungjawab
            // 
            this.Penanggungjawab.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Penanggungjawab.DataPropertyName = "PenanggungJawab";
            this.Penanggungjawab.HeaderText = "Penanggung Jawab";
            this.Penanggungjawab.Name = "Penanggungjawab";
            this.Penanggungjawab.ReadOnly = true;
            // 
            // KodeToko
            // 
            this.KodeToko.DataPropertyName = "KodeToko";
            this.KodeToko.HeaderText = "KodeToko";
            this.KodeToko.Name = "KodeToko";
            this.KodeToko.ReadOnly = true;
            this.KodeToko.Visible = false;
            // 
            // PiutangB
            // 
            this.PiutangB.DataPropertyName = "PiutangB";
            this.PiutangB.HeaderText = "PiutangB";
            this.PiutangB.Name = "PiutangB";
            this.PiutangB.ReadOnly = true;
            this.PiutangB.Visible = false;
            // 
            // PiutangJ
            // 
            this.PiutangJ.DataPropertyName = "PiutangJ";
            this.PiutangJ.HeaderText = "PiutangJ";
            this.PiutangJ.Name = "PiutangJ";
            this.PiutangJ.ReadOnly = true;
            this.PiutangJ.Visible = false;
            // 
            // Plafon
            // 
            this.Plafon.DataPropertyName = "Plafon";
            this.Plafon.HeaderText = "Plafon";
            this.Plafon.Name = "Plafon";
            this.Plafon.ReadOnly = true;
            this.Plafon.Visible = false;
            // 
            // ToJual
            // 
            this.ToJual.DataPropertyName = "ToJual";
            this.ToJual.HeaderText = "ToJual";
            this.ToJual.Name = "ToJual";
            this.ToJual.ReadOnly = true;
            this.ToJual.Visible = false;
            // 
            // ToRetPot
            // 
            this.ToRetPot.DataPropertyName = "ToRetPot";
            this.ToRetPot.HeaderText = "ToRetPot";
            this.ToRetPot.Name = "ToRetPot";
            this.ToRetPot.ReadOnly = true;
            this.ToRetPot.Visible = false;
            // 
            // JangkaWaktuKredit
            // 
            this.JangkaWaktuKredit.DataPropertyName = "JangkaWaktuKredit";
            this.JangkaWaktuKredit.HeaderText = "JangkaWaktuKredit";
            this.JangkaWaktuKredit.Name = "JangkaWaktuKredit";
            this.JangkaWaktuKredit.ReadOnly = true;
            this.JangkaWaktuKredit.Visible = false;
            // 
            // Cabang2
            // 
            this.Cabang2.DataPropertyName = "Cabang2";
            this.Cabang2.HeaderText = "C 2";
            this.Cabang2.Name = "Cabang2";
            this.Cabang2.ReadOnly = true;
            // 
            // Tgl1st
            // 
            this.Tgl1st.DataPropertyName = "Tgl1st";
            this.Tgl1st.HeaderText = "Tgl1st";
            this.Tgl1st.Name = "Tgl1st";
            this.Tgl1st.ReadOnly = true;
            this.Tgl1st.Visible = false;
            // 
            // Exist
            // 
            this.Exist.DataPropertyName = "Exist";
            this.Exist.HeaderText = "Exist";
            this.Exist.Name = "Exist";
            this.Exist.ReadOnly = true;
            this.Exist.Visible = false;
            // 
            // ClassID
            // 
            this.ClassID.DataPropertyName = "ClassID";
            this.ClassID.HeaderText = "ClassID";
            this.ClassID.Name = "ClassID";
            this.ClassID.ReadOnly = true;
            this.ClassID.Visible = false;
            // 
            // Catatan
            // 
            this.Catatan.DataPropertyName = "Catatan";
            this.Catatan.HeaderText = "Catatan";
            this.Catatan.Name = "Catatan";
            this.Catatan.ReadOnly = true;
            this.Catatan.Visible = false;
            // 
            // SyncFlag
            // 
            this.SyncFlag.DataPropertyName = "SyncFlag";
            this.SyncFlag.HeaderText = "SyncFlag";
            this.SyncFlag.Name = "SyncFlag";
            this.SyncFlag.ReadOnly = true;
            this.SyncFlag.Visible = false;
            // 
            // HariKirim
            // 
            this.HariKirim.DataPropertyName = "HariKirim";
            this.HariKirim.HeaderText = "Jx";
            this.HariKirim.Name = "HariKirim";
            this.HariKirim.ReadOnly = true;
            // 
            // KodePos
            // 
            this.KodePos.DataPropertyName = "KodePos";
            this.KodePos.HeaderText = "KodePos";
            this.KodePos.Name = "KodePos";
            this.KodePos.ReadOnly = true;
            this.KodePos.Visible = false;
            // 
            // Grade
            // 
            this.Grade.DataPropertyName = "Grade";
            this.Grade.HeaderText = "Grade";
            this.Grade.Name = "Grade";
            this.Grade.ReadOnly = true;
            this.Grade.Visible = false;
            // 
            // Plafon1st
            // 
            this.Plafon1st.DataPropertyName = "Plafon1st";
            this.Plafon1st.HeaderText = "Plafon1st";
            this.Plafon1st.Name = "Plafon1st";
            this.Plafon1st.ReadOnly = true;
            this.Plafon1st.Visible = false;
            // 
            // Flag
            // 
            this.Flag.DataPropertyName = "Flag";
            this.Flag.HeaderText = "Flag";
            this.Flag.Name = "Flag";
            this.Flag.ReadOnly = true;
            this.Flag.Visible = false;
            // 
            // Bentrok
            // 
            this.Bentrok.DataPropertyName = "Bentrok";
            this.Bentrok.HeaderText = "Bentrok";
            this.Bentrok.Name = "Bentrok";
            this.Bentrok.ReadOnly = true;
            this.Bentrok.Visible = false;
            // 
            // StatusAktif
            // 
            this.StatusAktif.DataPropertyName = "StatusAktif";
            this.StatusAktif.HeaderText = "StatusAktif";
            this.StatusAktif.Name = "StatusAktif";
            this.StatusAktif.ReadOnly = true;
            this.StatusAktif.Visible = false;
            // 
            // HariSales
            // 
            this.HariSales.DataPropertyName = "HariSales";
            this.HariSales.HeaderText = "Js";
            this.HariSales.Name = "HariSales";
            this.HariSales.ReadOnly = true;
            // 
            // Daerah
            // 
            this.Daerah.DataPropertyName = "Daerah";
            this.Daerah.HeaderText = "Daerah";
            this.Daerah.Name = "Daerah";
            this.Daerah.ReadOnly = true;
            this.Daerah.Visible = false;
            // 
            // Propinsi
            // 
            this.Propinsi.DataPropertyName = "Propinsi";
            this.Propinsi.HeaderText = "Propinsi";
            this.Propinsi.Name = "Propinsi";
            this.Propinsi.ReadOnly = true;
            this.Propinsi.Visible = false;
            // 
            // AlamatRumah
            // 
            this.AlamatRumah.DataPropertyName = "AlamatRumah";
            this.AlamatRumah.HeaderText = "AlamatRumah";
            this.AlamatRumah.Name = "AlamatRumah";
            this.AlamatRumah.ReadOnly = true;
            this.AlamatRumah.Visible = false;
            // 
            // Pengelola
            // 
            this.Pengelola.DataPropertyName = "Pengelola";
            this.Pengelola.HeaderText = "Pengelola";
            this.Pengelola.Name = "Pengelola";
            this.Pengelola.ReadOnly = true;
            this.Pengelola.Visible = false;
            // 
            // TglLahir
            // 
            this.TglLahir.DataPropertyName = "TglLahir";
            this.TglLahir.HeaderText = "TglLahir";
            this.TglLahir.Name = "TglLahir";
            this.TglLahir.ReadOnly = true;
            this.TglLahir.Visible = false;
            // 
            // Hp
            // 
            this.Hp.DataPropertyName = "HP";
            this.Hp.HeaderText = "HP";
            this.Hp.Name = "Hp";
            this.Hp.ReadOnly = true;
            this.Hp.Visible = false;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Visible = false;
            // 
            // ThnBerdiri
            // 
            this.ThnBerdiri.DataPropertyName = "ThnBerdiri";
            this.ThnBerdiri.HeaderText = "ThnBerdiri";
            this.ThnBerdiri.Name = "ThnBerdiri";
            this.ThnBerdiri.ReadOnly = true;
            this.ThnBerdiri.Visible = false;
            // 
            // StatusRuko
            // 
            this.StatusRuko.DataPropertyName = "StatusRuko";
            this.StatusRuko.HeaderText = "StatusRuko";
            this.StatusRuko.Name = "StatusRuko";
            this.StatusRuko.ReadOnly = true;
            this.StatusRuko.Visible = false;
            // 
            // JmlCabang
            // 
            this.JmlCabang.DataPropertyName = "JmlCabang";
            this.JmlCabang.HeaderText = "JmlCabang";
            this.JmlCabang.Name = "JmlCabang";
            this.JmlCabang.ReadOnly = true;
            this.JmlCabang.Visible = false;
            // 
            // JmlSales
            // 
            this.JmlSales.DataPropertyName = "JmlSales";
            this.JmlSales.HeaderText = "JmlSales";
            this.JmlSales.Name = "JmlSales";
            this.JmlSales.ReadOnly = true;
            this.JmlSales.Visible = false;
            // 
            // Kinerja
            // 
            this.Kinerja.DataPropertyName = "Kinerja";
            this.Kinerja.HeaderText = "Kinerja";
            this.Kinerja.Name = "Kinerja";
            this.Kinerja.ReadOnly = true;
            this.Kinerja.Visible = false;
            // 
            // BidangUsaha
            // 
            this.BidangUsaha.DataPropertyName = "BidangUsaha";
            this.BidangUsaha.HeaderText = "BidangUsaha";
            this.BidangUsaha.Name = "BidangUsaha";
            this.BidangUsaha.ReadOnly = true;
            this.BidangUsaha.Visible = false;
            // 
            // RefSales
            // 
            this.RefSales.DataPropertyName = "RefSales";
            this.RefSales.HeaderText = "RefSales";
            this.RefSales.Name = "RefSales";
            this.RefSales.ReadOnly = true;
            this.RefSales.Visible = false;
            // 
            // RefCollector
            // 
            this.RefCollector.DataPropertyName = "RefCollector";
            this.RefCollector.HeaderText = "RefCollector";
            this.RefCollector.Name = "RefCollector";
            this.RefCollector.ReadOnly = true;
            this.RefCollector.Visible = false;
            // 
            // RefSupervisor
            // 
            this.RefSupervisor.DataPropertyName = "RefSupervisor";
            this.RefSupervisor.HeaderText = "RefSupervisior";
            this.RefSupervisor.Name = "RefSupervisor";
            this.RefSupervisor.ReadOnly = true;
            this.RefSupervisor.Visible = false;
            // 
            // PlafonSurvey
            // 
            this.PlafonSurvey.DataPropertyName = "PlafonSurvey";
            this.PlafonSurvey.HeaderText = "PlafonSurvey";
            this.PlafonSurvey.Name = "PlafonSurvey";
            this.PlafonSurvey.ReadOnly = true;
            this.PlafonSurvey.Visible = false;
            // 
            // LastUpdatedBy
            // 
            this.LastUpdatedBy.DataPropertyName = "LastUpdatedBy";
            this.LastUpdatedBy.HeaderText = "LastUpdatedBy";
            this.LastUpdatedBy.Name = "LastUpdatedBy";
            this.LastUpdatedBy.ReadOnly = true;
            this.LastUpdatedBy.Visible = false;
            // 
            // LastUpdatedTime
            // 
            this.LastUpdatedTime.DataPropertyName = "LastUpdatedTime";
            this.LastUpdatedTime.HeaderText = "LastUpdatedTime";
            this.LastUpdatedTime.Name = "LastUpdatedTime";
            this.LastUpdatedTime.ReadOnly = true;
            this.LastUpdatedTime.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAdd.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.cmdAdd.Enabled = false;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(257, 285);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(100, 40);
            this.cmdAdd.TabIndex = 1;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEdit.CommandType = ISA.Controls.CommandButton.enCommandType.Edit;
            this.cmdEdit.Enabled = false;
            this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(374, 285);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(100, 40);
            this.cmdEdit.TabIndex = 2;
            this.cmdEdit.Text = "EDIT";
            this.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDelete.CommandType = ISA.Controls.CommandButton.enCommandType.Delete;
            this.cmdDelete.Enabled = false;
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(492, 285);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(100, 40);
            this.cmdDelete.TabIndex = 3;
            this.cmdDelete.Text = "DELETE";
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(1153, 285);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 4;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRefresh.Image = global::ISA.Finance.Properties.Resources.Ok32;
            this.cmdRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRefresh.Location = new System.Drawing.Point(6, 285);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(154, 40);
            this.cmdRefresh.TabIndex = 6;
            this.cmdRefresh.Text = "PROSES IDWIL";
            this.cmdRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmRiwayatIDWilBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1284, 341);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmRiwayatIDWilBrowse";
            this.Text = "Riwayat ID Wil";
            this.Load += new System.EventHandler(this.frmRiwayatIDWilBrowse_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.cmdEdit, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdRefresh, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ISA.Controls.CustomGridView dataGridView1;
        private ISA.Controls.CustomGridView dataGridView2;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.CommandButton cmdAdd;
        private ISA.Controls.CommandButton cmdEdit;
        private ISA.Controls.CommandButton cmdDelete;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TokoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alamat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kota;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoTelp;
        private System.Windows.Forms.DataGridViewTextBoxColumn WilID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Penanggungjawab;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn PiutangB;
        private System.Windows.Forms.DataGridViewTextBoxColumn PiutangJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plafon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToJual;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToRetPot;
        private System.Windows.Forms.DataGridViewTextBoxColumn JangkaWaktuKredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cabang2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tgl1st;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exist;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Catatan;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn HariKirim;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodePos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plafon1st;
        private System.Windows.Forms.DataGridViewTextBoxColumn Flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bentrok;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusAktif;
        private System.Windows.Forms.DataGridViewTextBoxColumn HariSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn Daerah;
        private System.Windows.Forms.DataGridViewTextBoxColumn Propinsi;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlamatRumah;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pengelola;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglLahir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThnBerdiri;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusRuko;
        private System.Windows.Forms.DataGridViewTextBoxColumn JmlCabang;
        private System.Windows.Forms.DataGridViewTextBoxColumn JmlSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kinerja;
        private System.Windows.Forms.DataGridViewTextBoxColumn BidangUsaha;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefCollector;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefSupervisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlafonSurvey;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedTime;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdWilBaru;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdWilLama;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keterangan;
        private System.Windows.Forms.DataGridViewCheckBoxColumn upd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row;

    }
}
