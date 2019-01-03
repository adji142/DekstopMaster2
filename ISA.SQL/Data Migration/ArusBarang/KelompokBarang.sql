USE ISAdb 
GO
DELETE FROM ISAdb.dbo.KelompokBarang
GO
INSERT INTO ISAdb.dbo.KelompokBarang
(
	KelompokBrgID, 
	Keterangan, 
	Kelompok, 
	MainACC, 
	SubACC, 
	NoPerk, 
	NopRj, 
	NopStk, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	RTRIM(klp),
	RTRIM(ket),
	RTRIM(kel),
	RTRIM(main_acc),
	RTRIM(sub_acc),
	RTRIM(no_perk),
	RTRIM(nop_rj),
	RTRIM(nop_stk),
	'Admin',
	GETDATE()
	FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM kel_brg')

GO

--SELECT * FROM KelompokBarang