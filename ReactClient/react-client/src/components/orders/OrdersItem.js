import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import { Link } from "react-router-dom"
import EntityTableItem from '../entitiesTable/EntityTableItem.js'
import{getOrdersCount} from '../../dataProviders/ApiProvider.js'
import { connect } from 'react-redux';
import {getOrdersAction} from '../../redux/actions.js'

class OrderItem extends React.Component {
  constructor() {
    super();
    this.state = { fetchData: "",fetchedItemsCount:"", CurrentPage:1, CurerentSort:"@PersonID" }
  }
  sortData=(page,sort)=>{
    if(page=="default" || page==undefined){
      page=this.props.Pagination.CurrentPage
    }
    if(sort =="default"|| sort==undefined){
      sort=this.props.Pagination.CurrentSort
    }
    this.props.dispatch(getOrdersAction(page,sort))
  }
  writeFetchedItemsCount=(number)=>{
    this.setState({fetchedItemsCount:"rendered",ItemsNumer:number})
  }
  writeFetchedData=(Items,page,sort)=>{
    this.setState({fetchData:"rendered", Items:Items,CurrentPage:page,CurrentSort:sort});
  }
  render() {
    const fields = ["OrderID", "OrderDate", "CarID", "PersonID"]
    if(!this.state.fetchedItemsCount){
      getOrdersCount(this.writeFetchedItemsCount)
    }
    console.log("Fethced data state :", this.state.fetchData)
    if(this.props.Persons==undefined  && this.state.fetchedItemsCount){
      this.props.dispatch(getOrdersAction(1))
    }
    console.log("Log from render:", this.state.Items);
        if (this.state.fetchData  && this.state.fetchedItemsCount) {
      const data = {
        Items: this.props.Orders,
        Pagination:this.props.Pagination,
        fields: fields,
        title:"order"
      }

      return (<EntityTableItem data={data} callback={this.sortData}
        CurrentPage={this.state.CurrentPage}  CurrentSort={this.state.CurerentSort}
        TotalPages={this.state.ItemsNumer % 5!=0? (Math.trunc(this.state.ItemsNumer / 5))+1:Math.trunc(this.state.ItemsNumer / 5) } />);
        
    }
    else {
      return(<div></div>);
    }
    
  }

}


const mapStateToProps = (state) => {
  return {
    Persons:state.Persons,
    Pagination:state.Pagination
  };
}

export default connect(mapStateToProps)(OrderItem)
