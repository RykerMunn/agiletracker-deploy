/*Get data from the mongo DB will return in JSON format*/
const findByUserNamePassword = (user, db) => {
  return db.collection("users").findOne(user);
};

// Just find by username
const findByUserName = (userName, db) => {
  return db.collection("users").findOne({ username: userName });
};

// Task finds
// get all tasks for a userName
const findTasksByUserName = (userName, db) => {
  return db
    .collection("tasks")
    .find({ username: userName })
    .toArray();
};

// Projects finds
// get a project for a userName
const findProjectByProjectName = (userNameID, projectName, db) => {
  return db
    .collection("projects")
    .find({
      projectName: projectName,
      userid: userNameID
    })
    .toArray();
};
// get all projects for a username
const findProjectsByUserName = (userNameID, db) => {
  return db
    .collection("projects")
    .find({
      userid: userNameID
    })
    .toArray();
};

// end task finds
module.exports = {
  findProjectsByUserName,
  findByUserNamePassword,
  findByUserName,
  findTasksByUserName,
  findProjectByProjectName
};
