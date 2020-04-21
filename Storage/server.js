const express = require("express");
const fse = require("fs-extra");
const path = require("path");
const bodyParser = require("body-parser");

// Constants
const PORT = 8080;
const HOST = "0.0.0.0";
const repoDir = "/var/www/repos/";
const extension = ".md";

// App
const app = express();
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());

app.post("/topics/:topic", (req, res) => {
  var fileName = req.params.topic;
  if (!fileName) {
    res.send("No File Name Provided!");
  }
  var fileContent = req.body.topic.body;
  var filePath = path.resolve(__dirname, repoDir, fileName).concat(extension);

  fse.ensureDir(path.resolve(__dirname, repoDir)).then(function () {
    fse.writeFile(filePath, fileContent, function (err) {
      if (err) throw err;
      res.send("File Saved!");
    });
  });
});

app.get("/topics/:topic", (req, res) => {
  var fileName = req.params.topic;
  if (!fileName) {
    res.send("No File Name Provided!");
  }
  var filePath = path.resolve(__dirname, repoDir, fileName).concat(extension);

  fse.ensureDir(path.resolve(__dirname, repoDir)).then(function () {
    res.sendFile(filePath);
  });
});

app.listen(PORT, HOST);
console.log(`Running on http://${HOST}:${PORT}`);
