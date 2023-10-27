import React, { useState } from "react";
import './App.css';
import LoginForm from './LoginForm';
import LoginAttemptList from './LoginAttemptList';

const App = () => {
  const [loginAttempts, setLoginAttempts] = useState(["test"]);

  return (
    <div className="App">
          <LoginForm onSubmit={({ login, password }) => {
              setLoginAttempts([...loginAttempts, login])
              console.log({ login, password })
          }} />
      <LoginAttemptList attempts={loginAttempts} />
    </div>
  );
};

export default App;
