USE ISAFinance
GO

DELETE FROM dbo.PartnerDetail

GO

INSERT INTO dbo.PartnerDetail
(
	PartnerID, 
	PartnerNo, 
	Nama, 
	StatusAktif, 
	DStamp, 
	Catatan, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	idpart,
	NoPart,
	Nama,
	lAktif,
	Dstamp,
	Catatan,
	'Import',
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_GL\'; ' '; ' ', 'SELECT * FROM DPartner')

GO



