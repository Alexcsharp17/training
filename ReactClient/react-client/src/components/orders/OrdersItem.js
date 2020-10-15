import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import EntityTableItem from '../entitiesTable/EntityTableItem.js'
import { connect } from 'react-redux';
import {getOrdersAction,getOrdersCountAction} from '../../redux/actions.js'

class OrdersListItem extends React.Component {
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
 
  render() {
    const fields = ["OrderID", "OrderDate", "CarID", "PersonID"]
    if(!this.props.ItemsCount){
      this.props.dispatch(getOrdersCountAction());
    }
    if(!this.props.Orders  && this.props.ItemsCount){
      this.props.dispatch(getOrdersAction(1))
    }
    if (this.props.Orders  && this.props.ItemsCount) {
      const data = {
        Items: this.props.Orders,
        Pagination:this.props.Pagination,
        fields: fields,
        title:"order"
      }

      return (<EntityTableItem data={data} callback={this.sortData} 
        CurrentPage={this.state.CurrentPage}  CurrentSort={this.state.CurerentSort}
        TotalPages={this.props.ItemsCount % 5!=0? (Math.trunc(this.props.ItemsCount / 5))+1:Math.trunc(this.props.ItemsCount / 5) } />);
        
    }
    else {
      return(<div>Loading</div>);
    }
    
  }

}


const mapStateToProps = (state) => {
  return {
    Orders:state.Orders,
    Pagination:state.Pagination,
    ItemsCount:state.ItemsCount
  };
}

export default connect(mapStateToProps)(OrdersListItem)
