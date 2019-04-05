const env = require("dotenv").config({ path: `$../../../common/config/.env` });
const logger = require("./logger");
const apiMasterRoutes = require("./apiMasterRoutes");
const express = require("express");
const app = express();
const bodyParser = require("body-parser");

const port = process.env.PORT || 27200;
// cors - remove in prod
app.use((req, res, next) => {
    res.header("Access-Control-Allow-Origin", "*");
    res.header(
        "Access-Control-Allow-Headers",
        "Origin, X-Requested-With, Content-Type, Accept"
    );
    res.header("Access-Control-Allow-Methods", "OPTIONS, GET, POST, PUT, DELETE");
    next();
});

// parse application/json
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());
app.use((req, res, next) => {
    logger.WriteConnectionLog(process.env.CONNLOG)
    next();
});

app.use("/agiletracker/api", apiMasterRoutes);