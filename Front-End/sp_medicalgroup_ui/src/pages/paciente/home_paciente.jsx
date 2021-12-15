import '../../assets/css/estilo.css'
import Logo from '../../assets/img/SP 1.png'
import Logo2 from '../../assets/img/SP 2.png'
import Logo3 from '../../assets/img/SP 9.png'
import circulo1 from '../../assets/img/Ellipse 1.png'
import circulo2 from '../../assets/img/Ellipse 2.png'
import imagemhome from '../../assets/img/undraw_doctors_hwty-removebg-preview 1.png'
import { Component } from 'react'
import { Link, useHistory } from 'react-router-dom';

class HomePaciente extends Component {

    redirecionarLista() {
        window.location.href = "/listaconsultaspaciente";
     }

    render() {
        return (
            <div>
                <header class="container container_header">
                    <div class="div_header">
                        <div class="logo_header">
                            <img src={Logo} alt="" />
                            <span>sp.medical group</span>
                        </div>
                        <div class="link_header">
                            <Link to="/home_paciente">Inicio</Link>
                            <Link to="/listaconsultaspaciente">Consultas</Link>
                            <a href="">Sobre</a>
                        </div>
                    </div>
                </header>
                <main class="main_home">
                    <section class="banner_home">
                        <div class="org_banner">
                            <img src={Logo2} alt="" />
                            <h1>sp.medical group</h1>
                            <hr />
                            <p>Buscando a qualidade de vida que você merece</p>
                        </div>
                    </section>
                    <section class="banner_botoes">
                        <img class="circulo_1" src={circulo1} alt="" />
                        <div class="org_botoes1">
                            <div class="botao_list">
                                <button onClick={this.redirecionarLista} class="btn_list" id="btn_list">Listagem de Consultas</button>
                            </div>
                            <div class="descricao">
                                <p>Prevenir doenças, aliviar o sofrimento e curar os doentes.
                                    Esse é o nosso trabalho</p>
                                <img src={imagemhome} alt="" />
                            </div>
                        </div>
                        <img class="circulo_2" src={circulo2} alt="" />
                    </section>
                    <footer>
                        <div class="org_footer container">
                            <div class="links_footer">
                                <a href="">Inicio</a>
                                <a href="">Lista de Consultas</a>
                                <a href="">Marque sua Consulta</a>
                            </div>
                            <div class="logo_footer">
                                <img src={Logo3} alt="" />
                                <span>Sp.Medical Group</span>
                            </div>
                            <div class="info_footer">
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
export default HomePaciente;