ALTER TABLE EditRequest
ADD CONSTRAINT FK_EditRequest_Topic
FOREIGN KEY (TopicName) REFERENCES Topic(Name)
ADD CONSTRAINT FK_EditRequest_UserAccount_MergedBy
FOREIGN KEY (MergedBy) REFERENCES UserAccount(Username)
ADD CONSTRAINT FK_EditRequest_UserAccount_OpenedBy
FOREIGN KEY (OpenedBy) REFERENCES UserAccount(Username)
ADD CONSTRAINT FK_EditRequest_TopicChange
FOREIGN KEY (MergeCommitId) REFERENCES TopicChange(Id);