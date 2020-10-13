import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import { Link } from "react-router-dom"
import EntityTableItem from '../entitiesTable/EntityTableItem.js'
import{ getPersonsCount} from '../../dataProviders/ApiProvider.js'
import {getPersonsAction} from '../../redux/actions.js'
import { connect } from 'react-redux';


class PersonItem extends React.Component {
  constructor() {
    super();
    this.state = { fetchData: "", fetchedItemsCount:"", CurrentPage:1,CurerentSort:"@PersonID" }
  }
  sortData=(page,sort)=>{
    if(page=="default" || page==undefined){
      page=this.props.Pagination.CurrentPage
    }
    if(sort =="default"|| sort==undefined){
      sort=this.props.Pagination.CurrentSort
    }
    this.props.dispatch(getPersonsAction(page,sort))     
  }


  writeFetchedItemsCount=(number)=>{
    this.setState({fetchedItemsCount:"rendered",ItemsNumer:number})
  }
  render() {
    const fields = ["PersonId", "FirstName", "LastName", "Phone"]
    if(!this.state.fetchedItemsCount){

      getPersonsCount(this.writeFetchedItemsCount)
    }
    if(this.props.Persons==undefined && this.state.fetchedItemsCount){
    
       this.props.dispatch(getPersonsAction(1))     
    }
    console.log("Log from render:", this.props.Persons);
    const data = {
      Items: this.props.Persons,
      Pagination:this.props.Pagination,
      fields: fields,
      title:"person"
    }
    if (this.props.Persons!=undefined && this.state.fetchedItemsCount!="") {
      return (<EntityTableItem data={data} callback={this.sortData} 
        CurrentPage={this.state.CurrentPage} CurrentSort={this.state.CurerentSort}
        TotalPages={this.state.ItemsNumer % 5!=0? (this.state.ItemsNumer % 5)+1:this.state.ItemsNumer % 5 } />)
    }
    else {
      console.log("Log from render:", this.props.Persons);
      return(<div>NO data availible</div>);
    }
    
  }
  

}

const mapStateToProps = (state) => {
  return {
    Persons:state.Persons,
    Pagination:state.Pagination
  };
}

export default connect(mapStateToProps)(PersonItem) 