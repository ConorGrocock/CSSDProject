import {Invoice} from "../../api/api.schemas";
import moment from "moment";

export interface BillPageProps {
    amount?: number;
    issuedAt?: string;
    invoice?: Invoice;
}

function BillPage(props: BillPageProps) {
    return (
        <div>
            <h1>BillPage</h1>
            <p>Issued At: {moment(props.issuedAt).format("DD/MM/YYYY")}</p>
            <p>Amount: £{props.amount}</p>
            <p>Invoice: {props.invoice?.id}</p>
        </div>
    );
}

export default BillPage;