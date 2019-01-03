 --1. Query buat crosschek data

select a.nokoreksi, a.RecordID, b.recordid from KoreksiReturPembelian a left outer join KoreksiReturPembelian_CRB b on a.NoKoreksi = b.nokoreksi and a.BarangID = b.barangid
where
a.TglKoreksi >= '2011/08/01' --and '2011/09/30'
and a.RecordID like 'CRB%'
order by a.TglKoreksi

-- ada 22 data null

--2. Kalo ada yang recordid kanan = null artinya data crb yang dikanan gak ada dikiri alias belum masuk. ambil no koreksinya, masukin di 2 query bawah

select * from KoreksiReturPembelian where nokoreksi = '000575'
select * from KoreksiReturPembelian_CRB where nokoreksi = '000575'

-- di cek k no koreksi :000575, /09-11/03, P/09-11/04, KOO3016, K003536, KOO3012, KOO3013, KOO3287, KOO3288, KOO3290, KOO3286, k000576, KOO3661, KOO3667, KOO3669, 
-- KOO3666, 000578, 000577, KOO3675, 000579, K003697, K003694

select top 100 * from KoreksiReturPembelian_MDN order by tglkoreksi desc

-- ini record aman dihapus karena data terakhir medan juga sampai tgl 10, ini artinya data diinput secara terpisah, jadi dihapus ga masalah, lanjut aja ke delete
 -- tgl koreksi tgl 2011-09-30 00:00:00.000, baru masuk ke isa 2011-10-04 12:02:51.683 (kemaren). Ini gak masalah karena data di ujung bulan.
 -- Semua dta lain sudah terlihat valid.
 
 -- 3. Delete dari table asli khusus dari kota yang bersangkutan, copy where statement dari query no.1
DELETE FROM dbo.KoreksiReturPembelian
 where
TglKoreksi >= '2011/08/01' --and '2011/09/30'
and RecordID like 'CRB%'


--4. Insert dari table CRB dengan where statement yang sama lagi.
INSERT INTO dbo.KoreksiReturPembelian
SELECT * FROM dbo.KoreksiReturPembelian_CRB a
where
a.TglKoreksi >= '2011/08/01' --and '2011/09/30'
and a.RecordID like 'CRB%'

--5. Proses selesai, file ini simpan ke isa.project.sql di folder fix data
 