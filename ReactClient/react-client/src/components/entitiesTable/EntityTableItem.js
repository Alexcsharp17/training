import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import { Link } from "react-router-dom"

class EntityTableItem extends React.Component {
    render() {
        const { data: { Items, fields } } =this.props
        return (
            <div className="content" id="order_area">
                <h2>Dashboard</h2>
                <table className="table table-bordered table-striped">
                    <TableHead fields={fields} />
                    <TableBody Items={Items} />
                </table>
            </div>
        );
    }

}

class TableHead extends React.Component {
    render() {
        const { fields } = this.props
        return (
            <thead>
                <tr>
                    {
                        fields.map(function (field) {
                            return (
                                <td>{field}</td>
                            )
                        })
                    }
                    <td></td>
                </tr>
            </thead>
        );

    }
}

class TableBody extends React.Component {
    render() {
        const { Items } = this.props
        return (
            <tbody>
                {
                    Items.map(function (item) {
                        return (
                            <tr>
                                {
                                    Object.keys(item).map(function(key,index){
                                    return(<td>{item[key]}</td>)
                                    })
                                }
                                <td>
                                    <Link className="" to={'/editorder/' + item[Object.keys(item)[0]]}>
                                        <span className="btn btn-warning mr-1">Edit</span>
                                    </Link>
                                    <Link className="" to="/deleteorder">
                                        <span className="btn btn-danger">Delete</span>
                                    </Link>
                                </td>
                            </tr>
                        )
                    })
                }
            </tbody>
        );

    }
}

export default EntityTableItem;