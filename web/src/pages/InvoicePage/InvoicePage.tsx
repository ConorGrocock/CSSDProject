import {useGetApiInvoice, useGetApiInvoiceId} from "../../api/invoice/invoice";

export interface InvoicePageProps {
  invoiceId: number;
}

function InvoicePage(props: InvoicePageProps) {
    const {data, isLoading, isError} = useGetApiInvoiceId(props.invoiceId);

  return (
    <div>
      <h1>Invoice Page</h1>
      <p>Invoice ID: {data?.data}</p>
    </div>
  );
}

export default InvoicePage;