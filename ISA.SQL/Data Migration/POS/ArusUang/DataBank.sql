USE ISAFinance
GO
TRUNCATE TABLE dbo.DataBank
GO

SELECT	 *
INTO #DataBank
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM DataBank') a
WHERE RTRIM(LTRIM(a.bank))<>'' OR Kota<>''

INSERT INTO dbo.DataBank 
SELECT NEWID(), x.Bank, x.Kota, y.lamaCair
FROM (
		SELECT d.bank, d.kota
		FROM #DataBank d
		GROUP BY d.bank, d.Kota
	)x
OUTER APPLY (	SELECT TOP 1 LamaCair
				FROM #databank k
				WHERE k.Bank = x.Bank AND k.Kota = k.Kota
		)y
DROP TABLE #DataBank