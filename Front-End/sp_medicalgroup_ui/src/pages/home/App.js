
import { Component } from "react";
import axios from 'axios';
import Logo3 from '../../assets/img/SP 3.png'
import { parseJwt, usuarioAutenticado } from "../../services/auth";

export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            email: '',
            senha: '',
            erroMensagem: '',
            isLoading: false,
        };
    }


    efetualogin = (log) => {
        log.preventDefault();

        this.setState({ erroMensagem: '', isLoading: true });

        axios.post('http://localhost:5000/api/Login', {
            email: this.state.email,
            senha: this.state.senha,

        }).then((resposta) => {
            // verifico se o status code dessa resposta é igual a 200
            if (resposta.status === 200) {

                localStorage.setItem('usuario-login', resposta.data.token);

                this.setState({ isLoading: false });


                let base64 = localStorage.getItem('usuario-login').split('.')[1];

                console.log(base64);

                switch (parseJwt().role) {
                    case '3':
                        console.log(this.props);
                        this.props.history.push('/home_adm');
                        console.log('estou logado: ' + usuarioAutenticado());
                        break;

                    case '1':
                        console.log(this.props);
                        this.props.history.push('/home_paciente');
                        console.log('estou logado: ' + usuarioAutenticado());
                        break;

                    case '2':
                        console.log(this.props);
                        this.props.history.push('/home_medico');
                        console.log('estou logado: ' + usuarioAutenticado());
                        break;

                    default: this.props.history.push('/notdefault');
                        break;
                }

            }
        })
            .catch(() => {
                // define o valor do state erroMensagem com uma mensagem personalizada
                this.setState({
                    erroMensagem: 'E-mail e/ou senha inválidos!',
                    isLoading: false,
                });
            });
    }

    atualizaStateCampo = (campo) => {
        console.log(campo);

        this.setState({ [campo.target.name]: campo.target.value });
    };

    render() {
        return (
            <div>
                <main className="main_login">
                    <section className="container_login">
                        <div className="organizar_campo container">
                            <div className="bloco-login">
                                <div className="header_login">
                                    <img src={Logo3} alt="" />
                                    <h1>sp.medical group</h1>
                                    <hr />
                                    <span>Login</span>
                                </div>
                                <div className="inicio-login">
                                    <h2>Entre com a sua conta MedicalGroup</h2>
                                    <div className="hr_login">
                                        <hr /> <hr />
                                    </div>
                                </div>
                                <form onSubmit={this.efetualogin} className="form-login">
                                    <span className="texto-email">Digite seu Email</span>
                                    <input className="input-login" value={this.state.email} onChange={this.atualizaStateCampo} name="email" type="email" id="login_email" />
                                    <span className="texto-senha">Digite sua Senha</span>
                                    <input className="input-login" value={this.state.senha} onChange={this.atualizaStateCampo} name="senha" type="password" id="login_senha" />
                                    <div className="botao-login">
                                        <button type='submit' className="btn-login" id="btn_login">
                                            Entrar
                                        </button>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </section>
                </main>
            </div>
        )


    }

};


