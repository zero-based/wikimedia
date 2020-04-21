ALTER TABLE Badge
ADD CONSTRAINT FK_Badge_Permission
FOREIGN KEY (PermissionId) REFERENCES Permission(Id);