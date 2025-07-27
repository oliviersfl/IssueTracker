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

-- Insert TicketType data (using status values)
INSERT INTO TicketType (description, "order") VALUES
('To Do', 1),
('In Progress', 2),
('On Hold', 3),
('Done', 4),
('Cancelled', 5),
('Reassigned', 6),
('Planned', 7),
('Waiting for Client', 8),
('Waiting on Internal Team', 9);