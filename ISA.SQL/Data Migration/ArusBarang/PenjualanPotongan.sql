-- 1. disc_acc, dil_acc di FOXPRO diubah ke text
-- 2. Transfer semua data disc_acc ditampung di field discacctemp varchar pada SQl
-- 3. Transfer semua data dil_acc ditampung di field dilacctemp varchar pada SQl
-- 4. 
	--UPDATE PenjualanPotongan
	--SET
	--DilACCTemp='0'
	--WHERE DilACCTemp like '**%'
-- 5.
--	UPDATE PenjualanPotongan
--	SET
--	DilACC=CONVERT(money, LTRIM(DilACCTemp))

--6.
----UPDATE PenjualanPotongan
----SET
----DiscACCTemp='0'
----WHERE DiscACCTemp like '**%'
--7.
----	UPDATE PenjualanPotongan
----	SET
----	DiscACC=CONVERT(money, LTRIM(DiscACCTemp))
--8.
----	UPDATE PenjualanPotongan
----	SET
----	ACCFlag='v'
----	WHERE RTRIM(ACCFlag)<>''


-- 1. disc_acc, dil_acc di FOXPRO diubah ke text


USE ISAdb 
GO
DELETE FROM dbo.PenjualanPotongan

GO
SELECT 
	NEWID() AS RowID, 
	b.RowID AS NotaPenjualanID, 
	RTRIM(a.idtr) AS TrID, 
	RTRIM(a.idpot) AS PotID,
	RTRIM(a.nopot)AS NoPot,
 	CONVERT(datetime , CASE LEFT(a.tgl_pot,2) WHEN '  ' THEN NULL ELSE RTRIM(a.tgl_pot) END ) AS TglPot, 
	a.dil AS Dil, 
	a.disc AS Disc, 
	a.rp_net AS RpNet, 
	RTRIM(a.catatan) AS Catatan,
	CONVERT(datetime , CASE LEFT(a.tgl_acc,2) WHEN '  ' THEN NULL ELSE RTRIM(a.tgl_acc) END ) AS TglACC, 
	a.dil_acc AS DilACC,
	RTRIM(a.cat_acc) AS CatACC, 
	a.disc_acc AS DiscACC,
	RTRIM(a.id_match) AS SyncFlag, 
	RTRIM(a.id_link) AS IdLink, 
	CASE WHEN RTRIM(a.acc)<> '' THEN 1 ELSE 0 END AS StatusACC
INTO #PenjualanPotonganTemp
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ','SELECT
STR(disc_acc) as disc_acc,
idtr,
idpot,
nopot,
tgl_pot,
dil,
disc,
rp_net,
catatan,
tgl_acc,
STR(dil_acc) as dil_acc,
cat_acc,
id_match,
id_link,
acc
FROM hpotj') a 
LEFT OUTER JOIN dbo.NotaPenjualan b
	ON a.idtr = b.RecordID

GO

UPDATE #PenjualanPotonganTemp
SET TglACC = NULL
WHERE
TglAcc = '1899-12-30 00:00:00.000'

UPDATE #PenjualanPotonganTemp
SET TglPot = NULL
WHERE
TglPot = '1899-12-30 00:00:00.000'


UPDATE #PenjualanPotonganTemp
SET
DilACC='0'
WHERE DilACC LIKE '**%'


UPDATE #PenjualanPotonganTemp
SET
DiscACC='0'
WHERE DiscACC like '**%'

GO
DELETE FROM ISAdb.dbo.PenjualanPotongan

GO

INSERT INTO dbo.PenjualanPotongan
(
RowID, NotaPenjualanID, TrID, PotID, NoPot, TglPot, Dil, Disc, RpNet, Catatan, TglACC, DilACC, CatACC, DiscACC, SyncFlag, IdLink, StatusACC, LastUpdatedTime, LastUpdatedBy
)
SELECT
RowID, NotaPenjualanID, TrID, PotID, NoPot, TglPot, Dil, Disc, RpNet, Catatan, TglACC, CONVERT(money,DilACC), CatACC, CONVERT(money,DiscACC), SyncFlag, IdLink, StatusACC, GetDate(), 'Upload'
FROM #PenjualanPotonganTemp

GO

DROP TABLE #PenjualanPotonganTemp
GO

--SELECT * FROM  dbo.PenjualanPotongan
