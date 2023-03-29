use DB_XPTO
 

if(object_id('tb_customer') is not null)
	drop table tb_customer


create table tb_customer
(
	id uniqueidentifier not null,
	code int identity(1,1) not null primary key,
	name varchar(150) null,
	nickname varchar(150) null,
	birth_date date null,
	person_type varchar(150),
	[identity] varchar(20) null,
	note varchar(8000) null,
	creation_date datetime not null,
	creation_user_id varchar(36) null,
	creation_user_name varchar(150) null,
	change_date datetime null,
	change_user_id varchar(36) null,
	change_user_name varchar(150) null
)
  



  USE [DB_XPTO]
GO

select * from [dbo].[tb_customer]

INSERT INTO [dbo].[tb_customer]
([id]
,[name]
,[nickname]
,[birth_date]
,[person_type]
,[identity]
,[note]
,[creation_date]
,[creation_user_id]
,[creation_user_name]
,[change_date]
,[change_user_id]
,[change_user_name])
VALUES
(
newid(),
'João da Silva',
'João',
'1985-08-19',
'pf',
'987654321',
null,
getdate(),
null,
null,
null,
null,
null)
GO


