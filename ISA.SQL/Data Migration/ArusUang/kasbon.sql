 USE ISAFinance 
GO
DELETE FROM dbo.Kasbon
GO
INSERT INTO dbo.Kasbon
(
	RowID, 
	RecordID, 
	NIP, 
	Nama, 
	UnitKerja, 
	NoBukti, 
	Tgl, 
	Keperluan, 
	BKKNo1, 
	TRKNo1, 
	BBKNo1, 
	BKKRp1, 
	TRKRp1, 
	BBKRp1, 
	Total1, 
	JVNo1, 
	JVNo2, 
	JVNo3, 
	JVRp1, 
	JVRp2, 
	JVRp3, 
	Total2, 
	BKKNo3, 
	TRKNo3, 
	BBKNo3, 
	BKMNo3, 
	TRNNo3, 
	BBMNo3, 
	BKKRp3, 
	TRKRp3, 
	BBKRp3, 
	Totku3, 
	BKMRp3, 
	TRNRp3, 
	BBMRp3, 
	Totle3, 
	Kode, 
	Sub, 
	SyncFlag, 
	Hari, 
	NoPerkiraan, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	idkasbon,
	nip,
	nama,
	unitkerja,
	[no],
	tgl,
	keperluan,
	bkkno1,
	trkno1,
	bbkno1,
	bkkrp1,
	trkrp1,
	bbkrp1,
	total1,
	jv_no1,
	jv_no2,
	jv_no3,
	jv_rp1,
	jv_rp2,
	jv_rp3,
	Total2, 
	BKKNo3, 
	TRKNo3, 
	BBKNo3, 
	BKMNo3, 
	TRNNo3, 
	BBMNo3, 
	BKKRp3, 
	TRKRp3, 
	BBKRp3, 
	Totku3, 
	BKMRp3, 
	TRNRp3, 
	BBMRp3, 
	Totle3, 
	Kode, 
	Sub,
	id_match,
	hari,
	no_perk,
	'Import',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT * FROM hkasbon')

GO



UPDATE DBO.KasBon
SET Status = 'O'
WHERE (Total2 = 0 AND Totle3 = 0 AND Totku3 = 0)

UPDATE DBO.KasBon
SET Status = 'C'
WHERE (Total2 > 0 OR Totle3 > 0 OR Totku3 > 0)

