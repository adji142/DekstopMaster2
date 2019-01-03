
USE ISAHR 
GO
DELETE FROM dbo.Staff
GO
CREATE TABLE [dbo].[Staff_Import](
	[NIP] [varchar](7) NOT NULL,
	[Nama] [varchar](25) NOT NULL,
	[Jabatan] [varchar](15) NOT NULL,
	[UnitKerja] [varchar](15) NOT NULL,
	[LP] [varchar](50) NOT NULL,
	[Alamat] [varchar](60) NOT NULL,
	[NoTelp] [varchar](15) NOT NULL,
	[TglLahir] [varchar](20) NULL,
	[TglMasuk] [varchar](20) NULL,
	[TglKeluar] [varchar](20) NULL,
	[Keterangan] [varchar](60) NOT NULL,
	[Gaji] [money] NOT NULL,
	[UM] [money] NOT NULL,
	[PerKoli] [money] NOT NULL,
	[Bonus] [money] NOT NULL,
	[Hutang] [money] NOT NULL,
	[Agama] [varchar](1) NOT NULL,
	[JTelat] [varchar](8) NOT NULL,
	[JMaxum] [varchar](8) NOT NULL,
	[Stk] [varchar](50) NOT NULL,
	[SyncFlag] [bit] NOT NULL,
	[LastUpdatedBy] [varchar](250) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL
) ON [PRIMARY]

GO
INSERT INTO dbo.Staff_Import
(
	NIP, 
	Nama, 
	Jabatan, 
	UnitKerja, 
	LP, 
	Alamat, 
	NoTelp, 
	TglLahir, 
	TglMasuk, 
	TglKeluar, 
	Keterangan, 
	Gaji, 
	UM, 
	PerKoli, 
	Bonus, 
	Hutang, 
	Agama, 
	JTelat, 
	JMaxum, 
	Stk, 
	SyncFlag, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	nip,
	nama,
	jabatan,
	unitkerja,
	lp,
	alamat,
	no_telp,
	tgl_lahir,
	tgl_masuk,
	tgl_keluar,
	keterangan,
	gaji,
	um,
	perkoli,
	bonus,
	hutang,
	agama,
	j_telat,
	j_maxum,
	stk,
	id_match,	
	'Import',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT * FROM SAS_staf')


GO

UPDATE Staff_Import
SET TglLahir = NULL
WHERE
LEFT(TglLahir,4) <= '1900'

GO

UPDATE Staff_Import
SET TglMasuk = NULL
WHERE
LEFT(TglMasuk,4) <= '1900'

GO
UPDATE Staff_Import
SET TglKeluar = NULL
WHERE
LEFT(TglKeluar,4) <= '1900'

GO

INSERT INTO dbo.Staff
SELECT * FROM Staff_Import

GO

DROP TABLE Staff_Import
 