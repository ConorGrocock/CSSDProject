import {useParams} from "react-router-dom";
import BillPage from "./BillPage";

function BillPageRouter() {
    const {billId} = useParams();

    if(billId !== undefined) {
        return <BillPage id={billId}/>
    }
    else {
        return <div>No bill selected</div>
    }
}

export default BillPageRouter;