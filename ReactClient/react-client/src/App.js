import React from 'react';
import {
  Route,
  Switch,
  Redirect,
} from 'react-router-dom';
import OrdersList from './components/orders/OrdersList';
import PersonsList from './components/persons/PersonsList';
import editOrderItem from './components/orders/EditOrder';
import editPersonItem from './components/persons/EditPerson';
import DashboardItem from './components/dashboard/DashboardItem';
import './App.css';

function App() {
  return (
    <div className="App">
      <Switch>
        <Route path="/dashboard" component={DashboardItem} />
        <Route path="/orders" component={OrdersList} />
        <Route path="/persons" component={PersonsList} />
        <Route path="/editorder/:id" component={editOrderItem} />
        <Route path="/editperson/:id" component={editPersonItem} />
        <Route path="/deleteperson/:id" component={editPersonItem} />
        <Route path="/deleteorder/:id" component={editPersonItem} />
        <Redirect from="/" to="/dashboard" />
      </Switch>
    </div>
  );
}

export default App;
