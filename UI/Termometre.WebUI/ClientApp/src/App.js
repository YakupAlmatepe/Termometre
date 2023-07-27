
import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";
import React, { useEffect, useState } from "react";

const App = () => {
    const [connection, setConnection] = useState();
    const [inputText, setInputText] = useState("asdas");

    useEffect(() => {
        getData();

        const connect = new HubConnectionBuilder()
            .withUrl("http://localhost:5000/myhub")
            .withAutomaticReconnect() // ba�lant� var ancak koptu�u anlarda kullan�l�r
            .build();

        setConnection(connect);
    }, []);

    useEffect(() => {
        if (connection) {
            connection
                .start()
                .then(() => {
                    connection.on("receiveMessage", (message) => {
                        getData();
                    });
                })
                .catch((error) => console.log(error));
        }
    }, [connection]);

    const getData = () => {
        // API iste�i at�l�p son durum �ekilecek
        fetch("http://localhost:5000/api/getDataFromAPI", {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
            },
        })
            .then((response) => response.json())
            .then((data) => {
                // API'den gelen sonu�lar� kullan, �rne�in:
                console.log("API'den gelen sonu�lar:", data);
                // Sonu�lar� kullanmak i�in burada uygun i�lemleri yapabilirsiniz.
                setInputText(data.message); // �rnek olarak gelen mesaj� inputText olarak ayarlad�k
            })
            .catch((error) => {
                console.error("API iste�i s�ras�nda hata olu�tu:", error);
            });
    };

    return (
        <>
            <label>{inputText}</label>
        </>
    );
};

export default App;






//import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";
//import React, { useEffect, useState } from "react";

//const App = () => {
//    const [connection, setConnection] = useState();
//    const [inputText, setInputText] = useState("asdas");

//    useEffect(() => {
//        getData();

//        const connect = new HubConnectionBuilder()
//            .withUrl("http://localhost:5000/myhub")
//            .withAutomaticReconnect()//ba�lant� var ancak koptu�u anlarda kullan�l�r
//            .build();

//        setConnection(connect);
//    }, []);

//    useEffect(() => {
//        if (connection) {
//            connection
//                .start()
//                .then(() => {
//                    connection.on("receiveMessage", (message) => {
//                        getData();
//                    });
//                })
//                .catch((error) => console.log(error));
//        }
//    }, [connection]);

//    const getData = () => {
//        // API istek at�l�p son durum �ekilecek
//    }


//    return (
//        <>
//            <label>{inputText}</label>
//        </>
//    );
//};

//export default App;