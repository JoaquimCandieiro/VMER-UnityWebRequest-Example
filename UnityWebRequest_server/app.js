const express = require("express")
const options = require("./config/config.json")
const requestHandlers = require("./requestHandlers.js")
const app = express()

app.use(express.json())

app.get("/get-data", requestHandlers.getData)
app.post("/post-data", requestHandlers.postData)

app.listen(options.server.port, function() {
    console.log(`Server running at ${options.server.host}:${options.server.port}`)
})