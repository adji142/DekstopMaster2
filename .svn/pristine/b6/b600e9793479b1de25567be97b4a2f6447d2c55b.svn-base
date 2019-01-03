USE ISAFinance
GO
TRUNCATE TABLE dbo.KartuPiutangLunas
GO
INSERT INTO dbo.KartuPiutangLunas
SELECT	k.RowID,
		a.*
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM kpiutlns') a
INNER JOIN dbo.KartuPiutang k (NOLOCK) ON a.id_kp = k.KPID

GO
