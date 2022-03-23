import {usePostApiAuthVerify} from "../../api/auth/auth";
import {useParams} from "react-router";
import {decodeJwt, jwtDecrypt} from "jose";
import {useEffect} from "react";

export interface AuthPageProps {
}

function AuthPage(props: AuthPageProps) {
    const {token} = useParams();
    const {mutate} = usePostApiAuthVerify({mutation: {
        onSuccess
        }});

    if(token === undefined) {
        return <div>Invalid token</div>
    }

    useEffect(() => {
        mutate({params: {
                token
            }})
    })

    function onSuccess(data: any) {
        const {token} = data;
        const decoded = decodeJwt(token);
        console.log(decoded);
    }

    return (
        <h1>Authenticating</h1>
    );
}

export default AuthPage;