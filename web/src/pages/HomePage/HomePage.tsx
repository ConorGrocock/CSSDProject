import React from "react";
import {useNavigate} from "react-router-dom";
import {useTranslation} from "react-i18next";


const HomePage = () => {

    const navigate = useNavigate();
    const {t} = useTranslation("home");

    const onPay = () => {
        navigate("/payment");
        window.location.reload();
    }

    interface Invoice {
        id: number;
        name: string;
        bill: string;
    }

    const invoices: Invoice[] = [{id: 1, name: "Rob", bill: "bill"}, {id: 2, name: "Matt", bill: "bill1"}, {
        id: 3,
        name: "Frank",
        bill: "bill3"
    }];

    console.log(invoices)
    return (
        <div>
            <h1 className="display-5">{t("home:welcome-text")}</h1>
            <div className="pt-3">
                <form className="d-flex form-inline my-2 my-lg-0">
                    <input className="form-control mr-sm-2" type="search" placeholder={t("home:search-placeholder")}
                           aria-label={t("home:search-label")}/>
                    <button className="btn btn-outline-success my-2 my-sm-0 bg-light">{t("home:search-text")}</button>
                </form>
            </div>
            <hr/>
            <div>
                <div className="d-flex justify-content-between">
                    <div><h4><b>{t("home:table-name")}</b></h4></div>
                    <div><h4><b>{t("home:table-rfid")}</b></h4></div>
                    <div><h4><b>{t("home:table-distance")}</b></h4></div>
                    <div><h4><b>{t("home:table-action")}</b></h4></div>
                </div>
                <hr/>
                {invoices.length > 0 ? (invoices.map((invoice) => (
                            <div key={invoice.id}>
                                <div className="d-flex justify-content-between">
                                    <div>
                                        <h4>
                                            {invoice.name}
                                        </h4>

                                    </div>
                                    <div>
                                        <h4>
                                            12312
                                        </h4>
                                    </div>
                                    <div>
                                        <h4>
                                            {invoice.bill}
                                        </h4>
                                    </div>
                                    <div>
                                        <button className="btn btn-success" onClick={() => onPay()}>{t("home:table-action-pay")}</button>
                                    </div>
                                </div>
                                <hr></hr>
                            </div>
                        )
                    )
                ) : (
                    <b>
                        {t("home:table-empty")}
                        <hr></hr>
                    </b>
                )}
            </div>
        </div>
    );
}

export default HomePage;