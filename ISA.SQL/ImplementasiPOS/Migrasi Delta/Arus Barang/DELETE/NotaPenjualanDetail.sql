﻿USE ISAdb_JKT
GO

DELETE FROM DBO.NotaPenjualanDetail 
WHERE RecordID NOT IN (SELECT RecordID FROM ISAdb.DBO.NotaPenjualanDetail)


GO
