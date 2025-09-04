using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenBlog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_new_table_and_relation_subcomment_and_parentsubcomments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ParentSubComment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubCommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentSubComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParentSubComment_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParentSubComment_SubComments_SubCommentId",
                        column: x => x.SubCommentId,
                        principalTable: "SubComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParentSubComment_SubCommentId",
                table: "ParentSubComment",
                column: "SubCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentSubComment_UserId",
                table: "ParentSubComment",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParentSubComment");

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
    }
}
