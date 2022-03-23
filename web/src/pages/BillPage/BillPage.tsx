import {useGetApiBillBillId} from "../../api/bill/bill";

export interface BillPageProps {
    id: string;
}

function BillPage(props: BillPageProps) {
    const { data } = useGetApiBillBillId(props.id);
    return (
        <div>
            <h1>BillPage</h1>
            <p>Issued At: {data?.data.issuedAt}</p>
            <p>Amount: {data?.data.amount}</p>
        </div>
    );
}

export default BillPage;