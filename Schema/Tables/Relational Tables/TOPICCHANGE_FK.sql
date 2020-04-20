ALTER TABLE TopicChange
ADD CONSTRAINT FK_TopicChange_EditRequest_EditRequestNumber
FOREIGN KEY (EditRequestNumber) REFERENCES EditRequest(Num)
ADD CONSTRAINT FK_TopicChange_UserAccount
FOREIGN KEY (AuthorUsername) REFERENCES UserAccount(Username)
ADD CONSTRAINT FK_TopicChange_EditRequest_TopicName
FOREIGN KEY (TopicName) REFERENCES EditRequest(TopicName);
