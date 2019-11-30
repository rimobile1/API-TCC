create database oldlove;
go
use oldlove;

/* drop database oldlove; */

create table cadastro_cliente
  (id_cliente				integer         not null primary key,
   nome_cliente				varchar(50)		not null,
   rg_cliente				varchar(50)		not null,
   cpf_cliente				varchar(11)		not null,
   endereco_cliente			varchar(50)		not null,
   telefone_cliente			integer			not null,
   email_cliente			varchar(50)		not null,
   );
go

create table cadastro_enfermeira
(  id_enfermeira				integer         not null primary key,
   nome_enfermeira				varchar			not null,
   rg_enfermeira				varchar			not null,
   cpf_enfermeira				varchar(11)		not null,
);
go

create table idoso
  (id_idoso					integer         not null primary key,
   nome_idoso				varchar			not null,
   rg_idoso					varchar			not null,
   cpf_idoso				varchar(11)		not null,
   remedios_idoso			varchar			not null,
   obs_idoso				varchar			not null,
   id_cliente				integer			
 constraint info_Cliente	foreign key (id_cliente) references cadastro_cliente (id_cliente)
   );
   go

   insert into cadastro_cliente  (id_cliente,nome_cliente,rg_cliente,cpf_cliente,endereco_cliente,telefone_cliente, email_cliente)
    values (12345,'Raul de Paiva Campos','52952548X','50050050050','Rua 50 N-50',1190505051,'coofix26@gmail.com'),
		   (12346,'Sarah de Paiva Campos','52952548Y','51050050050','Rua 51 N-50',1190505052,'coofix26@gmail.com'),
		   (12347,'Ana Raquel de Paiva Campos','52952548Z','52050050050','Rua 52 N-50',1190505053,'coofix26@gmail.com'),
		   (12348,'Nicole de Paiva Campos','52952548A','53050050050','Rua 53 N-50',1190505054,'coofix26@gmail.com');
go

select *from cadastro_cliente