DROP TABLE Vote CASCADE CONSTRAINTS;

CREATE TABLE Vote (
  Id NUMBER(38) NOT NULL,
  Type VARCHAR2(100),
  TopicName VARCHAR2(100),
  VoterUsername VARCHAR2(100),
  CONSTRAINT PK_Vote PRIMARY KEY(Id)
);