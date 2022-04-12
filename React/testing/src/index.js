import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import ClassApp from './ClassApp';
import ProductClass from './ProductClass';
import Redirecting from './Redirecting';
import Time from './Time';

ReactDOM.render(
  <React.StrictMode>
    <App />
    <ClassApp />
    <ProductClass />
    <Redirecting />
    <Time />
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
