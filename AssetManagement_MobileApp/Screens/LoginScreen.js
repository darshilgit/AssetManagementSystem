import React, { Component } from "react";
import { Text, View } from 'react-native';
import { Card, CardSection, Button, Header, Input } from '../src/components/common';
import StackNavigator from 'react-navigation';
import HomeScreen from './HomeScreen';
import axios from 'axios';
import AwesomeAlert from 'react-native-awesome-alerts';

class LoginScreen extends Component {
    static navigationOptions={
      title: 'LoginScreen'
    }
    
  constructor(props) {
    super(props);
    this.state = { 
      showAlert: false,
      //Added for Testing
      username: 'this@that.com', 
      password: 'password'
    };
  };
  
  showAlert = () => {
    this.setState({
     showAlert: true
    });
  };
 
  hideAlert = () => {
    this.setState({
      showAlert: false
    });
  };
    validateUser() {
      axios.get('https://sku1y8kfk4.execute-api.us-east-1.amazonaws.com/latest/getPassword?EMAIL='+this.state.username+'&PASSWORD='+this.state.password)
             .then(recordset => {
               const id = Object.values(recordset.data.recordset[0])[1];
              if(Object.values(recordset.data.recordset[0])[0] == 1){
                this.props.navigation.navigate('HomeScreen', {
                  Id: id
                });
              } else{
                this.showAlert();
              }
             });
      
    }
    render() {
      var { navigate } = this.props.navigation;
      const {showAlert} = this.state;
      return (
        <View>
          <Card>
            <Header headerText={'Asset Management System'}/>
            <CardSection>
              <Input
                label = {'Username'}
                placeholder = "Enter your Username"
                value={this.state.username}
                onChangeText={username => this.setState({ username })} 
              />
            </CardSection>
            <CardSection>
              <Input  
              label = {'Password'}
              secureTextEntry = { true }
              placeholder = "Enter your Password"
              value={this.state.password}
              onChangeText={password => this.setState({ password })}
              />
            </CardSection>
            <CardSection>
              <Button onPress={() => this.validateUser()} buttonText={'Login'} />
            </CardSection>
           
          </Card> 
          <Card>
            <AwesomeAlert
          show={showAlert}
          showProgress={false}
          title="AwesomeAlert"
          message="I have a message for you!"
          closeOnTouchOutside={true}
          closeOnHardwareBackPress={false}
          showCancelButton={true}
          showConfirmButton={false}
          cancelText="Dismiss"
          confirmButtonColor="#DD6B55"
          onCancelPressed={() => {
            this.hideAlert();
          }}
          onConfirmPressed={() => {
            this.hideAlert();
          }}
          />
          </Card> 
        </View>
      );
    }
  }

export default LoginScreen;