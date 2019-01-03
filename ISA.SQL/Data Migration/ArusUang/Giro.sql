USE ISAFinance 
GO

DELETE FROM dbo.Giro
GO
IF EXISTS (SELECT * FROM sys.all_objects a WHERE a.name='Giro_Import')
DROP TABLE dbo.Giro_Import
-- Giro_Import, Replace datetime with varchar(20)
CREATE TABLE [dbo].[Giro_Import](
	[RowID] [uniqueidentifier] NOT NULL,
	[VoucherID] [uniqueidentifier] NULL,
	[BBMID] [uniqueidentifier] NULL,
	[TitipID] [uniqueidentifier] NULL,
	[GiroID] [uniqueidentifier] NULL,
	[VoucherRecID] [varchar](23) NULL,
	[BBMRecID] [varchar](23) NULL,
	[TitipRecID] [varchar](23) NULL,
	[GiroRecID] [varchar](23) NULL,
	[KodeToko] [varchar](23) NULL,
	[AsalGiro] [varchar](30) NULL,
	[NamaBank] [varchar](20) NULL,
	[Lokasi] [varchar](20) NULL,
	[CHBG] [varchar](1) NULL,
	[Nomor] [varchar](15) NULL,
	[TglGiro] [varchar] (20) NULL,
	[TglJth] [varchar] (20) NULL,
	[Nominal] [money] NULL,
	[CairTolak] [varchar](1) NULL,
	[TglCair] [varchar] (20) NULL,
	[MainTitip] [varchar](7) NULL,
	[SubTitip] [varchar](11) NULL,
	[MainPiutang] [varchar](7) NULL,
	[SubPiutang] [varchar](11) NULL,
	[BankID] [varchar](23) NULL,
	[NamaBanki] [varchar](20) NULL,
	[NoPerkiraan] [varchar](6) NULL,
	[TglTitip] [varchar] (20) NULL,
	[SyncFlag] [bit] NULL,
	[NoACC] [varchar](15) NULL,
	[MainPerkiraan] [varchar](12) NULL,
	[LastUpdatedBy] [varchar](250) NULL,
	[LastUpdatedTime] [datetime] NULL,
 
) ON [PRIMARY]

GO


INSERT INTO dbo.Giro_Import
(
	RowID, 
	VoucherID, 
	BBMID, 
	TitipID, 
	GiroID, 
	VoucherRecID, 
	BBMRecID, 
	TitipRecID, 
	GiroRecID, 
	KodeToko, 
	AsalGiro, 
	NamaBank, 
	Lokasi, 
	CHBG, 
	Nomor, 
	TglGiro, 
	TglJth, 
	Nominal, 
	CairTolak, 
	TglCair, 
	MainTitip, 
	SubTitip, 
	MainPiutang, 
	SubPiutang, 
	BankID, 
	NamaBanki, 
	NoPerkiraan, 
	TglTitip, 
	SyncFlag, 
	NoACC, 
	MainPerkiraan, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),	
	NULL,
	NULL,
	NULL,
	NULL,
	idvoucher,
	idbbm,
	idtitip,
	idgiro,
	kd_toko,
	asalgiro,
	namabank,
	lokasi,
	chbg,
	nomor,
	tgl_giro,
	tgl_jt,
	nominal,
	cairtolak,
	tgl_cair,
	maintitip,
	subtitip,
	mainpiut,
	subpiut,
	idbank,
	nm_banki,
	no_perk,
	tgl_titip,
	id_match,
	no_acc,
	mainperk,
	'Import',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT * FROM Giro')

GO

-- Data Refinement
DELETE FROM Giro_Import
WHERE VoucherRecID = '' and GiroRecID = ''


GO

-- Date Refinement

UPDATE Giro_Import
SET 
TglGiro = NULL
WHERE LEFT(TglGiro,4) < '1900'

UPDATE Giro_Import
SET 
TglJth = NULL
WHERE LEFT(TglJth,4) < '1900'

UPDATE Giro_Import
SET 
TglCair = NULL
WHERE LEFT(TglCair,4) < '2000'

UPDATE Giro_Import
SET 
TglTitip = NULL
WHERE LEFT(TglTitip,4) < '1900'

GO



---- DELETE DUPLICATE Giro
--SELECT 
--COUNT(*) AS Jumlah,GiroRecID
--INTO #TEMP_Giro
--FROM DBO.Giro_Import
--GROUP BY GiroRecID
--HAVING COUNT(*) > 1 
--GO

--DECLARE delCursor CURSOR   
--FOR SELECT 
--GiroRecID
--FROM #TEMP_Giro

--OPEN delCursor

--DECLARE @RecordID varchar(23)
--DECLARE @RowID UNIQUEIDENTIFIER

--FETCH NEXT FROM delCursor      
--INTO @RecordID

--WHILE @@FETCH_STATUS = 0      
--BEGIN  
--SELECT  TOP 1 @RowID=GiroID FROM DBO.Giro_Import
--WHERE GiroRecID = @RecordID


--DELETE FROM DBO.Giro_Import WHERE RowID <> @RowID
--AND GiroRecID = @RecordID

--FETCH NEXT FROM delCursor      
--INTO @RecordID

--END
--CLOSE delCursor      
--DEALLOCATE delCursor  			  
--GO

--DROP TABLE #TEMP_Giro
--GO




-- Import to real Giro
INSERT INTO Giro
(GiroID,
VoucherID,
BBMID,
TitipID,
VoucherRecID,
BBMRecID,
TitipRecID,
GiroRecID,
KodeToko,
NamaBank,
Lokasi,
CHBG,
Nomor,
TglGiro,
TglJth,
Nominal,
CairTolak,
TglCair,
MainTitip,
SubTitip,
MainPiutang,
SubPiutang,
BankID,
NamaBanki,
NoPerkiraan,
TglTitip,
SyncFlag,
NoACC,
MainPerkiraan,
LastUpdatedBy,
LastUpdatedTime
)
SELECT 
RowID,
VoucherID,
BBMID,
TitipID,
VoucherRecID,
BBMRecID,
TitipRecID,
GiroRecID,
KodeToko,
NamaBank,
Lokasi,
CHBG,
Nomor,
TglGiro,
TglJth,
Nominal,
CairTolak,
TglCair,
MainTitip,
SubTitip,
MainPiutang,
SubPiutang,
BankID,
NamaBanki,
NoPerkiraan,
TglTitip,
SyncFlag,
NoACC,
MainPerkiraan,
LastUpdatedBy,
LastUpdatedTime
FROM Giro_Import

GO

-- Drop table Giro_Import
DROP TABLE Giro_Import
GO

UPDATE Giro SET
GiroID=b.RowID
FROM Giro a INNER JOIN IndenDetail b ON a.GirorecID=b.RecordID

UPDATE Giro SET
VoucherID = b.RowID
FROM Giro a INNER JOIN VoucherJournal b ON a.VoucherRecID = b.RecordID

UPDATE Giro SET
BBMID = b.RowID
FROM Giro a INNER JOIN BBM b ON a.BBMRecID = b.RecordID

UPDATE Giro
SET 
TitipID = (SELECT TOP 1 RowID FROM VoucherJournal b WHERE b.Tipe='TT' AND b.RecordID = a.TitipRecID)
FROM Giro a


GO


