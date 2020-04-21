DROP TABLE UserAccount CASCADE CONSTRAINTS;

CREATE TABLE UserAccount (
  Username VARCHAR2(50) NOT NULL,
  FirstName VARCHAR2(50),
  LastName VARCHAR2(50),
  Password VARCHAR2(50),
  JoinDate DATE DEFAULT SYSDATE,
  Points NUMBER DEFAULT 0,
  Email VARCHAR2(50),
  CONSTRAINT PK_UserAccount PRIMARY KEY (Username)
);