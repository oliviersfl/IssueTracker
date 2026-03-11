-- Migration: Add TicketAuditLog table
-- Safe to run multiple times due to IF NOT EXISTS guards

CREATE TABLE IF NOT EXISTS TicketAuditLog (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    ticketid INTEGER NOT NULL,
    Timestamp DATETIME DEFAULT CURRENT_TIMESTAMP,
    ChangeType TEXT NOT NULL,
    OldValue TEXT,
    NewValue TEXT,
    FOREIGN KEY (ticketid) REFERENCES Ticket(id)
);

CREATE INDEX IF NOT EXISTS idx_auditlog_ticket ON TicketAuditLog(ticketid);
CREATE INDEX IF NOT EXISTS idx_auditlog_timestamp ON TicketAuditLog(Timestamp);