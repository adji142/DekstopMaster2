﻿USE ISAFinance_JKT
GO

DELETE FROM DBO.PJTtoBukti 
WHERE KPRecID NOT IN (SELECT KPRecID FROM ISAFinance.DBO.PJTtoBukti)
AND BuktiRecID NOT IN (SELECT BuktiRecID  FROM ISAFinance.DBO.PJTtoBukti)

GO
