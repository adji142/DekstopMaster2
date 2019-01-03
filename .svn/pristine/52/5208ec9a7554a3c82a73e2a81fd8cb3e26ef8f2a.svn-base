use isafinance
go

/*
--cek data kasbon tidak update
--1. Voucher Journal
select * from KasBon k
inner join VoucherJournal v on k.RowID=v.RefRowID
outer apply
( 
	select sum(Debet) Debet from VoucherJournalDetail vd where v.RowID=vd.HeaderID

)vd
where k.JVNo1=''

--2. Bukti BKK
select * from KasBon k
inner join Bukti b on k.RowID=b.SrcID 
outer apply
(
	select sum(Jumlah) Jumlah from BuktiDetail bd where b.RowID=bd.HeaderID
)bd
where b.Src='BSK' and k.BKKNo3=''

--3. Bukti BKM
select * from KasBon k
inner join Bukti b on k.RowID=b.SrcID 
outer apply
(
	select sum(Jumlah) Jumlah from BuktiDetail bd where b.RowID=bd.HeaderID
)bd
where b.Src='BSL' and k.BKMNo3=''

*/

/*
--UPDATE KASBON -> VOUCHER JOURNAL
update KasBon 
set
	[Status]='C',
	JVNo1=v.NoVoucher,
	Total2=vd.Debet,
	JVRp1=vd.Debet
from KasBon k
inner join VoucherJournal v on k.RowID=v.RefRowID
outer apply
( 
	select sum(Debet) Debet from VoucherJournalDetail vd where v.RowID=vd.HeaderID

)vd
where k.JVNo1=''

--UPDATE KASBON PENYELESAIAN BUKTI KURANG -> BKK
UPDATE KasBon
set [Status]='C',
	BKKNo3=b.NoBukti,
	BKKRp3=bd.Jumlah,
	Totku3=bd.Jumlah
from KasBon k
inner join Bukti b on k.RowID=b.SrcID 
outer apply
(
	select sum(Jumlah) Jumlah from BuktiDetail bd where b.RowID=bd.HeaderID
)bd
where b.Src='BSK' and k.BKKNo3=''

--UPDATE KASBON PENYELESAIAN BUKTI LEBIH -> BKM
UPDATE KasBon
set [Status]='C',
	BKMNo3=b.NoBukti,
	BKMRp3=bd.Jumlah,
	Totle3=bd.Jumlah
from KasBon k
inner join Bukti b on k.RowID=b.SrcID 
outer apply
(
	select sum(Jumlah) Jumlah from BuktiDetail bd where b.RowID=bd.HeaderID
)bd
where b.Src='BSL' and k.BKMNo3=''

*/