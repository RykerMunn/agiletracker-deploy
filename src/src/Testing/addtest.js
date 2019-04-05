var mongoClient = require("mongodb").MongoClient;
const env = require("dotenv").config({ path: `${__dirname}/.env` });
const insertRtns = require("../js/DbRoutines/inserts");
const getRtns = require("../js/DbRoutines/gets");
// test for inserting many documnets into a mongo collection on azure
const addTestUser = async () => {
  let conn = undefined;
  try {
    conn = await mongoClient.connect(process.env.CONNURL, {
      useNewUrlParser: true
    });
    // connect to the DB
    const db = conn.db(`${process.env.DBURL}`);

    // get the raw data out of a json file
    let rawData = await rtnLib.readFileFromFSPromise(`./countries.json`);
    let json = JSON.parse(rawData);
    // create a test user to insert into the user collection
    let user = {
      username: "testFind",
      password: "pass"
    };
    // make sure the file routine works
    console.log(json);
    // insert into the usersCollection just 1 user
    let inserted = await insertRtns.addOneUser(user, db);
    // see if it worked
    console.log(inserted.insertedCount);

    // insert many test uncomment to run
    //// inserted = await insertRtns.addMany(json, db, "twoods_dev");

    // console.log(inserted.insertedCount);
  } catch (err) {
    console.log(err);
  } finally {
    conn ? conn.close : null;
    console.log(`Disconnected from the ${process.env.DBURL}`);
  }
  process.exit(0);
};

const addTaskTest = async () => {
  let conn = undefined;
  try {
    conn = await mongoClient.connect(process.env.LOCALDBURL, {
      useNewUrlParser: true
    });
    // connect to the DB
    const db = conn.db(`${process.env.DBURL}`);

    // create a test user to insert into the user collection
    // need to store the user ID as well so we can get it based off who is logged in
    let task = {
      username: "Thomas Woods",
      members: ["Thomas", "Ryker", "Matt", "4", "5"],
      taskIsComplete: 0,
      estimatedTime: "15 days",
      actualTime: "4 days",
      details:
        "This is regjremglkermglkermlkgmrelkgmer;lkgm;re;hlkern;hlkjen;hkjenrlk;hnerl;khnr;lkeqnhlk;erqnhl"
    };

    // insert into the usersCollection just 1 user
    let inserted = await insertRtns.addTask(task, db);
    // see if it worked
    console.log(inserted.insertedCount);

    // insert many test uncomment to run
    //// inserted = await insertRtns.addMany(json, db, "twoods_dev");

    // console.log(inserted.insertedCount);
  } catch (err) {
    console.log(err);
  } finally {
    conn ? conn.close : null;
    console.log(`Disconnected from the ${process.env.DBURL}`);
  }
  process.exit(0);
};

addTaskTest();
