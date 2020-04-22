CREATE or REPLACE PROCEDURE SIGN_UP
(User_Email IN UserAccount.Email% TYPE,
 User_Username IN UserAccount.Username% TYPE,
 User_FirstName IN UserAccount.FirstName% TYPE,
 User_LastName IN UserAccount.LastName% TYPE,
 User_JoinDate IN UserAccount.JoinDate% TYPE,
 User_Points IN UserAccount.Points% TYPE,
 User_Password IN UserAccount.Password% TYPE)
 IS 
 BEGIN
  INSERT INTO UserAccount
  VALUES (User_Username, User_FirstName, User_LastName, User_Password, User_JoinDate, User_Points, User_Email);
  COMMIT;
 END SIGN_UP;
 /