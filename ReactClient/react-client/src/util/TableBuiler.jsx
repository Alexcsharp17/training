import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';

export default function CreateTableHead(fields, callback) {
  return (
    <thead>
      <tr>
        {
          fields.map((field) => (
            <td key={field}>
              <div>{field}</div>
              <div className="">
                <button className="btn ml-1" type="button" value={field} onClick={() => { callback(1, "@" + field); }}>
                  <img src="sortUP.png" alt="^" className="sortImg" />
                </button>
              </div>
            </td>
          ))
        }
        <td />
      </tr>
    </thead>
  );
}
