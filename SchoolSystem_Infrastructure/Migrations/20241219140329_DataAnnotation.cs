using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem_Infrastructure.Migrations
{
	/// <inheritdoc />
	public partial class DataAnnotation : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropPrimaryKey(
				name: "PK_StudentSubjects",
				table: "StudentSubjects");

			migrationBuilder.DropIndex(
				name: "IX_StudentSubjects_SubID",
				table: "StudentSubjects");

			migrationBuilder.DropPrimaryKey(
				name: "PK_DepartmentSubjects",
				table: "DepartmentSubjects");

			migrationBuilder.DropIndex(
				name: "IX_DepartmentSubjects_SubID",
				table: "DepartmentSubjects");

			migrationBuilder.DropColumn(
				name: "StudSubID",
				table: "StudentSubjects");

			migrationBuilder.DropColumn(
				name: "DeptSubID",
				table: "DepartmentSubjects");

			migrationBuilder.RenameColumn(
				name: "Address",
				table: "Students",
				newName: "AddressEn");

			migrationBuilder.AddColumn<string>(
				name: "AddressAr",
				table: "Students",
				type: "nvarchar(100)",
				maxLength: 100,
				nullable: false,
				defaultValue: "");

			migrationBuilder.AddColumn<int>(
				name: "InsManager",
				table: "Departments",
				type: "int",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AddPrimaryKey(
				name: "PK_StudentSubjects",
				table: "StudentSubjects",
				columns: new[] { "SubID", "StudID" });

			migrationBuilder.AddPrimaryKey(
				name: "PK_DepartmentSubjects",
				table: "DepartmentSubjects",
				columns: new[] { "SubID", "DID" });

			migrationBuilder.CreateTable(
				name: "Instructor",
				columns: table => new
				{
					InsId = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					INameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
					INameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
					SupervisorId = table.Column<int>(type: "int", nullable: false),
					Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					DID = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Instructor", x => x.InsId);
					table.ForeignKey(
						name: "FK_Instructor_Departments_DID",
						column: x => x.DID,
						principalTable: "Departments",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Instructor_Instructor_SupervisorId",
						column: x => x.SupervisorId,
						principalTable: "Instructor",
						principalColumn: "InsId",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Ins_Subject",
				columns: table => new
				{
					InsId = table.Column<int>(type: "int", nullable: false),
					SubID = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Ins_Subject", x => new { x.SubID, x.InsId });
					table.ForeignKey(
						name: "FK_Ins_Subject_Instructor_InsId",
						column: x => x.InsId,
						principalTable: "Instructor",
						principalColumn: "InsId",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Ins_Subject_Subjects_SubID",
						column: x => x.SubID,
						principalTable: "Subjects",
						principalColumn: "SubID",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Departments_InsManager",
				table: "Departments",
				column: "InsManager",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_Ins_Subject_InsId",
				table: "Ins_Subject",
				column: "InsId");

			migrationBuilder.CreateIndex(
				name: "IX_Instructor_DID",
				table: "Instructor",
				column: "DID");

			migrationBuilder.CreateIndex(
				name: "IX_Instructor_SupervisorId",
				table: "Instructor",
				column: "SupervisorId");

			migrationBuilder.AddForeignKey(
				name: "FK_Departments_Instructor_InsManager",
				table: "Departments",
				column: "InsManager",
				principalTable: "Instructor",
				principalColumn: "InsId",
				onDelete: ReferentialAction.Restrict);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Departments_Instructor_InsManager",
				table: "Departments");

			migrationBuilder.DropTable(
				name: "Ins_Subject");

			migrationBuilder.DropTable(
				name: "Instructor");

			migrationBuilder.DropPrimaryKey(
				name: "PK_StudentSubjects",
				table: "StudentSubjects");

			migrationBuilder.DropPrimaryKey(
				name: "PK_DepartmentSubjects",
				table: "DepartmentSubjects");

			migrationBuilder.DropIndex(
				name: "IX_Departments_InsManager",
				table: "Departments");

			migrationBuilder.DropColumn(
				name: "AddressAr",
				table: "Students");

			migrationBuilder.DropColumn(
				name: "InsManager",
				table: "Departments");

			migrationBuilder.RenameColumn(
				name: "AddressEn",
				table: "Students",
				newName: "Address");

			migrationBuilder.AddColumn<int>(
				name: "StudSubID",
				table: "StudentSubjects",
				type: "int",
				nullable: false,
				defaultValue: 0)
				.Annotation("SqlServer:Identity", "1, 1");

			migrationBuilder.AddColumn<int>(
				name: "DeptSubID",
				table: "DepartmentSubjects",
				type: "int",
				nullable: false,
				defaultValue: 0)
				.Annotation("SqlServer:Identity", "1, 1");

			migrationBuilder.AddPrimaryKey(
				name: "PK_StudentSubjects",
				table: "StudentSubjects",
				column: "StudSubID");

			migrationBuilder.AddPrimaryKey(
				name: "PK_DepartmentSubjects",
				table: "DepartmentSubjects",
				column: "DeptSubID");

			migrationBuilder.CreateIndex(
				name: "IX_StudentSubjects_SubID",
				table: "StudentSubjects",
				column: "SubID");

			migrationBuilder.CreateIndex(
				name: "IX_DepartmentSubjects_SubID",
				table: "DepartmentSubjects",
				column: "SubID");
		}
	}
}
