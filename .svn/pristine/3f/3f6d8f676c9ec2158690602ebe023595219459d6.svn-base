USE ISAdb_JKT
GO



INSERT INTO DBO.PengirimanEkspedisi
SELECT * FROM ISAdb.DBO.PengirimanEkspedisi WHERE TrID NOT IN (SELECT TrID FROM DBO.PengirimanEkspedisi)

GO 