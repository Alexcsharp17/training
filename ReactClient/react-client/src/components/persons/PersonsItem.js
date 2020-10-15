import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import { Link } from "react-router-dom"
import EntityTableItem from '../entitiesTable/EntityTableItem.js'
import{ getPersonsCount} from '../../dataProviders/ApiProvider.js'
import {getPersonsAction,getPersonsCountAction} from '../../redux/actions.js'
import { connect } from 'react-redux';


class PersonsListItem extends React.Component {
  constructor() {
    super();
    this.state = { CurrentPage:1,CurerentSort:"@PersonID" }
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



  render() {
    const fields = ["PersonId", "FirstName", "LastName", "Phone"]
    if(!this.props.ItemsCount ){
      this.props.dispatch(getPersonsCountAction())
    }
    if(!this.props.Persons && this.props.ItemsCount){
    
       this.props.dispatch(getPersonsAction(1))     
    }
    const data = {
      Items: this.props.Persons,
      Pagination:this.props.Pagination,
      fields: fields,
      title:"person"
    }
    let totPages= this.props.ItemsCount % 5!=0? (this.props.ItemsCount % 5)+1:this.props.ItemsCount % 5 
   console.log("Total pages",totPages);
    if (this.props.Persons!=undefined && this.props.ItemsCount!=undefined) {
      return (<EntityTableItem data={data} callback={this.sortData} 
        CurrentPage={this.state.CurrentPage} CurrentSort={this.state.CurerentSort}
        TotalPages={totPages} />)
    }
    else {
      return(<div class="spinner-border" role="status">
      <span class="sr-only">Loading...</span>
    </div>);
    }
    
  }
  

}

const mapStateToProps = (state) => {
  return {
    Persons:state.Persons,
    Pagination:state.Pagination,
    ItemsCount:state.ItemsCount
  };
}

export default connect(mapStateToProps)(PersonsListItem) 