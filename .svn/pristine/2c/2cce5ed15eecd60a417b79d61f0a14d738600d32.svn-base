USE ISA_dbf
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISA_dbf].[dbo].[stokkembar]') AND type in (N'U'))
DROP TABLE ISA_dbf.dbo.stokkembar
GO

select c.RowID,a.BarangID into isa_dbf.dbo.stokkembar from ISAdb.dbo.Stok a
outer apply
(
	select top 1 RowID from ISAdb.dbo.Stok b
	where a.BarangID = b.BarangID
) c
group by c.RowID,a.BarangID having COUNT(*) > 1


delete from isadb.dbo.Stok where RowID in
(
	select a.RowID from ISAdb.dbo.Stok a inner join ISA_dbf.dbo.stokkembar b
	on a.BarangID = b.BarangID and a.RowID <> b.RowID
) 