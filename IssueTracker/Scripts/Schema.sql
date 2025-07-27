-- Create TicketCategory table
CREATE TABLE IF NOT EXISTS TicketCategory (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    description TEXT NOT NULL,
    "order" INTEGER NOT NULL,
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    ModifiedDate DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Create TicketPriority table
CREATE TABLE IF NOT EXISTS TicketPriority (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    description TEXT NOT NULL,
    "order" INTEGER NOT NULL,
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    ModifiedDate DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Create TicketType table
CREATE TABLE IF NOT EXISTS TicketType (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    description TEXT NOT NULL,
    "order" INTEGER NOT NULL,
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    ModifiedDate DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Create Ticket table
CREATE TABLE IF NOT EXISTS Ticket (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    title TEXT NOT NULL,
    description TEXT,
    categoryid INTEGER,
    priorityid INTEGER,
    typeid TEXT,
    statusid INTEGER,
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    ModifiedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    DueDate DATETIME,
    FOREIGN KEY (categoryid) REFERENCES TicketCategory(id),
    FOREIGN KEY (priorityid) REFERENCES TicketPriority(id),
	FOREIGN KEY (typeid) REFERENCES TicketType(id)
);

-- Create TicketSubTask table
CREATE TABLE IF NOT EXISTS TicketSubTask (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    ticketid INTEGER NOT NULL,
    title TEXT NOT NULL,
    isCompleted BOOLEAN DEFAULT 0,
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (ticketid) REFERENCES Ticket(id)
);

-- Create TicketComment table
CREATE TABLE IF NOT EXISTS TicketComment (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    ticketid INTEGER NOT NULL,
    author TEXT NOT NULL,
    text TEXT NOT NULL,
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (ticketid) REFERENCES Ticket(id)
);

-- Create indexes for better performance (with IF NOT EXISTS)
CREATE INDEX IF NOT EXISTS idx_ticket_category ON Ticket(categoryid);
CREATE INDEX IF NOT EXISTS idx_ticket_priority ON Ticket(priorityid);
CREATE INDEX IF NOT EXISTS idx_ticket_type ON Ticket(typeid);
CREATE INDEX IF NOT EXISTS idx_subtask_ticket ON TicketSubTask(ticketid);
CREATE INDEX IF NOT EXISTS idx_comment_ticket ON TicketComment(ticketid);