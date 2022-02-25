---USE SP_MED_GROUP;

--TIPO USUARIO
INSERT INTO TIPOUSUARIO(tipo)
VALUES ('Paciente'),('Médico'),('Administrador');
GO

--SITUACAO
INSERT INTO SITUACAO(descricao)
VALUES ('Agendada'),('Realizada'),('Cancelada')
GO

--ESPECIALIZACAO
INSERT INTO ESPECIALIDADE(nomeEspecialidade)
VALUES ('Acupuntura'),('Anestesiologia'),('Angiologia'),('Cardiologia'),
       ('Cirurgia Cardiovascular'),('Cirurgia da Mão'),('Cirurgia do Aparelho Digestivo'),('Cirurgia Geral'),('Cirurgia Pediátrica'),
	   ('Cirurgia Plástica'),('Cirurgia Torácica'),('Cirurgia Vascular'),('Dermatologia'),('Radioterapia'),('Urologia'),('Pediatria'),('Psiquiatria')
GO

--INSTITUICAO
INSERT INTO CLINICA(nomeClinica, razaoSocial, endereco, cnpj, email, telefone)
VALUES ('Clinica Senai','SP Medical Group','Av. Barão Limeira, 532, São Paulo, SP','19.100.890/0033-40', 'clinicaSenai@email.com', '1129812920')
GO

--USUARIO
INSERT INTO USUARIO(idTipoUsuario,nome,email,senha)
VALUES ('3','admin','admin@email.com','admin000'),
	   ('1','José','jose@email.com','jose000'),
	   ('2','Patricia','patricia@email.com','patricia000'),
	   ('1','Ana','ana@email.com','ana000'),
	   ('1','Luiza','luiza@email.com','luiza000'),
	   ('2','Mariana','mariana@email.com','mariana000'),
	   ('1','Thiago','thiago@email.com','thiago000'),
	   ('1','Gustavo','gustavo@email.com','gustavo000'),
	   ('2','Guilherme','guilherme@email.com','guilherme000'),
	   ('1','Bruna','bruna@email.com','bruna000') 
GO

--MEDICO
INSERT INTO MEDICO(idEspecialidade,idClinica,idUsuario,CRM,nomeMedico)
VALUES ('13','1','3','10101', 'Patricia Helena'),
	   ('4','1','6','54321', 'Mariana Santos'),
	   ('10','1','9','12345','Guilherme Ribeiro')
GO


--PACIENTE
INSERT INTO PACIENTE(idUsuario,nomePaciente,dataNascimento,CPF,RG,telefone,endereco)
VALUES ('2','José Jorge','17/03/1974','86372836831','343049399','1129876533','Rua Frederico Consolo, São Paulo - SP'),
	   ('4','Ana Clara','01/10/2003','15200529875','334127531','1178900654','Rua José Martinho de Moura Baptista, São Paulo - SP'),
	   ('5','Luiza Pardo','27/03/2004','48176847801','305132246','1139876601','Rua Bresser, São Paulo - SP'),
	   ('7','Thiago Soares','20/04/2000','69917183868','413104448','1129812629','Rua Frederico Consolo, São Paulo - SPTravessa Constelação do Cruzeiro'),
	   ('8','Gustavo Gomes','15/01/1999','66920976811','183906251','1140903374','Rua Frederico ConsoloRua Mataraca, São Paulo - SP'),
	   ('10','Bruna Lopes','19/05/1990','66217171805','217981641','11778903412','Rua Joaquim Mendes de Aguiar, São Paulo - SP')
GO


--CONSULTA
INSERT INTO CONSULTA (idMedico,idSituacao,idPaciente,dataConsulta,descricao)
VALUES('3','1','4','27/03/2021 10:00','Moldes para cirurgia no nariz feitos'),
	('2','1','2','28/03/2021 15:00','Exames feitos e remédios receitados'),
	('2','3','2','29/03/2021 11:00','Mudanças nos exames, paciente bem'),
	('3','2','4','30/03/2021 08:00','Cirurgia realizada e remédios receitados'),
	('3','1','5','02/04/2021 09:00','Medidas do rosto tiradas'),
	('1','1','6','03/04/2021 12:00','Examinação da pele e remédios receitados'),
	('1','2','6','07/04/2021 13:00','paciente respondeu bem a medicação'),
	('3','2','5','10/04/2021 10:00','Cirurgia realizada e remédios receitados')
GO
