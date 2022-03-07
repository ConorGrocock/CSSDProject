export interface InvoicePageProps {
  invoiceId: number;
}

function InvoicePage(props: InvoicePageProps) {
  return (
    <div>
      <h1>Invoice Page</h1>
      <p>Invoice ID: {props.invoiceId}</p>
    </div>
  );
}

export default InvoicePage;