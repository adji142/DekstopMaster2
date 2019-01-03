USE ISAdb

GO
DELETE FROM ISAdb.dbo.TargetSalesPerBarang

GO

INSERT INTO dbo.TargetSalesPerBarang
(	
	RecordID,
	TMT,
	TMTPasif,
	KodeSales,
	LastUpdatedBy,
	LastUpdatedTime
)

SELECT
	RTRIM(idtarget), 
	tmt,
	tmt_pasif,
	RTRIM(kd_sales),
	'DELTA CRB',
	GETDATE()

FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM Htarget')
GO
UPDATE dbo.TargetSalesPerBarang
SET 
TMTPasif =NULL
WHERE YEAR(TMTPasif)='1899'
GO
--SELECT * FROM  dbo.TargetSalesPerBarang  

 