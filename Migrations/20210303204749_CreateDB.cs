using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace api.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    identifier = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    code = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GroupType",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    identifier = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    code = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Month",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: true),
                    year = table.Column<short>(type: "smallint", nullable: false),
                    month = table.Column<short>(type: "smallint", nullable: false),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    identifier = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Month", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    identifier = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    code = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idGender = table.Column<long>(type: "bigint", nullable: false),
                    genderid = table.Column<long>(type: "bigint", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    name2 = table.Column<string>(type: "text", nullable: true),
                    surname = table.Column<string>(type: "text", nullable: true),
                    surname2 = table.Column<string>(type: "text", nullable: true),
                    birth = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    identifier = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.id);
                    table.ForeignKey(
                        name: "FK_Person_Gender_genderid",
                        column: x => x.genderid,
                        principalTable: "Gender",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idGroupType = table.Column<long>(type: "bigint", nullable: false),
                    groupTypeid = table.Column<long>(type: "bigint", nullable: true),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    identifier = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    code = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.id);
                    table.ForeignKey(
                        name: "FK_Group_GroupType_groupTypeid",
                        column: x => x.groupTypeid,
                        principalTable: "GroupType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Brother",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idPerson = table.Column<long>(type: "bigint", nullable: false),
                    personid = table.Column<long>(type: "bigint", nullable: true),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    identifier = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brother", x => x.id);
                    table.ForeignKey(
                        name: "FK_Brother_Person_personid",
                        column: x => x.personid,
                        principalTable: "Person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idPerson = table.Column<long>(type: "bigint", nullable: false),
                    personid = table.Column<long>(type: "bigint", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    username = table.Column<string>(type: "text", nullable: true),
                    pass = table.Column<string>(type: "text", nullable: true),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    identifier = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                    table.ForeignKey(
                        name: "FK_User_Person_personid",
                        column: x => x.personid,
                        principalTable: "Person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Group_Person",
                columns: table => new
                {
                    idGroup = table.Column<long>(type: "bigint", nullable: false),
                    idPerson = table.Column<long>(type: "bigint", nullable: false),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group_Person", x => new { x.idGroup, x.idPerson });
                    table.ForeignKey(
                        name: "FK_Group_Person_Group_idGroup",
                        column: x => x.idGroup,
                        principalTable: "Group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Group_Person_Person_idPerson",
                        column: x => x.idPerson,
                        principalTable: "Person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idBrother = table.Column<long>(type: "bigint", nullable: false),
                    brotherid = table.Column<long>(type: "bigint", nullable: true),
                    idMonth = table.Column<long>(type: "bigint", nullable: false),
                    monthid = table.Column<long>(type: "bigint", nullable: true),
                    time = table.Column<long>(type: "bigint", nullable: false),
                    placements = table.Column<short>(type: "smallint", nullable: false),
                    videos = table.Column<short>(type: "smallint", nullable: false),
                    visits = table.Column<short>(type: "smallint", nullable: false),
                    studies = table.Column<short>(type: "smallint", nullable: false),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    identifier = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.id);
                    table.ForeignKey(
                        name: "FK_Report_Brother_brotherid",
                        column: x => x.brotherid,
                        principalTable: "Brother",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Report_Month_monthid",
                        column: x => x.monthid,
                        principalTable: "Month",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User_Role",
                columns: table => new
                {
                    idRole = table.Column<long>(type: "bigint", nullable: false),
                    idUser = table.Column<long>(type: "bigint", nullable: false),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Role", x => new { x.idRole, x.idUser });
                    table.ForeignKey(
                        name: "FK_User_Role_Role_idRole",
                        column: x => x.idRole,
                        principalTable: "Role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Role_User_idUser",
                        column: x => x.idUser,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brother_identifier",
                table: "Brother",
                column: "identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brother_personid",
                table: "Brother",
                column: "personid");

            migrationBuilder.CreateIndex(
                name: "IX_Gender_identifier",
                table: "Gender",
                column: "identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Group_groupTypeid",
                table: "Group",
                column: "groupTypeid");

            migrationBuilder.CreateIndex(
                name: "IX_Group_identifier",
                table: "Group",
                column: "identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Group_Person_idPerson",
                table: "Group_Person",
                column: "idPerson");

            migrationBuilder.CreateIndex(
                name: "IX_GroupType_identifier",
                table: "GroupType",
                column: "identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Month_identifier",
                table: "Month",
                column: "identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_genderid",
                table: "Person",
                column: "genderid");

            migrationBuilder.CreateIndex(
                name: "IX_Person_identifier",
                table: "Person",
                column: "identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Report_brotherid",
                table: "Report",
                column: "brotherid");

            migrationBuilder.CreateIndex(
                name: "IX_Report_identifier",
                table: "Report",
                column: "identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Report_monthid",
                table: "Report",
                column: "monthid");

            migrationBuilder.CreateIndex(
                name: "IX_Role_identifier",
                table: "Role",
                column: "identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_identifier",
                table: "User",
                column: "identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_personid",
                table: "User",
                column: "personid");

            migrationBuilder.CreateIndex(
                name: "IX_User_Role_idUser",
                table: "User_Role",
                column: "idUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Group_Person");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "User_Role");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Brother");

            migrationBuilder.DropTable(
                name: "Month");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "GroupType");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Gender");
        }
    }
}
