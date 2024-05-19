using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace meme_api.Migrations
{
    /// <inheritdoc />
    public partial class removeimagestring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Meme");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Meme",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
