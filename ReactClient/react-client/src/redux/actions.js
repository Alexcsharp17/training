import {GET_ORDERS,GET_PERSONS,SET_PERSONS,SET_ORDERS, SET_PAGINAT} from './types.js'
import {getPersons,getOrders} from '../dataProviders/ApiProvider.js'

export function setPersons(persons){
    return{
        type:SET_PERSONS,
        payload:persons
    }
}
export function setOrders(orders){
    return{
        type:SET_ORDERS,
        payload:orders
    }
}

const initialPagin={
    page:1
}
export function setPagination(params=initialPagin) {
    return{
        type:SET_PAGINAT,
        payload:{
            page:params.page,
            sort:params.sort
        }
    }
}

export  function getPersonsAction(page,sort) {
    return async (dispatch)=>{
        let  result= await getPersons(page,sort)
            console.log("action Log",result)        
        if(result!=undefined){
            dispatch(setPagination({page:page,sort:sort}));
            console.log("action Log",result)    
            dispatch(setPersons(result))
       }
    }
}

export  function getOrdersAction(page,sort) {
    return async (dispatch)=>{
        let  result= await getOrders(page,sort)
            console.log("action Log",result)        
        if(result!=undefined){
            dispatch(setPagination({page:page,sort:sort}));
            console.log("action Log",result)    
            dispatch(setOrders(result))
       }
    }
}