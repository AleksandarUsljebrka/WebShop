
import './App.css';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';

import Register from './components/reg-log/Register';
import Login from './components/reg-log/Login';

function App(){
  return (
    <Router>
      <nav>
        <ul>
          <li>
            <Link to="/">Login</Link>
          </li>
          <li>
            <Link to="/register">Register</Link>
          </li>
          <li>
            <Link to="/contact">Contact</Link>
          </li>
        </ul>
      </nav>

      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/register" element={<Register />} />
       
      </Routes>
    </Router>
  );
};

export default App;
