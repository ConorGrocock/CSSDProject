import {Invoice} from "../../api/api.schemas";
import moment from "moment";
import {useTranslation} from "react-i18next";
import {useNavigate} from "react-router-dom";

export interface InvoicePageProps {
    invoice: Invoice;
}

function InvoicePage(props: InvoicePageProps) {
    const {t} = useTranslation(["translations", "invoice"]);
    const navigate = useNavigate();
    return (
        <>
            <h2>Invoice: #{props.invoice.id}</h2>
            <p><strong>{t("invoice:date")}:</strong> {moment(props.invoice.issuedAt).format("DD/MM/YYYY")}</p>
            <p><strong>{t("invoice:total")}:</strong> {t("translations:table-currency")}{props.invoice.amount}</p>
            <hr />

            <h3>{t("invoice:bills")}</h3>
            {props.invoice.bills?.map((item, index) => (
                <div key={index}>
                    <button onClick={() => navigate(`/bill/${item.id}`)} style={{ border: "none", background: "none", textDecoration: "underline" }}>{item.amount}</button>:{moment(item.issuedAt).format("DD/MM/YYYY")}
                </div>
            ))}

            { props.invoice.account !== null && <div className={`col-4`}>
                <h3>{t("invoice:account")}</h3>
                <p><strong>{t("invoice:name")}:</strong> {props.invoice.account?.name}</p>
                { props.invoice.postalAddress !== null && <>
                <strong>{t("invoice:address")}:</strong>
                    <address>
                {props.invoice.account?.postalAddress?.line1}<br/>
                {props.invoice.account?.postalAddress?.line2}<br/>
                {props.invoice.account?.postalAddress?.line3}<br/>
                {props.invoice.account?.postalAddress?.city}<br/>
                {props.invoice.account?.postalAddress?.country}<br/>
                {props.invoice.account?.postalAddress?.postcode}<br/>
                    </address></>}
            </div>}

            { props.invoice.paymentConfirmationId !== null && <div className={`col-4`}>
                <h3>{t("invoice:payment-confirmation")}</h3>
                <p><strong>ID:</strong> {props.invoice.paymentConfirmationId}</p>
                <p><strong>Date:</strong> {moment(props.invoice.paymentConfirmation?.paidAt).format("DD/MM/YYYY")}</p>
            </div> }
        </>
    )
}

export default InvoicePage;