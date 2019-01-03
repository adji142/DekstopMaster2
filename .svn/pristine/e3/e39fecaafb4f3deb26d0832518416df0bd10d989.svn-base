 --1. Query buat crosschek data

select a.nokoreksi, a.RecordID, b.recordid from KoreksiPembelian a left outer join KoreksiPembelian_CRB b on a.NoKoreksi = b.nokoreksi and a.BarangID = b.barangid
where
a.TglKoreksi >= '2011/08/01' --and '2011/09/30'
and a.RecordID like 'CRB%'
order by TglKoreksi


--2. Kalo ada yang recordid kanan = null artinya data crb yang dikanan gak ada dikiri alias belum masuk. ambil no koreksinya, masukin di 2 query bawah

select * from KoreksiPembelian where nokoreksi = 'P/09-11/22'
select * from KoreksiPembelian_CRB where nokoreksi = 'P/09-11/22'
select top 100 * from KoreksiPembelian_CRB order by tglkoreksi desc

-- ini record aman dihapus karena data terakhir medan juga sampai tgl 10, ini artinya data diinput secara terpisah, jadi dihapus ga masalah, lanjut aja ke delete
 -- tgl koreksi tgl 2011-09-30 00:00:00.000, baru masuk ke isa 2011-10-04 12:02:51.683 (kemaren). Ini gak masalah karena data di ujung bulan.
 -- Semua dta lain sudah terlihat valid.
 
 -- 3. Delete dari table asli khusus dari kota yang bersangkutan, copy where statement dari query no.1
DELETE FROM dbo.KoreksiPembelian
 where
TglKoreksi >= '2011/08/01' --and '2011/09/30'
and RecordID like 'CRB%'


--4. Insert dari table crb dengan where statement yang sama lagi.
INSERT INTO dbo.KoreksiPembelian
SELECT * FROM dbo.KoreksiPembelian_CRB a
where
a.TglKoreksi >= '2011/08/01' --and '2011/09/30'
and a.RecordID like 'CRB%'

--5. Proses selesai, file ini simpan ke isa.project.sql di folder fix data
 