import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";
import React, { useEffect, useState } from "react";

const App = () => {
    const [connection, setConnection] = useState();
    const [inputText, setInputText] = useState("asdas");

    useEffect(() => {
        const connect = new HubConnectionBuilder()
            .withUrl("http://localhost:5000/myhub")
            .withAutomaticReconnect()//baðlantý var ancak koptuðu anlarda kullanýlýr
            .build();

        setConnection(connect);
    }, []);

    useEffect(() => {
        if (connection) {
            connection
                .start()
                .then(() => {
                    connection.on("receiveMessage", (message) => {
                        /// TODO: Mesaj geldiginde API istek atýlacak
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