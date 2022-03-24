import {createContext} from "react";

export interface User {
    name: string
    role: string
    id: string
    token: string
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


