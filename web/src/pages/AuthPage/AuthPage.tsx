import {usePostApiAuthVerify} from "../../api/auth/auth";
import {useParams} from "react-router";
import {decodeJwt} from "jose";
import {useContext, useEffect} from "react";
import {User, UserContext} from "../../Contexts/UserContext";
import {useNavigate} from "react-router-dom";

function AuthPage() {
    const {token} = useParams();
    const navigate = useNavigate()
    const {setUser} = useContext(UserContext)
    const {mutate} = usePostApiAuthVerify({
        mutation: {
            onSuccess
        }
    });


    useEffect(() => {
        mutate({
            params: {
                token
            }
        })
    }, [token, mutate])

    if (token === undefined) {
        return <div>Invalid token</div>
    }

    function onSuccess(data: any) {
        const {token} = data.data;
        const decoded = decodeJwt(token);

        const user: User = {
            name: decoded.name as string,
            role: decoded.role as string,
            id: decoded.sub as string,
            token: token as string
        }

        setUser(user)
        navigate("/home")
    }

    return (
        <h1>Authenticating</h1>
    );
}

export default AuthPage;