import {
    SET_PERSONS,
    SET_ORDERS,
    SET_PAGINAT,
    SET_ITEMS_COUNT,
    SET_ERRORS,
    SET_CURRENT_PERSON,
    SET_CURRENT_ORDER,
    SET_CURRENT_SORT
    } from './types.js'
import {
    getPersons,
    getOrders,
    getOrdersCount,
    getPersonsCount,
    getPerson,
    addPerson,
    getOrder,
    addOrder,
    findPersons
} from '../dataProviders/ApiProvider.js'

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

export function setItemsCount(count){
    return{
        type:SET_ITEMS_COUNT,
        payload: count
    }
}

export  function getPersonsAction(page,sort) {
    return async (dispatch)=>{
        let  result= await getPersons(page,sort)
        if(result){
            dispatch(setPagination({page:page,sort:sort}));
            dispatch(setPersons(result))
       }
    }
}

export  function getOrdersAction(page,sort) {
    return async (dispatch)=>{
        let  result= await getOrders(page,sort)
        if(result){
            dispatch(setPagination({page:page,sort:sort}));
            dispatch(setOrders(result))
       }
    }
}

export function getOrdersCountAction(){
    return async (dispatch)=>{
        let res = await getOrdersCount()
        if(res){
            dispatch(setItemsCount(res))
        }
    }
}
export function getPersonsCountAction(){
    return async (dispatch)=>{
        let res = await getPersonsCount()
        if(res){

            dispatch(setItemsCount(res))
        }
    }
}


export function setCurrentPerson(person){
    if(!person.PersonID){
        person.PersonID=null
    }
    if(!person.firstName){
        person.FirstName=null
    }
    if(!person.lastName){
        person.LastName=null
    }
    if(!person.phone){
        person.Phone=null
    }
    return{
        type:SET_CURRENT_PERSON,
        payload:person
    }        
}


export function getPersonAction(id){
    
    return async (dispatch)=>{
        let res = await getPerson(id)
        if(!res){
            dispatch(setCurrentPerson({PersonID:0}))
        }
        else{
            dispatch(setCurrentPerson(res))
        }
    }
}

export function findPersonsAction(patern){
    return async(dispatch)=>{
        let res = await  findPersons(patern)
        dispatch(setPersons(res))
    }
}

export function addPersonAction(person){
    return async(dispatch)=>{
       let data= await addPerson(person);
       if(data.errors){
            dispatch(addErrors(data))    
        }
     else{
         dispatch(addErrors(null))
        alert("Person succesfully changed");     
     }
    }  
}

export function setCurrentOrder(order){
    if(order.orderID){
        order.orderID=null
    }
    if (order.orderDate) {
        order.orderDate=null
    }
    if(order.carID){
        order.carID=null
    }
    if(order.personId){
        order.personId=null
    }
    return{
        type:SET_CURRENT_ORDER,
        payload:order
    }        
}

export function getOrderAction(id){
    return async (dispatch)=>{
        
        let res = await getOrder(id)
       
        if(!res){
            
            dispatch(setCurrentOrder({OrderID:0}))
        }
        else{
            dispatch(setCurrentOrder(res))
        }
    }
}

export function addOrderAction(order){
    return async(dispatch)=>{
       let data= await addOrder(order);
       if(data.errors){
            dispatch(addErrors(data))    
        }
     else{
         dispatch(addErrors(null))
        alert("Order succesfully changed");     
     }
    }  
}

export function addErrors(data){
    return{
        type:SET_ERRORS,
        payload:data
    }
}

