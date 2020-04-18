ALTER TABLE TopicChange
ADD  FOREIGN KEY (EditRequestNumber) REFERENCES EditRequest(Num)
ADD  FOREIGN KEY (AuthorUsername) REFERENCES UserAccount(Username)
ADD  FOREIGN KEY (TopicName) REFERENCES EditRequest(TopicName);
