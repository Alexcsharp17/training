import React from 'react';
import OrdersListItem from './components/orders/OrdersItem.js'
import PersonsListItem from './components/persons/PersonsItem.js'
import editOrderItem from './components/orders/EditOrder.js'
import editPersonItem from './components/persons/EditPerson'
import DashboardItem from './components/dashboard/DashboardItem.js';
import './App.css';


import {
  Route,
  Switch,
  Redirect,
} from "react-router-dom"

function App() {
  return (
   
    <div className="App">
          <Switch>         
            <Route  path='/dashboard' component={DashboardItem} />
            <Route path='/orders' component={OrdersListItem} />
            <Route path='/persons' component={PersonsListItem} />
            <Route path='/editorder/:id' component={editOrderItem} />
            <Route path='/editperson/:id' component={editPersonItem} />
            <Route path='/deleteperson/:id' component={editPersonItem} />
            <Route path='/deleteorder/:id' component={editPersonItem} />
            <Redirect from='/' to='/dashboard'/>
          </Switch>
    </div>
  );
}

export default App;
