import React from "react";
import { useNavigate } from "react-router-dom";


const HomePage = ()  => {
    
  const navigate = useNavigate();

  const onPay = () => {
        navigate("/payment");
        window.location.reload();
    }

    interface Invoice {
        id: number;
        name: string;
        bill: string;
    }

    const invoices : Invoice[]= [{id: 1, name: "Rob", bill: "bill"}, {id: 2, name: "Matt", bill: "bill1"}, {id: 3, name: "Frank", bill: "bill3"}];
    
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
                <div><h4><b>Name</b></h4></div>    
                <div><h4><b>RFID Tag</b></h4></div>    
                <div><h4><b>Distance</b></h4></div>    
                <div><h4><b>Bill</b></h4></div>   
               
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
                    <button className="btn btn-success" onClick={() => onPay()}>Pay</button>
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