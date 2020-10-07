import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import {CreateTableHead} from "../../util/TableBuiler.js"

export class TableHead extends React.Component {
    render() {
        const { fields,callback } = this.props
        console.log("CAAAALBAACKK FROM TABLE HEAD",callback)
        return (
            CreateTableHead(fields,callback)
        );

    }
}