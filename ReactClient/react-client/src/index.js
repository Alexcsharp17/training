import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import * as serviceWorker from './serviceWorker';
import { BrowserRouter as Router } from "react-router-dom"
import { createBrowserHistory } from 'history'
import { createStore, applyMiddleware } from 'redux'
import thunk from 'redux-thunk';
import { Provider } from 'react-redux';
import {rootReducer} from './redux/rootReducer.js'

const historyr = createBrowserHistory()
const store = createStore(rootReducer,applyMiddleware(thunk,logger));

ReactDOM.render((
  <Provider store={store}>
    <Router history={historyr}>
      <App />
    </Router>
  </Provider>
), document.getElementById('root')
);

function logger(state){
  return function(next){
    return function(action){
      console.log("State",state.getState());
      console.log("Action",action);
      return next(action);
    }
  }
}

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
