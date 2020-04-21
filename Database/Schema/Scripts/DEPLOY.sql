-- User and Connection
@"/Schema/Security/Users/ZEROBASED"
CONNECT zerobased/zerobased@ORCLCDB;

-- Sequences
@"/Schema/Sequences/INTEREST_SEQ"
@"/Schema/Sequences/PERMISSION_SEQ"
@"/Schema/Sequences/VOTE_SEQ"

COMMIT;

-- Tables
@"/Schema/Tables/Relational Tables/BADGE"
@"/Schema/Tables/Relational Tables/EDITREQUEST"
@"/Schema/Tables/Relational Tables/INTEREST"
@"/Schema/Tables/Relational Tables/PERMISSION"
@"/Schema/Tables/Relational Tables/TOPIC"
@"/Schema/Tables/Relational Tables/TOPICCHANGE"
@"/Schema/Tables/Relational Tables/TOPICTAG"
@"/Schema/Tables/Relational Tables/USERACCOUNT"
@"/Schema/Tables/Relational Tables/USERBADGE"
@"/Schema/Tables/Relational Tables/USERINTEREST"
@"/Schema/Tables/Relational Tables/VOTE"

-- Relations
@"/Schema/Tables/Relational Tables/BADGE_FK"
@"/Schema/Tables/Relational Tables/EDITREQUEST_FK"
@"/Schema/Tables/Relational Tables/TOPIC_FK"
@"/Schema/Tables/Relational Tables/TOPICCHANGE_FK"
@"/Schema/Tables/Relational Tables/TOPICTAG_FK"
@"/Schema/Tables/Relational Tables/USERBADGE_FK"
@"/Schema/Tables/Relational Tables/USERINTEREST_FK"
@"/Schema/Tables/Relational Tables/VOTE_FK"

COMMIT;