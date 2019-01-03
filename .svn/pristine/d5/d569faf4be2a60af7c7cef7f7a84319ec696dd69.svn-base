USE ISAFinance 
GO
DELETE FROM dbo.BankDetail
GO

CREATE TABLE [dbo].[BankDetail_Import](
	[RowID] [uniqueidentifier] NOT NULL,
	[HeaderID] [uniqueidentifier] NULL,
	[RecordID] [varchar](23) NOT NULL,
	[HRecordID] [varchar](23) NOT NULL,
	[RegID] [varchar](23) NOT NULL,
	[TglTran] [varchar] (20) NULL,
	[NoBBK] [varchar](17) NOT NULL,
	[JnsTran] [varchar](3) NOT NULL,
	[NoBGCH] [varchar](15) NOT NULL,
	[Keterangan] [varchar](70) NOT NULL,
	[VTA] [varchar](3) NOT NULL,
	[Debet] [money] NOT NULL,
	[Kredit] [money] NOT NULL,
	[TglBank] [varchar] (20) NULL,
	[TglRK] [varchar](20) NULL,
	[Saldo] [money] NOT NULL,
	[NPrint] [int] NOT NULL,
	[SyncFlag] [bit] NOT NULL,
	[LinkRK] [varchar](1) NOT NULL,
	[Kode] [varchar](7) NOT NULL,
	[Sub] [varchar](11) NOT NULL,
	[Catatan] [varchar](20) NOT NULL,
	[NoPerkiraan] [varchar](12) NOT NULL,
	[LastUpdatedBy] [varchar](250) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,

) ON [PRIMARY]
GO

INSERT INTO dbo.BankDetail_Import
(
		RowID, 
		HeaderID, 
		RecordID, 
		HRecordID, 
		RegID, 
		TglTran, 
		NoBBK, 
		JnsTran, 
		NoBGCH, 
		Keterangan, 
		VTA, 
		Debet, 
		Kredit, 
		TglBank, 
		TglRK, 
		Saldo, 
		NPrint, 
		SyncFlag, 
		LinkRK, 
		Kode, 
		Sub, 
		Catatan, 
		NoPerkiraan, 
		LastUpdatedBy, 
		LastUpdatedTime
)
SELECT 
	NEWID(),
	NULL,
	iddbank,
	idbank,
	id_reg,
	RTRIM(tgl_tran),
	no_bbk,
	jns_tran,
	nobgch,
	keterangan,
	vta,
	debet,
	kredit,
	RTRIM(tgl_bank),
	RTRIM(tgl_rk),
	saldo,
	nprint,
	id_match,
	link_rk,
	kode,
	sub,
	catatan,
	no_perk,	
	'Import',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT * FROM dbank')

GO




UPDATE BankDetail_Import
SET 
TglTran = NULL
WHERE LEFT(TglTran,4) < '1900'

UPDATE BankDetail_Import
SET 
TglBank = NULL
WHERE LEFT(TglBank,4) < '1900'

UPDATE BankDetail_Import
SET 
TglRK = NULL
WHERE LEFT(TglRK,4) < '1900'

GO

INSERT INTO BankDetail
(		RowID, 
		HeaderID, 
		RecordID, 
		HRecordID, 
		RegID, 
		TglTran, 
		NoBBK, 
		JnsTran, 
		NoBGCH, 
		Keterangan, 
		VTA, 
		Debet, 
		Kredit, 
		TglBank, 
		TglRK, 
		Saldo, 
		NPrint, 
		SyncFlag, 
		LinkRK, 
		Kode, 
		Sub, 
		Catatan, 
		NoPerkiraan, 
		LastUpdatedBy, 
		LastUpdatedTime
)
SELECT 
RowID, 
		HeaderID, 
		RecordID, 
		HRecordID, 
		RegID, 
		TglTran, 
		NoBBK, 
		JnsTran, 
		NoBGCH, 
		Keterangan, 
		VTA, 
		Debet, 
		Kredit, 
		TglBank, 
		TglRK, 
		Saldo, 
		NPrint, 
		SyncFlag, 
		LinkRK, 
		Kode, 
		Sub, 
		Catatan, 
		NoPerkiraan, 
		LastUpdatedBy, 
		LastUpdatedTime
FROM BankDetail_Import
where JnsTran<>'VTG'
GO

UPDATE dbo.BankDetail
SET
	HeaderID = (SELECT TOP 1 RowID FROM dbo.Bank b WHERE b.BankID = a.HRecordID)
FROM dbo.BankDetail a

GO

UPDATE DBO.BankDetail
SET RowID = g.GiroID
FROM dbo.BankDetail bd INNER JOIN DBO.Giro g ON SUBSTRING(g.GiroRecID,1,22) + 'G' = bd.RecordID
GO


UPDATE DBO.BankDetail
SET RowID = tbd.RowID
FROM DBO.BankDetail bd INNER JOIN DBO.TransferBankDetail tbd ON bd.RecordID = tbd.RecordID
GO
UPDATE DBO.BankDetail
SET RowID = tbd.RowID
FROM DBO.BankDetail bd INNER JOIN DBO.GiroInternal tbd ON bd.RecordID = tbd.GiroRecID
GO




SELECT  
RowID,RecordID
INTO #TempT
FROM DBO.BankDetail
WHERE RTRIM(Right(RecordID,1)) = 'T'

UPDATE DBO.BankDetail
SET LinkTransferBankID = b.RowID
FROM DBO.BankDetail a INNER JOIN #TempT b ON SUBSTRING(a.RecordID,1,22) = SUBSTRING(b.RecordID,1,22)
WHERE RTRIM(Right(a.RecordID,1)) = 'M'
GO

DROP TABLE #TempT


SELECT  
RowID,RecordID
INTO #TempM
FROM DBO.BankDetail
WHERE RTRIM(Right(RecordID,1)) = 'M'

UPDATE DBO.BankDetail
SET LinkTransferBankID = b.RowID
FROM DBO.BankDetail a INNER JOIN #TempM b ON SUBSTRING(a.RecordID,1,22) = SUBSTRING(b.RecordID,1,22)
WHERE RTRIM(Right(a.RecordID,1)) = 'T'
GO

DROP TABLE #TempM
DROP TABLE BankDetail_Import
GO



