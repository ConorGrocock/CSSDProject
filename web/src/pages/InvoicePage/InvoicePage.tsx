import {Invoice} from "../../api/api.schemas";
import moment from "moment";

export interface InvoicePageProps {
    invoice: Invoice;
}

function InvoicePage(props: InvoicePageProps) {
    return (
        <>
            <h2>Invoice: #{props.invoice.id}</h2>
            <p><strong>Date:</strong> {moment(props.invoice.issuedAt).format("DD/MM/YYYY")}</p>
            <p><strong>Total:</strong> £{props.invoice.amount}</p>
            <hr />

            { props.invoice.account !== null && <div className={`col-4`}>
                <h3>Account</h3>
                <p><strong>Name:</strong> {props.invoice.account?.name}</p>
                <strong>Address:</strong>
                <address>
                    {props.invoice.account?.postalAddress?.line1}<br/>
                    {props.invoice.account?.postalAddress?.line2}<br/>
                    {props.invoice.account?.postalAddress?.line3}<br/>
                    {props.invoice.account?.postalAddress?.city}<br/>
                    {props.invoice.account?.postalAddress?.country}<br/>
                    {props.invoice.account?.postalAddress?.postcode}<br/>
                </address>
            </div>}

            { props.invoice.paymentConfirmationId !== null && <div className={`col-4`}>
                <h3>Payment Confirmation</h3>
                <p><strong>ID:</strong> {props.invoice.paymentConfirmationId}</p>
                <p><strong>Date:</strong> {moment(props.invoice.paymentConfirmation?.paidAt).format("DD/MM/YYYY")}</p>
            </div> }
        </>
    )
}

export default InvoicePage;