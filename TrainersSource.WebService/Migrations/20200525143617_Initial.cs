using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainersSource.WebService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trainerss",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Surname = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Patronymic = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Birthday = table.Column<string>(nullable: true),
                    Sport = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainerss", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Trainerss",
                columns: new[] { "Id", "Birthday", "Gender", "Name", "Patronymic", "Sport", "Surname" },
                values: new object[] { 1L, "19.01.1973", "женский", "Надежда", "Викторовна", "Большой спорт", "Абызова" });

            migrationBuilder.InsertData(
                table: "Trainerss",
                columns: new[] { "Id", "Birthday", "Gender", "Name", "Patronymic", "Sport", "Surname" },
                values: new object[] { 2L, "01.02.1960", "женский", "Лариса", "Владимировна", "Большой спорт", "Алешина" });

            migrationBuilder.InsertData(
                table: "Trainerss",
                columns: new[] { "Id", "Birthday", "Gender", "Name", "Patronymic", "Sport", "Surname" },
                values: new object[] { 3L, "21.11.1973", "мужской", "Алексей", "Михайлович", "Спортивный резерв", "Андрюхин" });

            migrationBuilder.InsertData(
                table: "Trainerss",
                columns: new[] { "Id", "Birthday", "Gender", "Name", "Patronymic", "Sport", "Surname" },
                values: new object[] { 4L, "10.11.1957", "мужской", "Александр", "Львович", "Большой спорт", "Ануров" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trainerss");
        }
    }
}
