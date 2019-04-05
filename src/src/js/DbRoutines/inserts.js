// bulk insert of documents to mongoDB
const addMany = (json, db, coll) => {
  return db.collection(coll).insertMany(json);
};
// adding one single user
const addOneUser = (user, db) =>
  db.collection("users").insertOne({
    username: user.username,
    password: user.password
  });

// adding a task
const addTask = (task, db) => {
  return db.collection("tasks").insertOne(task);
};

// adding anything as long as it's good JSON just
// 1 insert
const addOneToCollection = (json, db, coll) => {
  return db.collection(coll).insertOne(json);
};
// task add
module.exports = { addMany, addOneUser, addTask, addOneToCollection };
