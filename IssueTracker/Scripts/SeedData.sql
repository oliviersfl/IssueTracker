-- Insert TicketCategory data
INSERT INTO TicketCategory (description, "order", isDefault) VALUES
('Bug', 1, 0),
('Change Request', 2, 0),
('New Project', 3, 0),
('Documentation', 4, 0),
('Support', 5, 1),
('Training', 6, 0);

-- Insert TicketPriority data
INSERT INTO TicketPriority (description, "order", isDefault) VALUES
('Low', 1, 0),
('Medium', 2, 1),
('High', 3, 0),
('Critical', 4, 0);

-- Insert TicketType data (using status values)
INSERT INTO TicketType (description, "order", isDefault) VALUES
('API', 1, 0),
('Data Bridge', 2, 1),
('Custom Interface', 3, 0),
('SFTP', 4, 0);

-- Insert TicketStatus data (using status values)
INSERT INTO TicketStatus (description, "order") VALUES
('To Do', 1),
('In Progress', 2),
('On Hold', 3),
('Done', 4),
('Cancelled', 5),
('Reassigned', 6),
('Planned', 7),
('Waiting on Client', 8),
('Waiting on Internal Team', 9);

INSERT INTO Ticket
(title, description, categoryid, priorityid, typeid, statusid) VALUES
('Welcome to Issue Tracker', 'This is your first ticket', 4, 1, 3, 1);

INSERT INTO TicketComment
(ticketid, author, text) VALUES
(1, 'newuser', 'Hello, this is a sample comment');

INSERT INTO TicketSubTask
(ticketid, title, isCompleted) VALUES
(1, 'Mark subtask as complete', 0);