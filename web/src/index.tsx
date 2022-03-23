import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import {QueryClient, QueryClientProvider} from "react-query";
import axios from "axios";
import {ReactQueryDevtools} from "react-query/devtools";

axios.defaults.baseURL = 'http://localhost:8080';
const queryClient = new QueryClient();
ReactDOM.render(
    <React.StrictMode>
        <QueryClientProvider client={queryClient}>
            <App/>
            <ReactQueryDevtools />
        </QueryClientProvider>
    </React.StrictMode>,
    document.getElementById('root')
);
