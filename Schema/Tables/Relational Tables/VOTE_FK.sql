ALTER TABLE Vote
ADD  FOREIGN KEY (TopicName) REFERENCES Topic(Name)
ADD  FOREIGN KEY (VoterUsername) REFERENCES UserAccount(Username);
