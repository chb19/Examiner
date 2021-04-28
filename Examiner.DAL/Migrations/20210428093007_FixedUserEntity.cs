using Microsoft.EntityFrameworkCore.Migrations;

namespace Examiner.DAL.Migrations
{
    public partial class FixedUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerStudent_Answers_AnswerId",
                table: "AnswerStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_AnswerStudent_AspNetUsers_StudentId",
                table: "AnswerStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupStudent_AspNetUsers_StudentId",
                table: "GroupStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupStudent_Groups_GroupId",
                table: "GroupStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupTest_Groups_GroupId",
                table: "GroupTest");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupTest_Tests_TestId",
                table: "GroupTest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupTest",
                table: "GroupTest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupStudent",
                table: "GroupStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnswerStudent",
                table: "AnswerStudent");

            migrationBuilder.RenameTable(
                name: "GroupTest",
                newName: "GroupTests");

            migrationBuilder.RenameTable(
                name: "GroupStudent",
                newName: "GroupStudents");

            migrationBuilder.RenameTable(
                name: "AnswerStudent",
                newName: "AnswerStudents");

            migrationBuilder.RenameIndex(
                name: "IX_GroupTest_TestId",
                table: "GroupTests",
                newName: "IX_GroupTests_TestId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupTest_GroupId",
                table: "GroupTests",
                newName: "IX_GroupTests_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupStudent_StudentId",
                table: "GroupStudents",
                newName: "IX_GroupStudents_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupStudent_GroupId",
                table: "GroupStudents",
                newName: "IX_GroupStudents_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_AnswerStudent_StudentId",
                table: "AnswerStudents",
                newName: "IX_AnswerStudents_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_AnswerStudent_AnswerId",
                table: "AnswerStudents",
                newName: "IX_AnswerStudents_AnswerId");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupTests",
                table: "GroupTests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupStudents",
                table: "GroupStudents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnswerStudents",
                table: "AnswerStudents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerStudents_Answers_AnswerId",
                table: "AnswerStudents",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerStudents_AspNetUsers_StudentId",
                table: "AnswerStudents",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupStudents_AspNetUsers_StudentId",
                table: "GroupStudents",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupStudents_Groups_GroupId",
                table: "GroupStudents",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupTests_Groups_GroupId",
                table: "GroupTests",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupTests_Tests_TestId",
                table: "GroupTests",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerStudents_Answers_AnswerId",
                table: "AnswerStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_AnswerStudents_AspNetUsers_StudentId",
                table: "AnswerStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupStudents_AspNetUsers_StudentId",
                table: "GroupStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupStudents_Groups_GroupId",
                table: "GroupStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupTests_Groups_GroupId",
                table: "GroupTests");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupTests_Tests_TestId",
                table: "GroupTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupTests",
                table: "GroupTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupStudents",
                table: "GroupStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnswerStudents",
                table: "AnswerStudents");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "GroupTests",
                newName: "GroupTest");

            migrationBuilder.RenameTable(
                name: "GroupStudents",
                newName: "GroupStudent");

            migrationBuilder.RenameTable(
                name: "AnswerStudents",
                newName: "AnswerStudent");

            migrationBuilder.RenameIndex(
                name: "IX_GroupTests_TestId",
                table: "GroupTest",
                newName: "IX_GroupTest_TestId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupTests_GroupId",
                table: "GroupTest",
                newName: "IX_GroupTest_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupStudents_StudentId",
                table: "GroupStudent",
                newName: "IX_GroupStudent_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupStudents_GroupId",
                table: "GroupStudent",
                newName: "IX_GroupStudent_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_AnswerStudents_StudentId",
                table: "AnswerStudent",
                newName: "IX_AnswerStudent_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_AnswerStudents_AnswerId",
                table: "AnswerStudent",
                newName: "IX_AnswerStudent_AnswerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupTest",
                table: "GroupTest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupStudent",
                table: "GroupStudent",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnswerStudent",
                table: "AnswerStudent",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerStudent_Answers_AnswerId",
                table: "AnswerStudent",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerStudent_AspNetUsers_StudentId",
                table: "AnswerStudent",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupStudent_AspNetUsers_StudentId",
                table: "GroupStudent",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupStudent_Groups_GroupId",
                table: "GroupStudent",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupTest_Groups_GroupId",
                table: "GroupTest",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupTest_Tests_TestId",
                table: "GroupTest",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
