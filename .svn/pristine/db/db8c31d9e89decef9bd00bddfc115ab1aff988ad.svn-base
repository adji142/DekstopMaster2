USE [ISAdb]
GO
/****** Object:  UserDefinedFunction [dbo].[fnGetKoreksiID]    Script Date: 04/18/2011 11:23:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================================
-- Author:		Stephanie
-- Create date: 18 Apr 11
-- Description:	Mencari record KoreksiPenjualan
--				atau KoreksiReturPenjualan
--				atau KoreksiPembelian
--				atau KoreksiReturPembelian
--				(Function ini dibuat karena nota detail di data lama
--				banyak yang memiliki multi koreksi)
-- =================================================================
CREATE FUNCTION [dbo].[fnGetKoreksiID] 
(
	-- Add the parameters for the function here	
	@notaID uniqueidentifier,
	@type varchar(3),	-- Parameter untuk type nota yang dimasukan
					-- NPJ, NRJ, NPB, atau NRB 
	@tgl datetime = NULL
)
RETURNS uniqueidentifier
AS
BEGIN
	-- Declare the return variable here
	DECLARE @id uniqueidentifier
	SET @id = NULL


	/* Cari Koreksi Penjualan */

	IF (@type = 'NPJ')
	BEGIN
		SELECT TOP 1 
			@id = RowID
		FROM dbo.KoreksiPenjualan
		WHERE 
			NotaJualDetailID = @notaID
			AND 
			(@tgl IS NULL OR TglKoreksi <= @tgl)
		ORDER BY TglKoreksi, SUBSTRING(RecordID, 4, 16) DESC
	END


	/* Cari Koreksi Retur Penjualan */

	IF (@type = 'NRJ')
	BEGIN
		SELECT TOP 1 
			@id = RowID
		FROM dbo.KoreksiReturPenjualan
		WHERE 
			ReturJualDetailID = @notaID
			AND 
			(@tgl IS NULL OR TglKoreksi <= @tgl)
		ORDER BY TglKoreksi, SUBSTRING(RecordID, 4, 16) DESC
	END


	/* Cari Koreksi Pembelian */

	IF (@type = 'NPB')
	BEGIN
		SELECT TOP 1 
			@id = RowID
		FROM dbo.KoreksiPembelian
		WHERE 
			NotaBeliDetailID = @notaID
			AND 
			(@tgl IS NULL OR TglKoreksi <= @tgl)
		ORDER BY TglKoreksi, SUBSTRING(RecordID, 4, 16) DESC
	END


	/* Cari Koreksi Retur Pembelian */

	IF (@type = 'NRB')
	BEGIN
		SELECT TOP 1 
			@id = RowID
		FROM dbo.KoreksiReturPembelian
		WHERE 
			ReturBeliDetailID = @notaID			
			AND 
			(@tgl IS NULL OR TglKoreksi <= @tgl)
		ORDER BY TglKoreksi, SUBSTRING(RecordID, 4, 16) DESC
	END


	/* Retur RowID dari koreksinya */
	RETURN @id

END

