USE ISAFinance_JKT
GO


INSERT INTO DBO.PerkiraanKoneksi
SELECT * FROM ISAFinance.DBO.PerkiraanKoneksi WHERE RecordID NOT IN (SELECT RecordID FROM DBO.PerkiraanKoneksi)
GO 