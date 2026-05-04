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
    }
]

/**
 * Método para tratar a requisição GET para o endpoint /get-data
 * @param {Object} request 
 * @param {Object} response 
 */

function getData(request, response) {
    // Enviar os dados do jogador stringificados em formato Json
    response.send(JSON.stringify({_playerDataInfoArray: playerDataArray}))
}

module.exports.getData = getData