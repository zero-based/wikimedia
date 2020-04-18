ALTER TABLE Topic
ADD  FOREIGN KEY (CreatorUsername) REFERENCES UserAccount(Username);
