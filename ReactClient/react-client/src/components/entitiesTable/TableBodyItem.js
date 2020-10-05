import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import {CreateTableBody} from "../../util/TableBuiler.js"

export class TableBody extends React.Component {
    constructor(props) {
        super(props);
        this.props = props
        this.state = { 
            confirmDelete: false ,
            iDError:""
        };
    }

    FetchRequestHandler=(data)=>{
        console.log(data);
            if(data.IdError!=undefined){
                this.setState({IdError:"Can not delete person who has active records"})
                console.log("failed delete");
            }
            else{
                this.setState({IdError:""})
                console.log("sucess delete");
                console.log(data.IdError);
            }
    }

    render() {

        const { Items, title } = this.props
        if(this.state.IdError!="" && this.state.IdError!=undefined){
              alert(this.state.IdError);          
        }
        return (
           CreateTableBody(Items,title,this.FetchRequestHandler)
        );

    }
}
