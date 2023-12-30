import React, { createContext, useContext, useState, ReactNode } from "react";
import * as api from '../../apis/CrunchiVoteApi';

interface AuthContextType {
  token: string | null;
  isAuthenticated: boolean;
  login: (username: string, password: string) => void;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

interface AuthProviderProps {
  children: ReactNode;
}

export const AuthProvider: React.FC<AuthProviderProps> = ({ children }) => {
  const [token, setToken] = useState<string | null>(null);
  const [isAuthenticated, setIsAuthenticated] = useState(false);

  const login = async (username: string, password: string) => {
    try {
      const authData = await api.authenticate(username, password);

      setToken(authData.accessToken);
     
      setIsAuthenticated(true);
    } catch (error) {

      console.error("Authentication error:", error);
    }
  };

  return (
    <AuthContext.Provider value={{ token, isAuthenticated, login }}>
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => {
  const context = useContext(AuthContext);
  if (!context) {
    throw new Error("useAuth must be used within an AuthProvider");
  }
  return context;
};
