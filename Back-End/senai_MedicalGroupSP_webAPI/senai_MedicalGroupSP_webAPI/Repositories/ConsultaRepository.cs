using Microsoft.EntityFrameworkCore;
using senai_MedicalGroupSP_webAPI.Contexts;
using senai_MedicalGroupSP_webAPI.Domains;
using senai_MedicalGroupSP_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_MedicalGroupSP_webAPI.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        MedGroupContext ctx = new(); 
        public void AlterarDescricao(string novaDescricao, int idConsulta)
        {
            Consulta consultaBuscada = BuscarPorId(idConsulta);

            consultaBuscada.Descricao = novaDescricao;

            ctx.Consulta.Update(consultaBuscada);

            ctx.SaveChanges();
        }

        public Consulta BuscarPorId(int idConsulta)
        {
            return ctx.Consulta.FirstOrDefault(c => c.IdConsulta == idConsulta);
        }

        public void Cadastrar(Consulta novaConsulta)
        {
            novaConsulta.IdSituacao = 1;

            ctx.Consulta.Add(novaConsulta);

            ctx.SaveChanges();
        }

        public void Cancelar(int idConsulta)
        {
            Consulta consultaBuscada = BuscarPorId(idConsulta);

            consultaBuscada.IdSituacao = 2;
            consultaBuscada.Descricao = "Consulta Cancelada!";

            ctx.Consulta.Update(consultaBuscada);

            ctx.SaveChanges();
        }

        public void Deletar(int idConsulta)
        {
            ctx.Consulta.Remove(BuscarPorId(idConsulta));

            ctx.SaveChanges();
        }

        public List<Consulta> ListarMinhas(int id, int idTipo)
        {
            switch (idTipo)
            {
                case 2:
                    Medico medico = ctx.Medicos.FirstOrDefault(m => m.IdUsuario == id);
                    int idMedico = medico.IdMedico;
                    return ctx.Consulta
                        .Select(c => new Consulta()
                        {
                            IdConsulta = c.IdConsulta,
                            DataConsulta = c.DataConsulta,
                            IdSituacao = c.IdSituacao,
                            IdMedico = c.IdMedico,
                            Descricao = c.Descricao,
                            IdMedicoNavigation = new Medico()
                            {
                                NomeMedico = c.IdMedicoNavigation.NomeMedico
                            },
                            IdPacienteNavigation = new Paciente()
                            {
                                NomePaciente = c.IdPacienteNavigation.NomePaciente,
                                Telefone = c.IdPacienteNavigation.Telefone,
                                Endereco = c.IdPacienteNavigation.Endereco,
                                DataNascimento = c.IdPacienteNavigation.DataNascimento,
                                Cpf = c.IdPacienteNavigation.Cpf,
                                Rg = c.IdPacienteNavigation.Rg

                            },
                            IdSituacaoNavigation = new Situacao()
                            {
                                Descricao = c.IdSituacaoNavigation.Descricao
                            }


                        })
                        .Where(c => c.IdMedico == idMedico).ToList();


                case 1:
                    Paciente paciente = ctx.Pacientes.FirstOrDefault(p => p.IdUsuario == id);
                    int idPaciente = paciente.IdPaciente;
                    return ctx.Consulta
                        .Select(c => new Consulta()
                        {
                            IdConsulta = c.IdConsulta,
                            DataConsulta = c.DataConsulta,
                            IdSituacao = c.IdSituacao,
                            IdMedico = c.IdMedico,
                            IdPaciente = c.IdPaciente,
                            Descricao = c.Descricao,
                            IdMedicoNavigation = new Medico()
                            {
                                NomeMedico = c.IdMedicoNavigation.NomeMedico,
                                Crm = c.IdMedicoNavigation.Crm,
                                IdEspecialidade = c.IdMedicoNavigation.IdEspecialidade
                            },
                            IdSituacaoNavigation = new Situacao()
                            {
                                Descricao = c.IdSituacaoNavigation.Descricao
                            }



                        })
                        .Where(c => c.IdPaciente == idPaciente).ToList();

                default:
                    return null;

            }
        }

        public List<Consulta> ListarTodos()
        {
            return ctx.Consulta.Include(c => c.IdMedicoNavigation).Include(c => c.IdPacienteNavigation).Include(c => c.IdSituacaoNavigation).Include(c => c.IdMedicoNavigation.IdClinicaNavigation).ToList();
        }
    }
}
