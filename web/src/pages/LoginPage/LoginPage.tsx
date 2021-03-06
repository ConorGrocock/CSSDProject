import React, {FormEvent, useContext, useEffect, useState} from "react";
import {useNavigate} from "react-router-dom"
import {Form, Button} from "react-bootstrap"
import { usePostApiAuthRequest } from "../../api/auth/auth";
import { PostApiAuthRequestParams } from "../../api/api.schemas";
import logo from "../../assets/road.png"
import {useTranslation} from "react-i18next";
import {UserContext} from "../../Contexts/UserContext";

const LoginPage = () => {

    const {t} = useTranslation("login");
    const [loggingIn, setLoggingIn] = useState(false);
    const {user} = useContext(UserContext);


    const navigate = useNavigate();
    
    const onSuccess = () => {
        setLoggingIn(true)
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

    useEffect(() => {
        if(user){
            navigate("/home")
        }
    }, [user, navigate])

    return(
        <div className="d-flex justify-content-center">
            <div className="w-25">
                { loggingIn && <div>{t("login:login_message")}</div>}
                <Form onSubmit={handleLogin}>
                    <Form.Group className="mb-3">
                        <Form.Label style={{fontSize: 20}}>{t("login:email_label")}</Form.Label>
                        <Form.Control size="lg" type="email" name="email" placeholder={t("login:email_placeholder")} required/>
                    </Form.Group>
                    <div className="d-flex justify-content-center">
                    <Button style={{width: 120, height: 40}} variant="primary" type="submit">
                        {t('login:button')}
                    </Button>
                    </div>
                </Form>
            </div>
            <img src={logo} style={{position: "absolute", width: 300, height: 300, marginTop: 300}}  alt={"Nortol Logo"}/>
        </div>
        
    )
}


export default LoginPage;