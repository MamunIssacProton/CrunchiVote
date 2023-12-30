import React from 'react';
import logo from './logo.svg';
import './App.css';
import { AuthProvider } from './Components/Auth/AuthContext';
import Articles from './Components/Articles';

const App: React.FC = () => {
  return (
    <div className="App">
    <AuthProvider>
         <Articles />
    </AuthProvider>
   

    </div>
  );
};
export default App;
