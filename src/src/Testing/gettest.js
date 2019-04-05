/* test for the get method also shows how it works*/
var mongoClient = require("mongodb").MongoClient;
const env = require("dotenv").config({ path: `${__dirname}/.env` });
const getRtns = require("../DbRoutines/gets");
const rtnLib = require("../FileRoutines/fileRoutines");
// test for inserting many documnets into a mongo collection on azure
const GetUserNameTest = async () => {
  let conn = undefined;
  try {
    conn = await mongoClient.connect(process.env.LOCALDBURL, {
      useNewUrlParser: true
    });
    // connect to the DB
    const db = conn.db(`${process.env.DBURL}`);
    // create a user
    let user = {
      username: "testFind",
      password: "pass"
    };
    // find that user based of username
    let retUserName = await getRtns.findByUserName(user.username, db);

    // check if it worked
    console.log(retUserName);

    // pass the entire user up
    let retUserNamePass = await getRtns.findByUserNamePassword(user, db);
    console.log(retUserNamePass);
  } catch (err) {
    console.log(err);
  } finally {
    conn ? conn.close : null;
    console.log(`Disconnected from the ${process.env.DBURL}`);
  }
  process.exit(0);
};

// get test for tasks
const GetTaskTest = async () => {
  let conn = undefined;
  try {
    conn = await mongoClient.connect(process.env.CONNURL, {
      useNewUrlParser: true
    });
    // connect to the DB
    const db = conn.db(`${process.env.DBURL}`);
    // create a user
    // find that user based of username
    let retTasks = await getRtns.findTasksByUserName("Thomas Woods", db);

    // check if it worked
    console.log(retTasks);
  } catch (err) {
    console.log(err);
  } finally {
    conn ? conn.close : null;
    console.log(`Disconnected from the ${process.env.DBURL}`);
  }
  process.exit(0);
};
GetTaskTest();
