import {usePostApiAuthVerify} from "../../api/auth/auth";
import {useParams} from "react-router";
import {decodeJwt, jwtDecrypt} from "jose";
import {useEffect} from "react";

export interface AuthPageProps {
}

function AuthPage(props: AuthPageProps) {
    const {token} = useParams();
    const {mutate} = usePostApiAuthVerify();

    if(token === undefined) {
        return <div>Invalid token</div>
    }

    useEffect(() => {
        mutate({params: {
                token
            }})
    })

    return (
    );
}

export default AuthPage;