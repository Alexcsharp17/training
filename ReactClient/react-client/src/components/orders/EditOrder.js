import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import carsJson from '../../cars.json'
import { Link } from "react-router-dom"

import DatePicker from "react-datepicker";
 
import "react-datepicker/dist/react-datepicker.css";
const POST_URL=  "https://localhost:5001/api/order/addorder/";

class editOrderItem extends React.Component{
   
   constructor(props){
        super(props); 
        this.props=props;
       
        this.state={
            Order:{},
            errors:[],
            Persons:[]
    }
    this.handleChange = this.handleChange.bind(this);
        this.getOrder(this.props.match.params.id);
        this.getPersons();
    }
    async getPersons(callback) {
        const GET_URL = 'https://localhost:5001/api/person/getpersons';
        var Persons = [];
        await fetch(GET_URL)
          .then((response) => response.json())
          .then((data) => {
            Persons = data
          });
          this.setState({ Persons});
        return Persons
      }

    getSelectCarName(id){
        return carsJson.forEach(car =>{
            console.log("CAR NAME:",car.Name,"Car id",car.Id, "Seek id:",this.props.match.params.id);

            if(car.Id==this.props.match.params.id){
                return car.Name;
            }
        }) 
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
                 this.handleChange(this.state.CarID);
                
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
          this.setState({
              Order:data,
              CarID:data.CarID,
              PersonId:data.PersonId,
              OrderDate:data.OrderDate,
              OrderID:data.OrderID
            });
          })
          this.handleChange(this.state.CarID);
          this.handlePersonChange(this.state.PersonId);
        }
    }

    handleChange(id) {
        this.setState({
            selectedCar: id,
            CarID:id
        });

      }
    handlePersonChange(id){
        this.setState({
            selectedPerson:id,
            PersonId:id
        })
    }

    render(props){
        console.log(this.state.Order.PersonId);
        let errors =this.state.errors;
        let cars = carsJson;
        let Persons=this.state.Persons
        console.log("selected CAR", this.state.selectedCar);
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
                    <p>Car </p>
                    <select value={this.state.selectedCar} onChange={(event)=>this.handleChange(event.target.value)}>
                        {
                            cars.map(function(car){
                            return(<option value={car.Id}>{car.Name}</option>);
                            })
                        }
                    </select>
                </label>
                </div>
                <div className="form-group">
                <label>
                   <p> Order Date:</p>                 
                    <DatePicker selected={this.state.OrderDate==undefined?new Date():new Date(this.state.OrderDate)} onChange={(date)=>this.setState({OrderDate:date})} />
                </label>
                </div>
                <div className="form-group">
                <label>
                    <p>Person </p>
                    <select value={this.state.selectedPerson}  onChange={(event)=>this.handlePersonChange(event.target.value)}>
                        {
                            Persons.map(function(person){
                            return(<option value={person.PersonID}>{person.FirstName+" "+ person.LastName}</option>);
                            })
                        }
                    </select>
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