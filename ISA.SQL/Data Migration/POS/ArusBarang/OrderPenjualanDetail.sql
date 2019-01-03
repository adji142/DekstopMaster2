USE ISAdb

GO
DELETE FROM ISAdb.dbo.OrderPenjualanDetail

GO
INSERT INTO ISAdb.dbo.OrderPenjualanDetail
(
	RowID,  
	RecordID, 
	HtrID, 
	BarangID, 
	QtyRequest, 
	QtyDO, 
	HrgJual,	
	Disc1, 
	Disc2, 
	Disc3, 
	Pot, 
	DiscFormula, 
	NoDOBO, 
	NoACC, 
	Catatan, 
	SyncFlag, 
	NBOPrint,
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(), 
	RTRIM(idrec), 
	RTRIM(idhtr), 
	RTRIM(id_brg), 
	j_rq, 
	j_do, 
	h_jual,	
	disc_1, 
	disc_2, 
	disc_3, 
	pot_rp, 
	RTRIM(id_disc), 
	RTRIM(no_bodo), 
	RTRIM(no_acc), 
	RTRIM(catatan), 
	(CASE WHEN LEFT(id_match, 1) = '1' THEN 1 ELSE 0 END),
	nprint,
	'DELTA CRB',
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM dhtransj')

GO
UPDATE dbo.OrderPenjualanDetail
SET [HeaderID] = b.RowID
FROM dbo.OrderPenjualanDetail a LEFT OUTER JOIN dbo.OrderPenjualan b
ON a.HtrID = b.HtrID


GO

SELECT RTRIM(id_pj) AS id_pj, RTRIM(idrec) AS idrec INTO #tempJualBeli FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT a.id_pj, b.idrec FROM tmpsheet a INNER JOIN dosheet b ON a.id_do = b.idtr')

GO
UPDATE ISAdb.dbo.OrderPenjualanDetail
SET DOBeliDetailID = c.RowID
FROM dbo.OrderPenjualanDetail a
	LEFT OUTER JOIN #tempJualBeli b ON a.RecordID = b.id_pj
	LEFT OUTER JOIN dbo.OrderPembelianDetail c ON RTRIM(b.idrec) = c.RecordID

GO

DROP TABLE #tempJualBeli

GO
 IF EXISTS (SELECT 1 
    FROM INFORMATION_SCHEMA.TABLES 
    WHERE TABLE_TYPE='BASE TABLE' 
    AND 
    TABLE_NAME='OrderPenjualanDetailTemp') 
	BEGIN
		DROP TABLE OrderPenjualanDetailTemp
	END    

GO
CREATE TABLE ISAdb.dbo.OrderPenjualanDetailTemp
(
	DORecID varchar(23),
	NotaRecID varchar(23),
	RecordID varchar (23),
	BarangID varchar(23),
	NoACC VARCHAR(7),
	QtyRq int,
	QtyDO int,
	HrgJual money	
)

GO

CREATE CLUSTERED INDEX tempIndexJual ON OrderPenjualanDetailTemp (DORecID, BarangID, QtyRq)



GO


INSERT INTO ISAdb.dbo.OrderPenjualanDetailTemp
(
	DORecID,
	NotaRecID,
	RecordID,
	BarangID,
	NoACC,
	QtyRq,
	QtyDO,
	HrgJual
)
SELECT
	RTRIM(idhtr),
	RTRIM(idtr),
	RTRIM(idrec),
	RTRIM(id_brg),
	RTRIM(no_acc),
	j_rq,
	j_do,
	h_jual
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 
'SELECT b.idhtr,a.idtr, a.idrec, a.id_brg, a.j_rq,a.No_acc, a.j_do, a.h_jual FROM dtransj a INNER JOIN htransj b ON a.idtr = b.idtr')



GO

UPDATE OrderPenjualanDetail 
SET HrgJual = tdo.HrgJual
FROM dbo.OrderPenjualanDetail ddo
INNER JOIN dbo.OrderPenjualan hdo ON ddo.HeaderID = hdo.RowID
INNER JOIN dbo.OrderPenjualanDetailTemp tdo ON ddo.BarangID = tdo.BarangID AND tdo.DORecID = hdo.HtrID AND tdo.QtyRq = ddo.QtyRequest
WHERE ddo.HrgJual <> tdo.HrgJual AND tdo.HrgJual <> 0

UPDATE OrderPenjualanDetail 
SET 
	QtyDO = tdo.QtyDO,
	NoAcc = tdo.NoAcc
FROM dbo.OrderPenjualanDetail ddo
INNER JOIN dbo.OrderPenjualan hdo ON ddo.HeaderID = hdo.RowID
INNER JOIN dbo.OrderPenjualanDetailTemp tdo ON ddo.BarangID = tdo.BarangID AND tdo.DORecID = hdo.HtrID AND tdo.QtyRq = ddo.QtyRequest
--WHERE ddo.HrgJual <> tdo.HrgJual AND tdo.HrgJual <> 0

 Go
 UPDATE OrderPenjualanDetail
SET HrgJual=1,
	Pot=1
WHERE HrgJual=0 OR HrgJual=1
go
DROP TABLE OrderPenjualanDetailTemp
--SELECT * FROM OrderPenjualanDetail
GO

UPDATE DBO.OrderPenjualanDetail
SET RowID = b.RowID,
HeaderID = b.HeaderID

FROM DBO.OrderPenjualanDetail a INNER JOIN ISAdb_JKT.DBO.OrderPenjualanDetail b ON a.RecordID = b.RecordID



GO 