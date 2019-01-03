IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISA_TokoCleanUp].[dbo].[ReturPenjualan]') AND type in (N'U'))
DROP TABLE ISA_TokoCleanUp.dbo.ReturPenjualan
GO

declare @cabangID varchar(2)
select @cabangID = InitCabang from ISAdb.dbo.Perusahaan (nolock)

SELECT * INTO ISA_TokoCleanUp.dbo.ReturPenjualan FROM ISAdb.dbo.ReturPenjualan t
WHERE t.KodeToko IN (SELECT Kodetokodetail FROM ISAdb.dbo.mappingtoko2012 (nolock) WHERE Cabang = @cabangid and KodeTokoHeader <> KodeTokoDetail)

UPDATE isadb.dbo.ReturPenjualan 
SET KodeToko = b.KodeTokoHeader
FROM isadb.dbo.ReturPenjualan a inner join isadb.dbo.mappingtoko2012 b
ON a.KodeToko = b.KodeTokoDetail
WHERE b.Cabang = @cabangid and KodeTokoHeader <> KodeTokoDetail