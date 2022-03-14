import {Invoice} from "../../api/api.schemas";

export interface InvoicePageProps {
    invoice: Invoice | undefined;
}

function InvoicePage(props: InvoicePageProps) {
    return (
        <h1>Invoice: {props.invoice?.id}</h1>
    )
}

export default InvoicePage;