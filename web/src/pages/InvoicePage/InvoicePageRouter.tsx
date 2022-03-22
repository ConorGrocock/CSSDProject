import {useParams} from "react-router";
import {useGetApiInvoiceInvoiceId} from "../../api/invoice/invoice";
import InvoicePage from "./InvoicePage";

function InvoicePageRouter() {
    const { invoiceId } = useParams();
    const { data: invoice } = useGetApiInvoiceInvoiceId(invoiceId ? invoiceId : '');
    if(!invoice) {
        return <div>Loading...</div>;
    }

    return <InvoicePage invoice={invoice.data} />

}

export default InvoicePageRouter;