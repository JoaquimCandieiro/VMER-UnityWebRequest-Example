// Exemplo de um Object com dados de um jogador
let playerData = {
    name: "Player1",
    lives: 3,
    health: 80.5
}

// Exemplo de um array composto por Objects de dados do jogador
let playerDataArray = [
    {
        name: "Player1",
        lives: 3,
        health: 80.5
    },
    {
        name: "Player2",
        lives: 2,
        health: 70
    },
    {
        name: "Player3",
        lives: 1,
        health: 35.5
    }
]

const mysql = require("mysql2");
const config = require("./config/config.json");

/**
 * Método para tratar a requisição GET para o endpoint /get-data
 * @param {Object} request
 * @param {Object} response
 */

function getData(request, response) {
    // Envia os dados do jogador em formato Json stringificado
    response.send(JSON.stringify({_playerDataInfoArray: playerDataArray}));
}

function postData(request, response) {
    // Recebe dados enviados via Unity com o auxílio da classe integrada UnityEngine.JsonUtility
    let receivedData = request.body;
    // Envia resposta de sucesso
    console.log("Received data from client: ");
    console.log(receivedData);

    let name = receivedData.name;
    console.log(`Received name: ${name}`);
    let lives = receivedData.lives;
    console.log(`Received lives: ${lives}`);
    let health = receivedData.health;
    console.log(`Received health: ${health}`);

    response.send("Data received successfully!");
}

function getDataFromDatabase(request, response) {
    const connection = mysql.createConnection(config.database);
    connection.connect();
    connection.query(
        "SELECT name, lives, health FROM player_info",
        function (error, rows, fields) {
            if (error) {
                console.log("Error fetching data from database: ", error);
                response.status(500).send("Error fetching data from database");
            }
            else {
                response.send(
                    JSON.stringify({_playerDataInfoArray: rows})
                )
            }
        }
    )
    connection.end()
}

function postDataToDatabase(request, response) {
    let receivedData = request.body
    const connection = mysql.createConnection(config.database);
    connection.connect();
    connection.query(
        `INSERT INTO (name, lives, health) VALUES(${receivedData.name}, ${receivedData.lives}, ${receivedData.health})`,
        function (error, rows, fields) {
            // para fazer...
        }
    )
}

module.exports.getData = getData;
module.exports.postData = postData;
module.exports.getDataFromDatabase = getDataFromDatabase;
module.exports.postDataToDatabase = postDataToDatabase;