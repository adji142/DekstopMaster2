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
		'Admin',
		GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM Koret') a
LEFT OUTER JOIN	 dbo.ReturPenjualan b ON a.idretur=b.ReturID
GO
--SELECT * FROm dbo.Koret 