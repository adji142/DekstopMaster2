 -- dbo.OrderPenjualanDetail_Nota adalah duplikasi temporary table yang 
 -- 
 
 INSERT INTO dbo.OrderPenjualanDetail_Nota 
(
	RowID, 
	HeaderID, 
	RecordID, 
	HtrID, 
	BarangID, 
	QtyRequest, 
	QtyDO, 
	HrgJual, 
	KodeToko, 
	TglSuratJalan, 
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
	DOBeliDetailID, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	NULL,
	RTRIM(idrec),
	RTRIM(idtr),
	RTRIM(id_brg), 
	j_sj, 
	j_sj, 
	h_jual, 
	kd_toko, 
	NULL, 
	disc_1, 
	disc_2, 
	disc_3, 
	pot_rp, 
	id_disc, 
	no_bodo, 
	no_acc, 
	catatan, 
	id_match, 
	0, 
	NULL, 
	'Admin', 
	GETDATE()
	
FROM OPENROWSET('VFPOLEDB', 'D:\Share\SAS\Data 6 Ags 2011 - ISA Go Live\database'; ' '; ' ', 'SELECT * FROM dtransj')


GO
DECLARE @temp TABLE
(
	NDetailRecID varchar(23),
	DOID uniqueidentifier
)

-- Populate nota detail yg tidak ada do detailnya
INSERT INTO @temp
SELECT d.RecordID, oh.RowID
FROM dbo.NotaPenjualanDetail d
	INNER JOIN dbo.NotaPenjualan h
	ON d.HeaderID = h.RowID
	INNER JOIN dbo.OrderPenjualan oh
	ON oh.RowID = h.DOID
WHERE d.DODetailID IS NULL

-- Updated DO Header ID
UPDATE dbo.OrderPenjualanDetail_Nota 
SET HeaderID = t.DOID
FROM dbo.OrderPenjualanDetail_Nota do
INNER JOIN @temp t ON do.RecordID = t.NDetailRecID

GO
-- Delete nota yang tidak putus
DELETE dbo.OrderPenjualanDetail_Nota 
WHERE HeaderID IS NULL

GO
SELECT * FROM dbo.OrderPenjualanDetail_Nota 