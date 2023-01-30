use DB_XPTO


select * from sys.objects where type = 'u'

 
if(object_id('tb_customer') is not null)
	drop table tb_customer


create table tb_customer
(
	id UNIQUEIDENTIFIER not null,
	code int not null,
	name varchar(150) null,
	nickname varchar(150) null,
	birth_date Date null,
	person_type varchar(150),
	[identity] varchar(20) null,
	address varchar(8000) null,
	phone varchar(8000) null,
	email varchar(8000) null,
	note varchar(8000) null,
	creation_date datetime not null,
	creation_user_id varchar null,
	creation_user_name varchar(150) null,
	change_date datetime null,
	change_user_id varchar null,
	change_user_name varchar(150) null
)

 

if(object_id('tb_customer') is null)
begin
	create table tb_customer
	(
		id UNIQUEIDENTIFIER not null,
		code int not null,
		name varchar(150) null,
		nickname varchar(150) null,
		birth_date Date null,
		person_type varchar(150),
		[identity] varchar(20) null,
		address varchar(8000) null,
		phone varchar(8000) null,
		email varchar(8000) null,
		note varchar(8000) null,
		creation_date datetime not null,
		creation_user_id varchar null,
		creation_user_name varchar(150) null,
		change_date datetime null,
		change_user_id varchar null,
		change_user_name varchar(150) null
	)
end
 