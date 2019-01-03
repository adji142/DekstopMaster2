USE ISAdb 
GO
CREATE TABLE [dbo].[ReturPenjualanDetailTemp](
	[RowID] [uniqueidentifier] NOT NULL,
	[HeaderID] [uniqueidentifier] NULL,
	[NotaJualDetailID] [uniqueidentifier] NULL,
	[RecordID] [varchar](23) NOT NULL,
	[ReturID] [varchar](23) NOT NULL,
	[NotaJualDetailRecID] [varchar](23) NOT NULL,
	[KodeRetur] [varchar](1) NOT NULL,
	BarangID varchar(23),
	BarangIDAsli varchar(23),
	[NamaBarang] varchar(73),
	[NamaBarangAsli] varchar(73),
	KodeSales VARCHAR(23) NOT NULL,
	HargaJual MONEY NOT NULL,
	Pot MONEY NOT NULL,
	[QtyMemo] [int] NOT NULL,
	[QtyTarik] [int] NOT NULL,
	[QtyTerima] [int] NOT NULL,
	[QtyGudang] [int] NOT NULL,
	[QtyTolak] [int] NOT NULL,
	[Catatan1] [varchar](30) NOT NULL,
	[Catatan2] [varchar](30) NOT NULL,
	[SyncFlag] [bit] NOT NULL,
	[Kategori] [varchar](1) NOT NULL,
	[KodeGudang] [varchar](4) NOT NULL,
	[NoACC] [varchar](6) NOT NULL,
	[LastUpdatedBy] [varchar](250) NOT NULL,
	[LastUpdatedTime] [datetime] NULL,
 CONSTRAINT [PK_ReturPenjualanDetailTemp] PRIMARY KEY NONCLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

DELETE FROM ISAdb.dbo.ReturPenjualanDetail

GO
DELETE FROM ISAdb.dbo.ReturPenjualanTarikanDetail
GO

INSERT INTO ISAdb.dbo.ReturPenjualanDetailTemp
(
	RowID,  
	RecordID, 
	ReturID, 
	NotaJualDetailRecID,  
	KodeRetur, 
	BarangID,
	BarangIDAsli,
	NamaBarang,
	NamaBarangAsli,
	KodeSales,
	HargaJual,
	Pot,
	QtyMemo, 
	QtyTarik, 
	QtyTerima, 
	QtyGudang, 
	QtyTolak, 
	Catatan1, 
	Catatan2, 
	SyncFlag, 
	Kategori, 
	KodeGudang, 
	NoACC, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID() AS RowID,
	RTRIM(idrec) AS idrec, 
	RTRIM(idretur) AS idretur, 
	RTRIM(iddtr) AS iddtr,  
	RTRIM(kdretur) AS kdretur,  
	RTRIM(id_brg) AS BarangID,
	'' AS BarangIDAsli,
	RTRIM(nama_stok) AS nama_stok,
	'' nama_stok_asli,
	RTRIM(kd_sales) AS kd_sales,
	h_jual,
	pot_rp,
	q_memo, 
	q_tarik, 
	q_terima, 
	q_gudang, 
	q_tolak,  
	RTRIM(catatan) AS catatan, 
	RTRIM(catatan1) AS catatan1, 
	id_match, 
	RTRIM(kategori) AS kategori, 
	RTRIM(kd_gdg) AS kd_gdg, 
	RTRIM(no_acc) AS no_acc ,
	'DELTA CRB' AS lastUpdatedBy, 
	GETDATE() AS lastUpdatedTime
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM dreturj')
WHERE RTRIM(kdretur)IN ('1')

GO 

UPDATE ReturPenjualanDetailTemp
SET RowID = b.RowID,
HeaderID = b.HeaderID,
NotaJualDetailID = b.NotaJualDetailID

FROM DBO.ReturPenjualanDetail a INNER JOIN ISAdb_JKT.DBO.ReturPenjualanDetail b ON a.RecordID = b.RecordID


GO
UPDATE ReturPenjualanDetailTemp
SET [HeaderID] = b.RowID
FROM ReturPenjualanDetailTemp a LEFT OUTER JOIN ReturPenjualan b
ON a.ReturID = b.ReturID

GO
UPDATE ReturPenjualanDetailTemp
SET [NotaJualDetailID] = b.RowID
FROM ReturPenjualanDetailTemp a LEFT OUTER JOIN NotaPenjualanDetail b
ON a.NotaJualDetailRecID = b.RecordID

GO


UPDATE ReturPenjualanDetailTemp
SET 
	BarangIDAsli = c.BarangID,
	NamaBarangAsli = d.NamaStok 
FROM ReturPenjualanDetailTemp a 
LEFT OUTER JOIN NotaPenjualanDetail b ON a.NotaJualDetailRecID = b.RecordID
LEFT OUTER JOIN OrderPenjualanDetail c ON b.DODetailID = c.RowID
LEFT OUTER JOIN Stok d ON d.BarangID = c.BarangID 
GO


INSERT INTO ReturPenjualanDetail
(RowID, HeaderID, NotaJualDetailID, RecordID, ReturID, NotaJualDetailRecID, KodeRetur, QtyMemo, QtyTarik, QtyTerima, QtyGudang, QtyTolak, Catatan1, Catatan2, SyncFlag, Kategori, KodeGudang, NoACC, 
BarangID,HrgJual,LastUpdatedBy, LastUpdatedTime)
SELECT
RowID, HeaderID, NotaJualDetailID, RecordID, ReturID, NotaJualDetailRecID, KodeRetur, QtyMemo, QtyTarik, QtyTerima, QtyGudang, QtyTolak, Catatan1, Catatan2, SyncFlag, Kategori, KodeGudang, NoACC, 
BarangID,HargaJual,LastUpdatedBy, LastUpdatedTime
FROM ReturPenjualanDetailTemp
WHERE 
BarangID = BarangIDAsli

GO


INSERT INTO ISAdb.dbo.ReturPenjualanTarikanDetail
(RowID, HeaderID, RecordID, ReturID, NotaAsal, KodeRetur, BarangID, KodeSales, QtyMemo, QtyTarik, QtyTerima, QtyGudang, QtyTolak, HrgJual, Pot, Catatan1, Catatan2, SyncFlag, Kategori, KodeGudang, NoACC, LastUpdatedBy, LastUpdatedTime)
SELECT
	NEWID(), 
	t.HeaderID, 
	t.RecordID, 
	t.ReturID, 
	ISNULL(n.NoSuratJalan,'') AS NoSuratJalan, 
	'2',
	t.BarangID,
	t.KodeSales, 
	t.QtyMemo,
	t.QtyTarik,
	t.QtyTerima,
	t.QtyGudang, 
	t.QtyTolak,
	t.HargaJual,
	t.Pot ,
	t.Catatan1, 
	t.Catatan2, 
	t.SyncFlag, 
	t.Kategori, 
	t.KodeGudang, 
	t.NoACC, 
	'DELTA CRB', 
	GETDATE()
FROM ReturPenjualanDetailTemp t
CROSS APPLY (
			SELECT nd.NoSuratJalan
			FROM dbo.VwNotaPenjualanDetail  nd
			WHERE t.NotaJualDetailRecID =nd.recordID 
			)n
WHERE 
BarangID <> BarangIDAsli OR BarangIDAsli IS NULL
/*Tarikan n Antar Cabang*/
GO
INSERT INTO ISAdb.dbo.ReturPenjualanTarikanDetail
(
	RowID,  
	RecordID, 
	ReturID, 
	NotaAsal, 
	KodeRetur, 
	BarangID,
	KodeSales,
	QtyMemo, 
	QtyTarik, 
	QtyTerima, 
	QtyGudang, 
	QtyTolak, 
	HrgJual,
	Pot,
	Catatan1, 
	Catatan2, 
	SyncFlag, 
	Kategori, 
	KodeGudang, 
	NoACC, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(), 
	RTRIM(idrec), 
	RTRIM(idretur), 
	RTRIM(asalnota), 
	RTRIM(kdretur), 
	RTRIM(id_brg),
	RTRIM(kd_sales), 
	q_memo, 
	q_tarik, 
	q_terima, 
	q_gudang, 
	q_tolak,  
	h_jual,
	pot_rp,
	RTRIM(catatan), 
	RTRIM(catatan1), 
	id_match, 
	RTRIM(kategori), 
	RTRIM(kd_gdg), 
	RTRIM(no_acc), 
	'DELTA CRB', 
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM dreturj')
WHERE RTRIM(kdretur) IN('2','3')

GO

UPDATE DBO.ReturPenjualanTarikanDetail
SET RowID = b.RowID,
HeaderID = b.HeaderID

FROM DBO.ReturPenjualanTarikanDetail a INNER JOIN ISAdb_JKT.DBO.ReturPenjualanTarikanDetail b ON a.RecordID = b.RecordID



GO 

UPDATE ReturPenjualanTarikanDetail
SET [HeaderID] = b.RowID
FROM ReturPenjualanTarikanDetail a LEFT OUTER JOIN ReturPenjualan b
ON a.ReturID = b.ReturID
GO

DROP TABLE ReturPenjualanDetailTemp
GO