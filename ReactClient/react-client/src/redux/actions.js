import {
    SET_PERSONS,
    SET_ORDERS,
    SET_PAGINAT,
    SET_ITEMS_COUNT,
    SET_ERRORS,
    SET_CURRENT_PERSON,
    SET_CURRENT_ORDER
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
    console.log("SET ITEMS COUNT:",count)
    return{
        type:SET_ITEMS_COUNT,
        payload: count
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

export function getOrdersCountAction(){
    return async (dispatch)=>{
        let res = await getOrdersCount()
        if(res!=undefined){
            dispatch(setItemsCount(res))
        }
    }
}
export function getPersonsCountAction(){
    return async (dispatch)=>{
        let res = await getPersonsCount()
        if(res!=undefined){

            dispatch(setItemsCount(res))
        }
    }
}


export function setCurrentPerson(person){
    if(person.PersonID==undefined){
        person.PersonID=null
    }
    if(person.firstName!=undefined){
        person.FirstName=null
    }
    if(person.lastName!=undefined){
        person.LastName=null
    }
    if(person.phone!=undefined){
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
        if(res==undefined){
            console.log("HEEEEEEEE")
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
       if(data.errors!=null && data.errors!=undefined){
            dispatch(addErrors(data))    
        }
     else{
         dispatch(addErrors(null))
        alert("Person succesfully changed");     
     }
    }  
}

export function setCurrentOrder(order){
    console.log("AAAAAAAAAAAAAAAAAA",order)
    if(order.orderID==undefined){
        order.orderID=null
    }
    if (order.orderDate==undefined) {
        order.orderDate=null
    }
    if(order.carID==undefined){
        order.carID=null
    }
    if(order.personId==undefined){
        order.personId=null
    }
    return{
        type:SET_CURRENT_ORDER,
        payload:order
    }        
}

export function getOrderAction(id){
    console.log("HEEEEEEEE",id)
    return async (dispatch)=>{
        
        let res = await getOrder(id)
       
        console.log("BBBBBBBBBEEEEEEEEEE",res)
        if(res==undefined){
            
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
       if(data.errors!=null && data.errors!=undefined){
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