import React, { Component } from 'react';

import {
    StyleSheet,
    View,
  } from 'react-native';

import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';

const Tab = createBottomTabNavigator();

import Consultas from './Consultas';

export default class Main extends Component{
    render(){
        return(
            <View style={styles.main}>
                <Tab.Navigator
                    initialRouteName='Consultas'
                    screenOptions={({ route }) => ({
                        tabBarIcon: () => {
                            if (route.name === 'Consultas') {
                                return (
                                    <Image
                                        source={require('../../assets/img/checklist.png')}
                                        style={styles.tabBarIcon}
                                    />
                                )
                            }
                        },
                        headerShown: false,
                        tabBarShowLabel: false,
                        tabBarActiveBackgroundColor: '#056367',
                        tabBarStyle: { height: 49 }
                    })}
                >
                    <Tab.Screen name='Consulta' component={Consultas}></Tab.Screen>
                    {/* <Tab.Screen name='Perfil' component={Perfil}></Tab.Screen> */}
                    
                </Tab.Navigator>
            </View>
        )}}


const styles = StyleSheet.create({
    main: {
        flex: 1,
        backgroundColor: '#056367'
    },

    tabBarIcon: {
        width:10,
        height:50,
        
    }
    
});