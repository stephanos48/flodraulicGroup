using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace flodraulicproject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerLocations",
                columns: table => new
                {
                    CustomerLocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerLocations", x => x.CustomerLocationId);
                });

            migrationBuilder.CreateTable(
                name: "EcnLogStatuses",
                columns: table => new
                {
                    EcnLogStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcnLogStatuses", x => x.EcnLogStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Engineers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EngineerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engineers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estimators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstimatorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estimators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FloLocations",
                columns: table => new
                {
                    FloLocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloLocations", x => x.FloLocationId);
                });

            migrationBuilder.CreateTable(
                name: "HotlistResps",
                columns: table => new
                {
                    HotlistRespId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RespName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotlistResps", x => x.HotlistRespId);
                });

            migrationBuilder.CreateTable(
                name: "HotlistStatuses",
                columns: table => new
                {
                    HotlistStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotlistStatuses", x => x.HotlistStatusId);
                });

            migrationBuilder.CreateTable(
                name: "IssueCategories",
                columns: table => new
                {
                    IssueCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueCategories", x => x.IssueCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "LaborCodes",
                columns: table => new
                {
                    LaborCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaborCodeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaborCodes", x => x.LaborCodeId);
                });

            migrationBuilder.CreateTable(
                name: "LogStatuses",
                columns: table => new
                {
                    LogStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogStatusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogStatuses", x => x.LogStatusId);
                });

            migrationBuilder.CreateTable(
                name: "MfgLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MfgLocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MfgLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartFamilies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamilyName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartFamilies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesLocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceManuals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManualName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManualType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceManuals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "SupplierContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficeLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cell = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierContacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketStatuses",
                columns: table => new
                {
                    TicketStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketStatuses", x => x.TicketStatusId);
                });

            migrationBuilder.CreateTable(
                name: "WorkInstructions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WIName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WIType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkInstructions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    CustomerLocationId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_CustomerLocations_CustomerLocationId",
                        column: x => x.CustomerLocationId,
                        principalTable: "CustomerLocations",
                        principalColumn: "CustomerLocationId");
                });

            migrationBuilder.CreateTable(
                name: "FloContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloLocationId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FloContacts_FloLocations_FloLocationId",
                        column: x => x.FloLocationId,
                        principalTable: "FloLocations",
                        principalColumn: "FloLocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hotlists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Coordinator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineerId = table.Column<int>(type: "int", nullable: false),
                    IssueCategoryId = table.Column<int>(type: "int", nullable: false),
                    HotlistRespId = table.Column<int>(type: "int", nullable: false),
                    JobNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssueDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HrsLost = table.Column<double>(type: "float", nullable: true),
                    TotalDollarsLost = table.Column<double>(type: "float", nullable: true),
                    WorkStoppage = table.Column<bool>(type: "bit", nullable: false),
                    HotlistStatusId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotlists_Engineers_EngineerId",
                        column: x => x.EngineerId,
                        principalTable: "Engineers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hotlists_HotlistResps_HotlistRespId",
                        column: x => x.HotlistRespId,
                        principalTable: "HotlistResps",
                        principalColumn: "HotlistRespId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hotlists_HotlistStatuses_HotlistStatusId",
                        column: x => x.HotlistStatusId,
                        principalTable: "HotlistStatuses",
                        principalColumn: "HotlistStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hotlists_IssueCategories_IssueCategoryId",
                        column: x => x.IssueCategoryId,
                        principalTable: "IssueCategories",
                        principalColumn: "IssueCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeTrackers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateWorkPerformed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JobNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloLocationId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaborCodeId = table.Column<int>(type: "int", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineerId = table.Column<int>(type: "int", nullable: false),
                    WorkDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HrsWorked = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    P21Entered = table.Column<bool>(type: "bit", nullable: false),
                    ClosedEarly = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTrackers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeTrackers_Engineers_EngineerId",
                        column: x => x.EngineerId,
                        principalTable: "Engineers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeTrackers_FloLocations_FloLocationId",
                        column: x => x.FloLocationId,
                        principalTable: "FloLocations",
                        principalColumn: "FloLocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeTrackers_LaborCodes_LaborCodeId",
                        column: x => x.LaborCodeId,
                        principalTable: "LaborCodes",
                        principalColumn: "LaborCodeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    DiscountPrice = table.Column<double>(type: "float", nullable: false),
                    Qoh = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    PartFamilyId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeadTime = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_PartFamilies_PartFamilyId",
                        column: x => x.PartFamilyId,
                        principalTable: "PartFamilies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EngineeringLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogStatusId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuoteNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoricQuoteNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MfgLocationId = table.Column<int>(type: "int", nullable: false),
                    SalesLocationId = table.Column<int>(type: "int", nullable: false),
                    SalesPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qty = table.Column<int>(type: "int", nullable: true),
                    EstimatorId = table.Column<int>(type: "int", nullable: false),
                    QuoteRequestReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QuoteTargetDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QuoteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InitialQuoteReviewTargetDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InitialQuoteReviewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalQuoteReviewTargetDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalQuoteReviewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerPoNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PromiseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MIPTargetDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MIPDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContractReviewTargetDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContractReviewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderEntryTargetDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderEntryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EngineerId = table.Column<int>(type: "int", nullable: false),
                    KickOffTargetDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KickOffDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinancialReviewTargetDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinancialReviewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InitialDesignReviewTargetDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InitialDesignReviewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalDesignReviewTargetDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalDesignReviewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShopReleaseTargetDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShopReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RedlineNeeded = table.Column<bool>(type: "bit", nullable: false),
                    RedlineCompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QuotedEngHrs = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    QuotedShopHrs = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ActualEngHrs = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ActualShopHrs = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EngEff = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ShopEff = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    QuoteValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TargetShipDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ActualShipDate = table.Column<DateOnly>(type: "date", nullable: true),
                    QuotedOT = table.Column<bool>(type: "bit", nullable: false),
                    MIPOT = table.Column<bool>(type: "bit", nullable: false),
                    DesignOT = table.Column<bool>(type: "bit", nullable: false),
                    ShipOT = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineeringLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EngineeringLogs_Engineers_EngineerId",
                        column: x => x.EngineerId,
                        principalTable: "Engineers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EngineeringLogs_Estimators_EstimatorId",
                        column: x => x.EstimatorId,
                        principalTable: "Estimators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EngineeringLogs_LogStatuses_LogStatusId",
                        column: x => x.LogStatusId,
                        principalTable: "LogStatuses",
                        principalColumn: "LogStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EngineeringLogs_MfgLocations_MfgLocationId",
                        column: x => x.MfgLocationId,
                        principalTable: "MfgLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EngineeringLogs_SalesLocations_SalesLocationId",
                        column: x => x.SalesLocationId,
                        principalTable: "SalesLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShippingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderTotal = table.Column<double>(type: "float", nullable: false),
                    ListOrderTotal = table.Column<double>(type: "float", nullable: false),
                    LeadTime = table.Column<int>(type: "int", nullable: true),
                    PurchaseOrderNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrackingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Carrier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDueDate = table.Column<DateOnly>(type: "date", nullable: false),
                    SessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentIntentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderHeaders_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderHeaders_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Issue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TicketStatusId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_TicketStatuses_TicketStatusId",
                        column: x => x.TicketStatusId,
                        principalTable: "TicketStatuses",
                        principalColumn: "TicketStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotlistComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotlistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotlistComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotlistComments_Hotlists_HotlistId",
                        column: x => x.HotlistId,
                        principalTable: "Hotlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotlistImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotlistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotlistImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotlistImages_Hotlists_HotlistId",
                        column: x => x.HotlistId,
                        principalTable: "Hotlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloLocationId = table.Column<int>(type: "int", nullable: false),
                    StartQoh = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventories_FloLocations_FloLocationId",
                        column: x => x.FloLocationId,
                        principalTable: "FloLocations",
                        principalColumn: "FloLocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShippedQtys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloLocationId = table.Column<int>(type: "int", nullable: false),
                    QtyShipped = table.Column<int>(type: "int", nullable: false),
                    OrderNoId = table.Column<int>(type: "int", nullable: false),
                    ShipDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippedQtys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippedQtys_FloLocations_FloLocationId",
                        column: x => x.FloLocationId,
                        principalTable: "FloLocations",
                        principalColumn: "FloLocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShippedQtys_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FloLocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_FloLocations_FloLocationId",
                        column: x => x.FloLocationId,
                        principalTable: "FloLocations",
                        principalColumn: "FloLocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EcnLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EcnLogStatusId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EcnRequestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EngineeringLogId = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostImpact = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AffectPrice = table.Column<bool>(type: "bit", nullable: false),
                    CustomerApprovalReq = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ECNAddlEngHrs = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ECNAddlShopHrs = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PCNAddlEngHrs = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PCNAddlShopHrs = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RespToProcess = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EcnCompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcnLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EcnLogs_EcnLogStatuses_EcnLogStatusId",
                        column: x => x.EcnLogStatusId,
                        principalTable: "EcnLogStatuses",
                        principalColumn: "EcnLogStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EcnLogs_EngineeringLogs_EngineeringLogId",
                        column: x => x.EngineeringLogId,
                        principalTable: "EngineeringLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EngineeringLogImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineeringLogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineeringLogImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EngineeringLogImages_EngineeringLogs_EngineeringLogId",
                        column: x => x.EngineeringLogId,
                        principalTable: "EngineeringLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EngLogComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineeringLogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngLogComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EngLogComments_EngineeringLogs_EngineeringLogId",
                        column: x => x.EngineeringLogId,
                        principalTable: "EngineeringLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InitialQuoteReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineeringLogId = table.Column<int>(type: "int", nullable: false),
                    FGIForm = table.Column<bool>(type: "bit", nullable: false),
                    FGIFormDetail = table.Column<bool>(type: "bit", nullable: false),
                    MeetCustomerDate = table.Column<bool>(type: "bit", nullable: false),
                    CustomerWaitToTarget = table.Column<bool>(type: "bit", nullable: false),
                    CustomerSpecsReq = table.Column<bool>(type: "bit", nullable: false),
                    FallWithinFGICapability = table.Column<bool>(type: "bit", nullable: false),
                    ConfirmFGIForm = table.Column<bool>(type: "bit", nullable: false),
                    SystemType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimilarJob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Concerns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Suggestions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Engineer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntiateQuote = table.Column<bool>(type: "bit", nullable: false),
                    InitialQuoteCompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitialQuoteReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InitialQuoteReviews_EngineeringLogs_EngineeringLogId",
                        column: x => x.EngineeringLogId,
                        principalTable: "EngineeringLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderHeaderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    FloLocationId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_FloLocations_FloLocationId",
                        column: x => x.FloLocationId,
                        principalTable: "FloLocations",
                        principalColumn: "FloLocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_OrderHeaders_OrderHeaderId",
                        column: x => x.OrderHeaderId,
                        principalTable: "OrderHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EcnLogComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EcnLogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcnLogComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EcnLogComments_EcnLogs_EcnLogId",
                        column: x => x.EcnLogId,
                        principalTable: "EcnLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EcnLogImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EcnLogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcnLogImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EcnLogImages_EcnLogs_EcnLogId",
                        column: x => x.EcnLogId,
                        principalTable: "EcnLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Pumps" },
                    { 2, 2, "Valves" },
                    { 3, 3, "Filters" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[,]
                {
                    { 1, "Tech City", "Matheson", "6695446789", "12121", "IL", "124 Tech Dr" },
                    { 2, "Killua", "Refuse Supply", "6695446789", "12121", "WA", "126 Walawalla Dr" },
                    { 3, "Memphis", "United Fellows", "6695446789", "66121", "TN", "124 Africa Dr" }
                });

            migrationBuilder.InsertData(
                table: "CustomerLocations",
                columns: new[] { "CustomerLocationId", "Address", "City", "Country", "LocationName", "Notes", "State", "ZipCode" },
                values: new object[,]
                {
                    { 1, "", "", "", "ATL", "", "", "" },
                    { 2, "", "", "", "DFW", "", "", "" },
                    { 3, "", "", "", "HOU", "", "", "" }
                });

            migrationBuilder.InsertData(
                table: "EcnLogStatuses",
                columns: new[] { "EcnLogStatusId", "Notes", "StatusName" },
                values: new object[,]
                {
                    { 1, "", "New" },
                    { 2, "", "In Process" },
                    { 3, "", "Complete" }
                });

            migrationBuilder.InsertData(
                table: "Engineers",
                columns: new[] { "Id", "EngineerName", "ImageUrl", "Notes" },
                values: new object[,]
                {
                    { 1, "Anthony Bizon", "", "" },
                    { 2, "Brian Paxton", "", "" },
                    { 3, "Chris Dewandeler", "", "" },
                    { 4, "Chris Johnson", "", "" },
                    { 5, "Chris Walker", "", "" },
                    { 6, "Darren Zielke", "", "" },
                    { 7, "David Bucek", "", "" },
                    { 8, "Daymon Shear", "", "" },
                    { 9, "Derrick Herr", "", "" },
                    { 10, "Dylan Smith", "", "" },
                    { 11, "Kyle Swindlehurst", "", "" },
                    { 12, "Paul Brown", "", "" },
                    { 13, "Phil Kimberlin", "", "" },
                    { 14, "Randy Brown", "", "" },
                    { 15, "Scott Tidwell", "", "" },
                    { 16, "Dylan Smith", "", "" },
                    { 17, "Gaylynn Fisher", "", "" },
                    { 18, "Frank Edwards", "", "" },
                    { 19, "Joe Marshall", "", "" },
                    { 20, "Pat Laake", "", "" },
                    { 21, "Pending", "", "" }
                });

            migrationBuilder.InsertData(
                table: "Estimators",
                columns: new[] { "Id", "EstimatorName", "Notes" },
                values: new object[,]
                {
                    { 1, "Chris Walker", "" },
                    { 2, "Derrick Herr", "" },
                    { 3, "Frank Edwards", "" },
                    { 4, "Jeff Pogue", "" },
                    { 5, "Joe Sorano", "" },
                    { 6, "Kyle Swindlehurst", "" },
                    { 7, "Noelle Sorano", "" },
                    { 8, "Pat Laake", "" },
                    { 9, "Paul Brown", "" },
                    { 10, "Joe Marshall", "" },
                    { 11, "John Reed", "" },
                    { 12, "John Voss", "" },
                    { 13, "John Wheelock", "" },
                    { 14, "Scott Tidwell", "" },
                    { 15, "Scott Williams", "" },
                    { 16, "Theresa Schmittling", "" },
                    { 17, "Dave Bucek", "" },
                    { 18, "Inside Sales", "" },
                    { 19, "Unknown", "" }
                });

            migrationBuilder.InsertData(
                table: "FloLocations",
                columns: new[] { "FloLocationId", "Address", "City", "Country", "LocationName", "Notes", "State", "ZipCode" },
                values: new object[,]
                {
                    { 1, "", "", "", "ATL", "", "", "" },
                    { 2, "", "", "", "DFW", "", "", "" },
                    { 3, "", "", "", "HOU", "", "", "" }
                });

            migrationBuilder.InsertData(
                table: "HotlistResps",
                columns: new[] { "HotlistRespId", "Notes", "RespName" },
                values: new object[,]
                {
                    { 1, "", "Supplier" },
                    { 2, "", "Purchasing" },
                    { 3, "", "Engineering" },
                    { 4, "", "Operations" },
                    { 5, "", "Other" }
                });

            migrationBuilder.InsertData(
                table: "HotlistStatuses",
                columns: new[] { "HotlistStatusId", "Notes", "StatusName" },
                values: new object[,]
                {
                    { 1, "", "New" },
                    { 2, "", "In Process" },
                    { 3, "", "Complete" }
                });

            migrationBuilder.InsertData(
                table: "IssueCategories",
                columns: new[] { "IssueCategoryId", "CategoryName", "Notes" },
                values: new object[,]
                {
                    { 1, "Design Issue", "" },
                    { 2, "Drawing Creation Issue", "" },
                    { 3, "Part Damaged in Ops", "" },
                    { 4, "Parts Purchased Incorrectly", "" },
                    { 5, "Parts Not Purchased In Time", "" },
                    { 6, "Need Job Moved Up for Production", "" }
                });

            migrationBuilder.InsertData(
                table: "LaborCodes",
                columns: new[] { "LaborCodeId", "LaborCodeName", "Notes" },
                values: new object[,]
                {
                    { 1, "001", "Std Engineering Work on Project" },
                    { 2, "050", "First Time Test" },
                    { 3, "310", "Engineering Rework due to Vendor Error" },
                    { 4, "410", "Engineering Rework due to Eng Error" },
                    { 5, "460", "Engineering Rework due to Customer Change" },
                    { 6, "500", "Engineering Sales Support" },
                    { 7, "550", "PTO" },
                    { 8, "Overhead / Not Chargeable", "" },
                    { 9, "Manuals", "" },
                    { 10, "Redlines", "" },
                    { 11, "Quotes", "" }
                });

            migrationBuilder.InsertData(
                table: "LogStatuses",
                columns: new[] { "LogStatusId", "LogStatusName", "Notes" },
                values: new object[,]
                {
                    { 1, "A. Project Queue", "" },
                    { 2, "B. Quote Feasibility Review", "" },
                    { 3, "C. Preparing Quote", "" },
                    { 4, "D. Review Quote w/ Paul", "" },
                    { 5, "E. Sent Quote to Customer / Awaiting Decision", "" },
                    { 6, "F. Order Received / Eng Kick Off", "" },
                    { 7, "G. Managerial Approval for Quotes above $50K", "" },
                    { 8, "H. Engineering Design", "" },
                    { 9, "I. Design Sent to Customer for Approval", "" },
                    { 10, "J. Approved / Ready for Shop Release", "" },
                    { 11, "K. Shop Released / Waiting for Parts", "" },
                    { 12, "L. All Parts in Stock / Waiting to go to Assy", "" },
                    { 13, "M. Assembly & Test", "" },
                    { 14, "N. Shipping", "" },
                    { 15, "O. Documentation / Manual Done", "" },
                    { 16, "P. Completed Projects / Product Delivered", "" },
                    { 17, "Q. No Quote / Quote Archived", "" },
                    { 18, "R. On Hold", "" }
                });

            migrationBuilder.InsertData(
                table: "PartFamilies",
                columns: new[] { "Id", "DisplayOrder", "FamilyName" },
                values: new object[,]
                {
                    { 1, 1, "Tractor" },
                    { 2, 2, "Trailer" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "Notes", "StatusName" },
                values: new object[,]
                {
                    { 1, "", "NewOrder" },
                    { 2, "", "P21Entered" },
                    { 3, "", "Shipped/Invoiced" },
                    { 4, "", "Paid" },
                    { 5, "", "Canceled" }
                });

            migrationBuilder.InsertData(
                table: "TicketStatuses",
                columns: new[] { "TicketStatusId", "Notes", "StatusName" },
                values: new object[,]
                {
                    { 1, "", "New" },
                    { 2, "", "In Process" },
                    { 3, "", "Complete" }
                });

            migrationBuilder.InsertData(
                table: "FloContacts",
                columns: new[] { "Id", "Email", "FloLocationId", "Name", "Notes", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "stephen.english@me.com", 1, "Stephen English", "", null },
                    { 2, "trobbins@gmail.com", 2, "Tim Robbins", "", null },
                    { 3, "henglish@gmail.com", 3, "Helen English", "", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "DiscountPrice", "ImageUrl", "LeadTime", "ListPrice", "PartFamilyId", "PartNumber", "Qoh" },
                values: new object[,]
                {
                    { 1, 1, "Pump", 0.0, "", 14, 99.0, 1, "2000-3900", 5 },
                    { 2, 1, "Pump", 0.0, "", 14, 40.0, 1, "219-2370", 10 },
                    { 3, 2, "Valve", 0.0, "", 14, 55.0, 2, "031-6450", 15 },
                    { 4, 3, "Filter", 0.0, "", 14, 70.0, 1, "222-6780", 3 }
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "FloLocationId", "LocationName", "PartNumber", "ProductId", "StartQoh" },
                values: new object[,]
                {
                    { 1, 1, null, null, 1, 1 },
                    { 2, 2, null, null, 2, 10 },
                    { 3, 3, null, null, 3, 0 }
                });

            migrationBuilder.InsertData(
                table: "ShippedQtys",
                columns: new[] { "Id", "FloLocationId", "LocationName", "OrderNoId", "PartNumber", "ProductId", "QtyShipped", "ShipDate" },
                values: new object[,]
                {
                    { 1, 1, null, 1021, null, 1, 10, null },
                    { 2, 2, null, 1022, null, 2, 20, null },
                    { 3, 3, null, 1023, null, 3, 10, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CustomerLocationId",
                table: "AspNetUsers",
                column: "CustomerLocationId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EcnLogComments_EcnLogId",
                table: "EcnLogComments",
                column: "EcnLogId");

            migrationBuilder.CreateIndex(
                name: "IX_EcnLogImages_EcnLogId",
                table: "EcnLogImages",
                column: "EcnLogId");

            migrationBuilder.CreateIndex(
                name: "IX_EcnLogs_EcnLogStatusId",
                table: "EcnLogs",
                column: "EcnLogStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EcnLogs_EngineeringLogId",
                table: "EcnLogs",
                column: "EngineeringLogId");

            migrationBuilder.CreateIndex(
                name: "IX_EngineeringLogImages_EngineeringLogId",
                table: "EngineeringLogImages",
                column: "EngineeringLogId");

            migrationBuilder.CreateIndex(
                name: "IX_EngineeringLogs_EngineerId",
                table: "EngineeringLogs",
                column: "EngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_EngineeringLogs_EstimatorId",
                table: "EngineeringLogs",
                column: "EstimatorId");

            migrationBuilder.CreateIndex(
                name: "IX_EngineeringLogs_LogStatusId",
                table: "EngineeringLogs",
                column: "LogStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EngineeringLogs_MfgLocationId",
                table: "EngineeringLogs",
                column: "MfgLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_EngineeringLogs_SalesLocationId",
                table: "EngineeringLogs",
                column: "SalesLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_EngLogComments_EngineeringLogId",
                table: "EngLogComments",
                column: "EngineeringLogId");

            migrationBuilder.CreateIndex(
                name: "IX_FloContacts_FloLocationId",
                table: "FloContacts",
                column: "FloLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_HotlistComments_HotlistId",
                table: "HotlistComments",
                column: "HotlistId");

            migrationBuilder.CreateIndex(
                name: "IX_HotlistImages_HotlistId",
                table: "HotlistImages",
                column: "HotlistId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotlists_EngineerId",
                table: "Hotlists",
                column: "EngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotlists_HotlistRespId",
                table: "Hotlists",
                column: "HotlistRespId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotlists_HotlistStatusId",
                table: "Hotlists",
                column: "HotlistStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotlists_IssueCategoryId",
                table: "Hotlists",
                column: "IssueCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialQuoteReviews_EngineeringLogId",
                table: "InitialQuoteReviews",
                column: "EngineeringLogId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_FloLocationId",
                table: "Inventories",
                column: "FloLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_ProductId",
                table: "Inventories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_FloLocationId",
                table: "OrderDetails",
                column: "FloLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderHeaderId",
                table: "OrderDetails",
                column: "OrderHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_ApplicationUserId",
                table: "OrderHeaders",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_StatusId",
                table: "OrderHeaders",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PartFamilyId",
                table: "Products",
                column: "PartFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippedQtys_FloLocationId",
                table: "ShippedQtys",
                column: "FloLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippedQtys_ProductId",
                table: "ShippedQtys",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ApplicationUserId",
                table: "ShoppingCarts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_FloLocationId",
                table: "ShoppingCarts",
                column: "FloLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ProductId",
                table: "ShoppingCarts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ApplicationUserId",
                table: "Tickets",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketStatusId",
                table: "Tickets",
                column: "TicketStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTrackers_EngineerId",
                table: "TimeTrackers",
                column: "EngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTrackers_FloLocationId",
                table: "TimeTrackers",
                column: "FloLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTrackers_LaborCodeId",
                table: "TimeTrackers",
                column: "LaborCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "EcnLogComments");

            migrationBuilder.DropTable(
                name: "EcnLogImages");

            migrationBuilder.DropTable(
                name: "EngineeringLogImages");

            migrationBuilder.DropTable(
                name: "EngLogComments");

            migrationBuilder.DropTable(
                name: "FloContacts");

            migrationBuilder.DropTable(
                name: "HotlistComments");

            migrationBuilder.DropTable(
                name: "HotlistImages");

            migrationBuilder.DropTable(
                name: "InitialQuoteReviews");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ServiceManuals");

            migrationBuilder.DropTable(
                name: "ShippedQtys");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "SupplierContacts");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "TimeTrackers");

            migrationBuilder.DropTable(
                name: "WorkInstructions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "EcnLogs");

            migrationBuilder.DropTable(
                name: "Hotlists");

            migrationBuilder.DropTable(
                name: "OrderHeaders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "TicketStatuses");

            migrationBuilder.DropTable(
                name: "FloLocations");

            migrationBuilder.DropTable(
                name: "LaborCodes");

            migrationBuilder.DropTable(
                name: "EcnLogStatuses");

            migrationBuilder.DropTable(
                name: "EngineeringLogs");

            migrationBuilder.DropTable(
                name: "HotlistResps");

            migrationBuilder.DropTable(
                name: "HotlistStatuses");

            migrationBuilder.DropTable(
                name: "IssueCategories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "PartFamilies");

            migrationBuilder.DropTable(
                name: "Engineers");

            migrationBuilder.DropTable(
                name: "Estimators");

            migrationBuilder.DropTable(
                name: "LogStatuses");

            migrationBuilder.DropTable(
                name: "MfgLocations");

            migrationBuilder.DropTable(
                name: "SalesLocations");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "CustomerLocations");
        }
    }
}
