using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenBlog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_new_table_parent_sub_comments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParentSubComment_AspNetUsers_UserId",
                table: "ParentSubComment");

            migrationBuilder.DropForeignKey(
                name: "FK_ParentSubComment_SubComments_SubCommentId",
                table: "ParentSubComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParentSubComment",
                table: "ParentSubComment");

            migrationBuilder.RenameTable(
                name: "ParentSubComment",
                newName: "ParentSubComments");

            migrationBuilder.RenameIndex(
                name: "IX_ParentSubComment_UserId",
                table: "ParentSubComments",
                newName: "IX_ParentSubComments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ParentSubComment_SubCommentId",
                table: "ParentSubComments",
                newName: "IX_ParentSubComments_SubCommentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParentSubComments",
                table: "ParentSubComments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParentSubComments_AspNetUsers_UserId",
                table: "ParentSubComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParentSubComments_SubComments_SubCommentId",
                table: "ParentSubComments",
                column: "SubCommentId",
                principalTable: "SubComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParentSubComments_AspNetUsers_UserId",
                table: "ParentSubComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ParentSubComments_SubComments_SubCommentId",
                table: "ParentSubComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParentSubComments",
                table: "ParentSubComments");

            migrationBuilder.RenameTable(
                name: "ParentSubComments",
                newName: "ParentSubComment");

            migrationBuilder.RenameIndex(
                name: "IX_ParentSubComments_UserId",
                table: "ParentSubComment",
                newName: "IX_ParentSubComment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ParentSubComments_SubCommentId",
                table: "ParentSubComment",
                newName: "IX_ParentSubComment_SubCommentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParentSubComment",
                table: "ParentSubComment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParentSubComment_AspNetUsers_UserId",
                table: "ParentSubComment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParentSubComment_SubComments_SubCommentId",
                table: "ParentSubComment",
                column: "SubCommentId",
                principalTable: "SubComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
