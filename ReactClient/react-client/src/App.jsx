import React from 'react';
import {
  Route,
  Switch,
  Redirect,
} from 'react-router-dom';
import OrdersList from "./components/orders/OrdersList";
import PersonsList from './components/persons/PersonsList';
import EditOrderItem from './components/orders/EditOrder';
import EditPersonItem from './components/persons/EditPerson';
import DashboardItem from './components/dashboard/DashboardItem';
import './App.css';

function App() {
  return (
    <div className="App">
      <Switch>
        <Route path="/dashboard" component={DashboardItem} />
        <Route path="/orders" component={OrdersList} />
        <Route path="/persons" component={PersonsList} />
        <Route path="/editorder/:id" component={EditOrderItem} />
        <Route path="/editperson/:id" component={EditPersonItem} />
        <Route path="/deleteperson/:id" component={EditPersonItem} />
        <Route path="/deleteorder/:id" component={EditPersonItem} />
        <Redirect from="/" to="/dashboard" />
      </Switch>
    </div>
  );
}

export default App;
