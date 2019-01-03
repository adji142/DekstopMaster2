
USE ISAdb

GO
DELETE FROM ISAdb.dbo.TargetSalesPerBarangDetail

GO

INSERT INTO dbo.TargetSalesPerBarangDetail
(	
	TargetID,
	Jenis,
	GroupStokID,
	NamaGroup,
	Kelompok,
	Nominal,
	Qty,
	LastUpdatedBy,
	LastUpdatedTime
)

SELECT
	RTRIM(idtarget), 
	jns,
	RTRIM(id_grstok),
	RTRIM(nama_group),
	RTRIM(klp),
	nominal,
	qty,
	'DELTA CRB',
	GETDATE()

FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM Dtarget')

GO
--SELECT * FROM  dbo.TargetSalesPerBarangDetail  


 