import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import { Link } from "react-router-dom"
import EntityTableItem from '../entitiesTable/EntityTableItem.js'


class PersonItem extends React.Component {
  constructor() {
    super();
    this.state = { fetchData: "" }
  }
  render() {
    const fields = ["PersonId", "FirstName", "LastName", "Phone"]
    if(this.state.fetchData==""){
      this.getOrders()
    }
    console.log("Log from render:", this.state.Items);
    const data = {
      Items: this.state.Items,
      fields: fields
    }
    if (this.state.fetchData != "") {
      
      return (<EntityTableItem data={data} />)
    }
    else {
      return(<div></div>);
    }
    
  }
  async getOrders(callback) {
    const GET_URL = 'https://localhost:5001/api/person/getpersons';
    var Items = [];
    await fetch(GET_URL)
      .then((response) => response.json())
      .then((data) => {
        Items = data
      });
      this.setState({fetchData:"rendered", Items:Items});
    return Items
  }

}

export default PersonItem