﻿USE ISAFinance_JKT
GO

DELETE FROM DBO.KartuPiutangLunas 
WHERE KPID NOT IN (SELECT KPID FROM ISAFinance.DBO.KartuPiutangLunas)

GO
