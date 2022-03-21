import { userInfo } from "os";
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

  const onReview = () => {
        navigate("/home");
        window.location.reload();
  }

  interface User {
      id: number;
      email: string;
      role: string;
  }

  const users : User[]=[{id: 1, email: "user@user.com", role: "driver"}]

  interface Invoice {
      id: number;
      name: string;
      rfid: string;
      distance: number;
      price: number;
  }

  const invoices : Invoice[]= [{id: 1, name: "Rob Smith", rfid:"512412", distance: 84, price: 13.4}, {id: 2, name: "Frank Will", rfid:"172842", distance: 43, price: 6.4}, {id: 3, name: "John Kent", rfid:"917364", distance: 64, price: 9.7}, {id: 4, name: "Fran Pauls", rfid:"862743", distance: 102, price: 16.5},{id: 5, name: "Ben Hummer", rfid:"358465", distance: 10.4, price: 3.1}];
  
  const indexOfLastInvoice = currentPage * invoicesPerPage;
  const indexOfFirstInvoice = indexOfLastInvoice - invoicesPerPage;
  const currentInvoices = invoices.slice(indexOfFirstInvoice,indexOfLastInvoice);

  const paginate = (pageNumber: number) => setCurrentPage(pageNumber);

    
  return(
      <div>

      {users[0].role === "driver" ? (
        <div>
          <h1 className="display-5">Welcome, here are all your invoices</h1>
          <hr></hr>
          <div>
            <div className="d-flex justify-content-between">
              <h4><b>Invoice ID</b></h4>
              <h4><b>RFID Tag</b></h4>
              <h4><b>Distance</b></h4>
              <h4><b>Price</b></h4>
              <b></b>
            </div>
            <hr></hr>
          </div>
          {invoices.length > 0 ? (currentInvoices.map((invoice) => (
            <div key={invoice.id}>
              <div className="d-flex justify-content-between">
                <div>
                  <h5>
                    #{invoice.id}⠀⠀⠀⠀⠀⠀
                  </h5>
                </div>
                <div>
                  <h5>
                    {invoice.rfid}⠀⠀⠀⠀⠀⠀
                  </h5>
                </div>
                <div>
                  <h5>
                    {invoice.distance} kms⠀⠀⠀⠀
                  </h5>
                </div>
                <div>
                  <h5>
                   {invoice.price}€
                  </h5>
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
        <b>No invoices found</b>
        )}
        </div>
      ):(
        <div>
          <h1 className="display-5">Welcome Operator here are all invoices</h1>
          <hr></hr>
          <div>
            <div className="d-flex justify-content-between">
              <h4><b>Name</b></h4>
              <h4><b>RFID Tag</b></h4>
              <h4><b>Distance</b></h4>
              <h4><b>Price</b></h4>
              <b></b>
            </div>
            <hr></hr>
          </div>
          {invoices.length > 0 ? (currentInvoices.map((invoice) => (
            <div key={invoice.id}>
              <div className="d-flex justify-content-between">
                <div>
                  <h5>
                    {invoice.name}
                  </h5>
                  
                </div>
                <div>
                  <h5>
                    {invoice.rfid}
                  </h5>
                </div>
                <div>
                  <h5>
                    {invoice.distance} kms
                  </h5>
                </div>
                <div>
                  <h5>
                   {invoice.price}€
                  </h5>
                </div>
                <div>
                    <button className="btn btn-info" onClick={() => onReview()}>Review</button>
                </div>
              </div>
              <hr></hr>
            </div>
            )
          )
        ) : (
        <b>No invoices found</b>
        )}
        </div>
      )}

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