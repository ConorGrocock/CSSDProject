import React from "react";
import checkMark from "../../assets/checkmark.png"
import {useTranslation} from "react-i18next";

const ConfirmationPage = () => {
    const {t} = useTranslation(["translations", "confirmation"]);

    return(
        <div>
            <h2><b>{t("confirmation:confirm-title")}</b></h2>
            <h5>InvoiceID: #162313</h5>
            <div className="d-flex justify-content-around pt-4">
                <div>
                    <img src={checkMark} style={{width: 700, height: 400}}/>
                </div>
                <div className="pt-5">
                    <p style={{fontSize:34, textAlign: "center"}}>{t("confirmation:confirm-subtitle")}</p>
                </div>
            </div>
            <div className="d-flex justify-content-between pt-5">
                <button className="btn btn-info" style={{color: "white", width: "5em", height: "3em"}}>{t("translations:button-back")}</button>
                <h4><i>{t("translations:company-name")}</i></h4>
            </div>
        </div>
    );
}

export default ConfirmationPage;