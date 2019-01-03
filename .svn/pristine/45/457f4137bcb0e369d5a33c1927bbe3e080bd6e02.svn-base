 USE ISAdb

GO
--DELETE FROM ISAdb.dbo.NotaPenjualanDetail
DELETE ISAdb.dbo.NotaPenjualanDetail

GO
INSERT INTO ISAdb.dbo.NotaPenjualanDetail
(
	RowID
	,HeaderID
	,DODetailID
	,DOID
	,RecordID
	,HtrID
	,BarangID
	,HrgJual
	,Disc1
	,Disc2
	,Disc3
	,DiscFormula
	,Pot
	,KodeGudang
	,QtySuratJalan
	,QtyNota
	,QtyKoli
	,KoliAwal
	,KoliAkhir
	,NoKoli
	,Catatan
	,SyncFlag
	,KetKoli
	,NPackingListPrint
	,LastUpdatedBy
	,LastUpdatedTime
)
SELECT
	NEWID(), 
	b.RowID, 
	(SELECT TOP 1 c.RowID 
		FROM dbo.OrderPenjualanDetail c 
		WHERE b.DOID = c.HeaderID AND RTRIM(a.id_brg) = c.BarangID),
	b.DOID,	
	RTRIM(a.idrec), 
	RTRIM(a.idtr), 
	RTRIM(a.id_brg),
	h_jual,
	disc_1,
	disc_2,
	disc_3,
	id_disc,
	pot_rp,
	RTRIM(kd_gdg),
	a.j_sj, 
	a.j_nota, 
	a.j_koli, 
	a.koli_awal, 
	a.koli_akhir, 
	a.no_koli, 
	a.catatan, 
	a.id_match, 
	a.ket_koli,
	a.nprint, 
	'Admin', 
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 
'SELECT idrec,idtr,kd_gdg,id_brg,h_jual,disc_1,disc_2,disc_3,id_disc,pot_rp,j_sj,j_nota,j_koli,koli_awal,koli_akhir,no_koli,
catatan,id_match,ket_koli,nprint FROM DTRANSJ') AS a
LEFT OUTER JOIN dbo.NotaPenjualan b ON a.idtr = b.RecordID


/* 
UPDATE dbo.NotaPenjualanDetail
SET DODetailID = (SELECT TOP 1 d.RowID 
				FROM dbo.OrderPenjualanDetail d 
				WHERE c.DOID = d.HeaderID AND RTRIM(b.id_brg) = d.BarangID)
FROM dbo.NotaPenjualanDetail a  
LEFT OUTER JOIN SAS_FOX...dtransj b ON a.RecordID = RTRIM(b.idrec)
LEFT OUTER JOIN dbo.NotaPenjualan c ON a.HeaderID = c.RowID
*/

GO
--SELECT * FROM NotaPenjualanDetail