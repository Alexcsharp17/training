import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';
import { setItemsCount } from '../../redux/actions';

class SectionItem extends React.Component {
  render(props) {
    props.dispatch(setItemsCount(null));
    return (
      <div className="card m-1 d-flex ">
        <div className="card-header text-primary">
          <h4 className="text-center ">{props.title}</h4>
        </div>
        <div className="card-body">
          <h5>
            {props.title}
            {' '}
            Managment
          </h5>
          <p className="card-text">
            Open this section to view the
            {props.title}
          </p>
          <Link className="" to={props.href}>
            <span className="btn btn-success">View</span>
          </Link>
        </div>
      </div>
    );
  }
}

const mapStateToProps = () => ({});
export default connect(mapStateToProps)(SectionItem);
