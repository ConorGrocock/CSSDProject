import {createContext} from "react";

export interface User {
    aud: string
    exp: string
    iss: string
    name: string
    role: string
    sub: string
}

export interface UserContextType {
    user: User | null;
    setUser: (user: User | null) => void;
}

export const UserContext = createContext<UserContextType>({
    user: null,
    setUser: () => {}
});

export const UserProvider = UserContext.Provider;
export const UserConsumer = UserContext.Consumer;
