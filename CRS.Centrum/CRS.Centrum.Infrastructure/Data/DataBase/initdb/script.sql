CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;
CREATE TABLE "Offices" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "Address" text NOT NULL,
    "StartTime" timestamp with time zone NOT NULL,
    "FinishTime" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Offices" PRIMARY KEY ("Id")
);

CREATE TABLE "Masters" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "OfficeId" uuid NOT NULL,
    CONSTRAINT "PK_Masters" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Masters_Offices_OfficeId" FOREIGN KEY ("OfficeId") REFERENCES "Offices" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Services" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "Price" double precision NOT NULL,
    "Duration" timestamp with time zone NOT NULL,
    "MasterId" uuid NOT NULL,
    "OfficeId" uuid NOT NULL,
    CONSTRAINT "PK_Services" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Services_Offices_OfficeId" FOREIGN KEY ("OfficeId") REFERENCES "Offices" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Schedules" (
    "Id" uuid NOT NULL,
    "WhatDate" timestamp with time zone NOT NULL,
    "StartTime" timestamp with time zone NOT NULL,
    "FinishTime" timestamp with time zone NOT NULL,
    "MasterId" uuid NOT NULL,
    "OfficeId" uuid NOT NULL,
    CONSTRAINT "PK_Schedules" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Schedules_Masters_MasterId" FOREIGN KEY ("MasterId") REFERENCES "Masters" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Schedules_Offices_OfficeId" FOREIGN KEY ("OfficeId") REFERENCES "Offices" ("Id") ON DELETE CASCADE
);

CREATE TABLE "MasterServices" (
    "MasterId" uuid NOT NULL,
    "ServiceId" uuid NOT NULL,
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
VALUES ('20250201080207_CreateDB', '9.0.1');

CREATE TABLE "Client" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "BornDate" timestamp with time zone NOT NULL,
    "OfficeId" uuid NOT NULL,
    CONSTRAINT "PK_Client" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Client_Offices_OfficeId" FOREIGN KEY ("OfficeId") REFERENCES "Offices" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Appointment" (
    "Id" uuid NOT NULL,
    "AppointmentDateTime" timestamp with time zone NOT NULL,
    "MasterId" uuid NOT NULL,
    "ClientId" uuid NOT NULL,
    "ServiceId" uuid NOT NULL,
    "OfficeId" uuid NOT NULL,
    CONSTRAINT "PK_Appointment" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Appointment_Client_ClientId" FOREIGN KEY ("ClientId") REFERENCES "Client" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Appointment_Masters_MasterId" FOREIGN KEY ("MasterId") REFERENCES "Masters" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Appointment_Offices_OfficeId" FOREIGN KEY ("OfficeId") REFERENCES "Offices" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Appointment_Services_ServiceId" FOREIGN KEY ("ServiceId") REFERENCES "Services" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_Appointment_ClientId" ON "Appointment" ("ClientId");

CREATE INDEX "IX_Appointment_MasterId" ON "Appointment" ("MasterId");

CREATE INDEX "IX_Appointment_OfficeId" ON "Appointment" ("OfficeId");

CREATE INDEX "IX_Appointment_ServiceId" ON "Appointment" ("ServiceId");

CREATE INDEX "IX_Client_OfficeId" ON "Client" ("OfficeId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250208184014_AlterDB_AddTables', '9.0.1');

COMMIT;

