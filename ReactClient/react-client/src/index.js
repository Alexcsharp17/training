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
import  rootReducer  from './redux/rootReducer.js'
import  logger  from './util/loger.js'

const historyr = createBrowserHistory()
const store = createStore(rootReducer, applyMiddleware(thunk, logger));

ReactDOM.render((
  <Provider store={store}>
    <Router history={historyr}>
      <App />
    </Router>
  </Provider>
), document.getElementById('root')
);

serviceWorker.unregister();
