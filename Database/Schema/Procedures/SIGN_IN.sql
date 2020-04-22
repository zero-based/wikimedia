CREATE OR REPLACE PROCEDURE SIGN_IN
(User_Email IN VARCHAR2,
 User_Username OUT VARCHAR2,
 User_FirstName OUT VARCHAR2,
 User_LastName OUT VARCHAR2,
 User_JoinDate OUT DATE,
 User_Points OUT NUMBER,
 User_Password OUT VARCHAR2)
 AS 
 BEGIN
 SELECT Username, Firstname, Lastname, JoinDate, Points, Password
 INTO User_Username, User_FirstName, User_LastName, User_JoinDate, User_Points, User_Password
 FROM UserAccount
 WHERE Email = User_Email;
 END SIGN_IN;
 /