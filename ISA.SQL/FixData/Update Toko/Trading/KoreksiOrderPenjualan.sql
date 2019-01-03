IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISA_TokoCleanUp].[dbo].[OrderPenjualan]') AND type in (N'U'))
DROP TABLE ISA_TokoCleanUp.dbo.OrderPenjualan
GO

declare @cabangID varchar(2)
select @cabangID = InitCabang from ISAdb.dbo.Perusahaan (nolock)

SELECT * INTO ISA_TokoCleanUp.dbo.OrderPenjualan FROM ISAdb.dbo.OrderPenjualan t
WHERE t.KodeToko IN (SELECT Kodetokodetail FROM ISAdb.dbo.mappingtoko2012 (nolock) WHERE Cabang = @cabangid and KodeTokoHeader <> KodeTokoDetail)

UPDATE isadb.dbo.OrderPenjualan 
SET KodeToko = b.KodeTokoHeader
FROM isadb.dbo.OrderPenjualan a inner join isadb.dbo.mappingtoko2012 b
ON a.KodeToko = b.KodeTokoDetail
WHERE b.Cabang = @cabangid and KodeTokoHeader <> KodeTokoDetail