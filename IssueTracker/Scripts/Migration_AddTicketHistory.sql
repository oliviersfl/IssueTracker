-- Migration: Add TicketHistory table
-- Safe to run multiple times due to IF NOT EXISTS guards

CREATE TABLE IF NOT EXISTS TicketHistory (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    ticketid INTEGER NOT NULL,
    ModifiedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (ticketid) REFERENCES Ticket(id)
);

CREATE INDEX IF NOT EXISTS idx_history_ticket ON TicketHistory(ticketid);
CREATE INDEX IF NOT EXISTS idx_history_date ON TicketHistory(ModifiedDate);

-- Back-fill one history entry per existing ticket using its current ModifiedDate,
-- so existing tickets aren't invisible when filtering by modified date ranges.
INSERT INTO TicketHistory (ticketid, ModifiedDate)
SELECT id, ModifiedDate FROM Ticket
WHERE id NOT IN (SELECT DISTINCT ticketid FROM TicketHistory);