import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import { Link } from "react-router-dom"

const POST_URL=  "https://localhost:5001/api/order/addorder/";

class editOrderItem extends React.Component{
   
   constructor(props){
        super(props); 
        this.props=props;
        this.state={
            Order:{},
            errors:[]
    }
        this.getOrder(this.props.match.params.id);
    }
    validate=()=>{
        let CarIDError="";
        let PersonIDError="";
        let OrderDateError="";
       
        if(this.state.CarID=="" || this.state.CarID==undefined){
            CarIDError="Invalid Car Id"
        }

        if(this.state.PersonId=="" || this.state.PersonId==undefined){
            PersonIDError="Invalid PersonID"
        }

        if(this.state.OrderDate=="" || this.state.OrderDate==undefined){
            OrderDateError="Invalid Order Date"
        }

        if(PersonIDError || CarIDError || OrderDateError){
            this.setState({CarIDError,PersonIDError,OrderDateError})
            return false
        }

        return true;
    }
    PostForm= e =>{
        e.preventDefault();
        let isValid = this.validate();
        if(isValid){
         const res =  fetch(POST_URL,{
             method:'POST',
             headers: {
                 'Content-Type': 'application/json'
             },
             body: JSON.stringify({
                 OrderID:parseInt(this.state.OrderID),
                 OrderDate:new Date(Date.parse(this.state.OrderDate)),
                 CarID:parseInt(this.state.CarID),             
                 PersonId:parseInt(this.state.PersonId)
             })
         }).then((response) => response.json())
         .then((data) =>{ 
             if(data.errors!=null || data.errors!=undefined){
                console.log('This is your data', data);
            this.setState({errors:data.errors});
             }
             else{
                alert("Order succesfully changed");
                 this.setState({errors:[]});
                
             }
             
            });

        }
        
        
     };

   async getOrder(id){
    if(id !="" &&  id!=undefined,id!=0){
    const apiUrl = "https://localhost:5001/api/order/getorder?id="+this.props.match.params.id;
        await fetch(apiUrl)
        .then((response) => response.json())
        .then((data) =>{
          this.setState({Order:data});
          this.setState({CarID:data.CarID});
          this.setState({PersonId:data.PersonId});
          this.setState({OrderDate:data.OrderDate});
          this.setState({OrderID:data.OrderID});
          })
        }
    }

    render(props){
        console.log(this.state.Order.PersonId);
        let errors =this.state.errors;
        return( 
            
        <div className="mt-2 row">
        <div className="col-3 offset-4 card border-rounded p-2">
            <div className="bg-secondary"><h3 className="text-white">Edit order</h3></div>
            <div className="p-2 d-flex flex-row-start">           
            <form className="form">  
            <div>
                   {
                       
                      Object.keys(errors).map(function(key){
                          return(
                            <div>
                                {
                                    errors[key].map(function(e){
                                    return(<p className="text-danger">{e}</p>)
                                    })
                                }
                            </div>
                          );
                          
                      })
                   }
                </div>        
                <div className="form-group ">  
                <label className="col-form-label">                                
                <p> Order id:</p> 
                </label>
                <input type="text" className="form-control"  name="OrderID" 
                defaultValue={this.props.match.params.id} onChange={event=>this.setState({OrderID:event.target.value})} />
                    <div style={{fontSize:12,color:"red"}}>
                        {this.state.OrderIDError}
                    </div>
                </div>
                <div className="form-group">
                <label>
                    <span>Car id:</span>
                    <input type="text" className="form-control"  name="CarID"
                     defaultValue={this.state.Order.CarID} onChange={event=>this.setState({CarID:event.target.value})}/>
                    <div style={{fontSize:12,color:"red"}}>
                        {this.state.CarIDError}
                    </div>
                </label>
                </div>
                <div className="form-group">
                <label>
                    Order Date:
                    <input type="datetime" className="form-control"  name="OrderDate" 
                    defaultValue={this.state.Order.OrderDate} onChange={event=>this.setState({OrderDate:event.target.value})}/>
                    <div style={{fontSize:12,color:"red"}}>
                        {this.state.OrderDateError}
                    </div>
                </label>
                </div>
                <div className="form-group">
                <label>
                    Person Id:
                    <input type="text" className="form-control"  name="PersonId"
                     defaultValue={this.state.Order.PersonId} onChange={event=>this.setState({PersonId:event.target.value})}/>
                    <div style={{fontSize:12,color:"red"}}>
                        {this.state.PersonIDError}
                    </div>
                </label>
                </div>
                <input type="submit" onClick={this.PostForm} value="Send" />
            </form>
            </div>
        </div>
        </div>
        );
       
    }

}
export default editOrderItem