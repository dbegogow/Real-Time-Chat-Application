import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import Lobby from './components/Lobby';

const App = () => {
    return (
        <div className="app">
            <h2>MyChat</h2>
            <hr className="line" />
            <Lobby joinRoom={joinRoom} />
        </div>
    );
};

export default App;
