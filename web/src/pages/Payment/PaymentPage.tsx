import React from "react";
import {Form, Button} from "react-bootstrap"
import {useNavigate} from "react-router-dom"

const PaymentPage = () => {

    const navigate = useNavigate();

    const handlePayment = () => {
        navigate("/home");
        window.location.reload();
    }
    
    return(
        <div className="d-flex justify-content-center pt-3">
            <div className="w-50">
                <Form onSubmit={handlePayment}>
                    <Form.Group className="mb-3">
                        <Form.Label className="pt-4" style={{fontSize: 20}}>Card-Holder Name</Form.Label>
                        <Form.Control size="lg" type="string" name="name" placeholder="Card-Holder Name..." required/>
                        <Form.Label className="pt-4" style={{fontSize: 20}}>Card Number</Form.Label>
                        <Form.Control size="lg" type="number" name="cardNumber" placeholder="Enter card number..." required/>
                        <div className="d-flex justify-content-between pt-4">
                            <div>
                                <Form.Label style={{fontSize: 20}}>Expiring Date</Form.Label>
                                <Form.Control size="lg" type="date" name="date" placeholder="Enter date..." required/>
                            </div>
                            <div>
                                <Form.Label style={{fontSize: 20}}>Security Code</Form.Label>
                                <Form.Control size="lg" type="number" name="number" max="999" placeholder="Enter code..." required/>
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