USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_KoreksiPembelian_INSERT]    Script Date: 04/12/2011 11:22:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Stephanie
-- Create date: 12 Feb 11
-- Description:	Insert table KoreksiPembelian
-- =============================================
CREATE PROCEDURE [dbo].[usp_KoreksiPembelian_INSERT] 
	-- Add the parameters for the stored procedure here
	 @rowID uniqueidentifier,
	 @recordID varchar(19),
	 @notaBeliDetailID uniqueidentifier,
	 @notaBeliDetailRecID varchar(23),
	 @tglKoreksi datetime,
	 @noKoreksi varchar(11),
	 @qtyNotaBaru int,
	 @hrgBeliBaru money,
	 @catatan varchar(40),
	 @pemasok varchar(19),
	 @sumber varchar(3),
	 @linkID varchar(23),
	 @hrgBeliKoreksi money,
	 @qtyNotaKoreksi int,
	 @syncFlag bit,
	 @lastUpdatedBy varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
        	
	INSERT INTO dbo.KoreksiPembelian
	(
		RowID, 
		RecordID, 
		NotaBeliDetailID, 
		NotaBeliDetailRecID, 
		TglKoreksi, 
		NoKoreksi, 
		QtyNotaBaru, 
		HrgBeliBaru, 
		Catatan, 
		Pemasok, 
		Sumber, 
		LinkID, 
		HrgBeliKoreksi, 
		QtyNotaKoreksi, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	)
	SELECT 
		@rowID,
		@recordID,
		@notaBeliDetailID,
		@notaBeliDetailRecID,
		@tglKoreksi,
		@noKoreksi,
		@qtyNotaBaru,
		@hrgBeliBaru,
		@catatan,
		@pemasok,
		@sumber,
		@linkID,
		@hrgBeliKoreksi,
		@qtyNotaKoreksi,
		@syncFlag,
		@lastUpdatedBy,
		GETDATE()

	UPDATE dbo.NotaPembelian
	SET SyncFlag = '0'
	FROM dbo.NotaPembelianDetail a
	 LEFT OUTER JOIN dbo.NotaPembelian b ON a.HeaderID = b.RowID
	WHERE a.RowID = @notaBeliDetailID
	
END