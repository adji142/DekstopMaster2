sqlcmd -S localhost -U sa -P password -t 0 -i OrderPembelian.sql
sqlcmd -S localhost -U sa -P password -t 0 -i OrderPembelianDetail.sql
sqlcmd -S localhost -U sa -P password -t 0 -i NotaPembelian.sql
sqlcmd -S localhost -U sa -P password -t 0 -i NotaPembelianDetail.sql
sqlcmd -S localhost -U sa -P password -t 0 -i ReturPembelian.sql
sqlcmd -S localhost -U sa -P password -t 0 -i ReturPembelianDetail.sql
sqlcmd -S localhost -U sa -P password -t 0 -i ReturPembelianManualDetail.sql
sqlcmd -S localhost -U sa -P password -t 0 -i KoreksiPembelian.sql
sqlcmd -S localhost -U sa -P password -t 0 -i KoreksiReturPembelian.sql
PAUSE