USE ISAFinance
GO

--RET_BLMIND
DELETE FROM dbo.PerkiraanKoneksiDetail
WHERE
KodeTrn = 'RET_BLMIND'

INSERT INTO dbo.PerkiraanKoneksiDetail
select
NEWID(), NULL, 'C092012050717:53:00MNG','C092012050717:53:00MNG','110351200','Retur Penjualan Blm Teridentifikasi','','RET_BLMIND',0,(select initcabang from isadb.dbo.Perusahaan),'Import',GETDATE()
 