using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISA.Controls
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
            public const string UploadFailed = "Proses Upload gagal, silakan coba lagi";
            public const string NoDataAvailable = "Tidak ada data";
        }
    }
}
