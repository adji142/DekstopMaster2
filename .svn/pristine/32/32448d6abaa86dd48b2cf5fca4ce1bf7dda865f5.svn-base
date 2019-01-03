using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ISA.Toko
{
    public class Messages
    {
        public struct Error
        {
            public const string FormatError = "Format Salah";
            public const string InputRequired = "Harus Diisi";            
            public const string NotFound = "Data tidak ditemukan";
            public const string RowNotSelected = "Tidak ada data yang dipilih";
            public const string CustomStock = "Barang ID harus berinisial FXT";
            public const string CustomStockUsed = "Barang ID sudah pernah digunakan";
            public const string NoRequestUrgent = "No.RQ untuk DO Urgent (!) diisi setelah di ACC Piutang !!!";
            public const string StillProcessing = "Masih proses data, tidak bisa tutup form";
            public const string ACCDOFound = "Data sudah di ACC dan sudah ada transaksi penjualan";
            public const string LinkPiutang = "Sudah Link ke Piutang, tidak bisa dihapus";
            public const string FileNotFound = "File {0} tidak ada";
            public const string LoginFailed = "Login tidak berhasil";
            public const string WrongPassword = "Password Anda salah";
            public const string ConfirmPasswordNotMatch = "Confirm Password tidak sama";
            public const string AccountInactive = "User Anda tidak aktif, kontak Admin untuk mengaktifkan user account Anda";
            public const string CetakDONotAuthorized = "Maaf... anda tidak berhak cetak ulang DO";
            public const string FailDownload = "Download file gagal, silakan coba lagi";
            public const string NoInternetConnection = "Tidak ada koneksi ke jaringan internet"; 
            public const string DataNotValid = "Data {0} tidak Valid";
            public const string AlreadyClosingPJT = "Periode transaksi sampai tanggal {0} sudah diclosing";
        }

        public struct Question
        {
            public const string AskSave = "Simpan Data ini?";
            public const string AskDelete = "Hapus data ini?";
            public const string AskDownload = "Download data ini?";
            public const string AskCalculateBarang = "Hitung ulang untuk stok barang {0} ini?";
            public const string AskCalculateGudang = "Hitung ulang untuk stok gudang {0} ini?";
        }

        public struct Confirm
        {
            public const string LoginFailed = "Login Failed, wrong user or password";
            public const string DeleteSuccess = "Delete berhasil";
            public const string UpdateSuccess = "Update berhasil";            
            public const string ConfirmPasswordNotMatch = "Password baru tidak sama dengan Confirmed Password";
            public const string WrongPassword = "Password Anda salah";
            public const string DownloadSuccess = "Download berhasil";
            public const string ProcessFinished = "Proses selesai";
            public const string NoDetailData = "DO {0} tidak ada detail.";
            public const string UploadSuccessful = "Proses Upload sudah selesai";
            public const string UploadFailed = "Proses Upload ke FTP gagal, silahkan Upload manual";
            public const string NoDataAvailable = "Tidak ada data";
        }
    }


    public class KotakPesan
    {
        public static void Warning(String pesan, String Judul)
        {
            MessageBox.Show(pesan, Judul, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Warning(String pesan)
        {
            MessageBox.Show(pesan, "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Information(String pesan, String Judul)
        {
            MessageBox.Show(pesan, Judul, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Information(String pesan)
        {
            MessageBox.Show(pesan, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool PertanyaanYesNo(String pesan)
        {
            DialogResult Result = MessageBox.Show(pesan, "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return Result == DialogResult.Yes ? true : false; 
        }

        public static void HargaJual(String pesan)
        {
            Warning(pesan, "Cek Harga Jual");
        }

        public static void InfoHargaJual(String pesan)
        {
            Information(pesan, "Info Harga Jual");
        }

        public static void Plafon(String pesan)
        {
            Warning(pesan, "Cek Plafon");
        }

        public static void HargaBeli(String pesan)
        {
            Warning(pesan, "Cek Harga Beli");
        }

        public static void StatusHarga(String pesan)
        {
            Warning(pesan, "Cek Status Harga");
        }
    }
}
