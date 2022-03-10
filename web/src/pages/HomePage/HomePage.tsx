import React from "react";
import Button from "react-bootstrap"


const HomePage = ()  => {

    interface Invoice {
        id: number;
        name: string;
        bill: string;
    }

    const invoices : Invoice[]= [{id: 1, name: "hello", bill: "bill"}, {id: 2, name: "hello1", bill: "bill1"}, {id: 3, name: "hello2", bill: "bill3"}];
    
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
            <div>
            <div className="d-flex justify-content-between">
                <div><h4>Name</h4></div>    
                <div><h4>RFID Tag</h4></div>    
                <div><h4>Distance</h4></div>    
                <div><h4>Bill</h4></div>   
               
            </div>
             <hr></hr> 
            {invoices.length > 0 ? (invoices.map((invoice) => (
            <div key={invoice.id}>
              <div className="d-flex justify-content-between">
                <div>
                  <h4>
                    {invoice.name}
                  </h4>
                  
                </div>
                <div>
                  <h4>
                    12312
                  </h4>
                </div>
                <div>
                  <h4>
                    {invoice.bill}
                  </h4>
                </div>
                <div>
                    <button className="btn btn-success">Pay</button>
                </div>
              </div>
              <hr></hr>
            </div>
          )
        )
      ) : (
        <b>
          No invoices found.<hr></hr>
        </b>
      )}
            </div>
        </div>
    );
}

export default HomePage;