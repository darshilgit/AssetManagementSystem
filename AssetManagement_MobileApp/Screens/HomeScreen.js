import React, { Component } from "react";
import { StyleSheet, Text, View, ScrollView, Button } from 'react-native';
import LoginScreen from "./LoginScreen";
import FacilityList from "../src/components/FacilityList";
import { Header } from "../src/components/common";

class HomeScreen extends Component {
    static navigationOptions={
        title: 'HomeScreen',
        headerLeft: null,
      }
    
    render() {
        const { params } = this.props.navigation.state;
        const Id = params ? params.Id : null;
        var { navigate } = this.props.navigation;
        return (
            <View style={styles.viewStyle}>
                <Header headerText={ 'Welcome' }/>
                <FacilityList navigation={this.props.navigation} Id={Id} />
                <Button onPress={() => navigate('LoginScreen')} title="Logout" />
            </View>
        );
    }
  }

  const styles = {
      viewStyle: { 
        flex: 1,
        padding: 20
      }
  }


export default HomeScreen;