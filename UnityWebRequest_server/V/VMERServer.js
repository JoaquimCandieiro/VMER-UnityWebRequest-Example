let playerData = {
    name: "Player1",
    lives: 3,
    health: 80.5
}

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
    response.send(JSON.stringify({_playerDataInfoArray: playerDataArray}))
}

module.exports.getData = getData