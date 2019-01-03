USE ISAdb
GO

DELETE FROM ISAdb.dbo.BackOrder
GO

DECLARE @MYTEMP AS table
(
ID UNIQUEIDENTIFIER,
idrec varchar(2000),
idhtr varchar(2000),
rp_net money,
sub varchar(2000),
Admin varchar(100),
createdDate datetime
)
INSERT INTO @MYTEMP
SELECT
	NEWID(),
	RTRIM(idrec),
	RTRIM(idhtr),
	rp_net,
	cast(sub as varchar(2000)) as sub,
    'DELTA CRB',
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT idrec,idhtr,rp_net,STR(sub) as sub FROM dobo')

INSERT INTO ISAdb.dbo.BackOrder
(
	RowID, 
	RecordID, 
	DOHtrID, 
	RpNet, 
	Sub, 
	LastUpdatedBy, 
	LastUpdatedTime
)

SELECT
	ID,
	idrec,
	idhtr,
	rp_net,
	cast((CASE WHEN isnumeric(sub) = 0 THEN 0
	      ELSE sub
	      END
	)as int) AS sub,
	'DELTA CRB',
	GETDATE()
FROM @MYTEMP


GO

UPDATE dbo.BackOrder
SET
	RowID = b.RowID,
	DOID = b.DOID
FROM dbo.BackOrder a
INNER JOIN ISAdb_JKT.dbo.BackOrder b ON  a.RecordID = b.RecordID
 
GO 

UPDATE ISAdb.dbo.BackOrder
SET DOID = b.RowID
FROM dbo.BackOrder a LEFT OUTER JOIN dbo.OrderPenjualan b
ON a.DOHtrID = b.HtrID

GO
--SELECT * FROM BackOrder

