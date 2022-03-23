import {useParams} from "react-router-dom";
import BillPage from "./BillPage";
import {useGetApiBillBillId} from "../../api/bill/bill";

function BillPageRouter() {
    const {billId} = useParams();
    const { data, isLoadingError } = useGetApiBillBillId(billId ?? "");

    if(!isLoadingError && data) {
        const bill = data.data;
        return <BillPage invoice={bill.invoice} amount={bill.amount} issuedAt={bill.issuedAt}/>
    }
    else {
        return <div>No bill selected</div>
    }
}

export default BillPageRouter;