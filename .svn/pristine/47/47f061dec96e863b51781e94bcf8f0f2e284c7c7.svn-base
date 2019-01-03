USE ISAdb
GO
DELETE FROM dbo.KompensasiKerugian
GO

INSERT INTO dbo.KompensasiKerugian
(
 KelompokBarang,
DiscKompensasi
)
SELECT 
RTRIM(kel_brg),
disc_komp
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM KompensasiKerugian')

GO
--SELECT *FROM dbo.KompensasiKerugian  