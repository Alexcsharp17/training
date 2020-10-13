import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import { Link } from "react-router-dom"
import { TableHead } from '../entitiesTable/TableHeadItem.js';
import { TableBody } from '../entitiesTable/TableBodyItem.js';
import { PageLinks } from '../../util/PaginationBuilder.js'

class EntityTableItem extends React.Component {
    constructor(props) {
        super(props)
        this.state = { CurrentPage: this.props.CurrentPage }
    }
    render() {
        const { data: { Items, fields, title,Pagination}, callback, CurrentPage, TotalPages } = this.props
        return (
            <div className="content" id="order_area">
                <div className="alert"></div>
                <div className="bg-secondary text-white text-uppercase"><h2>{title}</h2></div>
                <div>
                    <div className="float-left">
                        <Link className="" to={'/dashboard'}>
                            <span className="btn btn-warning mr-1">Back to Dashboard</span>
                        </Link>
                    </div>
                    <div className="float-right">
                        <Link className="" to={'/edit' + title + "/" + 0}>
                            <span className="btn btn-success mr-1">Add new</span>
                        </Link>
                    </div>

                </div>
                <table className="table table-bordered table-striped">
                    <TableHead fields={fields} title={title} callback={callback} />
                    <TableBody Items={Items} title={title} />
                </table>
                <PageLinks CurrentPage={Pagination.CurrentPage} TotalPages={TotalPages} callback={callback} />
            </div>
        );
    }

}

export default EntityTableItem;