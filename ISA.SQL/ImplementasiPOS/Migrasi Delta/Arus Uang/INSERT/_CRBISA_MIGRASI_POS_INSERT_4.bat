sqlcmd -S CRBISA -U sa -P password -t 0 -i DataCustomer.sql
sqlcmd -S CRBISA -U sa -P password -t 0 -i InOut.sql
sqlcmd -S CRBISA -U sa -P password -t 0 -i KartuPiutangLunas.sql
sqlcmd -S CRBISA -U sa -P password -t 0 -i SaldoTransferOtomatis.sql
sqlcmd -S CRBISA -U sa -P password -t 0 -i Saldo.sql
sqlcmd -S CRBISA -U sa -P password -t 0 -i SetoranFmApi.sql
sqlcmd -S CRBISA -U sa -P password -t 0 -i SetoranFmApiBayar.sql
sqlcmd -S CRBISA -U sa -P password -t 0 -i DataBank.sql
PAUSE