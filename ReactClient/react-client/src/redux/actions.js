import {
  SET_PERSONS,
  SET_ORDERS,
  SET_PAGINAT,
  SET_ITEMS_COUNT,
  SET_ERRORS,
  SET_CURRENT_PERSON,
  SET_CURRENT_ORDER,
} from './types';
import {
  getPersons,
  getOrders,
  getOrdersCount,
  getPersonsCount,
  getPerson,
  addPerson,
  getOrder,
  addOrder,
  findPersons,
} from '../dataProviders/ApiProvider';

const initialPagin = {
  page: 1,
};

export function setPersons(persons) {
  return {
    type: SET_PERSONS,
    payload: persons,
  };
}
export function setOrders(orders) {
  return {
    type: SET_ORDERS,
    payload: orders,
  };
}

export function setPagination(params = initialPagin) {
  return {
    type: SET_PAGINAT,
    payload: {
      page: params.page,
      sort: params.sort,
    },
  };
}

export function setItemsCount(count) {
  return {
    type: SET_ITEMS_COUNT,
    payload: count,
  };
}

export function getPersonsAction(page, sort) {
  return async (dispatch) => {
    const result = await getPersons(page, sort);
    if (result) {
      dispatch(setPagination({ page, sort }));
      dispatch(setPersons(result));
    }
  };
}

export function getOrdersAction(page, sort) {
  return async (dispatch) => {
    const result = await getOrders(page, sort);
    if (result) {
      dispatch(setPagination({ page, sort }));
      dispatch(setOrders(result));
    }
  };
}

export function getOrdersCountAction() {
  return async (dispatch) => {
    const res = await getOrdersCount();
    if (res) {
      dispatch(setItemsCount(res));
    }
  };
}

export function getPersonsCountAction() {
  return async (dispatch) => {
    const res = await getPersonsCount();
    if (res) {
      dispatch(setItemsCount(res));
    }
  };
}

export function addErrors(data) {
  return {
    type: SET_ERRORS,
    payload: data,
  };
}

export function setCurrentPerson(p) {
  const person = p;
  if (!person.personID) {
    person.personID = null;
  }
  if (!person.firstName) {
    person.firstName = null;
  }
  if (!person.lastName) {
    person.lastName = null;
  }
  if (!person.phone) {
    person.phone = null;
  }
  return {
    type: SET_CURRENT_PERSON,
    payload: person,
  };
}

export function getPersonAction(id) {
  return async (dispatch) => {
    const res = await getPerson(id);
    if (!res) {
      dispatch(setCurrentPerson({ PersonID: 0 }));
    } else {
      dispatch(setCurrentPerson(res));
    }
  };
}

export function findPersonsAction(patern) {
  return async (dispatch) => {
    const res = await findPersons(patern);
    dispatch(setPersons(res));
  };
}

export function addPersonAction(person) {
  return async (dispatch) => {
    const data = await addPerson(person);
    if (data.errors != null && data.errors) {
      dispatch(addErrors(data));
    } else {
      dispatch(addErrors(null));
      alert('Person succesfully changed');
    }
  };
}

export function setCurrentOrder(ord) {
  const order = ord;
  if (!order.orderID) {
    order.orderID = null;
  }
  if (!order.orderDate) {
    order.orderDate = null;
  }
  if (!order.carID) {
    order.carID = null;
  }
  if (!order.personId) {
    order.personId = null;
  }
  return {
    type: SET_CURRENT_ORDER,
    payload: order,
  };
}

export function getOrderAction(id) {
  return async (dispatch) => {
    const res = await getOrder(id);

    if (!res) {
      dispatch(setCurrentOrder({ OrderID: 0 }));
    } else {
      dispatch(setCurrentOrder(res));
    }
  };
}

export function addOrderAction(order) {
  return async (dispatch) => {
    const data = await addOrder(order);
    if (data.errors != null && data.errors) {
      dispatch(addErrors(data));
    } else {
      dispatch(addErrors(null));
      alert('Order succesfully changed');
    }
  };
}
