import { Component } from "react";
import { useState, useEffect } from "react";
import axios from 'axios';
import Logo from '../../assets/img/SP 1.png'
import { Link, useHistory } from 'react-router-dom';

export default function MinhasConsultasM() {
    const [listaMinhasConsultas, setListaMinhasConsultas] = useState([]);

    function buscarMinhasConsultas() {
        console.log('buscar')
        axios('http://localhost:5000/api/Consultas/Listar/Minhas', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
        .then(response => {
            if (response.status === 200) {
                setListaMinhasConsultas(response.data)
            }
        })
        .catch(erro => console.log(erro));
    }

    useEffect(buscarMinhasConsultas, []);

            return (
                <div>
                    <header className="container container_header">
                        <div className="div_header">
                            <div className="logo_header">
                                <img src={Logo} alt="" />
                                <span>sp.medical group</span>
                            </div>
                            <div className="link_header">
                            <Link to="/home_medico">Inicio</Link>
                            <Link to="/listaconsultasmedico">Consultas</Link>
                                <a href="">Sobre</a>
                            </div>
                        </div>
                    </header>
                    <main className="main_list">
                        <section className="banner_list">
                            <div className="org_banner_list container">
                                <h1>Listagem de Consultas</h1>
                                <hr />
                            </div>
                        </section>
                        <section className="lista">
                            <div className="org_lista container">
                                <table className="tabela_medico">
                                    <thead>
                                        <tr>
                                            <th>Nome do Paciente</th>
                                            <th>Data da consulta</th>
                                            <th>Situa????o</th>
                                            <th>Descri????o</th>
                                            <th>Editar</th>
                                        </tr>
                                    </thead>
                                    <tbody>

                                        {
                                            listaMinhasConsultas.map((minhaConsulta) => {
                                                return (
                                                    <tr key={minhaConsulta.idConsulta}>
                                                        <td>{minhaConsulta.idPacienteNavigation.nomePaciente}</td>
                                                        <td>{Intl.DateTimeFormat("pt-BR", {
                                                            year: 'numeric', month: 'numeric', day: 'numeric',
                                                            hour: 'numeric', minute: 'numeric'
                                                        }).format(new Date(minhaConsulta.dataConsulta))}</td>
                                                        <td>{minhaConsulta.idSituacaoNavigation.descricao}</td>
                                                        <td>{minhaConsulta.descricao}</td>
                                                        <td className="bnt_editar_medico"><button>Editar</button></td>
                                                    </tr>
                                                )
                                            })
                                        }

                                    </tbody>
                                </table>
                            </div>
                        </section>
                        <footer>
                            <div className="org_footer container">
                                <div className="links_footer">
                                    <a href="">Inicio</a>
                                    <a href="">Lista de Consultas</a>
                                    <a href="">Marque sua Consulta</a>
                                </div>
                                <div className="logo_footer">
                                    <img src="../../assets/SP 9.png" alt="" />
                                    <span>Sp.Medical Group</span>
                                </div>
                                <div className="info_footer">
                                    <span>(11)29812920</span>
                                    <span>Av. Bar??o Limeira, 532, S??o Paulo, SP</span>
                                    <span>clinicaSenai@email.com</span>
                                </div>
                            </div>
                        </footer>
                    </main>
                </div>
            )
}
 