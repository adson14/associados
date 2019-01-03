--drop database AssociadosDePlantao
CREATE DATABASE AssociadosDePlantao
GO
USE AssociadosDePlantao
GO


CREATE TABLE funcionario(
	codFuncionario INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(50) NOT NULL,
	cpf VARCHAR(15) NOT NULL,
	dataNAsc VARCHAR(10) NOT NULL,
	endereco VARCHAR(50) NOT NULL,
	numero INT NOT NULL,
	complemento VARCHAR(50) NOT NULL,
	bairro VARCHAR(50)NOT NULL,
	cidade VARCHAR(50) NOT NULL,
	estado VARCHAR(50) NOT NULL,
	pais VARCHAR(50),
	telFixo VARCHAR(20),
	celular VARCHAR(20),
	email VARCHAR(50),
	tipoFuncionario VARCHAR(50) NOT NULL,
	loginUsuario VARCHAR(20) NOT NULL,
	senha VARCHAR(30) NOT NULL,
	statusFunc INT, 
	funcionario_codFuncResp INT FOREIGN KEY (funcionario_codFuncResp) REFERENCES funcionario (codFuncionario) 
) 

GO 

CREATE TABLE loja (
	codLoja INT PRIMARY KEY IDENTITY(1,1),
	razaoSocial VARCHAR(100) NOT NULL,
	nomeFantasia VARCHAR(30) NOT NULL,
	cnpJ VARCHAR(50) NOT NULL,
	endereco VARCHAR(50) NOT NULL,
	numero INT NOT NULL,
	complemento VARCHAR(50) NOT NULL,
	bairro VARCHAR(50)NOT NULL,
	cidade VARCHAR(50) NOT NULL,
	estado VARCHAR(50) NOT NULL,
	pais VARCHAR(50),
	telFixo VARCHAR(20),
	celular VARCHAR(20),
	email VARCHAR(50),
	siteEmpresa VARCHAR(50),
	dataInauguracao VARCHAR(10),
	tipoLoja INT,
	funcionario_codFuncResp INT FOREIGN KEY (funcionario_codFuncResp) REFERENCES funcionario (codFuncionario) 
	  
)

GO

CREATE TABLE trabalha(
	codTrabalha INT PRIMARY KEY IDENTITY (1,1), 
	dataCadastro VARCHAR(10),
	funcionario_codFuncionario INT FOREIGN KEY (funcionario_codFuncionario) REFERENCES funcionario (codFuncionario) ,
	loja_codLoja INT FOREIGN KEY (loja_codLoja) REFERENCES loja (codLoja)
)

GO

CREATE TABLE sala (
	codSala INT PRIMARY KEY IDENTITY(1,1),
	descricao VARCHAR(50),
	loja_codLoja INT FOREIGN KEY (loja_codLoja) REFERENCES loja (codLoja),
	funcionario_codFuncResp INT FOREIGN KEY (funcionario_codFuncResp) REFERENCES funcionario (codFuncionario)
)

GO

CREATE TABLE relatorioAcesso(
	codRelatorio INT PRIMARY KEY IDENTITY(1,1),
	funcionario_codFuncionario INT FOREIGN KEY (funcionario_codFuncionario) REFERENCES funcionario (codFuncionario), 
	sala_codSala INT FOREIGN KEY (sala_codSala) REFERENCES sala (codSala),
	dataAcesso VARCHAR(70)
	
)

GO
CREATE TABLE AcessoSala(
	codAcesso INT PRIMARY KEY IDENTITY (1,1),
	sala_codSala INT FOREIGN KEY (sala_codSala) REFERENCES sala (codSala),
	funcionario_codFuncionario INT FOREIGN KEY (funcionario_codFuncionario) REFERENCES funcionario (codFuncionario),
	
)

GO



CREATE VIEW vwAcessos AS(

SELECT A.codAcesso,F.nome,A.sala_codSala  
	FROM funcionario AS F INNER JOIN AcessoSala AS A
		ON (A.funcionario_codFuncionario = F.codFuncionario) 		

)

GO

--view para mostrar o relatorio de acesso dos funcionarios às salas
CREATE VIEW vwRelatorio AS(

SELECT R.codRelatorio AS 'CODIGO',F.nome AS 'NOME',R.sala_codSala AS 'SALA', R.dataAcesso AS 'DATA DO ACESSO À SALA'  
	FROM funcionario AS F INNER JOIN relatorioAcesso AS R
		ON (R.funcionario_codFuncionario = F.codFuncionario) 		

)

GO
--trigger para dar acesso a todas as salas para o admin
CREATE TRIGGER tgrLibAdmin--CRIAÇÃO TRIGGER
	ON sala--TABELA QUE DESPARA EVENTO
	FOR INSERT--EVENTO QUE DISPARA TRIGGER
	AS
	BEGIN--INICIO
		DECLARE--DECLARAÇÃO DE VARIÁVEIS COM @
			@codSala INT,
			@descricao VARCHAR(50),
			@loja_codLoja INT,
			@funcionario_codFuncResp INT

		--SELECIONA QUAL FOI O ÚLTIMO REGISTRO INSERIDO EM sala 
		SELECT @codSala= codSala , @descricao = descricao,@loja_codLoja = loja_codLoja,@funcionario_codFuncResp = funcionario_codFuncResp FROM inserted

		--REALIZAR A REGRA DE NEGÓCIO
		INSERT INTO AcessoSala VALUES (@codSala,1)
	END--FIM


INSERT INTO funcionario(nome,cpf,dataNAsc,endereco,numero,complemento,bairro,cidade,estado,pais,telFixo,celular,email,tipoFuncionario,loginUsuario,senha,statusFunc,funcionario_codFuncResp) VALUES ('admin',55454545,'11/11/1111','RUA N1',111,'','Belo Hills','BH','MG','BRASIL',222-222,NULL,'','Administrador','admin','000111',0,1)

SELECT * FROM funcionario 






