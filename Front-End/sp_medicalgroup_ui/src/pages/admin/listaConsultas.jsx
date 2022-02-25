import {Component} from "react";
import Logo from '../../assets/img/SP 1.png'
import { Link, useHistory } from 'react-router-dom';


class ListaConsultas extends Component{
    constructor(props){
        super(props);
        this.state ={
            listaConsultas : [],
            idConsulta: '',
            NomedoPaciente : '',
            NomedoMedico : '',
            DataConsulta : '',
            Situacao : '',
            Descricao : ''
        };
    };

    buscarConsulta = ()=> {
        fetch('https://6205582b161670001741b955.mockapi.io/consultas')

        .then(resposta => resposta.json())

        .then(dados => this.setState({listaConsultas : dados}))

        .catch(erro => console.log(erro))
    }

    componentDidMount(){
        this.buscarConsulta()
    };

    render(){
        return(
            <div>
            <header className="container container_header">
        <div className="div_header">
            <div className="logo_header">
                <img src={Logo} alt=""/>
                <span>sp.medical group</span>
            </div>
            <div className="link_header">
            <Link to="/home_adm">Inicio</Link>
                <a href="">Consultas</a>
                <a href="">Sobre</a>
            </div>
        </div>
    </header>
    <main className="main_list">
        <section className="banner_list"> 
            <div className="org_banner_list container">
                <h1>Listagem de Consultas</h1>
                <hr/>
            </div>
        </section>
        <section className="lista">
            <div className="org_lista container">
                <table className="tabela_medico">
                    <thead>
                        <tr>
                            <th>Nome do Paciente</th>
                            <th>Nome do Médico</th>
                            <th>Data da consulta</th>
                            <th>Situação</th>
                            <th>Descrição</th>
                        </tr>
                    </thead>
                    <tbody>
                        
                            {
                                this.state.listaConsultas.map((Consultas) => {
                                    return(
                                        <tr key={Consultas.idConsulta}>
                                            <td>{Consultas.idPacienteNavigation[0].nomePaciente}</td>
                                            <td>{Consultas.idMedicoNavigation[0].nomeMedico}</td>
                                            <td>{Intl.DateTimeFormat("pt-BR",{
                                            year: 'numeric',month: 'numeric', day:'numeric',
                                            hour:'numeric', minute:'numeric'
                                            }).format(new Date (Consultas.dataConsulta))}</td>
                                            <td>{Consultas.descricao}</td>
                                            <td>{Consultas.situacao}</td>
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
                    <img src="../../assets/SP 9.png" alt=""/>
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
}
export default ListaConsultas;