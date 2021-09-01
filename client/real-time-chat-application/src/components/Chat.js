import MessageContainer from "./MessageContainer";

const Chat = ({ messages, sendMessage }) => {
    return (
        <div>
            <div className="chat">
                <MessageContainer messages={messages} />
            </div>
        </div>
    );
};

export default Chat;