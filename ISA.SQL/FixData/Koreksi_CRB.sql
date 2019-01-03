--1. Query buat crosschek data

select a.nokoreksi, a.RecordID, b.recordid from KoreksiPenjualan a left outer join koreksipenjualan_crb b on a.NoKoreksi = b.nokoreksi and a.BarangID = b.barangid
where
a.TglKoreksi >= '2011/08/01' --and '2011/09/30'
and a.RecordID like 'CRB%'
order by NoKoreksi


--2. Kalo ada yang recordid kanan = null artinya data crb yang dikanan gak ada dikiri alias belum masuk. ambil no koreksinya, masukin di 2 query bawah

select * from KoreksiPenjualan where nokoreksi = '000579'
select * from KoreksiPenjualan_crb where nokoreksi = '000579'
 -- tgl koreksi tgl 2011-09-30 00:00:00.000, baru masuk ke isa 2011-10-04 12:02:51.683 (kemaren). Ini gak masalah karena data di ujung bulan.
 -- Semua dta lain sudah terlihat valid.
 
 -- 3. Delete dari table asli khusus dari kota yang bersangkutan, copy where statement dari query no.1
DELETE FROM dbo.KoreksiPenjualan
 where
TglKoreksi >= '2011/08/01' --and '2011/09/30'
and RecordID like 'CRB%'


--4. Insert dari table crb dengan where statement yang sama lagi.
INSERT INTO dbo.KoreksiPenjualan
SELECT * FROM dbo.KoreksiPenjualan_CRB a
where
a.TglKoreksi >= '2011/08/01' --and '2011/09/30'
and a.RecordID like 'CRB%'

--5. Proses selesai, file ini simpan ke isa.project.sql di folder fix data
