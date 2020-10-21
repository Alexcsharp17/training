import React from 'react';

export default function CreateErrorSection(errors) {
  return (
    <div>
      {
        errors.map((e) => (<p className="text-danger">{e}</p>))
      }
    </div>
  );
}
