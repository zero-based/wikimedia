ALTER TABLE UserBadge
ADD CONSTRAINT FK_UserBadge_UserAccount
FOREIGN KEY (Username) REFERENCES UserAccount(Username)
ADD CONSTRAINT FK_UserBadge_Badge
FOREIGN KEY (BadgeName) REFERENCES Badge(Name);
