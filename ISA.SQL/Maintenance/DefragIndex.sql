 DECLARE @TableName VARCHAR(250)
DECLARE @SqlCommand VARCHAR(250)
DECLARE @IndexName VARCHAR(250)
DECLARE @DatabaseName	VARCHAR(250) -- Nama database
DECLARE @maxfrag FLOAT-- maximum nilai fragmen yg di cari
DECLARE @MinFrag FLOAT-- Minimum nilai fragmen yg di cari

	SET @DatabaseName ='ISAdb'
	SET @maxfrag = 100
	SET @MinFrag = 5
	SET @TableName = ''
	SET @SqlCommand = ''


DECLARE @TableProses TABLE
	(
	RowNumber INT IDENTITY(1,1) PRIMARY KEY CLUSTERED,
	TableName	VARCHAR(250) DEFAULT(''),
	IndexName VARCHAR(250) DEFAULT(''),
	Fragment	FLOAT DEFAULT(0),
	SqlCommand	VARCHAR(250)
	)

INSERT INTO @TableProses
SELECT  OBJECT_NAME(i.object_id) AS TableName,

        i.name AS TableIndexName,

        phystat.avg_fragmentation_in_percent,

        (CASE WHEN(avg_fragmentation_in_percent>=30) 
			 THEN ' REBUILD'
			 ELSE ' REORGANIZE'--' REORGANIZE'
		END
	   ) AS Command

FROM    sys.dm_db_index_physical_stats(DB_ID(@DatabaseName), NULL, NULL, NULL, 'LIMITED') phystat

        INNER JOIN sys.indexes i ON i.object_id = phystat.object_id AND i.index_id = phystat.index_id

WHERE   i.name IS NOT NULL

        AND (phystat.avg_fragmentation_in_percent BETWEEN @minFrag AND @maxfrag )

ORDER BY OBJECT_NAME(i.object_id),phystat.avg_fragmentation_in_percent DESC

SELECT * FROM @TableProses

DECLARE @i INT
DECLARE @n INT
SET @i = 1
SET @n = (SELECT MAX(RowNumber) FROM @TableProses)
DECLARE @tes NVARCHAR(250)
WHILE (@i<=@n)
	BEGIN
		SELECT @SqlCommand = SqlCommand,@IndexName=IndexName, @TableName = TableName FROM @TableProses WHERE RowNumber = @i
		SET @SqlCommand = N'ALTER INDEX ['+ @IndexName + N'] ON ' + @TableName + @SqlCommand;
		SET @tes =@SqlCommand
		--SELECT @tes
		EXECUTE sp_executesql 	@tes;

		SET @i = @i+1
	END





