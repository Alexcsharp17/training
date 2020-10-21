import { executeGetRequest, executePostRequest, executeDeleteRequest } from '../util/FetchRequestBuilder';

const API_URL = 'https://localhost:5001/api/';
const GET_ORDERS_URL = `${API_URL}order/getorders`;
const GET_PERSONS_URL = `${API_URL}person/getpersons`;
const GET_PERSON_URL = `${API_URL}person/getperson`;
const GET_ORDER_URL = `${API_URL}order/getorder`;
const ADD_PERSON_URL = `${API_URL}person/addperson/`;
const ADD_ORDER_URL = `${API_URL}order/addorder/`;
const GET_ORDERS_COUNT_URL = `${API_URL}order/getorderscount`;
const GET_PERSONS_COUNT_URL = `${API_URL}person/getpersonscount`;
const FIND_PERSONS_URL = `${API_URL}person/findpersons`;

export async function findPersons(pattern) {
  const res = await executeGetRequest(FIND_PERSONS_URL, { pattern });
  return res;
}

export async function getOrdersCount() {
  const res = await executeGetRequest(GET_ORDERS_COUNT_URL);
  return res;
}
export async function getPersonsCount() {
  const res = await executeGetRequest(GET_PERSONS_COUNT_URL);
  return res;
}

export async function getOrders(page, sort) {
  const res = await executeGetRequest(GET_ORDERS_URL, { page, sort });
  return res;
}

export async function getPersons(page, sort) {
  const res = await executeGetRequest(GET_PERSONS_URL, { page, sort });
  return res;
}

export async function getPerson(id) {
  if (id !== '' && id && id !== 0) {
    const res = await executeGetRequest(GET_PERSON_URL, { id });
    return res;
  }
  return null;
}

export async function getOrder(id) {
  if (id !== '' && id && id !== 0) {
    const res = await executeGetRequest(GET_ORDER_URL, { id });
    return res;
  }
  return null;
}

export async function deleteItem(id, title, callback) {
  if (window.confirm('Do you want to delete this item?')) {
    let answ = [];
    const requestUrl = `${API_URL + title}/delete${title}`;
    answ = await executeDeleteRequest(requestUrl, { id });
    callback(answ);
  }
}

export async function addPerson(person) {
  let res = [];
  const body = await JSON.stringify({
    personID: parseInt(person.PersonID, 10),
    firstName: person.FirstName,
    lastName: person.LastName,
    phone: person.Phone,
  });

  res = await executePostRequest(ADD_PERSON_URL, null, body);
  return res;
}

export async function addOrder(order) {
  let res = [];
  const body = JSON.stringify({
    orderID: parseInt(order.orderID, 10),
    orderDate: new Date(Date.parse(order.orderDate)),
    carID: parseInt(order.carID, 10),
    personId: parseInt(order.personId, 10),
  });

  res = await executePostRequest(ADD_ORDER_URL, null, body);
  return res;
}
