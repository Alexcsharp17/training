import { executeGetRequest,executePostRequest,executeDeleteRequest  } from '../util/FetchRequestBuilder.js'
const API_URL = 'https://localhost:5001/api/';
const GET_ORDERS_URL = API_URL + 'order/getorders';
const GET_PERSONS_URL = API_URL + 'person/getpersons';
const GET_PERSON_URL = API_URL + "person/getperson";
const GET_ORDER_URL = API_URL + "order/getorder";
const ADD_PERSON_URL = API_URL + "person/addperson/";
const ADD_ORDER_URL = API_URL + "order/addorder/";
const GET_ORDERS_COUNT_URL = API_URL + "order/getorderscount"
const GET_PERSONS_COUNT_URL = API_URL + "person/getpersonscount"
const GET_ALL_PERSONS_URL = API_URL + "person/getallpersons"
const FIND_PERSONS_URL = API_URL + 'person/findpersons'


const PersonID = "@PersonID"

export async function findPersons(pattern) {
  return await executeGetRequest(FIND_PERSONS_URL, { pattern: pattern })
}

export async function getOrdersCount() {
  return await executeGetRequest(GET_ORDERS_COUNT_URL)
}
export async function getPersonsCount() {
  return await executeGetRequest(GET_PERSONS_COUNT_URL)
}

export async function getOrders(page, sort) {
  return await executeGetRequest(GET_ORDERS_URL, { page: page, sort: sort })
}

export async function getPersons(page, sort) {
  return await executeGetRequest(GET_PERSONS_URL, { page: page, sort: sort });
}

export async function getPerson(id) {
  if (id != "" && id && id != 0) {
    return await executeGetRequest(GET_PERSON_URL, { id: id })
  }
}

export async function getOrder(id) {
  if (id != "" && id && id != 0) {
    return await executeGetRequest(GET_ORDER_URL, { id: id });
  }
}

export async function deleteItem(id, title, callback) {
  if (window.confirm("Do you want to delete this item?")) {
    let answ = [];
    var requestUrl = API_URL + title + '/delete' + title;
    answ = await executeDeleteRequest(requestUrl, { id: id })
    callback(answ);
  }

}
export async function addPerson(person) {
  let res = [];
  let body = await JSON.stringify({
    personID: parseInt(person.PersonID),
    firstName: person.FirstName,
    lastName: person.LastName,
    phone: person.Phone
  });
  res = await executePostRequest(ADD_PERSON_URL, null, body)
  return res;
}
export async function addOrder(order) {
  let res = []
  let body =  JSON.stringify({
    orderID: parseInt(order.orderID),
    orderDate: new Date(Date.parse(order.orderDate)),
    carID: parseInt(order.carID),
    personId: parseInt(order.personId)
  })
  res = await executePostRequest(ADD_ORDER_URL,null,body)
  return res;
}