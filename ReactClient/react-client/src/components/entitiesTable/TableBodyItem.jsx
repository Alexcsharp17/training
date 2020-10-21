import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import { Link } from 'react-router-dom';
import { deleteItem } from '../../dataProviders/ApiProvider';

export default class TableBody extends React.Component {
  constructor(props) {
    super(props);
    this.props = props;
  }

  render() {
    const { Items, title } = this.props;
    console.log('ITEMS:', Items);

    if (this.state.IdError !== '' && this.state.IdError) {
      alert(this.state.IdError);
    }

    if (title === 'person') {
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
                  <Link className="" to={`/edit${title}/${item[Object.keys(item)[0]]}`}>
                    <span className="btn btn-warning mr-1">Edit</span>
                  </Link>
                  <button
                    className="btn btn-primary"
                    type="button"
                    onClick={() => deleteItem(item[Object.keys(item)[0]], title, this.fetchHandler)}
                  >
                    Delete
                  </button>

                </td>
              </tr>
            );
          })}
        </tbody>
      );
    }

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
                <Link className="" to={`/edit${title}/${item[Object.keys(item)[0]]}`}>
                  <span className="btn btn-warning mr-1">Edit</span>
                </Link>
                <button
                  className="btn btn-primary"
                  type="button"
                  onClick={() => deleteItem(item[Object.keys(item)[0]], title, this.fetchHandler)}
                >
                  Delete
                </button>
              </td>
            </tr>
          );
        })}
      </tbody>
    );
  }
}
