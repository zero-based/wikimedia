ALTER TABLE Vote
ADD CONSTRAINT FK_Vote_Topic
FOREIGN KEY (TopicName) REFERENCES Topic(Name)
ADD CONSTRAINT FK_Vote_UserAccount
FOREIGN KEY (VoterUsername) REFERENCES UserAccount(Username);
