const GET_ORDERS_URL = 'https://localhost:5001/api/order/getorders';
const GET_PERSONS_URL = 'https://localhost:5001/api/person/getpersons';
const GET_PERSON_URL = "https://localhost:5001/api/person/getperson?id=";
const GET_ORDER_URL = "https://localhost:5001/api/order/getorder?id=";
const ADD_PERSON_URL=  "https://localhost:5001/api/person/addperson/";
const ADD_ORDER_URL=  "https://localhost:5001/api/order/addorder/";
const API_URL = 'https://localhost:5001/api/';


export async function getOrders(callback) {
    var Items = [];
    await fetch(GET_ORDERS_URL)
      .then((response) => response.json())
      .then((data) => {
        Items = data
      });
    callback(Items);
}

export async function getPersons(callback) {
    var Items = [];
    await fetch(GET_PERSONS_URL)
      .then((response) => response.json())
      .then((data) => {
        Items = data
      });
    callback(Items);
  }

export  async function getPerson(id, callback){
    if(id !="" &&  id!=undefined && id!=0){
     await fetch(GET_PERSON_URL+id)
     .then((response) => response.json())
     .then((data) =>{
         callback(data);      
       })
    }
 }

 export  async function getOrder(id, callback){
    if(id !="" &&  id!=undefined && id!=0){
     await fetch(GET_ORDER_URL+id)
     .then((response) => response.json())
     .then((data) =>{
         callback(data);
       })
    }
 }

export async function deleteItem(id, title,callback) {
    if (window.confirm("Do you want to delete this item?")) {
        
    var requestUrl = API_URL + title + '/delete' + title + '?id=' + id;
      let answ=[];
      await  fetch(requestUrl, {
            method: 'DELETE'
        }).then((response) => response.json())
        .then((data)=>{
           answ=data;          
        })
        console.log(answ);
        callback(answ);
    }

}
export async function addPerson(person,callback){
    fetch(ADD_PERSON_URL,{
        method:'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            PersonID:parseInt(person.PersonID),
            FirstName:person.FirstName,
            LastName:person.LastName,
            Phone:person.Phone
        })
    }).then((response) => response.json())
    .then((data) =>{ 
        callback(data);
       })
}
export async function addOrder(order,callback){
    fetch(ADD_ORDER_URL,{
        method:'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
                OrderID:parseInt(order.OrderID),
                 OrderDate:new Date(Date.parse(order.OrderDate)),
                 CarID:parseInt(order.CarID),             
                 PersonId:parseInt(order.PersonId)
        })
    }).then((response) => response.json())
    .then((data) =>{ 
        callback(data);
       })
}