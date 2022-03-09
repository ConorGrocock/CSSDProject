import React from "react";


const HomePage = ()  => {

    interface Invoice {
        name: string;
        bill: string;
    }

    const invoices : Invoice[]= [{name: "hello", bill: "bill"}, {name: "hello1", bill: "bill1"}];
    
    const renderInvoices = () => {
        return (
            invoices.map((invoice) => {
                return(
                    <div>
                        <h2>{invoice.name}</h2>
                        <h2>{invoice.bill}</h2>
                    </div>
                )
            })
        )
    };

    return(
        <div>
            <h1 className="display-5">Welcome, here are all requests:</h1>
            Home Page!
            {renderInvoices}
        </div>
    );
}

export default HomePage;