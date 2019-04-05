const fsp = require(`fs`).promises;

// read from the file JSON
const readFileFromFSPromise = async fname => {
  let rawData;
  try {
    rawData = await fsp.readFile(fname);
  } catch (error) {
    console.log(error);
  } finally {
    if (rawData !== undefined) return rawData.toString();
  }
};
// get the file stats
const fileStatsPromise = async fname => {
  let stats;
  try {
    stats = await fsp.stat(fname);
  } catch (error) {
    1;
    error.code === "ENOENT" // doesn't exist
      ? console.log(`${fname} does not exist`)
      : console.log(error.message);
  }
  return stats;
};

// export the routines
module.exports = {
  readFileFromFSPromise,
  fileStatsPromise
};
