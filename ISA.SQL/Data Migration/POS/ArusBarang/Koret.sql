USE ISAdb 
GO
DELETE FROM ISAdb.dbo.Koret
GO

INSERT INTO ISAdb.dbo.Koret
(
ReturPenjualanID ,
ReturID ,
NoRetur ,
tk ,
LastUpdatedBy ,
LastUpdatedTime 
)
SELECT 
		b.RowID,
		a.idretur,
		a.no_ret,
		a.tk,
		'DELTA CRB',
		GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM Koret') a
LEFT OUTER JOIN	 dbo.ReturPenjualan b ON a.idretur=b.ReturID
GO
UPDATE DBO.Koret
SET ReturPenjualanID = b.ReturPenjualanID
FROM DBO.Koret a INNER JOIN ISAdb_JKT.DBO.Koret b ON a.ReturID = b.ReturID

GO
--SELECT * FROm dbo.Koret 