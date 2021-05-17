Create Table Escolaridades(
	Id int not null,
	Descricao varchar(15)
)

ALTER TABLE Escolaridades
ADD CONSTRAINT PK_Escolaridade PRIMARY KEY (Id);

Create Table Clientes (
	Id	int  Identity(1,1) not null, 		
	Nome varchar(50) not null,		
	Sobrenome varchar(100) not null,	
	Email varchar(50),		
	DataNascimento Date not null,	
	Escolaridade int
)

ALTER TABLE Clientes
ADD CONSTRAINT PK_Cliente PRIMARY KEY (Id);

ALTER TABLE Clientes
ADD CONSTRAINT FK_ClienteEscolaridade
FOREIGN KEY (Escolaridade) REFERENCES Escolaridades(Id);
	