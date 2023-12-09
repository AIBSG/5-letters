import React, { useState, useEffect } from 'react';
import logo from './logo.svg';
import './App.css';

function App() {
  useEffect(() => {
    fetch('https://5letters.stk8s.66bit.ru/api/weatherforecast')
       .then((response) => response.json())
       .then((data) => console.log(data))
       .catch((err) => console.log(err.message)) }, []);

  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
            <div>насрл</div>
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
      <div>насрал</div>
    </div>
  );
}

export default App;
