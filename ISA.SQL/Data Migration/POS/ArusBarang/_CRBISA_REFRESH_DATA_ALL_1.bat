sqlcmd -S CRBISA -U sa -P password -t 0 -i _PURGE_DATA.sql
sqlcmd -S CRBISA -U sa -P password -t 0 -i Toko.sql
sqlcmd -S CRBISA -U sa -P password -t 0 -i StatusToko.sql
sqlcmd -S CRBISA -U sa -P password -t 0 -i Sales.sql
sqlcmd -S CRBISA -U sa -P password -t 0 -i TokoToSales.sql
sqlcmd -S CRBISA -U sa -P password -t 0 -i Stok.sql
sqlcmd -S CRBISA -U sa -P password -t 0 -i TujuanExpedisi.sql
sqlcmd -S CRBISA -U sa -P password -t 0 -i PenanggungjawabRak.sql
sqlcmd -S CRBISA -U sa -P password -t 0 -i Sopir.sql
sqlcmd -S CRBISA -U sa -P password -t 0 -i StafPenjualan.sql
sqlcmd -S CRBISA -U sa -P password -t 0 -i BarangBonus.sql
sqlcmd -S CRBISA -U sa -P password -t 0 -i BarangBonusDetail.sql
PAUSE