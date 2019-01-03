update ReturPenjualanDetail 
SET
	BarangID = b.BarangID,
	HrgJual = ISNULL(b.HrgJual,0)
FROM 
ReturPenjualanDetail a
INNER JOIN vwReturPenjualanDetail b ON a.RowID = b.RowID 

GO

update ReturPenjualanDetail 
set
	hrgjual = 0
WHERE hrgjual is null