-- Insert TicketCategory data
INSERT INTO TicketCategory (description, "order", isDefault) VALUES
('Bug', 1, 0),
('Change Request', 2, 0),
('Integration', 3, 0),
('Documentation', 4, 0),
('Support', 5, 1),
('Training', 6, 0),
('Other', 7, 0);

-- Insert TicketPriority data
INSERT INTO TicketPriority (description, "order", isDefault) VALUES
('Low', 1, 0),
('Medium', 2, 1),
('High', 3, 0),
('Critical', 4, 0);

-- Insert TicketType data
INSERT INTO TicketType (description, "order", isDefault) VALUES
('API', 1, 0),
('Data Bridge', 2, 0),
('Custom Interface', 3, 1),
('Sandbox', 4, 0),
('SFTP', 5, 0),
('Others', 6, 0);

-- Insert TicketStatus data
INSERT INTO TicketStatus (description, "order", isDefault) VALUES
('To Do', 1, 1),
('In Progress', 2, 1),
('Planned', 3, 1),
('Processing', 4, 1),
('Call Scheduled', 5, 1),
('Waiting on Client', 6, 1),
('Waiting on Internal Team', 7, 1),
('On Hold', 8, 1),
('Reassigned', 9, 0),
('Cancelled', 10, 0),
('Done', 11, 0);

INSERT INTO Ticket
(title, description, categoryid, priorityid, typeid, statusid) VALUES
('Welcome to Issue Tracker', 'This is your first ticket', 4, 1, 3, 1);

INSERT INTO TicketComment
(ticketid, author, text) VALUES
(1, 'newuser', 'Hello, this is a sample comment');

INSERT INTO TicketSubTask
(ticketid, title, isCompleted) VALUES
(1, 'Mark subtask as complete', 0);