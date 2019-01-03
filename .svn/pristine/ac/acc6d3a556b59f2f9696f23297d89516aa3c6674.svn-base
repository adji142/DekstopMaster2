USE [ISAdb]
GO

IF OBJECT_ID('[dbo].[fnCekPTTransType]') IS NOT NULL
DROP PROC [dbo].[fnCekPTTransType] 
GO

/****** Object:  UserDefinedFunction [dbo].[fnCekPTTransType]    Script Date: 03/22/2011 13:59:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =======================================================
-- Author:		Stephanie
-- Create date: 18 Mar 11
-- Description:	Function to Return Perusahaan Name, Alamat
--				NPWP and TglPKP bases ON  
--              Nota Transaction Type 
-- ========================================================
ALTER FUNCTION [dbo].[fnCekPTTransType] 
(	
	-- Add the parameters for the function here
	@rowID uniqueidentifier
)
RETURNS @result 
TABLE 
(
	Nama varchar(30),
	Alamat varchar(60),
	NPWP varchar(25),
	TglPKP datetime
)
AS
BEGIN
	-- Add the SELECT statement with parameter references here
	DECLARE @transType varchar(2)
	DECLARE @cabang varchar(2)

	SELECT TOP 1
		@transType = a.TransactionType,
		@cabang = b.Cabang1
	FROM dbo.NotaPenjualan a LEFT OUTER JOIN dbo.OrderPenjualan b
	ON a.DOID = b.RowID
	WHERE a.RowID = @rowID	

	IF EXISTS (SELECT Nama FROM dbo.PT WHERE InitCabang = @cabang AND TransactionType LIKE '%' + @transType + '%')
	BEGIN
		INSERT INTO @result
		SELECT TOP 1
			Nama,
			Alamat,
			NPWP,
			TglPKP
		FROM dbo.PT
		WHERE InitCabang = @cabang AND TransactionType LIKE '%' + @transType + '%'
		ORDER BY Nama
	END
		
	ELSE 
	BEGIN
		INSERT INTO @result
		SELECT TOP 1
			Nama,
			Alamat,
			NPWP,
			TglPKP
		FROM dbo.Perusahaan
	END
	
	RETURN
END