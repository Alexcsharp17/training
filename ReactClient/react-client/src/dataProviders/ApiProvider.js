const API_URL = 'https://localhost:5001/api/';
const GET_ORDERS_URL = API_URL+'order/getorders';
const GET_PERSONS_URL =API_URL+'person/getpersons';
const GET_PERSON_URL = API_URL+"person/getperson?id=";
const GET_ORDER_URL =API_URL+ "order/getorder?id=";
const ADD_PERSON_URL=API_URL+ "person/addperson/";
const ADD_ORDER_URL= API_URL+ "order/addorder/";
const GET_ORDERS_COUNT_URL=API_URL+"order/getorderscount"
const GET_PERSONS_COUNT_URL=API_URL+"person/getpersonscount"
const GET_ALL_PERSONS_URL=API_URL+"person/getallpersons"
const FIND_PERSONS_URL=API_URL+'person/findpersons'

const PersonID="@PersonID"

export async function findPersons(patern){
  let dat=[];
  await fetch(FIND_PERSONS_URL+"?pattern="+patern)
  .then(async (response) =>{
    dat = await response.json();
  })
 return dat;
}


export async function getAllPersons(callback){
  let dat=[];
  await fetch(GET_ALL_PERSONS_URL)
  .then((response) => response.json())
  .then((data) => {
    dat = data
  });
callback(dat);
}

export async function getOrdersCount()
{
  let dat=[];
  await fetch(GET_ORDERS_COUNT_URL)
      .then( async (response) => {
         dat = await response.json();
      });    
    return dat;
}
export async function getPersonsCount()
{
  let dat=[];
  await fetch(GET_PERSONS_COUNT_URL)
      .then( async (response) => {
         dat = await response.json();
      });    
    return dat;
}

export async function getOrders(page,sort) {
    var Items = [];
    await fetch(GET_ORDERS_URL+"?page="+page+"&sort="+sort)
      .then(async (response) => {
        Items=await response.json();
      });
      return Items;
}

export async function getPersons(page,sort) {
  var Items = [];
  console.log("PAGE",page,"SORT",sort);
  await fetch(GET_PERSONS_URL+"?page="+page+"&sort="+sort)
    .then(async (response) =>
      {
       Items = await response.json() ;
    });
    return Items;
}

export  async function getPerson(id){
  console.log("HEEEEEEEE")
    if(id !="" &&  id!=undefined && id!=0){
     let dat=[];
     await fetch(GET_PERSON_URL+id)
     .then(async (response) => {
       dat = await response.json();
     })
     return dat;
    }
 }

 export  async function getOrder(id){
  
    if(id !="" &&  id!=undefined && id!=0){
     let dat=[];
     await fetch(GET_ORDER_URL+id)
     .then(async(response) =>{
       dat = await response.json()
     })
     return dat;
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
export async function addPerson(person){
  let res=[];
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
    }).then(async(response) => {
      res= await response.json();
    })
    return res;
}
export async function addOrder(order){
  let res=[]
    fetch(ADD_ORDER_URL,{
        method:'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
                OrderID:parseInt(order.orderID),
                 OrderDate:new Date(Date.parse(order.orderDate)),
                 CarID:parseInt(order.carID),             
                 PersonId:parseInt(order.personId)
        })
    }).then(async (response) => {
      res = await response.json()
    })
    return res;
}