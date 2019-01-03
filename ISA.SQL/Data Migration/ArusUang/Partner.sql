USE ISAFinance
GO

DELETE FROM DBO.Partner

INSERT INTO dbo.Partner
(
	PartnerID, 
	Uraian, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	idpart,
	uraian,
	'Import',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_GL\'; ' '; ' ', 'SELECT * FROM HPartner')

GO
