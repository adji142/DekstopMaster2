USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[rsp_CetakMPRBeli]    Script Date: 04/18/2011 14:57:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ==============================================================
-- Author:		Stephanie
-- Create date: 01 Apr 11
-- Description:	Pembelian > Transaksi > MPR(beli) > F3(Cetak MPR)
-- ==============================================================
ALTER PROCEDURE [dbo].[rsp_CetakMPRBeli] 
	-- Add the parameters for the stored procedure here
	@rowID uniqueidentifier

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

    -- Insert statements for procedure here
	SELECT
		LEFT(s.NamaStok, 73) AS NamaBarang,
		s.SatSolo AS Satuan,
		v.QtyTerima,
		v.HrgBeli,
		LEFT(v.Catatan,1)
			+(CASE WHEN RTRIM(SUBSTRING(v.Catatan, 3, 19)) = ''
				THEN '' ELSE ' - ' END) 
			+SUBSTRING(v.Catatan, 3, 19) AS Catatan,
		r.NoMPR,
		r.TglKeluar,
		r.TglKirim
	FROM dbo.ReturPembelian r
		LEFT OUTER JOIN dbo.vwReturPembelianDetail v ON r.RowID = v.HeaderID
		LEFT OUTER JOIN dbo.Stok s ON v.BarangID = s.BarangID
		
	WHERE 
		r.RowID = @rowID
		AND
		v.QtyTerima > 0

	ORDER BY s.NamaStok ASC

END
