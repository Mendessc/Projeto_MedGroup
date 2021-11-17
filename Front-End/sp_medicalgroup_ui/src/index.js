import React from 'react';
import ReactDOM from 'react-dom';
import{Route, BrowserRouter as Router, Switch, Redirect} from 'react-router-dom'
import './index.css';

import HomeAdm from './pages/admin/home_adm'
import ListaConsultas from './pages/admin/listaConsultas'
import MinhasConsultasM from './pages/medico/listaConsultasMedico';
import MinhasConsultasP from './pages/paciente/listaConsultasPaciente';
import CadastroConsultas from './pages/admin/cadastroConsultas'
import Login from './pages/home/App';
import HomeMedico from './pages/medico/home_medico';
import HomePaciente from './pages/paciente/home_paciente';


import NotFound from './pages/NotFound/notfound'
import reportWebVitals from './reportWebVitals';
import { Component } from 'react';
import { parseJwt, usuarioAutenticado } from './services/auth';

const PermissaoAdm = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && parseJwt().role === '3' ? (
        <Component {...props} />
      ) : (
        <Redirect to="login" />
      )
    }
  />
);
const PermissaoMedico = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && parseJwt().role === '2' ? (
        <Component {...props} />
      ) : (
        <Redirect to="login" />
      )
    }
  />
);
const PermissaoPaciente = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && parseJwt().role === '1' ? (
        <Component {...props} />
      ) : (
        <Redirect to="login" />
      )
    }
  />
);

const routing = (
  <Router>
    <div>
      <Switch>
        <PermissaoAdm path = "/home_adm" component = {HomeAdm}/>
        <PermissaoMedico path = "/home_medico" component = {HomeMedico}/>
        <PermissaoPaciente path = "/home_paciente" component = {HomePaciente}/>
        <PermissaoAdm path = "/listaconsultas" component = {ListaConsultas} />
        <PermissaoMedico path = "/listaconsultasmedico" component = {MinhasConsultasM}/>
        <PermissaoPaciente path = "/listaconsultaspaciente" component = {MinhasConsultasP}/>
        <PermissaoAdm path = "/cadastroConsultas" component = {CadastroConsultas} />
        <Route path = "/" component = {Login}/>
        <Route path = "/notfound" component = {NotFound} />
        <Redirect to = "/notfound"/>
        <Route />
      </Switch>
    </div>
  </Router>
)

ReactDOM.render(
  routing,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
