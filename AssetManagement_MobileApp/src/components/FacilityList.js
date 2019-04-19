import React, { Component } from 'react';
import { ScrollView } from 'react-native';
import axios from 'axios';
import FacilityDetail from './FacilityDetail';

export default class FacilityList extends Component {
    state = { facilities: []};
    constructor(props) {
        super(props);
    }
    componentWillMount(){
        axios.get('https://sku1y8kfk4.execute-api.us-east-1.amazonaws.com/latest/getFacilities?id='+this.props.Id)
             .then(recordset => this.setState({facilities: recordset.data.recordset}))
    }

    renderFacilities() {
        return this.state.facilities.map(facility => 
            <FacilityDetail key={facility.FacilityId} facility={ facility } navigation={this.props.navigation}/>
        );
    }

    render() {
        return (
            <ScrollView>
                {this.renderFacilities()}
            </ScrollView>
        );
    }
};

