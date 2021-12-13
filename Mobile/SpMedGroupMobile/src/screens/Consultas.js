import React, { Component } from 'react';

import api from '../services/api';


import AsyncStorage from '@react-native-async-storage/async-storage';
import { View, Text, StyleSheet, FlatList, Image } from 'react-native';

export default class Consultas extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaConsultas: []
        };
    }

    buscarConsultas = async () => {
        const token = await AsyncStorage.getItem('userToken')


        const resposta = await api.get('/Consultas/Listar/Minhas', {
            headers: {
                authorization: 'Bearer ' + token
            }
        });

        const dados = resposta.data;

        this.setState({ listaConsultas: dados })

        // console.warn(this.state.listaConsultas);

    }
    componentDidMount() {
        this.buscarConsultas();
    }

    render() {
        return (
            <View style={styles.main}>
                <Image
                    source={require('../../assets/img/SPlogoo.png')}
                    style={styles.imgHeader}
                />
                <Text style={styles.textHeader}>Lista de Consultas</Text>
                <View style={{ flex: 1 }}>
                    <FlatList
                        style={{ flex: 1}}
                        data={this.state.listaConsultas}
                        keyExtractor={item => item.idConsulta}
                        renderItem={this.renderItem}
                    />
                </View>
            </View>
        );
    }

    renderItem = ({ item }) => (
        <View style={styles.boxConteudo}>
            <Text style={styles.boxTexto}>Medico: {(item.idMedicoNavigation.nomeMedico)}</Text>
            <Text style={styles.boxTexto}>Paciente: {(item.idPacienteNavigation.nomePaciente)}</Text>
                <Text style={styles.boxTexto}>Data da Consulta: {Intl.DateTimeFormat("pt-BR", {
                    year: 'numeric', month: 'short', day: 'numeric', hour: 'numeric', minute: 'numeric'
                }).format(new Date(item.dataConsulta))}</Text>
            <Text style={styles.boxTexto}>Situação: {(item.idSituacaoNavigation.descricao)}</Text>
            <Text style={styles.boxTexto}>Descrição: {item.descricao}</Text>

        </View>
    )

}

const styles = StyleSheet.create({
    main: {
        flex: 1,
        alignItems: 'center',
        backgroundColor: '#003373'
    },
    imgHeader: {
        marginTop: 40,
        marginBottom: 8
    },
    textHeader: {
        fontSize: 26,
        color:'#fff',
        marginBottom:25
    },
    boxConteudo: {
        backgroundColor: '#00587D',
        flex: 4,
        width: 350,
        height: 168,
        marginBottom: 10,
        borderRadius: 10,
    },
    boxTexto:{
        paddingTop:10,
        paddingLeft:10,
        color:'#fff'
    }

})
