import React from 'react';
import { StatusBar } from 'react-native';

import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';

import Login from './src/screens/login';
import Main from './src/screens/main';

const AuthStack = createStackNavigator();

function App() {


  return (
    <NavigationContainer>
      <StatusBar
      // hidden={true}
      />
      <AuthStack.Navigator
        initialRouteName='Login'
        screenOptions={{
          headerShown: false,
        }}
      >
        <AuthStack.Screen name="Login" component={Login}></AuthStack.Screen>
        <AuthStack.Screen name="Main" component={Main}></AuthStack.Screen>
      </AuthStack.Navigator>
    </NavigationContainer>
  );
}
export default App;
