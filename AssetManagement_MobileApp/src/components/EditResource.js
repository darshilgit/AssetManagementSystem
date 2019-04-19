import React, { Component } from 'react';
import { View, StyleSheet, Button } from 'react-native';
import { NavigationActions } from 'react-navigation';
import axios from 'axios';
import t from 'tcomb-form-native'; // 0.6.9
import { KeyboardAwareScrollView } from 'react-native-keyboard-aware-scroll-view';

const Form = t.form.Form;

const Resource = t.struct({
  ResourceName: t.String,
  Description: t.maybe(t.String),
  Quantity: t.Number,
  Size: t.maybe(t.String),
  Color: t.maybe(t.String),
});

const formStyles = {
  ...Form.stylesheet,
  formGroup: {
    normal: {
      marginBottom: 10
    },
  },
  controlLabel: {
    normal: {
      color: 'blue',
      fontSize: 18,
      marginBottom: 7,
      fontWeight: '600'
    },
    // the style applied when a validation error occours
    error: {
      color: 'red',
      fontSize: 18,
      marginBottom: 7,
      fontWeight: '600'
    }
  }
}

const options = {
  fields: {
    ResourceName: {
      editable: false,
      label: 'Name'
    },
    Quantity: {
      error: 'Quantity is Required.',
    },
  },
  stylesheet: formStyles,
};

export default class EditResource extends Component {
    
  handleSubmit(Id, FacilityId) {
    const value = this._form.getValue();
    if(value){
        axios.put('https://sku1y8kfk4.execute-api.us-east-1.amazonaws.com/latest/editResources',{
        "Id": Id,
        "Description": value['Description'],
        "Quantity": value['Quantity'],
        "Size": value['Size'],
        "Color": value['Color']
        })
        .then(() => {
            this.props.navigation.navigate('ResourceList', { FacilityId: FacilityId});
        });
    }
    
    }
  
  render() {
    console.log(this.state);
    console.log(this.props);
    const { params } = this.props.navigation.state;
    const Id = Object.values(params.ResourceId)[0];
    const FacilityId = Object.values(params.FacilityId)[0];
    var values = {
        ResourceName: Object.values(params.ResourceName)[0], 
        Description: Object.values(params.Description)[0],
        Quantity: Object.values(params.Quantity)[0],
        Size: Object.values(params.Size)[0],
        Color: Object.values(params.Color)[0]
    };
    return (
      <KeyboardAwareScrollView>
      <View style={styles.container}>
            <Form 
            ref={c => this._form = c}
            type={Resource} 
            options={options}
            value={ values }
            />
            <Button
            title="Save"
            onPress={() => this.handleSubmit(Id, FacilityId)}
            />
        </View>
      </KeyboardAwareScrollView>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    justifyContent: 'center',
    marginTop: 50,
    padding: 20,
    backgroundColor: '#ffffff',
  },
});