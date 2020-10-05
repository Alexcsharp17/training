import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import { Link, Redirect } from "react-router-dom"
import{getPerson,addPerson} from '../../dataProviders/ApiProvider.js'

const POST_URL=  "https://localhost:5001/api/person/addperson/";
const DASHBOARD='/persons'

class editPersonItem extends React.Component{
   
   constructor(props){
        super(props); 
        this.props=props;
        this.state={
            Person:{},
            errors:[]
        }
        getPerson(this.props.match.params.id,this.FetchRequestResponse);
    
    }

    validate=()=>{
        let FirstNameError="";
        let LastNameError="";
        let PhoneError="";
       
        if(this.state.FirstName=="" || this.state.FirstName==undefined){
            FirstNameError="Invalid First Name"
        }

        if(this.state.LastName=="" || this.state.LastName==undefined){
            FirstNameError="Invalid Last Name"
        }

        if(this.state.Phone=="" || this.state.Phone==undefined){
            PhoneError="Invalid Phone number"
        }

        if(PhoneError || FirstNameError || LastNameError){
            this.setState({PhoneError,LastNameError,FirstNameError})
            return false
        }

        return true;
    }
    AddPersonHandler=(data)=>{
        if(data.errors!=null && data.errors!=undefined){
            console.log('This is your data', data);
        this.setState({errors:data.errors});
         }
         else{
            alert("Person succesfully changed");
             this.setState({errors:[]});       
         }
    }
    
    PostForm= e =>{
       e.preventDefault();
       let isValid = this.validate();
       if(isValid){
        let Person={
            PersonID:this.state.PersonID,
            FirstName:this.state.FirstName,
            LastName:this.state.LastName,
            Phone:this.state.Phone
        }
        addPerson(Person,this.AddPersonHandler)
       
       }
    }
    
    FetchRequestResponse=(data)=>{
        this.setState({
            Person:data,
            PersonID:data.PersonID,
            FirstName:data.FirstName,
            LastName:data.LastName,
            Phone:data.Phone
        });
        console.log("Fetched data",this.state.Person);
    }

    render(props){
        let errors =this.state.errors;
        return( 
        <div className="mt-2 row">
        <div className="col-2 offset-5 card border-rounded p-2">
            <div className="bg-secondary"><h3 className="text-white">Edit Person</h3></div>
            <div className="p-2 d-flex flex-row-start">
            <form className="form"  >
            <div>
                   {
                       
                      Object.keys(errors).map(function(key){
                          return(
                            <div>
                                {
                                    errors[key].map(function(e){
                                    return(<p className="text-danger">{e}</p>)
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
                <input type="text"  className="form-control"  name="PersonID" defaultValue={this.state.PersonID} onChange={event=>this.setState({PersonID:event.target.value})} />
                </div>
                <div className="form-group">
                <label>
                    <span>First Name:</span>
                    <input type="text"  className="form-control"  name="FirstName" defaultValue={this.state.FirstName} onChange={event=> this.setState({FirstName:event.target.value})} />
                    <div style={{fontSize:12,color:"red"}}>
                        {this.state.FirstNameError}
                    </div>
                </label>
                </div>
                <div className="form-group">
                <label>
                    Last Name:
                    <input type="datetime"  className="form-control"  name="LastName" defaultValue={this.state.LastName} onChange={event=>this.setState({LastName:event.target.value})} />
                    <div style={{fontSize:12,color:"red"}}>
                        {this.state.LastNameError}
                    </div>
                </label>
                </div>
                <div className="form-group">
                <label>
                    Phone:
                    <input type="text" className="form-control"  name="Phone" defaultValue={this.state.Phone} 
                    onChange={event=>this.setState({Phone:event.target.value})} />
                    <div style={{fontSize:12,color:"red"}}>
                        {this.state.PhoneError}
                    </div>
                </label>
                </div>
                <button onClick={this.PostForm} type="submit">Send</button>
            </form>
            </div>
        </div>
        </div>
        );  
    }
}

class SuccessEdit extends React.Component{
    render( ){
        return   <Redirect to={DASHBOARD}/>;
    }
}

export default editPersonItem