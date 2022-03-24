import {UserContext} from "../../Contexts/UserContext";
import {useContext, useEffect} from "react";
import {useNavigate} from "react-router-dom";
import * as React from "react";

export interface RequireAuthProps {
    children: React.ReactElement;
}

function RequireAuth(props: RequireAuthProps): React.ReactElement {
    const {user} = useContext(UserContext);

    const navigate = useNavigate();

    useEffect(() => {
        if (user === undefined) {
            navigate("/", {replace: true});
        }
    }, [user, navigate]);

    if (user) {
        return props.children;
    }
    return <>
        Loading...
    </>;
}

export default RequireAuth;