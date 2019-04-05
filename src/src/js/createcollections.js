var mongoClient = require("mongodb").MongoClient;
const env = require("dotenv").config({ path: `$../../common/config/.env` });
// DO NOT RUN THIS CODE UNLESS THE MONGODB IS EMPTY ON AZURE
const createMongoCollections = async () => {
  let conn = undefined;
  try {
    conn = await mongoClient.connect(process.env.CONNURL, {
      useNewUrlParser: true
    });

    const db = conn.db(process.env.DBURL);
    // create collections

    await db.createCollection(process.env.USERSCOLLECTION, {
      validator: {
        $jsonSchema: {
          bsonType: "object",
          required: ["username", "password", "ProjectId"],
          properties: {
            username: {
              bsonType: "string",
              description: "Username<string> is a required field."
            },
            password: {
              bsonType: "string",
              description: "Password<string> is a required field."
            },
            ProjectId: {
              bsonType: "objectId",
              description: "ProjectId<objectId> is a required feild."
            }
          }
        }
      },
      validationAction: "error",
      validationLevel: "moderate" // remove in production
    });
    await db.createCollection(process.env.TEAMSCOLLECTION);
    await db.createCollection(process.env.PROJECTSCOLLECTION, {
      validator: {
        $jsonSchema: {
          bsonType: "object",
          required: ["projectName", "userName", "userid", "tasks"],
          properties: {
            projectName: {
              bsonType: "string",
              description: "ProjetName<string> is a required field."
            },
            userName: {
              bsonType: "string",
              description: "Username<string> is a required field."
            },
            userid: {
              bsonType: "objectId",
              description:
                "UserId for username who created project is required."
            },
            tasks: {
              bsonType: "object",
              description: "Aggregate collection from Coll_Tasks."
            }
          }
        }
      },
      validationAction: "error",
      validationLevel: "moderate" // remove in production
    });
    await db.createCollection(process.env.TASKCOLLECTION, {
      validator: {
        $jsonSchema: {
          bsonType: "object",
          required: [
            "username",
            "userid",
            "members",
            "taskIsComplete",
            "estimatedTime",
            "actualTime",
            "details"
          ],
          properties: {
            username: {
              bsonType: "string",
              description: "Username<string> is a required field."
            },
            userid: {
              bsonType: "objectId",
              description:
                "The field used to relate username to the userId is required"
            },
            members: {
              bsonType: "object",
              description: "The members field is required."
            },
            taskIsComplete: {
              bsonType: "bool",
              description: "The taskIsCompleted field is required."
            },
            estimatedTime: {
              bsonType: "long",
              description: "The estimatedTime<milliseconds> is required."
            },
            actualTime: {
              bsonType: "long",
              description: "The actualTime<milliseconds> is required."
            },
            details: {
              bsonType: "string",
              description: "The task details field is required."
            }
          }
        },
        validationAction: "error",
        validationLevel: "moderate" // remove in production
      }
    });
    await db.createCollection(process.env.TIMETRACKINGCOLLECTION);
    await db.createCollection(process.env.GRAPHSCOLLECTION);
    await db.createCollection(process.env.BACKLOGCOLLECTION);
  } catch (err) {
    console.log(err);
  } finally {
    conn ? conn.close : null;
    console.log(`Disconnected from the ${process.env.DBURL}`);
  }
  process.exit(0);
};

createMongoCollections();
