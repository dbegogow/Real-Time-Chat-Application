import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import Lobby from './components/Lobby';

const App = () => {
    const joinRoom = async (user, room) => {
        try {
            const connection = new HubConnectionBuilder()
                .withUrl('https://localhost:5001/chat')
                .configureLogging(LogLevel.Information)
                .build();

            connection.on("ReceiveMessage", (user, message) => {
                console.log('message received: ', message);
            });
        } catch (e) {
            console.log(e);
        }
    };

    return (
        <div className="app">
            <h2>MyChat</h2>
            <hr className="line" />
            <Lobby joinRoom={joinRoom} />
        </div>
    );
};

export default App;
