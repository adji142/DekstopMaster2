﻿USE ISAFinance_JKT
GO

DELETE FROM DBO.BBM 
WHERE RecordID NOT IN (SELECT RecordID FROM ISAFinance.DBO.BBM)

GO