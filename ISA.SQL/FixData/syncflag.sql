 DECLARE @Table AS TABLE
(
ID INT IDENTITY(1,1) PRIMARY KEY CLUSTERED,
RowID Uniqueidentifier
)
INSERT INTO @Table
SELECT RowID 
FROM dbo.OrderPEnjualan 
WHERE tgldo between '2011/10/03' AND '2011/10/04'
DECLARE @i INT,@n INT
DECLARE @RowID UNIQUEIDENTIFIER
SET @i = 1
SELECT @n=COUNT(*) FROM @Table
SELECT @N
WHILE (@i<=@n)
	BEGIN
		SELECT @rowID=RowID FROM @Table WHERE ID=@i
		exec asp_DOGantiSyncFlag @rowID,0
		SET @i = @i+1
	END



----------------------------------------------------



UPDATE [ISAdb].[dbo].[Toko]
   SET [SyncFlag] = 0
 WHERE TokoID IN (
	SELECT TOP 10 TokoID from dbo.Toko
)


----------------------------------------------------

UPDATE [ISAdb].[dbo].[Opname]
   SET [SyncFlag] = 0
 WHERE RecordID IN (
	SELECT TOP 10 RecordID from dbo.Opname where LEFT (RecordID,3)='C09'
)
