declare @cabangID varchar(2)
select @cabangID = InitCabang from ISAdb.dbo.Perusahaan (nolock)

SELECT * INTO ISA_TokoCleanUp.dbo.DataCustomer FROM ISAFinance.dbo.DataCustomer t
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
       IF EXISTS(SELECT KodeToko FROM ISAFinance.dbo.DataCustomer where KodeToko = @KodeTokoDetail and KodeToko <> @KodeTokoHeader)
       BEGIN
       
			--Toko Header			
			IF EXISTS(SELECT KodeToko FROM ISAFinance.dbo.DataCustomer (nolock) where KodeToko = @KodeTokoHeader)
			BEGIN
				
				DELETE FROM ISAFinance.dbo.DataCustomer WHERE KodeToko = @KodeTokoDetail
				
			    PRINT('DELETE : ' + @KodeTokoDetail + ' - Valid : ' + @KodeTokoHeader)
			END
			ELSE
			BEGIN
				
				UPDATE ISAFinance.dbo.DataCustomer
				SET KodeToko = @KodeTokoHeader
				WHERE KodeToko = @KodeTokoDetail
				
				PRINT('UPDATE : ' + @KodeTokoDetail + ' - Menjadi : ' + @KodeTokoHeader)
			END			
       END
              
	   FETCH NEXT FROM CursorMapping INTO @KodeTokoHeader, @KodeTokoDetail
END   

CLOSE CursorMapping   
DEALLOCATE CursorMapping