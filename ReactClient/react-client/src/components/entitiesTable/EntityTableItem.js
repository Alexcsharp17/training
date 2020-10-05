import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import { Link } from "react-router-dom"
import {TableHead} from '../entitiesTable/TableHeadItem.js';
import {TableBody} from '../entitiesTable/TableBodyItem.js';

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

export default EntityTableItem;