import React from 'react';
import logo from './logo.svg';
import './App.css';
import { Provider } from 'react-redux';

import { AuthProvider } from './Components/Auth/AuthContext';

import { store } from './Store';
import ArticleList from './Components/Articles/ArticleList';

const App: React.FC = () => {
  return (
    <div className="App">
    <AuthProvider>
      <Provider store={store}>
                <ArticleList></ArticleList>
      </Provider>

    </AuthProvider>
   

    </div>
  );
};
export default App;
