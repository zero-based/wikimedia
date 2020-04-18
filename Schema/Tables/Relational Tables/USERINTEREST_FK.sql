ALTER TABLE UserInterest
ADD  FOREIGN KEY (Username) REFERENCES UserAccount(Username)
ADD  FOREIGN KEY (InterestId) REFERENCES Interest(Id);
