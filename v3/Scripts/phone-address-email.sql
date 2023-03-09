
IF OBJECT_ID('tb_customer_address') IS NOT NULL
DROP TABLE tb_customer_address
GO

CREATE TABLE tb_customer_address
(
id UNIQUEIDENTIFIER not null,
customer_code int not null FOREIGN KEY REFERENCES tb_customer (code), 
type VARCHAR(150) NULL,
street VARCHAR(150) NULL,
number VARCHAR(50) NULL,
complement VARCHAR(50) NULL,
district VARCHAR(150) NULL,
city VARCHAR(150) NULL,
state VARCHAR(2) NULL,
zip_code VARCHAR(8) NULL,
note VARCHAR(255) NULL
)
GO



IF OBJECT_ID('tb_customer_email') IS NOT NULL
DROP TABLE tb_customer_email
GO

CREATE TABLE tb_customer_email
(
id UNIQUEIDENTIFIER not null,
customer_code int not null FOREIGN KEY REFERENCES tb_customer (code), 
type VARCHAR(150) NULL,
address VARCHAR(255) NULL,
note VARCHAR(255) NULL
)
GO



IF OBJECT_ID('tb_customer_phone') IS NOT NULL
DROP TABLE tb_customer_phone
GO

CREATE TABLE tb_customer_phone
(
id UNIQUEIDENTIFIER not null,
customer_code int not null FOREIGN KEY REFERENCES tb_customer (code), 
type VARCHAR(150) NULL,
ddd INT NULL,
number BIGINT NULL,
note VARCHAR(255) NULL
)
GO



 
select * from tb_customer 
select * from tb_customer_phone

 
insert into [DB_XPTO].[dbo].[tb_customer_phone]
( 
[id]
,customer_code
,[type]
,[ddd]
,[number]
,[note]
)
values (
newid(),
15,
'Pessoal',
11,
9888555625,
null
)

