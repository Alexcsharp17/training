import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import carsJson from '../../cars.json'
import { Link } from "react-router-dom"
import { getOrder, addOrder, findPersons, getPerson } from '../../dataProviders/ApiProvider.js'
import { CreateErrorSection, createErrorSection } from '../../util/ErrorSectionBuilder.js'
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import closeIcon from './close.png';


class EditOrderItem extends React.Component {

    constructor(props) {
        super(props);
        this.props = props;
        this.state = {
            Order: {},
            errors: [],
            Persons: [],
            findPersonsState: "",
            getPersonState: "",
            getPersonsCountState: "",
            getOrderState: "",
            showSearchState: "d-none"

        }
        this.handleChange = this.handleChange.bind(this);

    }

    findPersonsHandler = (persons) => {
        this.setState({ Persons: persons, findPersonsState: "rendered" })
    }
    getPersonsCountHandler = (count) => {
        this.setState({ PersonsCount: count, getPersonsCountState: "rendered" })
    }
    fetchPersonHandler = (person) => {
        this.setState({ CurrentName: person.FirstName + " " + person.LastName, getPersonState: "rendered" })
    }

    getSelectCarName(id) {
        return carsJson.forEach(car => {
            console.log("CAR NAME:", car.Name, "Car id", car.Id, "Seek id:", this.props.match.params.id);
            if (car.Id == this.props.match.params.id) {
                return car.Name;
            }
        })
    }
    validate = () => {
        let CarIDError = "";
        let PersonIDError = "";
        let OrderDateError = "";

        console.log("CAR id", this.state.carID);
        if (!this.state.carID || this.state.carID == undefined) {
            CarIDError = "Invalid Car Id"
        }

        if (!this.state.personId || this.state.personId == undefined) {
            PersonIDError = "Invalid PersonID"
        }

        if (!this.state.orderDate || this.state.orderDate == undefined) {
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
        console.log("LOG FROM POST FORM");
        let isValid = this.validate();
        console.log("isVALID:", isValid, "ORDER ID", this.state.orderID);

        if (isValid) {
            let order = {
                OrderID: parseInt(this.state.orderID),
                orderDate: new Date(Date.parse(this.state.orderDate)),
                carID: parseInt(this.state.carID),
                personId: parseInt(this.state.personId)
            }

            addOrder(order, this.AddOrderHandler);
        }

    };
    AddOrderHandler = (data) => {
        if (data.errors != null || data.errors != undefined) {
            console.log('This is your data', data);
            this.setState({ errors: data.errors });
        }
        else {
            alert("Order succesfully changed");
            this.setState({ errors: [] });
            this.handleChange(this.state.CarID);
        }
    }

    FetchRequestResponse = (data) => {
        this.setState({
            Order: data,
            carID: data.carID,
            personId: data.personId,
            orderDate: data.orderDate,
            orderID: data.orderID,
            getOrderState: "rendered"

        });
        console.log("Fetched data", this.state.Order);
    }

    handleChange(id) {
        this.setState({
            selectedCar: id,
            carID: id
        });

    }
    handlePersonChange(id, name) {
        this.setState({
            selectedPerson: id,
            personId: id,
            CurrentName: name
        })
    }

    render(props) {
        console.log("final check:",);

        console.log("getOrderState:", this.state.getOrderState, "getPersonState:", this.state.getPersonState, "findPersonsState", this.state.findPersonsState);
        if (!this.state.getOrderState) {
            getOrder(this.props.match.params.id, this.FetchRequestResponse);
        }
        if (!this.state.getPersonState && this.state.getOrderState) {
            getPerson(this.state.personId, this.fetchPersonHandler)
        }
        if (!this.state.findPersonsState && this.state.getPersonState && this.state.getOrderState) {
            findPersons(this.findPersonsHandler, this.state.CurrentName)
        }
        const { errors } = this.state
        if (this.state.findPersonsState && this.state.getPersonState && this.state.getOrderState) {
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
                                        defaultValue={this.props.match.params.id} onChange={event => this.setState({ OrderID: event.target.value })} />
                                    <div style={{ fontSize: 12, color: "red" }}>
                                        {this.state.OrderIDError}
                                    </div>
                                </div>
                                <div className="form-group">
                                    <p>Select person</p>
                                    <div className="d-flex flex-row flex-nowrap">
                                        <input type="text" value={this.state.CurrentName} className="form-control" onClick={() => this.setState({ showSearchState: "d-block" })}
                                            onChange={(event) => { this.setState({ CurrentName: event.target.value }); findPersons(this.findPersonsHandler, event.target.value) }} />
                                        <img src={closeIcon} alt="X" className={"mb-1 ml-2 " + this.state.showSearchState} onClick={() => this.setState({ showSearchState: "d-none" })} />
                                    </div>

                                    <div className={"overflow-auto " + this.state.showSearchState} style={{ height: '150px', width: "200px", position: "absolute", left: "40px" }}>
                                        {
                                            this.state.Persons.map((person) => {
                                                return (<button type="button" value={person.personID} className="btn d-block btn-secondary w-100"
                                                    onClick={(event) => this.handlePersonChange(event.target.value, person.firstName + " " + person.lastName)}
                                                >{person.firstName + " " + person.lastName}</button>);
                                            })
                                        }
                                    </div>
                                </div>
                                <div className="form-group">
                                    <p>Car </p>
                                    <select onChange={(event) => this.handleChange(event.target.value)} className="form-control" >
                                        {
                                            carsJson.map((car) => {
                                                if (car.Id == this.state.carID) {
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
                                    <DatePicker selected={this.state.orderDate == undefined ? new Date() : new Date(this.state.orderDate)}
                                        onChange={(date) => this.setState({ orderDate: date })} className="form-control" />
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
export default EditOrderItem