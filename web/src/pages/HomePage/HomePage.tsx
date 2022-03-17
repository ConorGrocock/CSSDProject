import React, {useState} from "react";
import { useNavigate } from "react-router-dom";
import PaginationComponent from "../../components/Pagination";

const HomePage = ()  => {
    
  const navigate = useNavigate();

  const [currentPage, setCurrentPage] = useState(1);
  //change this state to see more ore less requests per page
  const [invoicesPerPage] = useState(4);

  

  const onPay = () => {
        navigate("/payment");
        window.location.reload();
    }

    interface Invoice {
        id: number;
        name: string;
        bill: string;
    }

    const invoices : Invoice[]= [{id: 1, name: "Rob", bill: "bill"}, {id: 2, name: "Matt", bill: "bill1"}, {id: 3, name: "Frank", bill: "bill1"}, {id: 4, name: "Xulo", bill: "bill1"}, {id: 5, name: "TTT", bill: "bill1"}];
    
    const indexOfLastInvoice = currentPage * invoicesPerPage;
    const indexOfFirstInvoice = indexOfLastInvoice - invoicesPerPage;
    const currentInvoices = invoices.slice(indexOfFirstInvoice,indexOfLastInvoice);

    const paginate = (pageNumber: number) => setCurrentPage(pageNumber);

    
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
            {invoices.length > 0 ? (currentInvoices.map((invoice) => (
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
      ): (
        <b>No found invoices</b>
      )}
            </div>
          <PaginationComponent
            invoicesPerPage={invoicesPerPage}
            totalInvoices={invoices.length}
            paginate={paginate}
            currentPage={currentPage}
          />
        </div>
    );
}

export default HomePage;