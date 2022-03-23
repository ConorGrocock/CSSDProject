import {usePostApiAuthVerify} from "../../api/auth/auth";
import {useParams} from "react-router";
import {decodeJwt, jwtDecrypt} from "jose";
import {useContext, useEffect} from "react";
import {User, UserConsumer, UserContext} from "../../Contexts/UserContext";
import {useNavigate} from "react-router-dom";

export interface AuthPageProps {
}

function AuthPage(props: AuthPageProps) {
    const {token} = useParams();
    const navigate = useNavigate()
    const {setUser} = useContext(UserContext)
    const {mutate} = usePostApiAuthVerify({mutation: {
        onSuccess
        }});


    useEffect(() => {
        mutate({params: {
                token
            }})
    }, [token]);

    if(token === undefined) {
        return <div>Invalid token</div>
    }

    function onSuccess(data: any) {
        const {token} = data.data;
        const decoded = decodeJwt(token);
        setUser(decoded as unknown as User)
        navigate("/home")
    }

    return (
        <h1>Authenticating</h1>
    );
}

export default AuthPage;