 UPDATE NotaPenjualanDetail 
SET
	BarangID = b.BarangID,
	HrgJual = b.HrgJual,
	Disc1 = b.Disc1,
	Disc2 = b.Disc2,
	Disc3 = b.Disc3,
	Pot = b.Pot,
	DiscFormula = b.DiscFormula
FROM
NotaPenjualanDetail a inner join OrderPenjualanDetail b on a.DODetailID = b.RowID 

GO

UPDATE NotaPenjualanDetail 
SET 
	
	HrgJual = ISNULL(HrgJual,0),
	Disc1 = ISNULL(Disc1, 0),
	Disc2 =  ISNULL(Disc2,0),
	Disc3 =  ISNULL(Disc3,0),
	Pot =  ISNULL(Pot, 0),
	DiscFormula =  ISNULL(DiscFormula,'')