import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import { Link } from "react-router-dom"
import EntityTableItem from '../entitiesTable/EntityTableItem.js'
import{ getPersons} from '../../dataProviders/ApiProvider.js'


class PersonItem extends React.Component {
  constructor() {
    super();
    this.state = { fetchData: "" }
  }
  WriteFetchedData=(Items)=>{
    this.setState({fetchData:"rendered", Items:Items});
  }
  render() {
    const fields = ["PersonId", "FirstName", "LastName", "Phone"]
    if(this.state.fetchData==""){
       getPersons(this.WriteFetchedData);     
    }
    console.log("Log from render:", this.state.Items);
    const data = {
      Items: this.state.Items,
      fields: fields,
      title:"person"
    }
    if (this.state.fetchData != "") {
      
      return (<EntityTableItem data={data} />)
    }
    else {
      return(<div></div>);
    }
    
  }
  

}

export default PersonItem