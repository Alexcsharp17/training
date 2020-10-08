import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import carsJson from '../../cars.json'
import { Link } from "react-router-dom"
import{getOrder,addOrder,getAllPersons} from '../../dataProviders/ApiProvider.js'
import{CreateErrorSection, createErrorSection} from '../../util/ErrorSectionBuilder.js'
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";


class EditOrderItem extends React.Component{
   
   constructor(props){
        super(props); 
        this.props=props;      
        this.state={
            Order:{},
            errors:[],
            Persons:[],
            getPersonsState:"",
            getPersonsCountState:""
        }
        this.handleChange = this.handleChange.bind(this);
        getOrder(this.props.match.params.id,this.FetchRequestResponse);
       
    }
    
    getPersonsHandler=(persons)=>{
        this.setState({Persons:persons, getPersonsState:"rendered"})
    }
    getPersonsCountHandler=(count)=>{
        this.setState({PersonsCount:count,getPersonsCountState:"rendered"})
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
        
        console.log("CAR id",this.state.carID);
        if(!this.state.carID || this.state.carID==undefined){
            CarIDError="Invalid Car Id"
        }

        if(!this.state.personId || this.state.personId==undefined){
            PersonIDError="Invalid PersonID"
        }

        if(!this.state.orderDate || this.state.orderDate==undefined){
            OrderDateError="Invalid Order Date"
        }
        console.log(PersonIDError,CarIDError,OrderDateError);
        if(PersonIDError || CarIDError || OrderDateError){
            this.setState({CarIDError,PersonIDError,OrderDateError})
            return false
        }

        return true;
    }
    PostForm=( e) =>{
        e.preventDefault();
        console.log("LOG FROM POST FORM");
        let isValid = this.validate();
        console.log("isVALID:" ,isValid);
        if(isValid){
         let order={
            orderID:parseInt(this.state.orderID),
            orderDate:new Date(Date.parse(this.state.orderDate)),
            carID:parseInt(this.state.carID),             
            personId:parseInt(this.state.personId)
         }
        
             addOrder(order,this.AddOrderHandler);
        }
            
     };
    AddOrderHandler=(data)=>{
        if(data.errors!=null || data.errors!=undefined){
            console.log('This is your data', data);
        this.setState({errors:data.errors});
         }
         else{
            alert("Order succesfully changed");
             this.setState({errors:[]});
             this.handleChange(this.state.CarID);          
         }
    }

    FetchRequestResponse=(data)=>{
        this.setState({
              Order:data,
              carID:data.carID,
              personId:data.personId,
              orderDate:data.orderDate,
              orderID:data.orderID
        });
        console.log("Fetched data",this.state.Order);
    }
    
    handleChange(id) {
        this.setState({
            selectedCar: id,
            carID:id
        });

      }
    handlePersonChange(id){
        this.setState({
            selectedPerson:id,
            personId:id
        })
    }
    
    render(props){
        console.log("getPersonsCountState",this.state.getPersonsCountState);

        if(!this.state.getPersonsState){
            getAllPersons(this.getPersonsHandler)
        }
        const{errors}=this.state
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
                                   CreateErrorSection(errors[key])
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
                    <select  onChange={(event)=>this.handleChange(event.target.value)}>
                        {
                            carsJson.map((car)=>{
                                if(car.Id==this.state.carID){
                                    return(<option selected="selected" value={car.Id}>{car.Name}</option>);
                                }
                                else{
                                    return(<option value={car.Id}>{car.Name}</option>);
                                }           
                            })
                        }
                    </select>
                </label>
                </div>
                <div className="form-group">
                <label>
                   <p> Order Date:</p>                 
                    <DatePicker selected={this.state.orderDate==undefined?new Date():new Date(this.state.orderDate)} onChange={(date)=>this.setState({orderDate:date})} />
                </label>
                </div>
                <div className="form-group">
                <label>
                    <p>Person </p>
                    <select value={this.state.selectedPerson}  onChange={(event)=>this.handlePersonChange(event.target.value)}>
                        {
                            this.state.Persons.map((person)=>{
                                if(this.state.personId==person.personID){
                                    return(<option selected="selected" value={person.personID}>{person.firstName+" "+ person.lastName}</option>);
                                }
                                else{
                                    return(<option value={person.personID}>{person.firstName+" "+ person.lastName}</option>);
                                }
                            })
                        }
                    </select>
                </label>
                </div>
                <button onClick={this.PostForm} type="submit">Send</button>
            </form>
            </div>
        </div>
        </div>
        );
       
    }

}
export default EditOrderItem