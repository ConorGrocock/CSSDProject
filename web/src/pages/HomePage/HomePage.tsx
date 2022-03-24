import React, {useContext} from "react";
import {useNavigate} from "react-router-dom";
import {useTranslation} from "react-i18next";
import {useGetApiInvoice} from "../../api/invoice/invoice";
import {Invoice} from "../../api/api.schemas";
import {UserContext} from "../../Contexts/UserContext";
import moment from "moment";


const HomePage = () => {
    const navigate = useNavigate();
    const {user} = useContext(UserContext);
    const {t} = useTranslation(["translations", "home"]);
    const {data} = useGetApiInvoice();

    const onPay = () => {
        navigate("/payment");
        window.location.reload();
    }
    const onView = (id: string | undefined) => {
        navigate(`/invoice/${id}`);
    }

    return (
        <div>
            <h1 className="display-5">{t("home:welcome-text")}</h1>
            <hr/>
            <div>
                <div className="d-flex justify-content-between">
                    {user?.role != "Driver" &&
                        <div><h4><b>{t("home:table-name")}</b></h4></div>}
                    <div><h4><b>{t("home:table-issued-at")}</b></h4></div>
                    <div><h4><b>{t("home:table-price")}</b></h4></div>
                    <div><h4><b>{t("home:table-bills")}</b></h4></div>
                    <div><h4><b>{t("home:table-action")}</b></h4></div>
                </div>
                <hr/>
                {data?.data.map((invoice: Invoice) => (
                        <div key={invoice.id}>
                            <div className="d-flex justify-content-between">
                                {user?.role !== "Driver" &&
                                    <h4>
                                        {invoice.account?.name}
                                    </h4>}
                                <h4>
                                    {moment(invoice.issuedAt).format("DD/MM/YYYY")}
                                </h4>
                                <h4>
                                    {t("translations:table-currency")}{invoice.amount?.toFixed(2)}
                                </h4>
                                <div>
                                    {invoice.bills?.length}
                                </div>
                                <div>
                                    {invoice.account?.id === user?.id && <button className="btn btn-success"
                                             onClick={() => onPay()}>{t("home:table-action-pay")}</button>}
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