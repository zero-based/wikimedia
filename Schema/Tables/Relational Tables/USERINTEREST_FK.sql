ALTER TABLE UserInterest
ADD CONSTRAINT FK_UserInterest_UserAccount
FOREIGN KEY (Username) REFERENCES UserAccount(Username)
ADD CONSTRAINT FK_UserInterest_Interest
FOREIGN KEY (InterestId) REFERENCES Interest(Id);
