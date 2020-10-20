import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import { Link } from "react-router-dom"
import { deleteItem } from '../dataProviders/ApiProvider.js'

function CreateTableRow(item, title, fetchHandler) {
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
                <button className="btn btn-primary" onClick={() => deleteItem(item[Object.keys(item)[0]], title, fetchHandler)}>Delete</button>

            </td>
        </tr>
    )
}

export function CreateTableHead(fields, callback) {

    return (
        <thead>
            <tr>
                {
                    fields.map(function (field) {
                        return (
                            <td key={field}>
                                <div>{field}</div>
                                <div className="">
                                    <button className="btn ml-1" value={field} onClick={event => { callback(1, "@" + field) }}>
                                        <img src="sortUP.png" alt="^" className="sortImg" />
                                    </button>
                                </div>
                            </td>
                        )
                    })
                }
                <td></td>
            </tr>
        </thead>
    );
}
