ALTER TABLE Badge
ADD  FOREIGN KEY (PermissionId) REFERENCES Permission(Id);