using Microsoft.EntityFrameworkCore.Migrations;

namespace FindTeamMateProject.DataAccessLayer.Migrations
{
    public partial class mig_message_appuser_relation_changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SenderReceiverPeople_Messages_ReceiverMessageID",
                table: "SenderReceiverPeople");

            migrationBuilder.DropForeignKey(
                name: "FK_SenderReceiverPeople_Messages_SenderMessageID",
                table: "SenderReceiverPeople");

            migrationBuilder.DropIndex(
                name: "IX_SenderReceiverPeople_ReceiverMessageID",
                table: "SenderReceiverPeople");

            migrationBuilder.DropIndex(
                name: "IX_SenderReceiverPeople_SenderMessageID",
                table: "SenderReceiverPeople");

            migrationBuilder.DropColumn(
                name: "ReceiverMessageID",
                table: "SenderReceiverPeople");

            migrationBuilder.DropColumn(
                name: "SenderMessageID",
                table: "SenderReceiverPeople");

            migrationBuilder.AddColumn<int>(
                name: "SenderReceiverMessageID",
                table: "SenderReceiverPeople",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SenderReceiverMessages",
                columns: table => new
                {
                    SenderReceiverMessageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderMessageID = table.Column<int>(type: "int", nullable: false),
                    ReceiverMessageID = table.Column<int>(type: "int", nullable: false),
                    MessageID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SenderReceiverMessages", x => x.SenderReceiverMessageID);
                    table.ForeignKey(
                        name: "FK_SenderReceiverMessages_Messages_MessageID",
                        column: x => x.MessageID,
                        principalTable: "Messages",
                        principalColumn: "MessageID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SenderReceiverMessages_Messages_ReceiverMessageID",
                        column: x => x.ReceiverMessageID,
                        principalTable: "Messages",
                        principalColumn: "MessageID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SenderReceiverMessages_Messages_SenderMessageID",
                        column: x => x.SenderMessageID,
                        principalTable: "Messages",
                        principalColumn: "MessageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SenderReceiverPeople_SenderReceiverMessageID",
                table: "SenderReceiverPeople",
                column: "SenderReceiverMessageID");

            migrationBuilder.CreateIndex(
                name: "IX_SenderReceiverMessages_MessageID",
                table: "SenderReceiverMessages",
                column: "MessageID");

            migrationBuilder.CreateIndex(
                name: "IX_SenderReceiverMessages_ReceiverMessageID",
                table: "SenderReceiverMessages",
                column: "ReceiverMessageID");

            migrationBuilder.CreateIndex(
                name: "IX_SenderReceiverMessages_SenderMessageID",
                table: "SenderReceiverMessages",
                column: "SenderMessageID");

            migrationBuilder.AddForeignKey(
                name: "FK_SenderReceiverPeople_SenderReceiverMessages_SenderReceiverMessageID",
                table: "SenderReceiverPeople",
                column: "SenderReceiverMessageID",
                principalTable: "SenderReceiverMessages",
                principalColumn: "SenderReceiverMessageID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SenderReceiverPeople_SenderReceiverMessages_SenderReceiverMessageID",
                table: "SenderReceiverPeople");

            migrationBuilder.DropTable(
                name: "SenderReceiverMessages");

            migrationBuilder.DropIndex(
                name: "IX_SenderReceiverPeople_SenderReceiverMessageID",
                table: "SenderReceiverPeople");

            migrationBuilder.DropColumn(
                name: "SenderReceiverMessageID",
                table: "SenderReceiverPeople");

            migrationBuilder.AddColumn<int>(
                name: "ReceiverMessageID",
                table: "SenderReceiverPeople",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SenderMessageID",
                table: "SenderReceiverPeople",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SenderReceiverPeople_ReceiverMessageID",
                table: "SenderReceiverPeople",
                column: "ReceiverMessageID");

            migrationBuilder.CreateIndex(
                name: "IX_SenderReceiverPeople_SenderMessageID",
                table: "SenderReceiverPeople",
                column: "SenderMessageID");

            migrationBuilder.AddForeignKey(
                name: "FK_SenderReceiverPeople_Messages_ReceiverMessageID",
                table: "SenderReceiverPeople",
                column: "ReceiverMessageID",
                principalTable: "Messages",
                principalColumn: "MessageID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SenderReceiverPeople_Messages_SenderMessageID",
                table: "SenderReceiverPeople",
                column: "SenderMessageID",
                principalTable: "Messages",
                principalColumn: "MessageID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
