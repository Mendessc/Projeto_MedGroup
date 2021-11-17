import { Component } from "react";
import Logo from '../../assets/img/SP 9.png'
import Logo1 from '../../assets/img/SP 1.png'
import Desenho from '../../assets/img/undraw_doctor_kw5l 1.png'
import { Link, useHistory } from 'react-router-dom';
import { useState, useEffect } from 'react';
import axios from "axios";


export default function CadastroConsultas() {
    const [listaPac, setListaPac] = useState([]);
    const [listaMed, setListaMed] = useState([]);
    const [idPaciente, setIdPaciente] = useState('');
    const [idMedico, setIdMedico] = useState('');
    const [dataConsul, setDataConsul] = useState('');
    const [idSituacao, setIdSituacao] = useState('');
    const [idDescricao, setIdDescricao] = useState('');


    function listarPacientes() {
        axios('http://localhost:5000/api/Pacientes', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    setListaPac(resposta.data)
                }
            })

            .catch(erro => console.log(erro))
    }

    useEffect(listarPacientes, []);

    function listarMedicos() {
        axios('http://localhost:5000/api/Medicos', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    setListaMed(resposta.data)
                }
            })

            .catch(erro => console.log(erro.response.data))
    }

    useEffect(listarMedicos, []);


    function cadastrarConsulta(evento) {

        evento.preventDefault()

        axios.post('http://localhost:5000/api/Consultas', {
                idPaciente: idPaciente,
                idMedico: idMedico,
                DataConsulta: dataConsul,
                idSituacao: idSituacao,
                Descricao: idDescricao
            }, {
                headers: {
                    'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
                }
            })
            .then(resposta => {
                if (resposta.status === 201) {
                    console.log('Consulta cadastrada');
                    setIdMedico('');
                    setIdPaciente('');
                    setDataConsul('');
                    setIdSituacao('');
                    setIdDescricao('');
                }
            })
            .catch(erro => console.log(erro))
    }

    return (
        <div>
            <header className="container container_header">
                <div className="div_header">
                    <div className="logo_header">
                        <img src={Logo1} alt="" />
                        <span>sp.medical group</span>
                    </div>
                    <div className="link_header">
                        <Link to="/home_adm">Inicio</Link>
                        <a href="">Consultas</a>
                        <a href="">Sobre</a>
                    </div>
                </div>
            </header>
            <main className="main_cad">
                <section className="banner_cad">
                    <div className="org_banner_cad container">
                        <h1>Cadastro de Consultas</h1>
                        <hr />
                    </div>
                </section>
                <section className="cadastro">
                    <div className="container_cad"></div>
                    <div className="org_cadastro container">
                        <h2>Cadastrar Consulta</h2>
                        <hr />
                        <form onSubmit={cadastrarConsulta}>
                            <select
                                name="paciente"
                                id="paciente"
                                value={idPaciente}
                                onChange={(campo) => setIdPaciente(campo.target.value)}
                            >
                                <option value="0">Selecione o Paciente</option>

                                {listaPac.map((paciente) => {
                                    return (
                                        <option key={paciente.idPaciente} value={paciente.idPaciente}>
                                            {paciente.nomePaciente}
                                        </option>
                                    )
                                })}
                            </select>

                            <select
                                name="medico"
                                id="medico"
                                value={idMedico}
                                onChange={(campo) => setIdMedico(campo.target.value)}
                            >
                                <option value="0">Selecione o Médico</option>

                                {listaMed.map((medico) => {
                                    return (
                                        <option key={medico.idMedico} value={medico.idMedico}>
                                            {medico.nomeMedico}
                                        </option>
                                    )
                                })}
                            </select>
                            <input type="datetime-local" name="dataConsul" value={dataConsul} placeholder="Data da consulta" onChange={(campo) => setDataConsul(campo.target.value)} ></input>
                            <select
                                name="situacao"
                                id="situacao"
                                value={idSituacao}
                                onChange={(campo) => setIdSituacao(campo.target.value)}
                            >
                                <option value="0">Selecione a Situação da Consulta</option>
                                <option value="1">Agendada</option>
                                <option value="2">Realizada</option>
                                <option value="3">Cancelada</option>
                            </select>
                            <input type="text" name="idDescricao" placeholder="Descrição" value={idDescricao} onChange={(campo) => setIdDescricao(campo.target.value)}></input>

                            <button type="submit" className="bnt_cadastrar">Cadastrar</button>
                        </form>
                    </div>
                    <div className="org_img_cad">
                        <img src={Desenho} alt="" />
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
                            <img src={Logo} alt="" />
                            <span>Sp.Medical Group</span>
                        </div>
                        <div className="info_footer">
                            <span>(11)29812920</span>
                            <span>Av. Barão Limeira, 532, São Paulo, SP</span>
                            <span>clinicaSenai@email.com</span>
                        </div>
                    </div>
                </footer>
            </main>
        </div>
    )
}
