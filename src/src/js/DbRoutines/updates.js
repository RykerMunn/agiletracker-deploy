// update a user
const updateOneUser = (user, db, coll) => {
  let realId = new ObjectID(user._id);
  return db
    .collection(coll)
    .updateOne({ _id: realId }, { $set: { ProjectId: user.ProjectId } });
};

const updateOneProjet = (project, db) => {
  let realId = new ObjectID(project._id);
  return db
    .collection("project")
    .updateOne({ _id: realId }, { $set: { project } });
};
