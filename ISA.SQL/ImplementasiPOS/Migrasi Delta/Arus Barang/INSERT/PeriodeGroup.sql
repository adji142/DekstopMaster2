﻿USE ISAdb_JKT
GO

INSERT INTO DBO.PeriodeGroup
SELECT * FROM ISAdb.DBO.PeriodeGroup WHERE StokGroupID NOT IN (SELECT StokGroupID FROM DBO.PeriodeGroup)

GO  