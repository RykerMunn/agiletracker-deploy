const env = require("dotenv").config({ path: `$../../../common/config/.env` });
const logger = require("./logger");
const express = require("express");
const router = express.Router();

router.get("/"),
    async (req, res) => {
        res.send("<h1>Gute Codierung GmbH. API Test </h1>");
    };