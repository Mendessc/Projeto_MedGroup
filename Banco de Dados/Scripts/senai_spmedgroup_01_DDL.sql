CREATE DATABASE SP_MED_GROUP;
GO


USE SP_MED_GROUP;

--TIPO USUARIO

CREATE TABLE TIPOUSUARIO (
	idTipoUsuario TINYINT PRIMARY KEY IDENTITY,
	tipo VARCHAR(70) UNIQUE NOT NULL
);
GO

--SITUAÇÃO 

CREATE TABLE SITUACAO (
	idSituacao TINYINT PRIMARY KEY IDENTITY,
	descricao VARCHAR(70) UNIQUE NOT NULL
);
GO

--ESPECIALIZAÇÃO

CREATE TABLE ESPECIALIDADE (
	idEspecialidade SMALLINT PRIMARY KEY IDENTITY,
	nomeEspecialidade VARCHAR(70) UNIQUE NOT NULL
);
GO

--INSTITUIÇÃO

CREATE TABLE CLINICA (
	idClinica SMALLINT PRIMARY KEY IDENTITY,
	nomeClinica VARCHAR(100) UNIQUE NOT NULL,
	razaoSocial VARCHAR(100) UNIQUE NOT NULL,
	endereco VARCHAR(150) UNIQUE NOT NULL,
	cnpj VARCHAR(18) UNIQUE NOT NULL,
	email VARCHAR (256)UNIQUE NOT NULL,
	telefone VARCHAR(20)NOT NULL
);
GO

--USUARIO

CREATE TABLE USUARIO (
	idUsuario INT PRIMARY KEY IDENTITY,
	idTipoUsuario TINYINT FOREIGN KEY REFERENCES TIPOUSUARIO(idTipoUsuario),
	nome VARCHAR(100) NOT NULL,
	email VARCHAR(256) NOT NULL,
	senha VARCHAR(18) NOT NULL
);
GO

--MEDICO

CREATE TABLE MEDICO (
	idMedico INT PRIMARY KEY IDENTITY,
	idEspecialidade SMALLINT FOREIGN KEY REFERENCES ESPECIALIDADE(idEspecialidade),
	idClinica SMALLINT FOREIGN KEY REFERENCES CLINICA(idClinica),
	idUsuario INT FOREIGN KEY REFERENCES USUARIO(idUsuario),
	CRM VARCHAR(7) UNIQUE NOT NULL,
	nomeMedico VARCHAR(60) NOT NULL
);
GO

--PACIENTE

CREATE TABLE PACIENTE (
	idPaciente INT PRIMARY KEY IDENTITY,
	idUsuario INT FOREIGN KEY REFERENCES USUARIO(idUsuario),
	nomePaciente VARCHAR(60) NOT NULL,
	dataNascimento DATE NOT NULL,
	CPF CHAR(12) UNIQUE NOT NULL,
	RG CHAR(9) UNIQUE NOT NULL,
	telefone VARCHAR(12), 
	endereco VARCHAR(150) UNIQUE NOT NULL
);
GO

--CONSULTA
CREATE TABLE CONSULTA (
	idConsulta INT PRIMARY KEY IDENTITY,
	idMedico INT FOREIGN KEY REFERENCES MEDICO(idMedico),
	idSituacao TINYINT FOREIGN KEY REFERENCES SITUACAO(idSituacao) DEFAULT(1),
	idPaciente INT FOREIGN KEY REFERENCES PACIENTE(idPaciente),
	dataConsulta DATETIME NOT NULL,
	descricao VARCHAR(50)
);
GO

