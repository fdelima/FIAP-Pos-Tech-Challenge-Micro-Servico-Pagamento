Feature: ControlarPedidos
	Para controlar os pedidos da lanchonete
	Eu preciso das seguindes funcionalidades
	Adicionar um pedido
	Alterar um pedido
	Consultar um pedido
	Listar os pedidos
	Iniciar preparação do pedido
	Finalizar preparação do pedido
	Finalizar o pedido
	Deletar um pedido

Scenario: Controlar pedidos
	Given Recebendo um pedido na lanchonete vamos preparar o pedido
	And Adicionar o pedido
	And Encontrar o pedido
	And Alterar o pedido
	And Consultar o pedido
	And Listar o pedido
	And Iniciar preparação do pedido
	And Finalizar preparação do pedido
	When Finalizar o pedido
	Then posso deletar o pedido