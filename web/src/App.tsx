import './App.css';
import React, { useState } from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom"
import "bootstrap/dist/css/bootstrap.min.css";
import HomePage from "../src/pages/HomePage/HomePage"
import LoginPage from './pages/LoginPage/LoginPage';
import PaymentPage from './pages/Payment/PaymentPage';
import ConfirmationPage from './pages/ConfirmationPage/ConfirmationPage';

function App() {
  return (
    <div>
      <Router>
        <nav className="navbar navbar-expand navbar-dark" style={{ backgroundColor: "#61DBAE" }}>
          <a className="navbar-brand">⠀<i>NorToll</i></a>

          <div className="navbar-nav mr-auto">
          </div>
        </nav>
        <div className="container mt-3 ">
          <Routes>
            <Route path="/home" element={<HomePage />} />
            <Route path="/payment" element={<PaymentPage />} />
            <Route path="/confirmation" element={<ConfirmationPage />} />
            <Route path="/" element={<LoginPage />} />
          </Routes>
        </div>
      </Router>
    </div>
  );
}


export default App;
