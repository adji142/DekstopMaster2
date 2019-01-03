 -- QUERY DATA DO
SELECT
a.RowID, NoDO, a.TglDO, a.NoRequest, a.KodeToko, b.NamaToko, TransactionType, a.HariSales, c.HariSalesFn, b.HariSales, a.LastUpdatedBy
FROM OrderPenjualan  a
INNER JOIN Toko b ON a.KodeToko = b.KodeToko 
OUTER APPLY 
(
	SELECT dbo.fngetHariSales(a.KodeToko , a.TransactionType ) AS HariSalesFn
) c
WHERE TglDO >='2011/10/01'
AND a.HariSales <> c.HariSalesFn
AND a.HtrID LIKE 'C09%'
ORDER BY NoDO

GO

--UPDATE DO
UPDATE OrderPenjualan 
SET HariSales = c.HariSalesFn
FROM OrderPenjualan  a
INNER JOIN Toko b ON a.KodeToko = b.KodeToko 
OUTER APPLY 
(
	SELECT dbo.fngetHariSales(a.KodeToko , a.TransactionType ) AS HariSalesFn
) c
WHERE TglDO >='2011/10/01'
AND a.HtrID LIKE 'C09%'
AND a.HariSales <> c.HariSalesFn

GO
--SELECT FROM NOTA
SELECT
a.RowID, NoSuratJalan, a.TglSuratJalan, a.KodeToko, b.NamaToko, TransactionType, a.HariSales, c.HariSalesFn, b.HariSales, a.LastUpdatedBy
FROM NotaPenjualan  a
INNER JOIN Toko b ON a.KodeToko = b.KodeToko 
OUTER APPLY 
(
	SELECT dbo.fngetHariSales(a.KodeToko , a.TransactionType ) AS HariSalesFn
) c
WHERE TglSuratJalan >='2011/10/01'
AND a.HariSales <> c.HariSalesFn
AND a.HtrID LIKE 'C09%'
ORDER BY NoSuratJalan

GO

--UPDATE NOTA
UPDATE NotaPenjualan 
SET HariSales = c.HariSalesFn
FROM NotaPenjualan  a
INNER JOIN Toko b ON a.KodeToko = b.KodeToko 
OUTER APPLY 
(
	SELECT dbo.fngetHariSales(a.KodeToko , a.TransactionType ) AS HariSalesFn
) c
WHERE TglSuratJalan >='2011/10/01'
AND a.RecordID LIKE 'C09%'
AND a.HariSales <> c.HariSalesFn


GO
--SELECT FROM KartuPiutang
SELECT
a.KPID, a.NoTransaksi , a.TglTransaksi, a.KodeToko, b.NamaToko, TransactionType, a.HariSales, c.HariSalesFn, b.HariSales, a.LastUpdatedBy
FROM KartuPiutang  a
INNER JOIN Toko b ON a.KodeToko = b.KodeToko 
OUTER APPLY 
(
	SELECT dbo.fngetHariSales(a.KodeToko , a.TransactionType ) AS HariSalesFn
) c
WHERE TglTransaksi >='2011/10/01'
AND a.HariSales <> c.HariSalesFn
AND a.KPID LIKE 'C09%'
ORDER BY NoTransaksi


GO
--CREATE TABLE FixPiutang
USE [ISAdb]
GO

/****** Object:  Table [dbo].[FixPiutang]    Script Date: 10/13/2011 18:37:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FixPiutang](
	[RecordID] [varchar](23) NOT NULL,
	[HariSales] [int] NULL) 
	ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


--INSERT INTO FixPiutang
INSERT INTO FixPiutang
select 
a.RecordID , 
a.HariSales 
from notapenjualan a 
inner join KartuPiutang b ON a.RecordID = b.KPID
where a.TglSuratJalan >='2011/10/1'
AND a.HariSales <> b.HariSales


INSERT INTO FixPiutang
select 
a.KPID , 
c.HariSalesFn 
FROM KartuPiutang  a
INNER JOIN Toko b ON a.KodeToko = b.KodeToko 
OUTER APPLY 
(
	SELECT dbo.fngetHariSales(a.KodeToko , a.TransactionType ) AS HariSalesFn
) c
WHERE TglTransaksi >='2011/10/01'
AND a.HariSales <> c.HariSalesFn
AND a.KPID LIKE 'C09%'


-- PREPARE FOXPRO INJECTION
INSERT INTO FoxproInjection
(RowID, Script, Source, Target, KeyValue, RunDate, Complete, LastUpdatedBy, LastUpdatedTime)
select 
	NEWID(),
	'UPDATE KPIUTANG SET ' +
	'hari_sls=' + CONVERT(varchar(3), b.HariSales) + ', '
		+
							'tgl_jt = CTOD("' + CONVERT (varchar(10), DATEADD(d, b.HariSales + a.HariKirim + a.JangkaWaktu  ,a.TglTransaksi),101) + '")' +
							' WHERE id_kp = "' + a.KPID + '"' AS script,
	'KartuPiutang' AS Source, 
	'kpiutang' AS Target, 
	a.KPID AS KeyValue, 
	NULL AS RunDate,
	0 AS Complete,
	'RAY' AS LastUpdatedBy,
	GETDATE() AS LastUpdatedTime
from KartuPiutang a
inner join fixPiutang b ON a.KPID = b.RecordID



GO

-- UPDATE KPiutang
Update KartuPiutang
SET HariSales = b.HariSales,
	TglJatuhTempo = DATEADD(d, b.HariSales + a.HariKirim  ,a.TglTransaksi)
FROM KartuPiutang a
inner join fixPiutang b ON a.KPID = b.RecordID


--UPDATE KartuPiutang
UPDATE dbo.KartuPiutang
SET
	HariSales = c.HariSalesFn,
	TglJatuhTempo = DATEADD(d, a.HariSales + a.HariKirim  ,a.TglTransaksi)	
FROM KartuPiutang  a
OUTER APPLY 
(
	SELECT dbo.fngetHariSales(a.KodeToko , a.TransactionType ) AS HariSalesFn
) c
WHERE TglTransaksi >='2011/10/01'
AND a.HariSales <> c.HariSalesFn
AND a.KPID LIKE 'C09%'


SELECT 
*
FROM KartuPiutang a
inner join fixPiutang b ON a.KPID = b.RecordID
