import React from "react";


const HomePage = ()  => {

    interface Invoice {
        name: string;
        bill: string;
    }

    const invoices : Invoice[]= [{name: "hello", bill: "bill"}, {name: "hello1", bill: "bill1"}];
    
    console.log(invoices)
    return(
        <div>
            
            <h1 className="display-5">Welcome, here are all your invoices</h1>
            <div className="pt-3">
                <form className="d-flex form-inline my-2 my-lg-0">
                    <input className="form-control mr-sm-2" type="search" placeholder="Search invoice..." aria-label="Search"></input>
                    <button className="btn btn-outline-success my-2 my-sm-0 bg-light" >Search</button>
                </form>
            </div>
            <hr></hr>
            {invoices.map((invoice) => {
                    <div>
                        <h2>{invoice.name}</h2>
                        <h2>{invoice.bill}</h2>
                    </div>
            })}
        </div>
    );
}

export default HomePage;