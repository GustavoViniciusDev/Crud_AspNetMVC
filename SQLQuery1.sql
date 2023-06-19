create database crud_mvc

use crud_mvc

create table Bandas(
	IdBandas int primary key identity(1,1) not null,
	NomeBanda varchar(255) not null,
	Genero varchar(255) not null,
	QtdAlbuns int not null
)

select * from Bandas