USE DB_XPTO

 
insert into tb_customer 
(
	id,
	code,
	name,
	nickname,
	birth_date,
	person_type,
	[identity],
	address,
	phone,
	email,
	note,
	creation_date,
	creation_user_id,
	creation_user_name,
	change_date,
	change_user_id,
	change_user_name
)
values
(
	newid(),
	1,
	'João da Silva',
	null,
	'1985-08-19',
	'pf',
	'123456789',
	'Rua x 15',
	'1198522632',
	'joao@gmail.com',
	null,
	getdate(),
	null,
	null,
	null,
	null,
	null
),
(
	newid(),
	1,
	'João da Silva',
	null,
	'1985-08-19',
	'pf',
	'123456789',
	'Rua x 15',
	'1198522632',
	'joao@gmail.com',
	null,
	getdate(),
	null,
	null,
	null,
	null,
	null
),
(
	newid(),
	1,
	'João da Silva',
	null,
	'1985-08-19',
	'pf',
	'123456789',
	'Rua x 15',
	'1198522632',
	'joao@gmail.com',
	null,
	getdate(),
	null,
	null,
	null,
	null,
	null
)


select * from tb_customer