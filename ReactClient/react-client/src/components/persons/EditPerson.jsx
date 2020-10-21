import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import { connect } from 'react-redux';
import { addPersonAction, getPersonAction, setCurrentPerson } from '../../redux/actions';

class editPersonItem extends React.Component {
  constructor(props) {
    super(props);
    this.props = props;
    this.state = {
      errors: [],
    };
  }

  validate() {
    let FirstNameError = '';
    const LastNameError = '';
    let PhoneError = '';

    if (!this.props.CurrentPerson.FirstName) {
      FirstNameError = 'Invalid First Name';
    }

    if (!this.props.CurrentPerson.LastName) {
      FirstNameError = 'Invalid Last Name';
    }

    if (!this.props.CurrentPerson.Phone) {
      PhoneError = 'Invalid Phone number';
    }

    if (PhoneError || FirstNameError || LastNameError) {
      this.setState({ PhoneError, LastNameError, FirstNameError });
      return false;
    }

    return true;
  }

  PostForm(e) {
    e.preventDefault();
    const isValid = this.validate();
    if (isValid) {
      this.props.dispatch(addPersonAction(this.props.CurrentPerson));
    }
  }

  render() {
    const { errors } = this.state;
    console.log('CurrentPers', this.props.CurrentPerson);
    if (!this.props.CurrentPerson) {
      this.props.dispatch(getPersonAction(this.props.match.params.id));
    }
    if (this.props.CurrentPerson) {
      return (
        <div className="mt-2 row">
          <div className="col-2 offset-5 card border-rounded p-2">
            <div className="bg-secondary"><h3 className="text-white">Edit Person</h3></div>
            <div className="p-2 d-flex flex-row-start">
              <form className="form">
                <div>
                  {
                    Object.keys(errors).map((key) => (
                      <div>
                        {
                          errors[key].map((e) => (<p className="text-danger">{e}</p>))
                        }
                      </div>
                    ))
                  }
                </div>
                <div className="form-group ">
                  <div className="col-form-label">
                    <p> Person id:</p>
                  </div>
                  <input
                    type="text"
                    disabled
                    className="form-control"
                    name="PersonID"
                    defaultValue={this.props.CurrentPerson.PersonID}
                  />
                </div>
                <div className="form-group">
                  <div>
                    <span>First Name:</span>
                    <input
                      type="text"
                      placeholder="Input first name"
                      className="form-control"
                      name="FirstName"
                      defaultValue={this.props.CurrentPerson.FirstName}
                      onChange={(event) => this.props.dispatch(setCurrentPerson(
                        {
                          PersonID: this.props.CurrentPerson.PersonID,
                          FirstName: event.target.value,
                          LastName: this.props.CurrentPerson.LastName,
                          Phone: this.props.CurrentPerson.Phone,
                        },
                      ))}
                    />
                    <div style={{ fontSize: 12, color: 'red' }}>
                      {this.state.FirstNameError}
                    </div>
                  </div>
                </div>
                <div className="form-group">
                  <div>
                    Last Name:
                    <input
                      type="text"
                      placeholder="Input last name"
                      className="form-control"
                      name="LastName"
                      defaultValue={this.props.CurrentPerson.LastName}
                      onChange={(event) => this.props.dispatch(setCurrentPerson(
                        {
                          PersonID: this.props.CurrentPerson.PersonID,
                          FirstName: this.props.CurrentPerson.FirstName,
                          LastName: event.target.value,
                          Phone: this.props.CurrentPerson.Phone,
                        },
                      ))}
                    />
                    <div style={{ fontSize: 12, color: 'red' }}>
                      {this.state.LastNameError}
                    </div>
                  </div>
                </div>
                <div className="form-group">
                  <div>
                    Phone:
                    <input
                      type="text"
                      placeholder="Input phone number"
                      className="form-control"
                      name="Phone"
                      defaultValue={this.props.CurrentPerson.Phone}
                      onChange={(event) => this.props.dispatch(setCurrentPerson(
                        {
                          PersonID: this.props.CurrentPerson.PersonID,
                          FirstName: this.props.CurrentPerson.FirstName,
                          LastName: this.props.CurrentPerson.LastName,
                          Phone: event.target.value,
                        },
                      ))}
                    />
                    <div style={{ fontSize: 12, color: 'red' }}>
                      {this.state.PhoneError}
                    </div>
                  </div>
                </div>
                <button onClick={this.PostForm} type="submit" className="btn btn-primary">Send</button>
              </form>
            </div>
          </div>
        </div>
      );
    }

    return (<div>Loading...</div>);
  }
}

const mapStateToProps = (state) => ({
  CurrentPerson: state.CurrentPerson,
});

export default connect(mapStateToProps)(editPersonItem);
