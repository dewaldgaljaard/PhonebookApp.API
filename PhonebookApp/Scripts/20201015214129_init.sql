CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

CREATE TABLE "PhoneBooks" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_PhoneBooks" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NULL
);

CREATE TABLE "Entries" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Entries" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NULL,
    "PhoneNumber" TEXT NULL,
    "PhoneBookId" INTEGER NULL,
    CONSTRAINT "FK_Entries_PhoneBooks_PhoneBookId" FOREIGN KEY ("PhoneBookId") REFERENCES "PhoneBooks" ("Id") ON DELETE RESTRICT
);

CREATE UNIQUE INDEX "IX_Entries_Name" ON "Entries" ("Name");

CREATE INDEX "IX_Entries_PhoneBookId" ON "Entries" ("PhoneBookId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20201015214129_init', '3.1.9');

