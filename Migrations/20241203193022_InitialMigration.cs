using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainReservationAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Admin_ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Admin_ID);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Passenger_ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Miles_Travelled = table.Column<int>(type: "INTEGER", nullable: false),
                    Loyalty_Class = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Passenger_ID);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Station_ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Station_ID);
                });

            migrationBuilder.CreateTable(
                name: "Trains",
                columns: table => new
                {
                    Train_ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trains", x => x.Train_ID);
                });

            migrationBuilder.CreateTable(
                name: "Dependents",
                columns: table => new
                {
                    Dependent_ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Passenger_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Discount_Applied = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependents", x => x.Dependent_ID);
                    table.ForeignKey(
                        name: "FK_Dependents_Passengers_Passenger_ID",
                        column: x => x.Passenger_ID,
                        principalTable: "Passengers",
                        principalColumn: "Passenger_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Reservation_No = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Passenger_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Train_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    Expiry_Date = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Reservation_No);
                    table.ForeignKey(
                        name: "FK_Reservations_Passengers_Passenger_ID",
                        column: x => x.Passenger_ID,
                        principalTable: "Passengers",
                        principalColumn: "Passenger_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Trains_Train_ID",
                        column: x => x.Train_ID,
                        principalTable: "Trains",
                        principalColumn: "Train_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Schedule_ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Train_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Departure_Time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Arrival_Time = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Schedule_ID);
                    table.ForeignKey(
                        name: "FK_Schedules_Trains_Train_ID",
                        column: x => x.Train_ID,
                        principalTable: "Trains",
                        principalColumn: "Train_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Trip_No = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Train_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Trip_No);
                    table.ForeignKey(
                        name: "FK_Trips_Trains_Train_ID",
                        column: x => x.Train_ID,
                        principalTable: "Trains",
                        principalColumn: "Train_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WaitingLists",
                columns: table => new
                {
                    Waiting_List_ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Passenger_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Train_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Position = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaitingLists", x => x.Waiting_List_ID);
                    table.ForeignKey(
                        name: "FK_WaitingLists_Passengers_Passenger_ID",
                        column: x => x.Passenger_ID,
                        principalTable: "Passengers",
                        principalColumn: "Passenger_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WaitingLists_Trains_Train_ID",
                        column: x => x.Train_ID,
                        principalTable: "Trains",
                        principalColumn: "Train_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Payment_No = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Reservation_No = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Payment_Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Payment_No);
                    table.ForeignKey(
                        name: "FK_Payments_Reservations_Reservation_No",
                        column: x => x.Reservation_No,
                        principalTable: "Reservations",
                        principalColumn: "Reservation_No",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Ticket_No = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Reservation_No = table.Column<int>(type: "INTEGER", nullable: false),
                    Seat_Class = table.Column<string>(type: "TEXT", nullable: false),
                    Seat_No = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Ticket_No);
                    table.ForeignKey(
                        name: "FK_Tickets_Reservations_Reservation_No",
                        column: x => x.Reservation_No,
                        principalTable: "Reservations",
                        principalColumn: "Reservation_No",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dependents_Passenger_ID",
                table: "Dependents",
                column: "Passenger_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Reservation_No",
                table: "Payments",
                column: "Reservation_No");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Passenger_ID",
                table: "Reservations",
                column: "Passenger_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Train_ID",
                table: "Reservations",
                column: "Train_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_Train_ID",
                table: "Schedules",
                column: "Train_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Reservation_No",
                table: "Tickets",
                column: "Reservation_No");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_Train_ID",
                table: "Trips",
                column: "Train_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WaitingLists_Passenger_ID",
                table: "WaitingLists",
                column: "Passenger_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WaitingLists_Train_ID",
                table: "WaitingLists",
                column: "Train_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Dependents");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "WaitingLists");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Trains");
        }
    }
}
