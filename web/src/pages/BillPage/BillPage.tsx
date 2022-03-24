import {Bill} from "../../api/api.schemas";
import moment from "moment";

export interface BillPageProps {
    bill: Bill;
}

function BillPage(props: BillPageProps) {

    return (
        <div>
            <h1 style={{ textAlign: "justify" }}>#{props.bill.id}</h1>
            <p><b>Issued At:</b> {moment(props.bill.issuedAt).format("DD/MM/YYYY")}</p>
            <p><b>Amount:</b> £{props.bill.amount}</p>
        </div>
    );
}

export default BillPage;