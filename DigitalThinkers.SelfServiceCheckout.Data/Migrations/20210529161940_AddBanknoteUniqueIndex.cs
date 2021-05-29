using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalThinkers.SelfServiceCheckout.Data.Migrations
{
    public partial class AddBanknoteUniqueIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Banknotes_ValueInTCY_CurrencyId",
                table: "Banknotes",
                columns: new[] { "ValueInTCY", "CurrencyId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Banknotes_ValueInTCY_CurrencyId",
                table: "Banknotes");
        }
    }
}
