import React, {Suspense, useEffect, useState} from 'react';
import {BrowserRouter as Router, Link, Route, Routes} from "react-router-dom"
import "bootstrap/dist/css/bootstrap.min.css";
import HomePage from "../src/pages/HomePage/HomePage"
import LoginPage from './pages/LoginPage/LoginPage';
import PaymentPage from './pages/Payment/PaymentPage';
import ConfirmationPage from './pages/ConfirmationPage/ConfirmationPage';
import InvoicePageRouter from "./pages/InvoicePage/InvoicePageRouter";
import BillPageRouter from "./pages/BillPage/BillPageRouter";
import {QueryClient, QueryClientProvider} from "react-query";
import axios from "axios";
import LanguagePicker from "./components/LanguagePicker/LanguagePicker";
import AuthPage from "./pages/AuthPage/AuthPage";
import {User, UserProvider} from "./Contexts/UserContext";
import {ReactQueryDevtools} from "react-query/devtools";
import RequireAuth from "./components/RequireAuth/RequireAuth";

axios.defaults.baseURL = "https://localhost:7107";

function App() {
    const queryClient = new QueryClient()
    const [user, setUser] = useState<User | null>(null);

    useEffect(() => {
        // Load user from local storage
        if (user === null) {
            const user = localStorage.getItem("user");
            if (user !== null) {
                setUser(JSON.parse(user));
            }
        }
    }, [user])

    useEffect(() => {
        if (user !== null) {
            localStorage.setItem("user", JSON.stringify(user));
        }
    }, [user]);

    useEffect(() => {
            if (user) {
                const interceptorId = axios.interceptors.request.use((config) => {
                    return {
                        ...config,
                        headers: user.token
                            ? {
                                ...config.headers,
                                Authorization: `Bearer ${user.token}`,
                            }
                            : config.headers,
                    };
                });
                return () => {
                    axios.interceptors.request.eject(interceptorId);
                };
            }
        }, [user]
    );

    return (
        <QueryClientProvider client={queryClient}>
            <UserProvider value={{user, setUser}}>
                <Suspense fallback={"loading"}>
                    <div>
                        <Router>
                            <nav className="navbar navbar-expand navbar-dark" style={{backgroundColor: "#61DBAE"}}>
                                <a className="navbar-brand" href={"/home"}>⠀<i>NorToll</i></a>

                                <div className="navbar-nav mr-auto">
                                    {user && (
                                        <li className="nav-item">
                                            <Link to={"/home"} className="nav-link">
                                                Home
                                            </Link>
                                        </li>
                                    )}
                                </div>

                                {user ? (
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
                                    <Route path="/home" element={<RequireAuth><HomePage/></RequireAuth>}/>
                                    <Route path="/payment" element={<RequireAuth><PaymentPage/></RequireAuth>}/>
                                    <Route path="/confirmation" element={<RequireAuth><ConfirmationPage/></RequireAuth>}/>
                                    <Route path="/invoice/:invoiceId" element={<RequireAuth><InvoicePageRouter/></RequireAuth>}/>
                                    <Route path="/bill/:billId" element={<RequireAuth><BillPageRouter/></RequireAuth>}/>
                                    <Route path="/auth/:token" element={<AuthPage/>}/>
                                    <Route path="/" element={<LoginPage/>}/>
                                </Routes>
                            </div>
                        </Router>
                    </div>
                    <LanguagePicker/>

                </Suspense>
            </UserProvider>
            <ReactQueryDevtools/>
        </QueryClientProvider>
    );
}


export default App;
