
const ConnectedUsers = ({ users }) => {
    return (
        <div className="user-list">
            <h4>Connected Users</h4>

            {
                users.map((u, i) =>
                    <h6 key={i}>{u}</h6>)
            }
        </div>
    );
};

export default ConnectedUsers;