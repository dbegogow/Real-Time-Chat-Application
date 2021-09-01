import MessageContainer from "./MessageContainer";

const Chat = ({ messages }) => {
    return (
        <div>
            <div className="chat">
                <MessageContainer messages={messages} />
            </div>
        </div>
    );
};

export default Chat;