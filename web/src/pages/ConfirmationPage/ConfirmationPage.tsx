import React from "react";
import checkMark from "../../assets/checkmark.png"

const ConfirmationPage = () => {

    return(
        <div>
            <h2><b>Payment has been received</b></h2>
            <h5>InvoiceID: #162313</h5>
            <div className="d-flex justify-content-around pt-4">
                <div>
                    <img src={checkMark} style={{width: 700, height: 400}}></img>
                </div>
                <div className="pt-5">
                    <p style={{fontSize:34, textAlign: "center"}}>You will soon receive an email with payment confirmation details. Thank you</p>
                </div>
            </div>
            <div className="d-flex justify-content-between">
                <button className="btn btn-info" style={{color: "white"}}>Back</button>
                <h4><i>The Nordic Department of Transport</i></h4>
            </div>
        </div>
    );
}

export default ConfirmationPage;