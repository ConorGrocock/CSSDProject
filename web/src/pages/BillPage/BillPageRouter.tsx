import {useParams} from "react-router-dom";
import BillPage from "./BillPage";
import {useGetApiBillBillId} from "../../api/bill/bill";

function BillPageRouter() {
    const {billId} = useParams();
    const { data, isLoadingError } = useGetApiBillBillId(billId ?? "");

    if(!isLoadingError && data) {
        const bill = data.data;
        return <BillPage bill={bill}/>
    }
    else {
        return <div>{billId} Not found</div>
    }
}

export default BillPageRouter;