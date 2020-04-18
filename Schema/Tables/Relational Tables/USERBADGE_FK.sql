ALTER TABLE UserBadge
ADD  FOREIGN KEY (Username) REFERENCES UserAccount(Username)
ADD  FOREIGN KEY (BadgeName) REFERENCES Badge(Name);
