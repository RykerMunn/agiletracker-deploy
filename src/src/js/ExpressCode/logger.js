const fsp = require("fs").promises;

const WriteConnectionLog = async (fname, ...data) => {
    try {
        let str = "New connection established :\n";
        str += `"Time:" ${new Date() + 3600000 * -5.0}`;
        await (fsp.writeFile(fname, str));
    } catch (err) {
        fsp.writeFile(`./error.log`, "Error writing connection log.");
        console.log(err);
    }
}

module.exports = {
    WriteConnectionLog
}