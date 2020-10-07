import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import { Link } from "react-router-dom"
import EntityTableItem from '../entitiesTable/EntityTableItem.js'
import{getOrders,getOrdersCount} from '../../dataProviders/ApiProvider.js'


class OrderItem extends React.Component {
  constructor() {
    super();
    this.state = { fetchData: "",fetchedItemsCoutn:"", CurrentPage:1, CurerentSort:"@PersonID" }
  }
  sortData=(page,sort)=>{
    if(page=="default" || page==undefined){
      page=this.state.CurrentPage
    }
    if(sort =="default"|| sort==undefined){
      sort=this.state.CurrentSort
    }
    getOrders(this.WriteFetchedData,page,sort)
  }
  writeFetchedItemsCount=(number)=>{
    this.setState({fetchedItemsCoutn:"rendered",ItemsNumer:number})
  }
  WriteFetchedData=(Items,page,sort)=>{
    this.setState({fetchData:"rendered", Items:Items,CurrentPage:page,CurrentSort:sort});
  }
  render() {
    const fields = ["OrderID", "OrderDate", "CarID", "PersonID"]
    if(this.state.fetchedItemsCoutn==""){
      getOrdersCount(this.writeFetchedItemsCount)
    }
    console.log("Fethced data state :", this.state.fetchData)
    if(this.state.fetchData=="" && this.state.fetchedItemsCoutn!=""){
      getOrders(this.WriteFetchedData,1);
    }
    console.log("Log from render:", this.state.Items);
    const data = {
      Items: this.state.Items,
      fields: fields,
      title:"order"
    }
    if (this.state.fetchData != ""   && this.state.fetchedItemsCoutn!="") {
      
      return (<EntityTableItem data={data} callback={this.sortData}
        CurrentPage={this.state.CurrentPage}  CurrentSort={this.state.CurerentSort}
        TotalPages={this.state.ItemsNumer % 5!=0? (Math.trunc(this.state.ItemsNumer / 5))+1:Math.trunc(this.state.ItemsNumer / 5) } />);
        
    }
    else {
      return(<div></div>);
    }
    
  }
  async getOrders(callback) {
    const GET_URL = 'https://localhost:5001/api/order/getorders';
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

export default OrderItem