import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import { Link } from "react-router-dom"
import {deleteItem} from '../dataProviders/ApiProvider.js'

export function  CreateTableBody(items,title,fetchHandler){
    return(
        <tbody>
            {
                items.map((item) => {
                    return (
                        CreateTableRow(item,title,fetchHandler)
                    )
                })
            }
        </tbody>
    );
}

function CreateTableRow(item,title,fetchHandler){
    return (
        <tr>
            {
                Object.keys(item).map(function (key, index) {
                    return (<td>{item[key]}</td>)
                })
            }

            <td>
                <Link className="" to={'/edit' + title + "/" + item[Object.keys(item)[0]]}>
                    <span className="btn btn-warning mr-1">Edit</span>
                </Link>
                <button className="btn btn-primary" onClick={() => deleteItem(item[Object.keys(item)[0]], title,fetchHandler)}>Delete</button>

            </td>
        </tr>
    )
}

export function CreateTableHead(fields){
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
