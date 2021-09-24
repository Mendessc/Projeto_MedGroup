USE SP_MED_GROUP;

--listar tudo de cada um
SELECT * FROM PACIENTE;
SELECT * FROM CONSULTA;
SELECT * FROM USUARIO;
SELECT * FROM MEDICO;
SELECT * FROM SITUACAO;
SELECT * FROM TIPOUSUARIO;
SELECT * FROM CLINICA;
SELECT * FROM ESPECIALIDADE;

--listar todos dados relacionados � consulta
SELECT UP.nome Paciente, 
	   E.nomeEspecialidade Especialidade,
	   CONVERT(VARCHAR(25),C.dataConsulta,103) [Data da Consulta],
	   S.descricao Situa��o,
	   C.descricao 
  FROM CONSULTA C
 INNER JOIN SITUACAO S
    ON C.idSituacao = S.idSituacao
 INNER JOIN PACIENTE P
    ON C.idPaciente = P.idPaciente
 INNER JOIN MEDICO M
    ON C.idMedico = M.idMedico 
 INNER JOIN ESPECIALIDADE E
    ON M.idEspecialidade = E.idEspecialidade
 INNER JOIN USUARIO UP
    ON P.idUsuario = UP.idUsuario
 INNER JOIN USUARIO UM
    ON M.idUsuario = UM.idUsuario
GO

--Criou uma fun��o para retornar a quantidade de m�dicos de uma determinada especialidade
 CREATE FUNCTION MED_ESPECIALIDADE(@nomeEspec VARCHAR(90))
RETURNS TABLE
     AS
 RETURN (
          SELECT @nomeEspec AS especialidade, COUNT(idEspecialidade) [N�mero de M�dicos]
		    FROM ESPECIALIDADE
		   WHERE nomeEspecialidade LIKE '%' + @nomeEspec + '%'
        )
GO
--DROP FUNCTION MED_ESPECIALIZACAO
SELECT * FROM MED_ESPECIALIDADE('Psiquiatria')
GO

--Criou uma fun��o para que retorne a idade do usu�rio a partir de uma determinada stored procedure
CREATE PROCEDURE  IdadePaciente
 @nome VARCHAR(20)
    AS
 BEGIN
SELECT nome, DATEDIFF(YEAR,dataNascimento,GETDATE())
    AS idade
  FROM USUARIO U
 INNER JOIN PACIENTE P
    ON U.idUsuario = P.idUsuario
 WHERE nome = @nome
   END
GO

EXEC IdadePaciente 'Luiza'

--Mostrar a quantidade de usu�rio ap�s realizar a importa��o do banco de dados
SELECT COUNT(idUsuario) [Quantidade de Usuarios] FROM USUARIO
GO