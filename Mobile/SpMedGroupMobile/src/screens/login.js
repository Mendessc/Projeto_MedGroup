import React, { Component } from 'react';
import {
    StyleSheet,
    Text,
    TouchableOpacity,
    View,
    Image,
    ImageBackground,
    TextInput,
} from 'react-native';

import AsyncStorage from '@react-native-async-storage/async-storage';
import jwt_decode from "jwt-decode";


import api from '../services/api';

export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            email: 'guilherme@email.com',
            senha: 'guilherme000',
        };
    }

    realizarLogin = async () => {

        console.warn(this.state.email + ' ' + this.state.senha);

        const resposta = await api.post('/login', {
            email: this.state.email,
            senha: this.state.senha,
        });

        const token = resposta.data.token;
        await AsyncStorage.setItem('userToken', token);

        if (resposta.status == 200) {
            console.warn('Login efetuado')
            this.props.navigation.navigate('Main')
        }

        console.warn(token);


    };


    render() {
        return (
            <ImageBackground
                source={require('../../assets/img/backgroundLogin.png')}
                style={StyleSheet.absoluteFillObject}>
                <View style={styles.overlay} />
                <View style={styles.main}>
                    <Image
                        source={require('../../assets/img/SPlogo.png')}
                        style={styles.mainImgLogin}
                    />
                    <Text style={styles.textLogin}>sp.medical group</Text>


                    <TextInput
                        style={styles.inputLogin}
                        placeholder="Digite seu E-mail"
                        placeholderTextColor="#fff"
                        keyboardType="email-address"

                        onChangeText={email => this.setState({ email })}
                    />

                    <TextInput
                        style={styles.inputLogin}
                        placeholder="Digite sua Senha"
                        placeholderTextColor="#fff"
                        keyboardType="default"
                        secureTextEntry={true}

                        onChangeText={senha => this.setState({ senha })}
                    />

                    <TouchableOpacity
                        style={styles.btnLogin}
                        onPress={this.realizarLogin}>
                        <Text style={styles.btnLoginText}>Entrar</Text>
                    </TouchableOpacity>
                </View>
            </ImageBackground>

        )
    }
}

const styles = StyleSheet.create({

    // conteúdo da main
    main: {
        justifyContent: 'center',
        alignItems: 'center',
        width: '100%',
        height: '100%',
    },
    mainImgLogin: {
        justifyContent: 'center',
        alignItems: 'center',
        marginBottom: 10,
    },
    textLogin: {
        fontSize: 24,
        color: '#fff',
        marginBottom: 70,
        textTransform: 'uppercase'
    },

    inputLogin: {
        width: 310,
        marginBottom: 50,
        fontSize: 18,
        borderColor: '#fff',
        borderBottomWidth: 2,
    },

    placeholder: {
        textTransform: 'uppercase'
    },

    btnLogin: {
        justifyContent: 'center',
        alignItems: 'center',
        backgroundColor: '#003373',
        width: 215,
        height: 55,
        borderRadius: 6,
        marginTop: 50,
        marginBottom: 30
    },
    btnLoginText: {
        fontSize: 23,
        color: '#fff'
    }
});