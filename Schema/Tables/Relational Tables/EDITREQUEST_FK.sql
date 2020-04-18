ALTER TABLE EditRequest
ADD  FOREIGN KEY (TopicName) REFERENCES Topic(Name)
ADD  FOREIGN KEY (MergedBy) REFERENCES UserAccount(Username)
ADD  FOREIGN KEY (OpenedBy) REFERENCES UserAccount(Username)
ADD  FOREIGN KEY (MergeCommitId) REFERENCES TopicChange(Id);