﻿USE ISAdb_JKT
GO

DELETE FROM DBO.Opname 
WHERE RecordID NOT IN (SELECT RecordID FROM ISAdb.DBO.Opname)


GO 