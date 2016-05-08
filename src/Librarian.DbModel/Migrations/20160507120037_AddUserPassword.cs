using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Librarian.DbModel.Migrations
{
    public partial class AddUserPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Book_Library_LibraryId", table: "Books");
            migrationBuilder.DropForeignKey(name: "FK_History_Book_BookId", table: "Histories");
            migrationBuilder.DropForeignKey(name: "FK_History_User_UserId", table: "Histories");
            migrationBuilder.DropForeignKey(name: "FK_Rating_Book_BookId", table: "Ratings");
            migrationBuilder.DropForeignKey(name: "FK_Rating_User_UserId", table: "Ratings");
            migrationBuilder.DropForeignKey(name: "FK_Statistics_Book_BookId", table: "Statisticses");
            migrationBuilder.DropForeignKey(name: "FK_Statistics_User_UserId", table: "Statisticses");
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_Book_Library_LibraryId",
                table: "Books",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_History_Book_BookId",
                table: "Histories",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_History_User_UserId",
                table: "Histories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Book_BookId",
                table: "Ratings",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Rating_User_UserId",
                table: "Ratings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_Book_BookId",
                table: "Statisticses",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_User_UserId",
                table: "Statisticses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Book_Library_LibraryId", table: "Books");
            migrationBuilder.DropForeignKey(name: "FK_History_Book_BookId", table: "Histories");
            migrationBuilder.DropForeignKey(name: "FK_History_User_UserId", table: "Histories");
            migrationBuilder.DropForeignKey(name: "FK_Rating_Book_BookId", table: "Ratings");
            migrationBuilder.DropForeignKey(name: "FK_Rating_User_UserId", table: "Ratings");
            migrationBuilder.DropForeignKey(name: "FK_Statistics_Book_BookId", table: "Statisticses");
            migrationBuilder.DropForeignKey(name: "FK_Statistics_User_UserId", table: "Statisticses");
            migrationBuilder.DropColumn(name: "Password", table: "Users");
            migrationBuilder.AddForeignKey(
                name: "FK_Book_Library_LibraryId",
                table: "Books",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_History_Book_BookId",
                table: "Histories",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_History_User_UserId",
                table: "Histories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Book_BookId",
                table: "Ratings",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Rating_User_UserId",
                table: "Ratings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_Book_BookId",
                table: "Statisticses",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_User_UserId",
                table: "Statisticses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
