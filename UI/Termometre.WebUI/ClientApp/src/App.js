import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";
import React, { useEffect, useState } from "react";

const App = () => {
    const [connection, setConnection] = useState();
    const [inputText, setInputText] = useState("asdas");

    useEffect(() => {
        const connect = new HubConnectionBuilder()
            .withUrl("http://localhost:5000/myhub")
            .withAutomaticReconnect()//ba�lant� var ancak koptu�u anlarda kullan�l�r
            .build();

        setConnection(connect);
    }, []);

    useEffect(() => {
        if (connection) {
            connection
                .start()
                .then(() => {
                    connection.on("receiveMessage", (message) => {
                        /// TODO: Mesaj geldiginde API istek at�lacak
                    });
                })
                .catch((error) => console.log(error));
        }
    }, [connection]);

    return (
        <>
            <label>{inputText}</label>
        </>
    );
};

export default App;