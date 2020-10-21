import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import { Link } from 'react-router-dom';
import TableHead from './TableHeadItem';
import TableBody from './TableBodyItem';
import PageLinks from '../../util/PaginationBuilder';

export default class EntityTableItem extends React.Component {
  render() {
    const {
      data: {
        Items, fields, title, Pagination,
      }, callback, ItemsCount, TotalPages,
    } = this.props;
    return (
      <div className="content" id="order_area">
        <div className="alert" />
        <div className="bg-secondary text-white text-uppercase"><h2>{title}</h2></div>
        <div>
          <div className="float-left">
            <Link className="" to="/dashboard">
              <span className="btn btn-warning mr-1">Back to Dashboard</span>
            </Link>
          </div>
          <div className="float-right">
            <Link className="" to={`/edit${title}/${0}`}>
              <span className="btn btn-success mr-1">Add new</span>
            </Link>
          </div>
        </div>
        <table className="table table-bordered table-striped">
          <TableHead fields={fields} title={title} callback={callback} />
          <TableBody Items={Items} title={title} />
        </table>
        <PageLinks
          CurrentPage={Pagination.CurrentPage}
          ItemsCount={ItemsCount}
          TotalPages={TotalPages}
          callback={callback}
        />
      </div>
    );
  }
}
