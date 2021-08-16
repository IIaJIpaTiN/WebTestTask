import React from 'react';
import User from "./User";

const UserList = ({users, updateUsers, editUser}) => {
    if (users.length == 0) {
        return (
            <div>
                <h3>Загрузка</h3>
            </div>
        )
    }
    return (
        <div className="userList">
            {users.map(user => <User user = {user} update={updateUsers} key={user.id} edit={editUser}/> )}
        </div>
    );
};

export default UserList;