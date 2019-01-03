USE ISAdb
GO
DELETE FROM	dbo.ClosingStok
GO
INSERT INTO dbo.ClosingStok
(
	RowID,
	Tipe,
	TglAwal,
	TglAkhir,
	LastUpdatedBy,
	LastUpdatedTime
)
SELECT
	NEWID(),
	RTRIM(ID),
	Tgl1,
	Tgl2,
	'Admin',
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM Closing')

GO
--SELECT * FROM dbo.ClosingStok 