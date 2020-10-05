import React from 'react';
export function CreateErrorSection(errors){
    return(
        <div>
            {
               errors.map(function(e){
                return(<p className="text-danger">{e}</p>)
                })
            }
        </div>
      );           
}