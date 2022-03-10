import './App.css';
import React, { useState } from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom"
import "bootstrap/dist/css/bootstrap.min.css";
import HomePage from "../src/pages/HomePage/HomePage"

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <p>
          Edit <code>src/App.js</code> and save to reload.
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
      <div>
        <Router>
          <nav className="navbar navbar-expand navbar-dark" style={{ backgroundColor: "#61DBAE" }}>
            <a className="navbar-brand">⠀<i>Nordic Department of Transport</i></a>

          </nav>
          <div className="container mt-3">
            <Routes>
              <Route path="/home" element={<HomePage />} />
              <Route path="/users" element={<HomePage />} />
            </Routes>
          </div>
          <div className="container mt-3 ">
            <Routes>
              <Route path="/home" element={<HomePage />} />
              <Route path="/users" element={<HomePage />} />
            </Routes>
          </div>
        </Router>
      </div>
    </div>
  );
}


export default App;
