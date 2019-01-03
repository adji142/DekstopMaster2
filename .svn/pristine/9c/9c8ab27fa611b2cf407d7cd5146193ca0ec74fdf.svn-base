 --1. Query buat crosschek data

select a.nokoreksi, a.RecordID, b.recordid from KoreksiReturPenjualan a left outer join KoreksiReturPenjualan_PTK b on a.NoKoreksi = b.nokoreksi and a.BarangID = b.barangid
where
a.TglKoreksi >= '2011/08/01' --and '2011/09/30'
and a.RecordID like 'PTK%'
order by a.TglKoreksi

-- Ada 5 row Null semua kanannya

--2. Kalo ada yang recordid kanan = null artinya data crb yang dikanan gak ada dikiri alias belum masuk. ambil no koreksinya, masukin di 2 query bawah

select * from KoreksiReturPenjualan where nokoreksi = 'RJ00506'
select * from KoreksiReturPenjualan_PTK where nokoreksi = 'RJ00506'

select * from KoreksiReturPenjualan where nokoreksi = 'UIA0053'
select * from KoreksiReturPenjualan_PTK where nokoreksi = 'UIA0053'

select * from KoreksiReturPenjualan where nokoreksi = 'UHA0197'
select * from KoreksiReturPenjualan_PTK where nokoreksi = 'UHA0197'

select * from KoreksiReturPenjualan where nokoreksi = 'UFA0440'
select * from KoreksiReturPenjualan_PTK where nokoreksi = 'UFA0440'

select * from KoreksiReturPenjualan where nokoreksi = 'RJ00366'
select * from KoreksiReturPenjualan_PTK where nokoreksi = 'RJ00366'

-- semua tidak ada linkID

select top 100 * from KoreksiReturPembelian_MDN order by tglkoreksi desc

-- ini record aman dihapus karena data terakhir medan juga sampai tgl 10, ini artinya data diinput secara terpisah, jadi dihapus ga masalah, lanjut aja ke delete
 -- tgl koreksi tgl 2011-09-30 00:00:00.000, baru masuk ke isa 2011-10-04 12:02:51.683 (kemaren). Ini gak masalah karena data di ujung bulan.
 -- Semua dta lain sudah terlihat valid.
 
 -- 3. Delete dari table asli khusus dari kota yang bersangkutan, copy where statement dari query no.1
DELETE FROM dbo.KoreksiReturPenjualan
 where
TglKoreksi >= '2011/08/01' --and '2011/09/30'
and RecordID like 'PTK%'


--4. Insert dari table PTK dengan where statement yang sama lagi.
INSERT INTO dbo.KoreksiReturPenjualan
SELECT * FROM dbo.KoreksiReturPenjualan_PTK a
where
a.TglKoreksi >= '2011/08/01' --and '2011/09/30'
and a.RecordID like 'PTK%'

--5. Proses selesai, file ini simpan ke isa.project.sql di folder fix data
 