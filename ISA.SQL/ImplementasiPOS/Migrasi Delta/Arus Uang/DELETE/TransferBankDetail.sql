﻿USE ISAFinance_JKT
GO

DELETE FROM DBO.TransferBankDetail 
WHERE RecordID NOT IN (SELECT RecordID FROM ISAFinance.DBO.TransferBankDetail)


GO
