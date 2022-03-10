import React, { FormEvent, useState } from "react";
import {useNavigate} from "react-router-dom"
import {Form, Button} from "react-bootstrap"
import { usePostApiAuthRequest } from "../../api/auth/auth";
import { PostApiAuthRequestParams } from "../../api/api.schemas";
import logo from "../../assets/road.png"

const LoginPage = () => {

    const navigate = useNavigate();
    
    const onSuccess = () => {
        navigate("/home");
        window.location.reload();
    }

    const {mutate} = usePostApiAuthRequest({mutation:{onSuccess}});
    const handleLogin = (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        const {email} = e.target as typeof e.target & {
            email: {value: string}
        }
        console.log(email.value);
        const data: PostApiAuthRequestParams = {email: email.value}
        mutate({params: data});
        
    };

    return(
        <div className="d-flex justify-content-center">
            <div className="w-25">
                <Form onSubmit={handleLogin}>
                    <Form.Group className="mb-3">
                        <Form.Label style={{fontSize: 20}}>E-mail address</Form.Label>
                        <Form.Control size="lg" type="email" name="email" placeholder="Enter email..." required/>
                        <Form.Label style={{fontSize: 20}}>Password</Form.Label>
                        <Form.Control size="lg" type="password" name="email" placeholder="Enter password..." required/>
                    </Form.Group>
                    <div className="d-flex justify-content-center">
                    <Button style={{width: 120, height: 40}} variant="primary" type="submit"> 
                        Log in
                    </Button>
                    </div>
                </Form>
            </div>
            <img src={logo} style={{position: "absolute", width: 300, height: 300, marginTop: 300}}></img>
        </div>
        
    )
}


export default LoginPage;