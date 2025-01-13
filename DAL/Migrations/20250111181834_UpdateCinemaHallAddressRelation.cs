using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCinemaHallAddressRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaAddress_PostalCodes_PostalCodeId",
                table: "CinemaAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_CinemaHall_CinemaAddress_CinemaAddressId",
                table: "CinemaHall");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_CinemaHall_CinemaHallId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Screenings_CinemaHall_CinemaHallId",
                table: "Screenings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CinemaHall",
                table: "CinemaHall");

            migrationBuilder.DropIndex(
                name: "IX_CinemaHall_CinemaAddressId",
                table: "CinemaHall");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CinemaAddress",
                table: "CinemaAddress");

            migrationBuilder.RenameTable(
                name: "CinemaHall",
                newName: "CinemaHalls");

            migrationBuilder.RenameTable(
                name: "CinemaAddress",
                newName: "CinemaAddresses");

            migrationBuilder.RenameIndex(
                name: "IX_CinemaAddress_PostalCodeId",
                table: "CinemaAddresses",
                newName: "IX_CinemaAddresses_PostalCodeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CinemaHalls",
                table: "CinemaHalls",
                column: "CinemaHallId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CinemaAddresses",
                table: "CinemaAddresses",
                column: "CinemaAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaHalls_CinemaAddressId",
                table: "CinemaHalls",
                column: "CinemaAddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaAddresses_PostalCodes_PostalCodeId",
                table: "CinemaAddresses",
                column: "PostalCodeId",
                principalTable: "PostalCodes",
                principalColumn: "PostalCodeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaHalls_CinemaAddresses_CinemaAddressId",
                table: "CinemaHalls",
                column: "CinemaAddressId",
                principalTable: "CinemaAddresses",
                principalColumn: "CinemaAddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_CinemaHalls_CinemaHallId",
                table: "Movies",
                column: "CinemaHallId",
                principalTable: "CinemaHalls",
                principalColumn: "CinemaHallId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Screenings_CinemaHalls_CinemaHallId",
                table: "Screenings",
                column: "CinemaHallId",
                principalTable: "CinemaHalls",
                principalColumn: "CinemaHallId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaAddresses_PostalCodes_PostalCodeId",
                table: "CinemaAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_CinemaHalls_CinemaAddresses_CinemaAddressId",
                table: "CinemaHalls");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_CinemaHalls_CinemaHallId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Screenings_CinemaHalls_CinemaHallId",
                table: "Screenings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CinemaHalls",
                table: "CinemaHalls");

            migrationBuilder.DropIndex(
                name: "IX_CinemaHalls_CinemaAddressId",
                table: "CinemaHalls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CinemaAddresses",
                table: "CinemaAddresses");

            migrationBuilder.RenameTable(
                name: "CinemaHalls",
                newName: "CinemaHall");

            migrationBuilder.RenameTable(
                name: "CinemaAddresses",
                newName: "CinemaAddress");

            migrationBuilder.RenameIndex(
                name: "IX_CinemaAddresses_PostalCodeId",
                table: "CinemaAddress",
                newName: "IX_CinemaAddress_PostalCodeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CinemaHall",
                table: "CinemaHall",
                column: "CinemaHallId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CinemaAddress",
                table: "CinemaAddress",
                column: "CinemaAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaHall_CinemaAddressId",
                table: "CinemaHall",
                column: "CinemaAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaAddress_PostalCodes_PostalCodeId",
                table: "CinemaAddress",
                column: "PostalCodeId",
                principalTable: "PostalCodes",
                principalColumn: "PostalCodeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaHall_CinemaAddress_CinemaAddressId",
                table: "CinemaHall",
                column: "CinemaAddressId",
                principalTable: "CinemaAddress",
                principalColumn: "CinemaAddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_CinemaHall_CinemaHallId",
                table: "Movies",
                column: "CinemaHallId",
                principalTable: "CinemaHall",
                principalColumn: "CinemaHallId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Screenings_CinemaHall_CinemaHallId",
                table: "Screenings",
                column: "CinemaHallId",
                principalTable: "CinemaHall",
                principalColumn: "CinemaHallId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
