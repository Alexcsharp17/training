import { combineReducers } from 'redux';
import {
  SET_ORDERS,
  SET_PAGINAT,
  SET_PERSONS, SET_ITEMS_COUNT,
  SET_CURRENT_PERSON,
  SET_CURRENT_ORDER,
  SET_ERRORS,
} from './types';

const initialPagination = {
  page: 1,
};

function personsReducer(state = null, action) {
  switch (action.type) {
    case SET_PERSONS:
      state = action.payload;
      return action.payload;
    default:
      return state;
  }
}

function ordersReducer(state = null, action) {
  switch (action.type) {
    case SET_ORDERS:
      state = action.payload;
      return state;
    default:
      return state;
  }
}

function paginationReducer(state = initialPagination, action) {
  switch (action.type) {
    case SET_PAGINAT:
      return ({ ...state, CurrentPage: action.payload.page, CurrentSort: action.sort });

    default:
      return state;
  }
}

function itemsCountReducer(state = null, action) {
  switch (action.type) {
    case SET_ITEMS_COUNT:
      state = action.payload;
      return state;
    default:
      return state;
  }
}

function currentPersonReducer(state = null, action) {
  switch (action.type) {
    case SET_CURRENT_PERSON:
      return ({
        ...state,
        FirstName: action.payload.FirstName,
        LastName: action.payload.LastName,
        Phone: action.payload.Phone,
        PersonID: action.payload.PersonID,
      });
    default:
      return state;
  }
}

function currentOrderReducer(state = null, action) {
  switch (action.type) {
    case SET_CURRENT_ORDER:
      return ({
        ...state,
        carID: action.payload.carID,
        orderID: action.payload.orderID,
        orderDate: action.payload.orderDate,
        personId: action.payload.personId,
      });
    default:
      return state;
  }
}

function errorsReducer(state = null, action) {
  switch (action.type) {
    case SET_ERRORS:
      state = action.payload;
      return state;
    default:
      return state;
  }
}

export default combineReducers({
  Persons: personsReducer,
  Orders: ordersReducer,
  Pagination: paginationReducer,
  ItemsCount: itemsCountReducer,
  CurrentPerson: currentPersonReducer,
  CurrentOrder: currentOrderReducer,
  Errors: errorsReducer,
});
