import React from 'react';
import OrderItem from './components/orders/OrdersItem.js'
import PersonItem from './components/persons/PersonsItem.js'
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
            <Route path='/orders' component={OrderItem} />
            <Route path='/persons' component={PersonItem} />
            <Route path='/editorder/:id' component={editOrderItem} />
            <Route path='/editperson/:id' component={editPersonItem} />
            <Route path='/deleteperson/:id' component={editPersonItem} />
            <Route path='/deleteorder/:id' component={editPersonItem} />
            {/* <Route path='/persons' component={PersonItem} />
            <Route path='/editorder/:id' component={editOrderItem} />
            <Route path='/editperson/:id' component={editPersonItem} /> */}
            <Redirect from='/' to='/dashboard'/>
          </Switch>
    </div>
  );
}

export default App;
