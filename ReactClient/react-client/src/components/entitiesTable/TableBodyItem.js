import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import { deleteItem } from '../../dataProviders/ApiProvider.js'
import { Link } from "react-router-dom"

export class TableBody extends React.Component {

    constructor(props) {
        super(props);
        this.props = props
        this.state = {
            confirmDelete: false,
            iDError: ""
        };
    }

    FetchRequestHandler = (data) => {
        console.log(data);
        if (data.IdError) {
            this.setState({ IdError: "Can not delete person who has active records" })
            console.log("failed delete");
        }
        else {
            this.setState({ IdError: "" })
            console.log("sucess delete");
            console.log(data.IdError);
        }
    }

    render() {
        const { Items, title } = this.props
        console.log("ITEMS:", Items);

        if (this.state.IdError != "" && this.state.IdError) {
            alert(this.state.IdError);
        }

        if (title == "person") {
            return (
                <tbody>
                    {Items.map(function (item) {
                        return (
                            <tr>
                                <td>{item.personID}</td>
                                <td>{item.firstName}</td>
                                <td>{item.lastName}</td>
                                <td>{item.phone}</td>
                                <td>
                                    <Link className="" to={'/edit' + title + "/" + item[Object.keys(item)[0]]}>
                                        <span className="btn btn-warning mr-1">Edit</span>
                                    </Link>
                                    <button className="btn btn-primary" onClick=
                                    {() => deleteItem(item[Object.keys(item)[0]], title, this.fetchHandler)}>Delete</button>

                                </td>
                            </tr>
                        )
                    })}
                </tbody>
            )
        }
        else {
            return (
                <tbody>
                    {Items.map(function (item) {
                        return (
                            <tr>
                                <td>{item.orderID}</td>
                                <td>{item.orderDate}</td>
                                <td>{item.carID}</td>
                                <td>{item.personId}</td>
                                <td>
                                    <Link className="" to={'/edit' + title + "/" + item[Object.keys(item)[0]]}>
                                        <span className="btn btn-warning mr-1">Edit</span>
                                    </Link>
                                    <button className="btn btn-primary" onClick=
                                    {() => deleteItem(item[Object.keys(item)[0]], title, this.fetchHandler)}>Delete</button>
                                </td>
                            </tr>
                        )
                    })}
                </tbody>
            )
        }
    }
}
