-- last edited by ferry
USE ISAdb 
GO
DELETE FROM ISAdb.dbo.Kompensasi
GO
INSERT INTO ISAdb.dbo.Kompensasi
(
	RowID, 
	RecordID, 
	DiscKompensasi, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)

SELECT 
	a.RowID, 
	 Isnull(RTRIM(b.idrec),'') as idrec, 
	(case when ISNUMERIC(disc_komp) = 0
	 then 0
	 when ISNUMERIC(disc_komp) =1  then
	    CONVERT(decimal(5,2),RTRIM(b.disc_komp))
	end) as disc_komp,
	isnull(b.id_match,'') as id_match, 
	'DELTA CRB' as lastupdatedby, 
	getdate() as lastupdatedtime  
FROM dbo.OrderPenjualanDetail a LEFT OUTER JOIN 
OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT idrec,STR(disc_komp) as disc_komp,id_match FROM kompen where idrec IS NOT NULL and empty(idrec) = .F. GROUP BY idrec,disc_komp,id_match HAVING(COUNT(disc_komp)) = 1') b
ON a.RecordID = b.idrec

INSERT INTO ISAdb.dbo.Kompensasi
(
	RowID, 
	RecordID, 
	DiscKompensasi, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)

SELECT 
	a.RowID, 
	 Isnull(RTRIM(b.idrec),'') as idrec, 
	(case when ISNUMERIC(disc_komp) = 0
	 then 0
	 when ISNUMERIC(disc_komp) =1  then
	    CONVERT(decimal(5,2),RTRIM(b.disc_komp))
	end) as disc_komp,
	isnull(b.id_match,'') as id_match, 
	'DELTA CRB' as lastupdatedby, 
	getdate() as lastupdatedtime  
FROM dbo.OrderPenjualanDetail a inner join
OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT distinct idrec,STR(disc_komp) as disc_komp,id_match FROM kompen where idrec IS NOT NULL and EMPTY(idrec) = .F. GROUP BY idrec,disc_komp,id_match HAVING(COUNT(disc_komp)) >= 2') b
ON a.RecordID = b.idrec
and a.RowID not in (select RowID from dbo.Kompensasi with (nolock))

GO
