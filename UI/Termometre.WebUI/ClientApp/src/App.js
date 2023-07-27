
import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";
import React, { useEffect, useState } from "react";
interface obj {
    id: Number, tempreture: Number

}
const App = () => {
    const [connection, setConnection] = useState();
    const [inputText, setInputText] = useState([]);

    useEffect(() => {
        getData();

        const connect = new HubConnectionBuilder()
            .withUrl("http://localhost:5000/myhub")
            .withAutomaticReconnect() // baðlantý var ancak koptuðu anlarda kullanýlýr
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
        // API isteði atýlýp son durum çekilecek
        fetch("http://localhost:5000/api/Values/getDataFromAPI", {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
            },
        })
            .then((response) => response.json())
            .then((data) => {
                // API'den gelen sonuçlarý kullan, örneðin:
                console.log("API'den gelen sonuçlar:", data);
                // Sonuçlarý kullanmak için burada uygun iþlemleri yapabilirsiniz.
                setInputText(data); // Örnek olarak gelen mesajý inputText olarak ayarladýk
            })
            .catch((error) => {
                console.error("API isteði sýrasýnda hata oluþtu:", error);

            });
    };

    return (
        <>
            {
                inputText.map((row, index) => (
                    <p key={row.id}>{row.tempreture}</p>
                    )
                )
            }
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
//            .withAutomaticReconnect()//baðlantý var ancak koptuðu anlarda kullanýlýr
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
//        // API istek atýlýp son durum çekilecek
//    }


//    return (
//        <>
//            <label>{inputText}</label>
//        </>
//    );
//};

//export default App;