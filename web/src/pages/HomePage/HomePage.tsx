import React from "react";
import {useNavigate} from "react-router-dom";
import {useTranslation} from "react-i18next";
import {useGetApiInvoice} from "../../api/invoice/invoice";
import {Invoice} from "../../api/api.schemas";


const HomePage = () => {

    const navigate = useNavigate();
    const {t} = useTranslation("home");
    const {data} = useGetApiInvoice();

    const onPay = () => {
        navigate("/payment");
        window.location.reload();
    }
    const onView = (id: string|undefined) => {
        navigate(`/invoice/${id}`);
        window.location.reload();
    }

    return (
        <div>
            <h1 className="display-5">{t("home:welcome-text")}</h1>
            <hr/>
            <div>
                <div className="d-flex justify-content-between">
                    <div><h4><b>{t("home:table-name")}</b></h4></div>
                    <div><h4><b>{t("home:table-rfid")}</b></h4></div>
                    <div><h4><b>{t("home:table-distance")}</b></h4></div>
                    <div><h4><b>{t("home:table-action")}</b></h4></div>
                </div>
                <hr/>
                {data?.data.map((invoice: Invoice) => (
                        <div key={invoice.id}>
                            <div className="d-flex justify-content-between">
                                <h4>
                                    {invoice.account?.name}
                                </h4>
                                <h4>
                                    {invoice.paymentReference !== undefined ? "Paid" : "Unpaid"}
                                </h4>
                                <div>
                                    {invoice.bills?.length}
                                </div>
                                <div>
                                    <button className="btn btn-success"
                                            onClick={() => onPay()}>{t("home:table-action-pay")}</button>
                                    <button className="btn btn-success"
                                            onClick={() => onView(invoice.id)}>{t("home:table-action-view")}</button>
                                </div>
                            </div>
                            <hr></hr>
                        </div>
                    )
                )}
            </div>
        </div>
    );
}

export default HomePage;