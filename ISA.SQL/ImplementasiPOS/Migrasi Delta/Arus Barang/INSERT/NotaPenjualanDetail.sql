USE ISAdb_JKT
GO



INSERT INTO DBO.NotaPenjualanDetail
(
RowID, HeaderID, DOID, DODetailID, RecordID, HtrID, KodeGudang, BarangID, QtySuratJalan, QtyNota, HrgJual, Disc1, Disc2, Disc3, Pot, DiscFormula, QtyKoli, KoliAwal, KoliAkhir, NoKoli, Catatan, SyncFlag, KetKoli, NPackingListPrint, LastUpdatedBy, LastUpdatedTime
)

SELECT a.RowID, 
nota.RowID AS HeaderID, 
nota.DOID AS DOID, 
(SELECT TOP 1 RowID FROM DBO.OrderPenjualanDetail x WHERE x.HeaderID = nota.DOID AND x.BarangID = a.BarangID ) AS DODetailID, 
RecordID, HtrID, KodeGudang, BarangID, QtySuratJalan, QtyNota, HrgJual, Disc1, Disc2, Disc3, Pot, DiscFormula, QtyKoli, KoliAwal, KoliAkhir, NoKoli, Catatan, SyncFlag, KetKoli, NPackingListPrint, LastUpdatedBy, LastUpdatedTime
FROM ISAdb.DBO.NotaPenjualanDetail a 
OUTER APPLY
(
	SELECT TOP 1 RowID, DOID FROM DBO.NotaPenjualan x WHERE x.RecordID = a.HtrID
) nota
WHERE RecordID NOT IN (SELECT RecordID FROM DBO.NotaPenjualanDetail)

GO