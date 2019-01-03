 USE ISAFinance 
GO
DELETE FROM dbo.KasOpname
GO
INSERT INTO dbo.KasOpname
(
	RowID, TglOpname, Kasir, K100000, K50000, K20000, K10000, K5000, K2000, K1000, K500, K100, L1000, L500, L200, L100, L50, L25, LastUpdatedBy, LastUpdatedTime
)
SELECT 
	NEWID(),
	Convert(Datetime,idKasir),
	idKasir,
	K100000, 
	K50000, 
	K20000, 
	K10000, 
	K5000, 
	K2000, 
	K1000, 
	K500, 
	K100, 
	L1000, 
	L500, 
	L200, 
	L100, 
	L50, 
	L25, 
	'DELTA CRB', 
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT * FROM STOKKAS')

GO



   