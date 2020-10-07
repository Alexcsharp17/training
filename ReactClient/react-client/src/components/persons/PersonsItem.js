import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import { Link } from "react-router-dom"
import EntityTableItem from '../entitiesTable/EntityTableItem.js'
import{ getPersons,getPersonsCount} from '../../dataProviders/ApiProvider.js'


class PersonItem extends React.Component {
  constructor() {
    super();
    this.state = { fetchData: "", fetchedItemsCoutn:"", CurrentPage:1,CurerentSort:"@PersonID" }
  }
  sortData=(page,sort)=>{
    if(page=="default" || page==undefined){
      page=this.state.CurrentPage
    }
    if(sort =="default"|| sort==undefined){
      sort=this.state.CurrentSort
    }
    getPersons(this.WriteFetchedData,page,sort)
  }

  WriteFetchedData=(Items,page,sort)=>{
    console.log("PAGE AT CALLBACK",page);
    this.setState({fetchData:"rendered", Items:Items,CurrentPage:page,CurrentSort:sort});
  }
  writeFetchedItemsCount=(number)=>{
    this.setState({fetchedItemsCoutn:"rendered",ItemsNumer:number})
  }
  render() {
    const fields = ["PersonId", "FirstName", "LastName", "Phone"]
    if(this.state.fetchedItemsCoutn==""){

      getPersonsCount(this.writeFetchedItemsCount)
    }
    if(this.state.fetchData=="" && this.state.fetchedItemsCoutn!=""){
       getPersons(this.WriteFetchedData,1);     
    }
    console.log("Log from render:", this.state.Items);
    const data = {
      Items: this.state.Items,
      fields: fields,
      title:"person"
    }
    if (this.state.fetchData != "" && this.state.fetchedItemsCoutn!="") {

      return (<EntityTableItem data={data} callback={this.sortData} 
        CurrentPage={this.state.CurrentPage} CurrentSort={this.state.CurerentSort}
        TotalPages={this.state.ItemsNumer % 5!=0? (this.state.ItemsNumer % 5)+1:this.state.ItemsNumer % 5 } />)
    }
    else {
      return(<div>NO data availible</div>);
    }
    
  }
  

}

export default PersonItem