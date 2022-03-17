import React from "react";
import { Pagination } from "react-bootstrap";

const PaginationComponent = ({
  invoicesPerPage,
  totalInvoices,
  paginate,
  currentPage,
}:{invoicesPerPage: number, totalInvoices: number, paginate: (a: number) => void, currentPage: number}) => {
  const pageNumber = [];

  for (let i = 1; i <= Math.ceil(totalInvoices / invoicesPerPage); i++) {
    pageNumber.push(i);
  }

  return (
    <div className="d-flex justify-content-center">
      <Pagination>
        {pageNumber.map((number) => (
          <Pagination.Item
            key={number}
            active={number === currentPage}
            onClick={() => paginate(number)}
          >
            {number}
          </Pagination.Item>
        ))}
      </Pagination>
    </div>
  );
};

export default PaginationComponent;
