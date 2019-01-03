USE [ISAdb]

IF OBJECT_ID('[dbo].[dbo.fnHitungSisaStok]') IS NOT NULL
DROP FUNCTION [dbo].[dbo.fnHitungSisaStok] 
GO

/****** Object:  UserDefinedFunction [dbo].[dbo.fnHitungSisaStok]    Script Date: 03/03/2011 16:27:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Stephanie
-- Create date: 03 Mar 2011
-- Description:	Hitung Sisa Stok Per Barang
-- =============================================
CREATE FUNCTION [dbo].[dbo.fnHitungSisaStok] 
(
	-- Add the parameters for the function here	
	@barangID varchar(23)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @result int
	SELECT 
		@result = (QtyAwal + QtyBeli 
					- QtyJual + QtyRetJual 
					- QtyRetBeli + QtyMutasi 
					- QtyKorJual + QtyKorBeli
					+ QtyRetJual - QtyRetBeli
					+ QtyAntarGudangTerima - QtyAntarGudangKirim)
	FROM [dbo].[vwStokGudang] 
	WHERE BarangID = @barangID

RETURN @result

END
/*
nQ_sisa = Stok2gd.Q_awal + Stok2gd.Q_beli 
		- Stok2gd.Q_jual + Stok2gd.Q_retj 
        - Stok2gd.Q_retb + Stok2gd.Q_mtsi 
        + Stok2gd.Q_krsi + Stok2gd.Q_angd
		+ Stok2gd.Q_slsh
*/



