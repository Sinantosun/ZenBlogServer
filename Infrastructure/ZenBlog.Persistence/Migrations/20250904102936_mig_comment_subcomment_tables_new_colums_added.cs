using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenBlog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_comment_subcomment_tables_new_colums_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUpdated",
                table: "SubComments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "OldMessageBody",
                table: "SubComments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsUpdated",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "OldMessageBody",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUpdated",
                table: "SubComments");

            migrationBuilder.DropColumn(
                name: "OldMessageBody",
                table: "SubComments");

            migrationBuilder.DropColumn(
                name: "IsUpdated",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "OldMessageBody",
                table: "Comments");
        }
    }
}
