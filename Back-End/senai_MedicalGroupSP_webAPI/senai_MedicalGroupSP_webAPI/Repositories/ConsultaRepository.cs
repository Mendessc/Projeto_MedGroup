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
            if (idTipo == 3)
            {
                Medico medicoBuscado = ctx.Medicos.FirstOrDefault(m => m.IdUsuario == id);

                int idMedico = medicoBuscado.IdMedico;

                return ctx.Consulta.Where(m => m.IdMedico == idMedico)
                    .Select(p => new Consulta()
                    {
                        DataConsulta = p.DataConsulta,
                        IdConsulta = p.IdConsulta,
                        Descricao = p.Descricao,
                        IdMedicoNavigation = new Medico()
                        {
                            Crm = p.IdMedicoNavigation.Crm,
                            IdUsuarioNavigation = new Usuario()
                            {
                                Nome = p.IdMedicoNavigation.IdUsuarioNavigation.Nome,
                                Email = p.IdMedicoNavigation.IdUsuarioNavigation.Email
                            }
                        },
                        IdPacienteNavigation = new Paciente()
                        {
                            Cpf = p.IdPacienteNavigation.Cpf,
                            Telefone = p.IdPacienteNavigation.Telefone,
                            IdUsuarioNavigation = new Usuario()
                            {
                                Nome = p.IdPacienteNavigation.IdUsuarioNavigation.Nome,
                                Email = p.IdPacienteNavigation.IdUsuarioNavigation.Email
                            }
                        },
                        IdSituacaoNavigation = new Situacao
                        {
                            Descricao = p.IdSituacaoNavigation.Descricao
                        }
                    })
                    .ToList();
            }
            else if (idTipo == 1)
            {
                Paciente pacienteBuscado = ctx.Pacientes.FirstOrDefault(p => p.IdPaciente == id);

                int idPaciente = pacienteBuscado.IdPaciente;

                return ctx.Consulta.Where(m => m.IdPaciente == idPaciente)
                    .Select(p => new Consulta()
                    {
                        DataConsulta = p.DataConsulta,
                        IdConsulta = p.IdConsulta,
                        IdMedicoNavigation = new Medico()
                        {
                            Crm = p.IdMedicoNavigation.Crm,
                            IdUsuarioNavigation = new Usuario()
                            {
                                Nome = p.IdMedicoNavigation.IdUsuarioNavigation.Nome,
                                Email = p.IdMedicoNavigation.IdUsuarioNavigation.Email
                            }
                        },
                        IdPacienteNavigation = new Paciente()
                        {
                            Cpf = p.IdPacienteNavigation.Cpf,
                            Telefone = p.IdPacienteNavigation.Telefone,
                            IdUsuarioNavigation = new Usuario()
                            {
                                Nome = p.IdPacienteNavigation.IdUsuarioNavigation.Nome,
                                Email = p.IdPacienteNavigation.IdUsuarioNavigation.Email
                            }
                        },
                        IdSituacaoNavigation = new Situacao
                        {
                            Descricao = p.IdSituacaoNavigation.Descricao
                        }
                    })
                    .ToList();
            }

            return null;
        }

        public List<Consulta> ListarTodos()
        {
            return ctx.Consulta.Include(c => c.IdMedicoNavigation).Include(c => c.IdPacienteNavigation).Include(c => c.IdSituacaoNavigation).Include(c => c.IdMedicoNavigation.IdClinicaNavigation).ToList();
        }
    }
}
