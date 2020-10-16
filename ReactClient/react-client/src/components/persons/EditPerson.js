import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import { Link, Redirect } from "react-router-dom"
import { getPerson, addPerson } from '../../dataProviders/ApiProvider.js'
import { addPersonAction, getPersonAction, setCurrentPerson } from '../../redux/actions.js'
import { connect } from 'react-redux';


class editPersonItem extends React.Component {

    constructor(props) {
        super(props);
        this.props = props;
        this.state = {
            Person: {},
            errors: []
        }
    }

    validate = () => {
        let FirstNameError = "";
        let LastNameError = "";
        let PhoneError = "";

        if (!this.props.CurrentPerson.FirstName) {
            FirstNameError = "Invalid First Name"
        }

        if (!this.props.CurrentPerson.LastName) {
            FirstNameError = "Invalid Last Name"
        }

        if (!this.props.CurrentPerson.Phone) {
            PhoneError = "Invalid Phone number"
        }

        if (PhoneError || FirstNameError || LastNameError) {
            this.setState({ PhoneError, LastNameError, FirstNameError })
            return false
        }

        return true;
    }

    PostForm = e => {
        e.preventDefault();
        let isValid = this.validate();
        if (isValid) {
            this.props.dispatch(addPersonAction(this.props.CurrentPerson));
        }
    }

    render() {
        let errors = this.state.errors;
        console.log("CurrentPers", this.props.CurrentPerson)
        if (!this.props.CurrentPerson) {
            this.props.dispatch(getPersonAction(this.props.match.params.id))
        }
        if (this.props.CurrentPerson) {
            return (
                <div className="mt-2 row">
                    <div className="col-2 offset-5 card border-rounded p-2">
                        <div className="bg-secondary"><h3 className="text-white">Edit Person</h3></div>
                        <div className="p-2 d-flex flex-row-start">
                            <form className="form"  >
                                <div>
                                    {
                                        Object.keys(errors).map(function (key) {
                                            return (
                                                <div>
                                                    {
                                                        errors[key].map(function (e) {
                                                            return (<p className="text-danger">{e}</p>)
                                                        })
                                                    }
                                                </div>
                                            );

                                        })
                                    }
                                </div>
                                <div className="form-group ">
                                    <label className="col-form-label">
                                        <p> Person id:</p>
                                    </label>
                                    <input type="text" disabled={true} className="form-control" name="PersonID"
                                        defaultValue={this.props.CurrentPerson.PersonID} />
                                </div>
                                <div className="form-group">
                                    <label>
                                        <span>First Name:</span>
                                        <input type="text" placeholder="Input first name" className="form-control" name="FirstName"
                                            defaultValue={this.props.CurrentPerson.FirstName}
                                            onChange={event => this.props.dispatch(setCurrentPerson(
                                                {
                                                    PersonID: this.props.CurrentPerson.PersonID,
                                                    FirstName: event.target.value,
                                                    LastName: this.props.CurrentPerson.LastName,
                                                    Phone: this.props.CurrentPerson.Phone
                                                }))} />
                                        <div style={{ fontSize: 12, color: "red" }}>
                                            {this.state.FirstNameError}
                                        </div>
                                    </label>
                                </div>
                                <div className="form-group">
                                    <label>
                                        Last Name:
                            <input type="text" placeholder="Input last name" className="form-control"
                                            name="LastName" defaultValue={this.props.CurrentPerson.LastName}
                                            onChange={event => this.props.dispatch(setCurrentPerson(
                                                {
                                                    PersonID: this.props.CurrentPerson.PersonID,
                                                    FirstName: this.props.CurrentPerson.FirstName,
                                                    LastName: event.target.value,
                                                    Phone: this.props.CurrentPerson.Phone
                                                }))} />
                                        <div style={{ fontSize: 12, color: "red" }}>
                                            {this.state.LastNameError}
                                        </div>
                                    </label>
                                </div>
                                <div className="form-group">
                                    <label>
                                        Phone:
                            <input type="text" placeholder="Input phone number" className="form-control" name="Phone"
                                            defaultValue={this.props.CurrentPerson.Phone}
                                            onChange={event => this.props.dispatch(setCurrentPerson(
                                                {
                                                    PersonID: this.props.CurrentPerson.PersonID,
                                                    FirstName: this.props.CurrentPerson.FirstName,
                                                    LastName: this.props.CurrentPerson.LastName,
                                                    Phone: event.target.value
                                                }))} />
                                        <div style={{ fontSize: 12, color: "red" }}>
                                            {this.state.PhoneError}
                                        </div>
                                    </label>
                                </div>
                                <button onClick={this.PostForm} type="submit" className="btn btn-primary">Send</button>
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

const mapStateToProps = (state) => {
    return {
        CurrentPerson: state.CurrentPerson
    }
}

export default connect(mapStateToProps)(editPersonItem)