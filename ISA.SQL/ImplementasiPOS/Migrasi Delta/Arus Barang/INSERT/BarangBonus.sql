﻿USE ISAdb_JKT
GO

INSERT INTO DBO.BarangBonus
SELECT * FROM ISAdb.DBO.BarangBonus WHERE TrID NOT IN (SELECT TrID FROM DBO.BarangBonus)

GO  