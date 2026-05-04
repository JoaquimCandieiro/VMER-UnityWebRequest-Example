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

module.exports.getData = getData;
module.exports.postData = postData;