﻿USE ISAdb_JKT
GO


INSERT INTO DBO.RekapKoli
SELECT * FROM ISAdb.DBO.RekapKoli WHERE RecordID NOT IN (SELECT RecordID FROM DBO.RekapKoli)

GO 