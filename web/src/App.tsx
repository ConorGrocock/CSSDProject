import './App.css';
import React, {useState, Suspense} from 'react';
import {BrowserRouter as Router, Link, Route, Routes} from "react-router-dom"
import "bootstrap/dist/css/bootstrap.min.css";
import HomePage from "../src/pages/HomePage/HomePage"
import LoginPage from './pages/LoginPage/LoginPage';
import PaymentPage from './pages/Payment/PaymentPage';
import ConfirmationPage from './pages/ConfirmationPage/ConfirmationPage';
import InvoicePageRouter from "./pages/InvoicePage/InvoicePageRouter";
import {QueryClient, QueryClientProvider, useQueryClient} from "react-query";
import axios from "axios";

axios.defaults.baseURL = "https://localhost:7107";

function App() {
    const queryClient = new QueryClient()
    const [currentUser, setCurrentUser] = useState(undefined);

    return (
        <QueryClientProvider client={queryClient}>
            <Suspense fallback={"loading"}>
            <div>
                <Router>
                    <nav className="navbar navbar-expand navbar-dark" style={{backgroundColor: "#61DBAE"}}>
                        <a className="navbar-brand">⠀<i>NorToll</i></a>

                        <div className="navbar-nav mr-auto">
                            {currentUser && (
                                <li className="nav-item">
                                    <Link to={"/home"} className="nav-link">
                                        Home
                                    </Link>
                                </li>
                            )}
                        </div>

                        {currentUser ? (
                            <div className="navbar-nav ms-auto">
                                <li className="nav-item">
                                    <a href="/login" className="nav-link">
                                        Logout
                                    </a>
                                </li>
                            </div>
                        ) : (
                            <div className="navbar-nav ms-auto">
                                <li className="nav-item">
                                    <Link to={"/"} className="nav-link">
                                        Login
                                    </Link>
                                </li>
                            </div>
                        )}
                    </nav>
                    <div className="container mt-3 ">
                        <Routes>
                            <Route path="/home" element={<HomePage/>}/>
                            <Route path="/payment" element={<PaymentPage/>}/>
                            <Route path="/confirmation" element={<ConfirmationPage/>}/>
                            <Route path="/invoice/:invoiceId" element={<InvoicePageRouter/>}/>
                            <Route path="/" element={<LoginPage/>}/>
                        </Routes>
                    </div>
                </Router>
            </div>
            </Suspense>
        </QueryClientProvider>
    );
}


export default App;
