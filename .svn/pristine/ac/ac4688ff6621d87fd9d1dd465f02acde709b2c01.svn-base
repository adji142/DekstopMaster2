--IF  EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'ISA_TokoCleanUp')
--DROP DATABASE ISA_TokoCleanUp

CREATE DATABASE ISA_TokoCleanUp
GO

declare @cabangID varchar(2)
select @cabangID = InitCabang from ISAdb.dbo.Perusahaan (nolock)

SELECT * INTO ISA_TokoCleanUp.dbo.Toko FROM ISAdb.dbo.Toko t
WHERE t.KodeToko IN (SELECT Kodetokodetail FROM ISAdb.dbo.mappingtoko2012 (nolock) WHERE Cabang = @cabangid and KodeTokoHeader <> KodeTokoDetail)

DECLARE @KodeTokoDetail VARCHAR(19)
DECLARE @KodeTokoHeader VARCHAR(19)

DECLARE CursorMapping CURSOR FOR 
SELECT Distinct KodeTokoHeader, KodeTokoDetail From ISAdb.dbo.mappingtoko2012 WHERE Cabang = @cabangid and KodeTokoHeader <> KodeTokoDetail


OPEN CursorMapping   
FETCH NEXT FROM CursorMapping INTO @KodeTokoHeader, @KodeTokoDetail
WHILE @@FETCH_STATUS = 0   
BEGIN      
	   
       --Toko Detail
       IF EXISTS(SELECT KodeToko FROM isadb.dbo.Toko where KodeToko = @KodeTokoDetail and KodeToko <> @KodeTokoHeader)
       BEGIN
       
			--Toko Header			
			IF EXISTS(SELECT KodeToko FROM isadb.dbo.Toko (nolock) where KodeToko = @KodeTokoHeader)
			BEGIN
				
				DELETE FROM isadb.dbo.Toko WHERE KodeToko = @KodeTokoDetail
				
			    PRINT('DELETE : ' + @KodeTokoDetail + ' - Valid : ' + @KodeTokoHeader)
			END
			ELSE
			BEGIN
				
				UPDATE isadb.dbo.Toko
				SET KodeToko = @KodeTokoHeader
				WHERE KodeToko = @KodeTokoDetail
				
				PRINT('UPDATE : ' + @KodeTokoDetail + ' - Menjadi : ' + @KodeTokoHeader)
			END			
       END
              
	   FETCH NEXT FROM CursorMapping INTO @KodeTokoHeader, @KodeTokoDetail
END   

CLOSE CursorMapping   
DEALLOCATE CursorMapping