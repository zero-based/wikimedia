DROP TABLE UserInterest CASCADE CONSTRAINTS;

CREATE TABLE UserInterest (
  Username VARCHAR2(50) NOT NULL,
  InterestId NUMBER(38) NOT NULL,
  CONSTRAINT PK_UserInterest PRIMARY KEY (Username, InterestId)
);