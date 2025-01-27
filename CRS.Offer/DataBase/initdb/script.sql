CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;
CREATE TABLE "Offices" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Offices" PRIMARY KEY,
    "Name" TEXT NOT NULL,
    "Address" TEXT NOT NULL,
    "StartTime" TEXT NOT NULL,
    "FinishTime" TEXT NOT NULL
);

CREATE TABLE "Masters" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Masters" PRIMARY KEY,
    "Name" TEXT NOT NULL,
    "OfficeId" TEXT NOT NULL,
    CONSTRAINT "FK_Masters_Offices_OfficeId" FOREIGN KEY ("OfficeId") REFERENCES "Offices" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Services" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Services" PRIMARY KEY,
    "Name" TEXT NOT NULL,
    "Price" REAL NOT NULL,
    "Duration" TEXT NOT NULL,
    "MasterId" TEXT NOT NULL,
    "OfficeId" TEXT NOT NULL,
    CONSTRAINT "FK_Services_Offices_OfficeId" FOREIGN KEY ("OfficeId") REFERENCES "Offices" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Schedules" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Schedules" PRIMARY KEY,
    "WhatDate" TEXT NOT NULL,
    "StartTime" TEXT NOT NULL,
    "FinishTime" TEXT NOT NULL,
    "MasterId" TEXT NOT NULL,
    "OfficeId" TEXT NOT NULL,
    CONSTRAINT "FK_Schedules_Masters_MasterId" FOREIGN KEY ("MasterId") REFERENCES "Masters" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Schedules_Offices_OfficeId" FOREIGN KEY ("OfficeId") REFERENCES "Offices" ("Id") ON DELETE CASCADE
);

CREATE TABLE "MasterServices" (
    "MasterId" TEXT NOT NULL,
    "ServiceId" TEXT NOT NULL,
    CONSTRAINT "PK_MasterServices" PRIMARY KEY ("MasterId", "ServiceId"),
    CONSTRAINT "FK_MasterServices_Masters_MasterId" FOREIGN KEY ("MasterId") REFERENCES "Masters" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_MasterServices_Services_ServiceId" FOREIGN KEY ("ServiceId") REFERENCES "Services" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_Masters_OfficeId" ON "Masters" ("OfficeId");

CREATE INDEX "IX_MasterServices_ServiceId" ON "MasterServices" ("ServiceId");

CREATE INDEX "IX_Schedules_MasterId" ON "Schedules" ("MasterId");

CREATE INDEX "IX_Schedules_OfficeId" ON "Schedules" ("OfficeId");

CREATE INDEX "IX_Services_OfficeId" ON "Services" ("OfficeId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250127191723_CreateDB', '9.0.1');

COMMIT;

