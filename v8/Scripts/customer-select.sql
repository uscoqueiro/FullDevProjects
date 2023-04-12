select * from tb_customer where code = 0


select top 3
	id as [código do cliente], 
	[identity] as cpf, 
	name as [nome do cliente]
from tb_customer 
where code = 0

