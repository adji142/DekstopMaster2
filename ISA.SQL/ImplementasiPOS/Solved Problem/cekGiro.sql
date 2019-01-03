--TITIPRECID & TITIPID
select * from Giro g1
inner join ISAFinance.dbo.Giro g2 on g1.GiroRecID=g2.GiroRecID
where g1.TitipRecID<>g2.TitipRecID
and g2.TitipRecID<>''
/*
update Giro 
set TitipRecID =g2.TitipRecID,
	TitipID = g2.TitipID,
	TglTitip = g2.TglTitip
from Giro g1
inner join ISAFinance.dbo.Giro g2 on g1.GiroRecID=g2.GiroRecID
where g1.TitipRecID<>g2.TitipRecID
and g2.TitipRecID<>''
*/


--BBMRECID & BBMID
select * from Giro g1
inner join ISAFinance.dbo.Giro g2 on g1.GiroRecID=g2.GiroRecID
where g1.BBMRecID<>g2.BBMRecID
and g2.BBMRecID<>''
/*
update Giro
set BBMRecID =g2.BBMRecID,
	BBMID = g2.BBMID,
	TglCair = g2.TglCair,
	CairTolak=g2.CairTolak
from Giro g1
inner join ISAFinance.dbo.Giro g2 on g1.GiroRecID=g2.GiroRecID
where g1.BBMRecID<>g2.BBMRecID
and g2.BBMRecID<>''
*/

--CAIRTOLAK
select * from Giro g1
inner join ISAFinance.dbo.Giro g2 on g1.GiroRecID=g2.GiroRecID
where g1.CairTolak<>g2.CairTolak
and g2.CairTolak<>''
/*
update Giro
set TglCair=g2.TglCair,
	CairTolak=g2.CairTolak
from Giro g1
inner join ISAFinance.dbo.Giro g2 on g1.GiroRecID=g2.GiroRecID
where g1.CairTolak<>g2.CairTolak
and g2.CairTolak<>''
*/ 