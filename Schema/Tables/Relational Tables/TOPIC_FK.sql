ALTER TABLE Topic
ADD CONSTRAINT FK_Topic_UserAccount
FOREIGN KEY (CreatorUsername) REFERENCES UserAccount(Username);
