select * from tb_customer


update tb_customer set code = 2, name = 'Marcos' 

update tb_customer 
set code = 1, 
name = 'João da Silva'
where id = '9D0F896C-5EA5-4D02-AFBC-02E37D958A0E'



update tb_customer 
set code = 0, 
name = 'João da Silva'
where code > 1