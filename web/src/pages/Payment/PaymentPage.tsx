import React from "react";
import {Form, Button} from "react-bootstrap"
import {useNavigate} from "react-router-dom"
import {useTranslation} from "react-i18next";

const PaymentPage = () => {

    const navigate = useNavigate();
    const { t, i18n } = useTranslation("payment");

    const handlePayment = () => {
        navigate("/home");
        window.location.reload();
    }
    
    return(
        <div className="d-flex justify-content-center pt-3">
            <div className="w-50">
                <Form onSubmit={handlePayment}>
                    <Form.Group className="mb-3">
                        <Form.Label className="pt-4" style={{fontSize: 20}}>{t("payment:card_holder_name_label")}</Form.Label>
                        <Form.Control size="lg" type="string" name="name" placeholder={t("payment:card_holder_name_placeholder")} required/>
                        <Form.Label className="pt-4" style={{fontSize: 20}}>{t("payment:card_number_label")}</Form.Label>
                        <Form.Control size="lg" type="number" name="cardNumber" placeholder={t("payment:card_number_placeholder")} required/>
                        <div className="d-flex justify-content-between pt-4">
                            <div>
                                <Form.Label style={{fontSize: 20}}>{t("payment:card_expiry_label")}</Form.Label>
                                <Form.Control size="lg" type="date" name="date" required/>
                            </div>
                            <div>
                                <Form.Label style={{fontSize: 20}}>{t("payment:card_ccv")}</Form.Label>
                                <Form.Control size="lg" type="number" name="number" max="999" placeholder={t("payment:card_ccv_placeholder")} required/>
                            </div> 
                        </div>
                    </Form.Group>
                    <div className="d-flex justify-content-between pt-4">
                    <Button style={{width: "10em", height: "3em"}} variant="danger" type="submit"> 
                        Cancel
                    </Button>
                    <Button style={{width: "10em", height: "3em"}} variant="success" type="submit"> 
                        Pay
                    </Button>
                    </div>
                </Form>
            </div>
        </div>
    );
}

export default PaymentPage;