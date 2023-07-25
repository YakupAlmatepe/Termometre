import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
        <div>

            <title></title>
            <script>
                $(document).ready())=>{
                    const connection = new signalR.HubConnectionBuilder()
                    .withUrl(""http://*:5000/"")
                       .build();
                conncection.start();
               .then=> $("h4").html(connection.connectionId)

                connection.on("receiveMessage", message => {
                    alert(message);
                    return "Client Result";
                });
                });
            </script>
        </div>
    );
  }
}
           
