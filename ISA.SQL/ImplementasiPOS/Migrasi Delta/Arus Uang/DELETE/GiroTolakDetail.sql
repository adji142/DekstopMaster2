USE ISAFinance_JKT
GO

DELETE FROM DBO.GiroTolakDetail 
WHERE RecordID NOT IN (SELECT RecordID FROM ISAFinance.DBO.GiroTolakDetail)

GO

