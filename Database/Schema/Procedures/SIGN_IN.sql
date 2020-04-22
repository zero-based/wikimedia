CREATE OR REPLACE PROCEDURE SIGN_IN
(User_Email IN VARCHAR2,
 User_Username OUT VARCHAR2,
 User_FirstName OUT VARCHAR2,
 User_LastName OUT VARCHAR2,
 User_Password OUT VARCHAR2)
 AS 
 BEGIN
 SELECT Username, Firstname, Lastname, Password
 INTO User_Username, User_FirstName, User_LastName, User_Password
 FROM UserAccount
 WHERE Email = User_Email;
 END SIGN_IN;
 /