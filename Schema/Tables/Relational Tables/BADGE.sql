DROP TABLE Badge CASCADE CONSTRAINTS;

CREATE TABLE Badge (
  Name VARCHAR2(50) NOT NULL PRIMARY KEY,
  Points NUMBER(38) NOT NULL,
  PermissionId NUMBER(38)
);