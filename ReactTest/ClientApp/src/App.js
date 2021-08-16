import './App.css';
import React, {useEffect, useState} from "react";
import InputForm from "./components/InputForm";
import User from "./components/User";
import userImg from './components/default-user.png';
import ModelBlock from "./components/ModelBlock";
import UserList from "./components/UserList";
import addIcon from './icons/add.png';
import axios from "axios";

function App() {

    const [users, setUsers] = useState([])
    const [modal, setModal] = useState(false)

    const [editUserData, setEditUser] = useState(null)
    const [isEdit, setEdit] = useState(false)

    const url = "https://localhost:44365/api/users/"

    useEffect(fetchUsers, [])

    async function fetchUsers() {
        const response = await axios.get(url)
        console.log("Запрос")
        console.log(response)
        console.log(users)
        setUsers(response.data)
    }

    function editUser(user) {
        setEditUser(user)
        setEdit(true)
        setModal(true)
    }

    return (
        <div className="App">
            <h1>Список пользователей</h1>
            <button className="addButton" onClick={() => setModal(true)}><img src={addIcon}/></button>
            <ModelBlock isVisible={modal} setVisible={setModal} setEdit={setEdit}>
                <InputForm updateUsers={fetchUsers} setModal={setModal} userDate={editUserData} edit={isEdit} setEdit={setEdit}/>
            </ModelBlock>
            <UserList users={users} updateUsers={fetchUsers} editUser={editUser}/>
        </div>
    );
}

export default App;
