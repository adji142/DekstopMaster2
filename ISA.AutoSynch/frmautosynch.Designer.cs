namespace ISA.AutoSynch
{
    partial class frmautosynch
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmautosynch));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.lbltanggal = new System.Windows.Forms.Label();
            this.txttarget = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblkomputer = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbldetik = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblmenit = new System.Windows.Forms.Label();
            this.lbljam = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblprogress = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.cekupload = new System.Windows.Forms.Label();
            this.cekdownload = new System.Windows.Forms.Label();
            this.timerJadwalEx = new System.Windows.Forms.Timer(this.components);
            this.lblJadwalEx = new System.Windows.Forms.Label();
            this.timermonitoring = new System.Windows.Forms.Timer(this.components);
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtRealisasiSetoran = new System.Windows.Forms.Label();
            this.txtRencanaSetoran = new System.Windows.Forms.Label();
            this.journal = new System.Windows.Forms.Label();
            this.lblHPPA = new System.Windows.Forms.Label();
            this.lblnotapenjualan = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.timerautoclose = new System.Windows.Forms.Timer(this.components);
            this.timerNotaPenjualan = new System.Windows.Forms.Timer(this.components);
            this.timerHPPA = new System.Windows.Forms.Timer(this.components);
            this.timerJournal = new System.Windows.Forms.Timer(this.components);
            this.bwRencana = new System.ComponentModel.BackgroundWorker();
            this.bwRealisasi = new System.ComponentModel.BackgroundWorker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioRealisasi = new System.Windows.Forms.RadioButton();
            this.radioRencana = new System.Windows.Forms.RadioButton();
            this.commandButton1 = new ISA.Controls.CommandButton();
            this.monthYearBox = new ISA.Controls.MonthYearBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.timerSetoran = new System.Windows.Forms.Timer(this.components);
            this.bwSentEmail = new System.ComponentModel.BackgroundWorker();
            this.bwCheckFile = new System.ComponentModel.BackgroundWorker();
            this.bwMatchingan = new System.ComponentModel.BackgroundWorker();
            this.bwINPMAN = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(269, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "Auto Sync Depo";
            // 
            // lbltanggal
            // 
            this.lbltanggal.AutoSize = true;
            this.lbltanggal.ForeColor = System.Drawing.Color.White;
            this.lbltanggal.Location = new System.Drawing.Point(158, 37);
            this.lbltanggal.Name = "lbltanggal";
            this.lbltanggal.Size = new System.Drawing.Size(72, 16);
            this.lbltanggal.TabIndex = 11;
            this.lbltanggal.Text = "lbltanggal";
            // 
            // txttarget
            // 
            this.txttarget.BackColor = System.Drawing.Color.White;
            this.txttarget.Enabled = false;
            this.txttarget.ForeColor = System.Drawing.Color.Black;
            this.txttarget.Location = new System.Drawing.Point(157, 68);
            this.txttarget.Name = "txttarget";
            this.txttarget.Size = new System.Drawing.Size(74, 22);
            this.txttarget.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DimGray;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblkomputer);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lbldetik);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblmenit);
            this.groupBox1.Controls.Add(this.lbljam);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txttarget);
            this.groupBox1.Controls.Add(this.lbltanggal);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 169);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Keterangan AutoSynch";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 28;
            this.label1.Text = "Komputer";
            // 
            // lblkomputer
            // 
            this.lblkomputer.AutoSize = true;
            this.lblkomputer.ForeColor = System.Drawing.Color.White;
            this.lblkomputer.Location = new System.Drawing.Point(158, 100);
            this.lblkomputer.Name = "lblkomputer";
            this.lblkomputer.Size = new System.Drawing.Size(84, 16);
            this.lblkomputer.TabIndex = 29;
            this.lblkomputer.Text = "lblkomputer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(250, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 28);
            this.label5.TabIndex = 27;
            this.label5.Text = ":";
            // 
            // lbldetik
            // 
            this.lbldetik.AutoSize = true;
            this.lbldetik.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldetik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbldetik.Location = new System.Drawing.Point(265, 132);
            this.lbldetik.Name = "lbldetik";
            this.lbldetik.Size = new System.Drawing.Size(42, 28);
            this.lbldetik.TabIndex = 25;
            this.lbldetik.Text = "00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label6.Location = new System.Drawing.Point(200, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 28);
            this.label6.TabIndex = 26;
            this.label6.Text = ":";
            // 
            // lblmenit
            // 
            this.lblmenit.AutoSize = true;
            this.lblmenit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmenit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblmenit.Location = new System.Drawing.Point(215, 132);
            this.lblmenit.Name = "lblmenit";
            this.lblmenit.Size = new System.Drawing.Size(42, 28);
            this.lblmenit.TabIndex = 24;
            this.lblmenit.Text = "00";
            // 
            // lbljam
            // 
            this.lbljam.AutoSize = true;
            this.lbljam.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbljam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbljam.Location = new System.Drawing.Point(165, 131);
            this.lbljam.Name = "lbljam";
            this.lbljam.Size = new System.Drawing.Size(42, 28);
            this.lbljam.TabIndex = 23;
            this.lbljam.Text = "00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(15, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Target";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tanggal Sekarang";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(429, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(153, 148);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // lblprogress
            // 
            this.lblprogress.AutoSize = true;
            this.lblprogress.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblprogress.Location = new System.Drawing.Point(272, 255);
            this.lblprogress.Name = "lblprogress";
            this.lblprogress.Size = new System.Drawing.Size(0, 16);
            this.lblprogress.TabIndex = 15;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "AutoSynch Upload";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-1, 40);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(671, 10);
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // cekupload
            // 
            this.cekupload.AutoSize = true;
            this.cekupload.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cekupload.ForeColor = System.Drawing.Color.White;
            this.cekupload.Location = new System.Drawing.Point(8, 20);
            this.cekupload.Name = "cekupload";
            this.cekupload.Size = new System.Drawing.Size(136, 15);
            this.cekupload.TabIndex = 17;
            this.cekupload.Text = "INPMAN is Disabled";
            this.cekupload.Click += new System.EventHandler(this.cekupload_Click);
            // 
            // cekdownload
            // 
            this.cekdownload.AutoSize = true;
            this.cekdownload.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cekdownload.ForeColor = System.Drawing.Color.White;
            this.cekdownload.Location = new System.Drawing.Point(8, 45);
            this.cekdownload.Name = "cekdownload";
            this.cekdownload.Size = new System.Drawing.Size(205, 15);
            this.cekdownload.TabIndex = 18;
            this.cekdownload.Text = "Koreksi Penjualan is Disabled";
            this.cekdownload.Click += new System.EventHandler(this.cekdownload_Click);
            // 
            // timerJadwalEx
            // 
            this.timerJadwalEx.Interval = 1000;
            this.timerJadwalEx.Tick += new System.EventHandler(this.timerJadwalEx_Tick);
            // 
            // lblJadwalEx
            // 
            this.lblJadwalEx.AutoSize = true;
            this.lblJadwalEx.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJadwalEx.ForeColor = System.Drawing.Color.White;
            this.lblJadwalEx.Location = new System.Drawing.Point(8, 72);
            this.lblJadwalEx.Name = "lblJadwalEx";
            this.lblJadwalEx.Size = new System.Drawing.Size(189, 15);
            this.lblJadwalEx.TabIndex = 19;
            this.lblJadwalEx.Text = "Jadwal Expedisi is Disabled";
            // 
            // timermonitoring
            // 
            this.timermonitoring.Interval = 1000;
            this.timermonitoring.Tick += new System.EventHandler(this.timermonitoring_Tick);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(12, 557);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(647, 29);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 20;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.DimGray;
            this.groupBox2.Controls.Add(this.txtRealisasiSetoran);
            this.groupBox2.Controls.Add(this.txtRencanaSetoran);
            this.groupBox2.Controls.Add(this.journal);
            this.groupBox2.Controls.Add(this.lblHPPA);
            this.groupBox2.Controls.Add(this.lblnotapenjualan);
            this.groupBox2.Controls.Add(this.cekupload);
            this.groupBox2.Controls.Add(this.cekdownload);
            this.groupBox2.Controls.Add(this.lblJadwalEx);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.groupBox2.Location = new System.Drawing.Point(6, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(627, 240);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informasi Program Yang Berjalan";
            // 
            // txtRealisasiSetoran
            // 
            this.txtRealisasiSetoran.AutoSize = true;
            this.txtRealisasiSetoran.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRealisasiSetoran.ForeColor = System.Drawing.Color.White;
            this.txtRealisasiSetoran.Location = new System.Drawing.Point(8, 213);
            this.txtRealisasiSetoran.Name = "txtRealisasiSetoran";
            this.txtRealisasiSetoran.Size = new System.Drawing.Size(201, 15);
            this.txtRealisasiSetoran.TabIndex = 24;
            this.txtRealisasiSetoran.Text = "Realisasi Setoran is Disabled";
            // 
            // txtRencanaSetoran
            // 
            this.txtRencanaSetoran.AutoSize = true;
            this.txtRencanaSetoran.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRencanaSetoran.ForeColor = System.Drawing.Color.White;
            this.txtRencanaSetoran.Location = new System.Drawing.Point(8, 187);
            this.txtRencanaSetoran.Name = "txtRencanaSetoran";
            this.txtRencanaSetoran.Size = new System.Drawing.Size(198, 15);
            this.txtRencanaSetoran.TabIndex = 23;
            this.txtRencanaSetoran.Text = "Rencana Setoran is Disabled";
            // 
            // journal
            // 
            this.journal.AutoSize = true;
            this.journal.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.journal.ForeColor = System.Drawing.Color.White;
            this.journal.Location = new System.Drawing.Point(11, 158);
            this.journal.Name = "journal";
            this.journal.Size = new System.Drawing.Size(125, 15);
            this.journal.TabIndex = 22;
            this.journal.Text = "Jurnal is Disabled";
            // 
            // lblHPPA
            // 
            this.lblHPPA.AutoSize = true;
            this.lblHPPA.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHPPA.ForeColor = System.Drawing.Color.White;
            this.lblHPPA.Location = new System.Drawing.Point(11, 133);
            this.lblHPPA.Name = "lblHPPA";
            this.lblHPPA.Size = new System.Drawing.Size(119, 15);
            this.lblHPPA.TabIndex = 21;
            this.lblHPPA.Text = "HPPA is Disabled";
            // 
            // lblnotapenjualan
            // 
            this.lblnotapenjualan.AutoSize = true;
            this.lblnotapenjualan.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnotapenjualan.ForeColor = System.Drawing.Color.White;
            this.lblnotapenjualan.Location = new System.Drawing.Point(9, 101);
            this.lblnotapenjualan.Name = "lblnotapenjualan";
            this.lblnotapenjualan.Size = new System.Drawing.Size(185, 15);
            this.lblnotapenjualan.TabIndex = 20;
            this.lblnotapenjualan.Text = "Nota Penjualan is Disabled";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tempus Sans ITC", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(13, 602);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(607, 15);
            this.label7.TabIndex = 22;
            this.label7.Text = "NB : Apabila gambar berhenti berputar, hal itu menandakan bahwa progress Upload/D" +
                "ownload sedang dilakukan. Don\'t close it!";
            // 
            // timerautoclose
            // 
            this.timerautoclose.Interval = 1000;
            this.timerautoclose.Tick += new System.EventHandler(this.timerautoclose_Tick);
            // 
            // timerNotaPenjualan
            // 
            this.timerNotaPenjualan.Interval = 1000;
            this.timerNotaPenjualan.Tick += new System.EventHandler(this.timerNotaPenjualan_Tick);
            // 
            // timerHPPA
            // 
            this.timerHPPA.Interval = 1000;
            this.timerHPPA.Tick += new System.EventHandler(this.timerHPPA_Tick);
            // 
            // timerJournal
            // 
            this.timerJournal.Interval = 1000;
            this.timerJournal.Tick += new System.EventHandler(this.timerJournal_Tick);
            // 
            // bwRencana
            // 
            this.bwRencana.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwRencana_DoWork);
            this.bwRencana.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwRencana_RunWorkerCompleted);
            this.bwRencana.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwRencana_ProgressChanged);
            // 
            // bwRealisasi
            // 
            this.bwRealisasi.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwRealisasi_DoWork);
            this.bwRealisasi.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwRealisasi_RunWorkerCompleted);
            this.bwRealisasi.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwRealisasi_ProgressChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 250);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(647, 272);
            this.tabControl1.TabIndex = 23;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(639, 246);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "AUTO";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(639, 246);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "MANUAL";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.DimGray;
            this.groupBox3.Controls.Add(this.radioRealisasi);
            this.groupBox3.Controls.Add(this.radioRencana);
            this.groupBox3.Controls.Add(this.commandButton1);
            this.groupBox3.Controls.Add(this.monthYearBox);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.groupBox3.Location = new System.Drawing.Point(6, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(627, 240);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Auto Sync Seoran";
            // 
            // radioRealisasi
            // 
            this.radioRealisasi.AutoSize = true;
            this.radioRealisasi.Location = new System.Drawing.Point(32, 65);
            this.radioRealisasi.Name = "radioRealisasi";
            this.radioRealisasi.Size = new System.Drawing.Size(139, 19);
            this.radioRealisasi.TabIndex = 31;
            this.radioRealisasi.TabStop = true;
            this.radioRealisasi.Text = "Realisasi Setoran";
            this.radioRealisasi.UseVisualStyleBackColor = true;
            // 
            // radioRencana
            // 
            this.radioRencana.AutoSize = true;
            this.radioRencana.Location = new System.Drawing.Point(32, 40);
            this.radioRencana.Name = "radioRencana";
            this.radioRencana.Size = new System.Drawing.Size(136, 19);
            this.radioRencana.TabIndex = 30;
            this.radioRencana.TabStop = true;
            this.radioRencana.Text = "Rencana Setoran";
            this.radioRencana.UseVisualStyleBackColor = true;
            // 
            // commandButton1
            // 
            this.commandButton1.CommandType = ISA.Controls.CommandButton.enCommandType.None;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.commandButton1.ForeColor = System.Drawing.Color.Black;
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(444, 88);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 29;
            this.commandButton1.Text = "Proses";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // monthYearBox
            // 
            this.monthYearBox.Location = new System.Drawing.Point(235, 40);
            this.monthYearBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.monthYearBox.Month = 1;
            this.monthYearBox.Name = "monthYearBox";
            this.monthYearBox.Size = new System.Drawing.Size(309, 21);
            this.monthYearBox.TabIndex = 27;
            this.monthYearBox.Year = 2015;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 528);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(643, 23);
            this.progressBar.TabIndex = 26;
            // 
            // timerSetoran
            // 
            this.timerSetoran.Interval = 1000;
            this.timerSetoran.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // bwSentEmail
            // 
            this.bwSentEmail.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSentEmail_DoWork);
            // 
            // bwCheckFile
            // 
            this.bwCheckFile.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwCheckFile_DoWork);
            // 
            // bwMatchingan
            // 
            this.bwMatchingan.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwMatchingan_DoWork);
            this.bwMatchingan.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwMatchingan_RunWorkerCompleted);
            // 
            // bwINPMAN
            // 
            this.bwINPMAN.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwINPMAN_DoWork);
            this.bwINPMAN.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwINPMAN_RunWorkerCompleted);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.SystemColors.Menu;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restoreToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.restoreToolStripMenuItem.Text = "Restore";
            this.restoreToolStripMenuItem.Click += new System.EventHandler(this.restoreToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // frmautosynch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(671, 626);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblprogress);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmautosynch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto Sync Depo";
            this.Load += new System.EventHandler(this.frmautosynch_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmautosynch_FormClosing);
            this.Resize += new System.EventHandler(this.frmautosynch_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbltanggal;
        private System.Windows.Forms.TextBox txttarget;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblprogress;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbldetik;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblmenit;
        private System.Windows.Forms.Label lbljam;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label cekupload;
        private System.Windows.Forms.Label cekdownload;
        private System.Windows.Forms.Timer timerJadwalEx;
        private System.Windows.Forms.Label lblJadwalEx;
        private System.Windows.Forms.Timer timermonitoring;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblkomputer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer timerautoclose;
        private System.Windows.Forms.Timer timerNotaPenjualan;
        private System.Windows.Forms.Label lblnotapenjualan;
        private System.Windows.Forms.Timer timerHPPA;
        private System.Windows.Forms.Label journal;
        private System.Windows.Forms.Label lblHPPA;
        private System.Windows.Forms.Timer timerJournal;
        private System.ComponentModel.BackgroundWorker bwRencana;
        private System.ComponentModel.BackgroundWorker bwRealisasi;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label txtRealisasiSetoran;
        private System.Windows.Forms.Label txtRencanaSetoran;
        private System.Windows.Forms.GroupBox groupBox3;
        private ISA.Controls.MonthYearBox monthYearBox;
        private ISA.Controls.CommandButton commandButton1;
        private System.Windows.Forms.RadioButton radioRealisasi;
        private System.Windows.Forms.RadioButton radioRencana;
        private System.Windows.Forms.Timer timerSetoran;
        private System.ComponentModel.BackgroundWorker bwSentEmail;
        private System.ComponentModel.BackgroundWorker bwCheckFile;
        private System.ComponentModel.BackgroundWorker bwMatchingan;
        private System.ComponentModel.BackgroundWorker bwINPMAN;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}