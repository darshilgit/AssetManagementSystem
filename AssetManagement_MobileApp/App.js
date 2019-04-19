import React from 'react';
import { StyleSheet, Text, View } from 'react-native';
import { StackNavigator } from 'react-navigation';
import LoginScreen from './Screens/LoginScreen';
import HomeScreen from './Screens/HomeScreen';
import ResourceList from './src/components/ResourceList';
import FacilityDetail from './src/components/FacilityDetail';
import FacilityList from './src/components/FacilityList';
import EditResource from './src/components/EditResource';


export default class App extends React.Component {
  render() {
    return (
      <AppNavigator/>
    );
  }
}

const AppNavigator = StackNavigator({
  LoginScreen: {screen: LoginScreen},
  HomeScreen: {screen: HomeScreen},
  FacilityList: {screen: FacilityList},
  ResourceList: {screen: ResourceList},
  FacilityDetail: {screen: FacilityDetail},
  EditResource: {screen: EditResource},
})