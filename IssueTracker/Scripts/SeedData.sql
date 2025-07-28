-- Insert TicketCategory data
INSERT INTO TicketCategory (description, "order") VALUES
('Bug', 1),
('Feature', 2),
('Enhancement', 3),
('Documentation', 4),
('Support', 5);

-- Insert TicketPriority data
INSERT INTO TicketPriority (description, "order") VALUES
('Low', 1),
('Medium', 2),
('High', 3),
('Critical', 4);

-- Insert TicketStatus data (using status values)
INSERT INTO TicketStatus (description, "order") VALUES
('To Do', 1),
('In Progress', 2),
('On Hold', 3),
('Done', 4),
('Cancelled', 5),
('Reassigned', 6),
('Planned', 7),
('Waiting for Client', 8),
('Waiting on Internal Team', 9);

-- Insert TicketType data (using status values)
INSERT INTO TicketType (description, "order") VALUES
('API', 1),
('Data Bridge', 2),
('Custom Interface', 3),
('SFTP', 4);

INSERT INTO Ticket
(title, description, categoryid, priorityid, typeid, statusid) VALUES
('Welcome to Issue Tracker', 'This is your first ticket', 4, 1, 3, 1);

INSERT INTO TicketComment
(ticketid, author, text) VALUES
(1, 'newuser', 'Hello, this is a sample comment');

INSERT INTO TicketSubTask
(ticketid, title, isCompleted) VALUES
(1, 'Mark subtask as complete', 0);