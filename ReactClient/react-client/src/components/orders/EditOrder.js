import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import carsJson from '../../cars.json'
import { Link } from "react-router-dom"
import { getOrder, addOrder, findPersons, getPerson } from '../../dataProviders/ApiProvider.js'
import { CreateErrorSection, createErrorSection } from '../../util/ErrorSectionBuilder.js'
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import closeIcon from './close.png';
import { connect } from 'react-redux';
import{addOrderAction, getOrderAction,setCurrentOrder,getPersonAction,findPersonsAction} from'../../redux/actions.js'



class EditOrderItem extends React.Component {

    constructor(props) {
        super(props);
        this.props = props;
        this.state = {
            errors: [],
            Persons: [],
            showSearchState: "d-none",
        }
    }

    validate = () => {
        let CarIDError = "";
        let PersonIDError = "";
        let OrderDateError = "";
        if (this.props.CurrentOrder.carID==null|| this.props.CurrentOrder.carID==undefined) {
            CarIDError = "Invalid Car Id"
        }
        if (this.props.CurrentOrder.personId==null || this.props.CurrentOrder.personId==undefined) {
            PersonIDError = "Invalid PersonID"
        }

        if (this.props.CurrentOrder.orderDate==null || this.props.CurrentOrder.orderDate == undefined) {
            OrderDateError = "Invalid Order Date"
        }
        console.log(PersonIDError, CarIDError, OrderDateError);
        if (PersonIDError || CarIDError || OrderDateError) {
            this.setState({ CarIDError, PersonIDError, OrderDateError })
            return false
        }

        return true;
    }
    PostForm = (e) => {
        e.preventDefault();
        let isValid = this.validate();
        if (isValid) {
            this.props.dispatch(addOrderAction(this.props.CurrentOrder))
        }

    };
 

    render() {
    
        console.log("getOrderState:", this.props.CurrentOrder, "getPersonState:", this.props.CurrentPerson, "findPersonsState", this.props.Persons);
        if (this.props.CurrentOrder==undefined) {
           this.props.dispatch(getOrderAction(this.props.match.params.id));
        }
        if (this.props.CurrentPerson==undefined && this.props.CurrentOrder!=undefined) {
            
           this.props.dispatch(getPersonAction(this.props.CurrentOrder.personId));
        }
        if (this.props.Persons==undefined && this.props.CurrentPerson!=undefined && this.props.CurrentOrder!=undefined) {
           this.props.dispatch(findPersonsAction (this.state.CurrentName));
        }
        const { errors } = this.state
        if (this.props.Persons!=undefined && this.props.CurrentPerson!=undefined && this.props.CurrentOrder!=undefined) {
            return (
                <div className="mt-2 row">
                    <div className="col-2 offset-5 card border-rounded p-2">
                        <div className="bg-secondary"><h3 className="text-white">Edit order</h3></div>
                        <div className="p-2 d-flex justify-content-center">
                            <form className="form">
                                <div>
                                    {
                                        Object.keys(errors).map(function (key) {
                                            return (
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
                                    <input type="text" className="form-control" name="OrderID" disabled
                                        defaultValue={this.props.CurrentOrder.orderID} onChange={event => this.setState({ OrderID: event.target.value })} />
                                    <div style={{ fontSize: 12, color: "red" }}>
                                        {this.state.OrderIDError}
                                    </div>
                                </div>
                                <div className="form-group">
                                    <p>Select person</p>
                                    <div className="d-flex flex-row flex-nowrap">
                                        <input type="text"  value={this.state.CurrentName==undefined?this.props.CurrentPerson.FirstName+' '+this.props.CurrentPerson.LastName:this.state.CurrentName} 
                                        className="form-control" onClick={() => this.setState({ showSearchState: "d-block" })}
                                            onChange={(event) => { this.setState({ CurrentName: event.target.value });
                                            this.props.dispatch(findPersonsAction( event.target.value)) }} />
                                        <img src={closeIcon} alt="X" className={"mb-1 ml-2 " + this.state.showSearchState} onClick={() => this.setState({ showSearchState: "d-none" })} />
                                    </div>

                                    <div className={"overflow-auto " + this.state.showSearchState} style={{ height: '150px', width: "200px", position: "absolute", left: "40px" }}>
                                        {
                                            this.props.Persons.map((person) => {
                                                return (<button type="button" value={person.personID} className="btn d-block btn-secondary w-100"
                                                onClick={(event) =>{this.props.dispatch(setCurrentOrder({
                                                    orderID:this.props.CurrentOrder.orderID,
                                                    carID:this.props.CurrentOrder.carId,
                                                    personId:event.target.value,
                                                    orderDate:this.props.CurrentOrder.orderDate
                                                })); this.setState({CurrentName:person.firstName + " " + person.lastName})}}
                                                >{person.firstName + " " + person.lastName}</button>);
                                            })
                                        }
                                    </div>
                                </div>
                                <div className="form-group">
                                    <p>Car </p>
                                    <select onClick={(event) =>{
                                    this.props.dispatch(setCurrentOrder({
                                            orderID:this.props.CurrentOrder.orderID,
                                            carID:event.target.value,
                                            personId:this.props.CurrentOrder.personId,
                                            orderDate:this.props.CurrentOrder.orderDate
                                    }))} 
                                    } className="form-control" >
                                        {
                                            carsJson.map((car) => {
                                                if (car.Id == this.props.CurrentOrder.carID) {
                                                    return (<option selected="selected" value={car.Id}>{car.Name}</option>);
                                                }
                                                else {
                                                    return (<option value={car.Id}>{car.Name}</option>);
                                                }
                                            })
                                        }
                                    </select>
                                </div>
                                <div className="form-group">
                                    <p> Order Date:</p>
                                    <DatePicker selected={this.props.CurrentOrder.orderDate == undefined ? new Date() : new Date(this.props.CurrentOrder.orderDate)}
                                        onChange={(date) =>this.props.dispatch(setCurrentOrder({
                                            orderID:this.props.CurrentOrder.orderID,
                                            carID:this.props.CurrentOrder.carID,
                                            personId:this.props.CurrentOrder.personId,
                                            orderDate:date
                                        }))} className="form-control" />
                                </div>

                                <button onClick={this.PostForm} className="btn btn-outline-primary" type="submit">Send</button>
                            </form>
                        </div>
                    </div>
                </div>
            );
        }
        else {
            return (<div>Loading...</div>)
        }


    }

}
const mapStateToProps=(state)=>{
    return{
        CurrentOrder:state.CurrentOrder,
        CurrentPerson:state.CurrentPerson,
        Persons:state.Persons
    }
}
export default connect(mapStateToProps)(EditOrderItem) 