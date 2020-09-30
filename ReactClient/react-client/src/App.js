import React from 'react';
import OrderItem from './components/orders/OrdersItem.js'
import PersonItem from './components/persons/PersonsItem.js'
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
            {/* <Route path='/persons' component={PersonItem} />
            <Route path='/editorder/:id' component={editOrderItem} />
            <Route path='/editperson/:id' component={editPersonItem} /> */}
            <Redirect from='/' to='/dashboard'/>
          </Switch>
    </div>
  );
}

export default App;
