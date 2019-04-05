/*
Brief:  Schema for the projects collection will need to store alot of data
        - Need to have an array of tasks probably just get the Task ID for this
        - upon creation of task get the ID add to a JSON array
        - 
*/
var mongoClient = require("mongodb").MongoClient;
const env = require("dotenv").config({ path: `${__dirname}/.env` });
const insertRtns = require("../js/DbRoutines/inserts");
const getRtns = require("../js/DbRoutines/gets");
const AddProject = async () => {
  let conn = undefined;
  try {
    conn = await mongoClient.connect(process.env.LOCALDBURL, {
      useNewUrlParser: true
    });
    // connect to the DB
    const db = conn.db(`${process.env.DBURL}`);

    // create a test user to insert into the user collection
    // need to store the user ID as well so we can get it based off who is logged in

    let retTasks = await getRtns.findTasksByUserName("Thomas Woods", db);
    // insert into the usersCollection just 1 user

    if (!retTasks) {
      retTasks = {
        username: "Thomas Woods",
        members: ["Thomas", "Ryker", "Matt", "4", "5"],
        taskIsComplete: 0,
        estimatedTime: "15 days",
        actualTime: "4 days",
        details:
          "This is regjremglkermglkermlkgmrelkgmer;lkgm;re;hlkern;hlkjen;hkjenrlk;hnerl;khnr;lkeqnhlk;erqnhl"
      };
    }
    let project = {
      projectName: "Fortnite 3",
      userName: "Thomas Woods",
      tasks: retTasks
    };

    // see if it worked
    retTasks = await getRtns.findTasksByUserName("Thomas Woods", db);
    let inserted = await insertRtns.addOneToCollection(
      project,
      db,
      process.env.PROJECTSCOLLECTION
    );

    console.log(inserted.insertedCount + " projects inserted");
  } catch (err) {
    console.log(err);
  } finally {
    conn ? conn.close : null;
    console.log(`Disconnected from the ${process.env.DBURL}`);
  }
  process.exit(0);
};

AddProject();
