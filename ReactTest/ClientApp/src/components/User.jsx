import React from 'react';
import userImg from './default-user.png';
import axios from "axios";
import editIcon from "../icons/edit.png"
import deletIcon from "../icons/delet.png"

const User = ({user , update, edit}) => {

    async function deleteUser () {
        await axios.delete("https://localhost:44365/api/users/" + user.id, { data: user })
        update()
    }

    return (
        <div className= "user">
            <img src = {user.dateUrl}/>
            <div>
                <h3>Имя: {user.name}</h3>
                <h3>Почта: {user.mail}</h3>
                <h3>Пароль: {user.password}</h3>
                <h3>Дата рождения: {user.birthday}</h3>
            </div>
            <div className="buttonContainer">
                <button onClick={() => {edit(user)}}><img src={editIcon}/></button>
                <button onClick={deleteUser}><img src={deletIcon}/></button>
            </div>
        </div>
    );
};

export default User;