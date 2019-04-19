import React, { Component } from 'react';
import { Text, View } from 'react-native';

const Header = ({headerText}) => {
    const { textStyle, viewStyle } = styles; 
    return(
        <View style={ viewStyle }>
            <Text style={ textStyle }>{ headerText }</Text>
        </View>
    ); 
}

const styles = {
    textStyle: {
        fontSize: 30
    },
    viewStyle: {
        justifyContent: 'center',
        alignItems: 'center',
        backgroundColor: '#F0F0F0',
        height: 100,
        paddingTop: 10,
        shadowColor: '#000',
        shadowOffset: {width:0, height:2},
        shadowOpacity: 0.4,
        elevation: 2,
        position: 'relative'
    }
}
export { Header };