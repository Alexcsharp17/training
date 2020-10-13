import { combineReducers } from "redux"
import {SET_ORDERS,SET_PAGINAT,SET_PERSONS} from './types.js'
function personsReducer(state=null, action) {
    switch (action.type) {
      case SET_PERSONS:
      
        return state =action.payload
      default:
        console.log("REducer log")
        return state
    }
  }

 function ordersReducer(state=null,action){
    switch(action.type){
        case SET_ORDERS:
        return state=action.payload
        default:
            return state
    }
}
const initialPagination={
    page:1
}
function paginationReducer(state=initialPagination, action){
  switch (action.type) {
    case SET_PAGINAT:
      return({...state,CurrentPage:action.payload.page,CurrentSort:action.sort})
  
    default:
      return state;
  }
}

export const rootReducer = combineReducers({
    Persons:personsReducer,
    Orders:ordersReducer,
    Pagination:paginationReducer
})