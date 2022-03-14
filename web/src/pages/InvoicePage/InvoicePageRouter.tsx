import {useParams} from "react-router";
import {useGetApiInvoiceInvoiceId} from "../../api/invoice/invoice";
import {Invoice} from "../../api/api.schemas";

function InvoicePage() {
    const { invoiceId } = useParams();
    const { data: invoice } = useGetApiInvoiceInvoiceId(invoiceId ? invoiceId : '');
    if(!invoice) {
        return <div>Loading...</div>;
    }

    return (
        <InvoicePage invoice={invoice} />
    )
}

export default InvoicePage;