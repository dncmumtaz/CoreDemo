using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class add_msg2_table_refac : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message2_Writers_RecieverId",
                table: "Message2");

            migrationBuilder.DropForeignKey(
                name: "FK_Message2_Writers_SenderId",
                table: "Message2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message2",
                table: "Message2");

            migrationBuilder.RenameTable(
                name: "Message2",
                newName: "Message2s");

            migrationBuilder.RenameIndex(
                name: "IX_Message2_SenderId",
                table: "Message2s",
                newName: "IX_Message2s_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Message2_RecieverId",
                table: "Message2s",
                newName: "IX_Message2s_RecieverId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message2s",
                table: "Message2s",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message2s_Writers_RecieverId",
                table: "Message2s",
                column: "RecieverId",
                principalTable: "Writers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message2s_Writers_SenderId",
                table: "Message2s",
                column: "SenderId",
                principalTable: "Writers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message2s_Writers_RecieverId",
                table: "Message2s");

            migrationBuilder.DropForeignKey(
                name: "FK_Message2s_Writers_SenderId",
                table: "Message2s");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message2s",
                table: "Message2s");

            migrationBuilder.RenameTable(
                name: "Message2s",
                newName: "Message2");

            migrationBuilder.RenameIndex(
                name: "IX_Message2s_SenderId",
                table: "Message2",
                newName: "IX_Message2_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Message2s_RecieverId",
                table: "Message2",
                newName: "IX_Message2_RecieverId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message2",
                table: "Message2",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message2_Writers_RecieverId",
                table: "Message2",
                column: "RecieverId",
                principalTable: "Writers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message2_Writers_SenderId",
                table: "Message2",
                column: "SenderId",
                principalTable: "Writers",
                principalColumn: "Id");
        }
    }
}
