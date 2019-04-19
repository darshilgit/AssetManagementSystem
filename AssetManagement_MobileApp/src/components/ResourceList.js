import React, { Component } from 'react';
import { ScrollView, Text } from 'react-native';
import axios from 'axios';
import ResourceDetail from './ResourceDetail';

export default class ResourceList extends Component {
    state = { 
        resources: []
    };
    constructor(props) {
        super(props);
    }
    componentWillMount(){
        axios.get('https://sku1y8kfk4.execute-api.us-east-1.amazonaws.com/latest/getResources?id='+this.props.navigation.state.params.FacilityId)
             .then(recordset => this.setState({resources: recordset.data.recordset}));
    }
    renderResources() {
        return this.state.resources.map(resource => 
            <ResourceDetail key={resource.ResourceId} FacilityId = {this.props.navigation.state.params.FacilityId} resource={ resource } navigation={this.props.navigation}/>
        );
    }
    render(){
        console.log(this.state);
        console.log(this.props);
        return(
            <ScrollView>
                {this.renderResources()}
            </ScrollView>
        );
    }
}