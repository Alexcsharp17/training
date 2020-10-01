import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import { Link } from "react-router-dom"

class EntityTableItem extends React.Component {
    render() {
        const { data: { Items, fields, title } } = this.props
        return (
            <div className="content" id="order_area">
                <div className="alert"></div>
                <div><h2>Dashboard</h2></div>
                <div>
                    <Link className="" to={'/edit' + title + "/" + 0}>
                        <span className="btn btn-success mr-1">Add new</span>
                    </Link>
                </div>
                <table className="table table-bordered table-striped">
                    <TableHead fields={fields} title={title} />
                    <TableBody Items={Items} title={title} />
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
    constructor(props) {
        super(props);
        this.props = props
        this.state = { confirmDelete: false };
    }

    deleteItem(id, title) {
        if (window.confirm("Do you want to delete this item?")) {
            const apiUrl = 'https://localhost:5001/api/' + this.props.title + '/delete' + this.props.title + '?id=' + id;
            fetch(apiUrl, {
                method: 'DELETE'
            });

        }

    }
    render() {

        const { Items, title } = this.props
        return (
            <tbody>
                {
                    Items.map((item, title) => {
                        return (
                            <tr>
                                {
                                    Object.keys(item).map(function (key, index) {
                                        return (<td>{item[key]}</td>)
                                    })
                                }

                                <td>
                                    <Link className="" to={'/edit' + this.props.title + "/" + item[Object.keys(item)[0]]}>
                                        <span className="btn btn-warning mr-1">Edit</span>
                                    </Link>
                                    <button className="btn btn-primary" onClick={() => this.deleteItem(item[Object.keys(item)[0]], title)}>Delete</button>

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