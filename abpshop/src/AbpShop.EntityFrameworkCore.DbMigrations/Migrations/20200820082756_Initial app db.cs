using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbpShop.Migrations
{
    public partial class Initialappdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "IdentityServerPersistedGrants",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "IdentityServerIdentityResources",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "IdentityServerDeviceFlowCodes",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "IdentityServerClients",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "IdentityServerApiResources",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "AbpUsers",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "AbpTenants",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "AbpRoles",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(256) CHARACTER SET utf8mb4",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "AbpClaimTypes",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(256) CHARACTER SET utf8mb4",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "AbpBackgroundJobs",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "AbpAuditLogs",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "abp_article",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cid = table.Column<string>(type: "varchar(255)", nullable: true),
                    title = table.Column<string>(type: "varchar(255)", nullable: false),
                    author = table.Column<string>(type: "varchar(255)", nullable: true),
                    image_input = table.Column<string>(type: "varchar(255)", nullable: false),
                    synopsis = table.Column<string>(type: "varchar(255)", nullable: true),
                    share_title = table.Column<string>(type: "varchar(255)", nullable: true),
                    share_synopsis = table.Column<string>(type: "varchar(255)", nullable: true),
                    visit = table.Column<string>(type: "varchar(255)", nullable: true),
                    sort = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    url = table.Column<string>(type: "varchar(255)", nullable: true),
                    status = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    add_time = table.Column<string>(type: "varchar(255)", nullable: false),
                    hide = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    admin_id = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    mer_id = table.Column<uint>(type: "int(10) unsigned", nullable: true),
                    product_id = table.Column<int>(type: "int(10)", nullable: false),
                    is_hot = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    is_banner = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_article", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_article_category",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    pid = table.Column<int>(type: "int(11)", nullable: false),
                    title = table.Column<string>(type: "varchar(255)", nullable: false),
                    intr = table.Column<string>(type: "varchar(255)", nullable: true),
                    image = table.Column<string>(type: "varchar(255)", nullable: false),
                    status = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    sort = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    is_del = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    add_time = table.Column<string>(type: "varchar(255)", nullable: false),
                    hidden = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_article_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_article_content",
                columns: table => new
                {
                    nid = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    content = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_article_content", x => x.nid);
                });

            migrationBuilder.CreateTable(
                name: "abp_cache",
                columns: table => new
                {
                    key = table.Column<string>(type: "varchar(32)", nullable: false),
                    result = table.Column<string>(type: "text", nullable: true),
                    expire_time = table.Column<int>(type: "int(11)", nullable: false),
                    add_time = table.Column<int>(type: "int(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_cache", x => x.key);
                });

            migrationBuilder.CreateTable(
                name: "abp_diy",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    version = table.Column<string>(type: "varchar(255)", nullable: true),
                    name = table.Column<string>(type: "varchar(255)", nullable: true),
                    value = table.Column<string>(type: "text", nullable: true),
                    add_time = table.Column<int>(type: "int(11)", nullable: true),
                    update_time = table.Column<int>(type: "int(11)", nullable: true),
                    status = table.Column<bool>(nullable: true),
                    type = table.Column<bool>(nullable: true),
                    is_del = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_diy", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_express",
                columns: table => new
                {
                    id = table.Column<uint>(type: "mediumint(11) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(type: "varchar(50)", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", nullable: false),
                    sort = table.Column<int>(type: "int(11)", nullable: false),
                    is_show = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_express", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_qrcode",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    third_type = table.Column<string>(type: "varchar(32)", nullable: false),
                    third_id = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    ticket = table.Column<string>(type: "varchar(255)", nullable: false),
                    expire_seconds = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    status = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    add_time = table.Column<string>(type: "varchar(255)", nullable: false),
                    url = table.Column<string>(type: "varchar(255)", nullable: false),
                    qrcode_url = table.Column<string>(type: "varchar(255)", nullable: false),
                    scan = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    type = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_qrcode", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_routine_access_token",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(11) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    access_token = table.Column<string>(type: "varchar(256)", nullable: false),
                    stop_time = table.Column<uint>(type: "int(11) unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_routine_access_token", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_routine_form_id",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(11) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    uid = table.Column<int>(type: "int(11)", nullable: true),
                    form_id = table.Column<string>(type: "varchar(36)", nullable: false),
                    stop_time = table.Column<uint>(type: "int(11) unsigned", nullable: true),
                    status = table.Column<byte>(type: "tinyint(1) unsigned", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_routine_form_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_routine_qrcode",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    third_type = table.Column<string>(type: "varchar(32)", nullable: false),
                    third_id = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    status = table.Column<byte>(type: "tinyint(1) unsigned", nullable: true),
                    add_time = table.Column<string>(type: "varchar(255)", nullable: true),
                    page = table.Column<string>(type: "varchar(255)", nullable: true),
                    qrcode_url = table.Column<string>(type: "varchar(255)", nullable: true),
                    url_time = table.Column<uint>(type: "int(11) unsigned", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_routine_qrcode", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_shipping_templates",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(255)", nullable: false),
                    type = table.Column<bool>(nullable: false),
                    appoint = table.Column<bool>(nullable: false),
                    sort = table.Column<int>(type: "int(11)", nullable: false),
                    add_time = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_shipping_templates", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_shipping_templates_free",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    province_id = table.Column<int>(type: "int(11)", nullable: false),
                    temp_id = table.Column<int>(type: "int(11)", nullable: false),
                    city_id = table.Column<int>(type: "int(11)", nullable: false),
                    number = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    type = table.Column<bool>(nullable: false),
                    uniqid = table.Column<string>(type: "varchar(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_shipping_templates_free", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_shipping_templates_region",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    province_id = table.Column<int>(type: "int(11)", nullable: false),
                    temp_id = table.Column<int>(type: "int(11)", nullable: false),
                    city_id = table.Column<int>(type: "int(11)", nullable: false),
                    first = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    first_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    @continue = table.Column<decimal>(name: "continue", type: "decimal(10,2)", nullable: false),
                    continue_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    type = table.Column<bool>(nullable: false),
                    uniqid = table.Column<string>(type: "varchar(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_shipping_templates_region", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_sms_record",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(11) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    uid = table.Column<string>(type: "varchar(255)", nullable: false),
                    phone = table.Column<string>(type: "char(11)", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    add_time = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    add_ip = table.Column<string>(type: "varchar(16)", nullable: false),
                    template = table.Column<string>(type: "varchar(255)", nullable: false),
                    resultcode = table.Column<uint>(type: "int(6) unsigned", nullable: true),
                    record_id = table.Column<uint>(type: "int(11) unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_sms_record", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_store_bargain",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(11) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    product_id = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    title = table.Column<string>(type: "varchar(255)", nullable: false),
                    image = table.Column<string>(type: "varchar(150)", nullable: false),
                    unit_name = table.Column<string>(type: "varchar(16)", nullable: true),
                    stock = table.Column<uint>(type: "int(11) unsigned", nullable: true),
                    sales = table.Column<uint>(type: "int(11) unsigned", nullable: true),
                    images = table.Column<string>(type: "varchar(2000)", nullable: false),
                    start_time = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    stop_time = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    store_name = table.Column<string>(type: "varchar(255)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: true),
                    min_price = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: true),
                    num = table.Column<uint>(type: "int(11) unsigned", nullable: true),
                    bargain_max_price = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: true),
                    bargain_min_price = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: true),
                    bargain_num = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    status = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    give_integral = table.Column<decimal>(type: "decimal(10,2) unsigned", nullable: false),
                    info = table.Column<string>(type: "varchar(255)", nullable: true),
                    cost = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: true),
                    sort = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    is_hot = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    is_del = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    add_time = table.Column<uint>(type: "int(11) unsigned", nullable: true),
                    is_postage = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    postage = table.Column<decimal>(type: "decimal(10,2) unsigned", nullable: true),
                    rule = table.Column<string>(type: "text", nullable: true),
                    look = table.Column<uint>(type: "int(11) unsigned", nullable: true),
                    share = table.Column<uint>(type: "int(11) unsigned", nullable: true),
                    temp_id = table.Column<int>(type: "int(11)", nullable: true),
                    weight = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    volume = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    quota = table.Column<int>(type: "int(10)", nullable: false),
                    quota_show = table.Column<int>(type: "int(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_store_bargain", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_store_bargain_user",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(11) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    uid = table.Column<uint>(type: "int(11) unsigned", nullable: true),
                    bargain_id = table.Column<uint>(type: "int(11) unsigned", nullable: true),
                    bargain_price_min = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: true),
                    bargain_price = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: true),
                    status = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    add_time = table.Column<uint>(type: "int(11) unsigned", nullable: true),
                    is_del = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_store_bargain_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_store_bargain_user_help",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(11) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    uid = table.Column<uint>(type: "int(11) unsigned", nullable: true),
                    bargain_id = table.Column<uint>(type: "int(11) unsigned", nullable: true),
                    bargain_user_id = table.Column<uint>(type: "int(11) unsigned", nullable: true),
                    price = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: true),
                    add_time = table.Column<uint>(type: "int(11) unsigned", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_store_bargain_user_help", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_store_cart",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint(8) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    uid = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    type = table.Column<string>(type: "varchar(32)", nullable: false),
                    product_id = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    product_attr_unique = table.Column<string>(type: "varchar(16)", nullable: false),
                    cart_num = table.Column<ushort>(type: "smallint(5) unsigned", nullable: false),
                    add_time = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    is_pay = table.Column<bool>(nullable: false),
                    is_del = table.Column<bool>(nullable: false),
                    is_new = table.Column<bool>(nullable: false),
                    combination_id = table.Column<uint>(type: "int(11) unsigned", nullable: true),
                    seckill_id = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    bargain_id = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_store_cart", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_store_category",
                columns: table => new
                {
                    id = table.Column<int>(type: "mediumint(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    pid = table.Column<int>(type: "mediumint(11)", nullable: false),
                    cate_name = table.Column<string>(type: "varchar(100)", nullable: false),
                    sort = table.Column<int>(type: "mediumint(11)", nullable: false),
                    pic = table.Column<string>(type: "varchar(128)", nullable: false),
                    is_show = table.Column<bool>(nullable: false),
                    add_time = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_store_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_store_combination",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    product_id = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    mer_id = table.Column<uint>(type: "int(10) unsigned", nullable: true),
                    image = table.Column<string>(type: "varchar(255)", nullable: false),
                    images = table.Column<string>(type: "varchar(2000)", nullable: false),
                    title = table.Column<string>(type: "varchar(255)", nullable: false),
                    attr = table.Column<string>(type: "varchar(255)", nullable: true),
                    people = table.Column<uint>(type: "int(2) unsigned", nullable: false),
                    info = table.Column<string>(type: "varchar(255)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2) unsigned", nullable: false),
                    sort = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    sales = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    stock = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    add_time = table.Column<string>(type: "varchar(128)", nullable: false),
                    is_host = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    is_show = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    is_del = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    combination = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    mer_use = table.Column<byte>(type: "tinyint(1) unsigned", nullable: true),
                    is_postage = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    postage = table.Column<decimal>(type: "decimal(10,2) unsigned", nullable: false),
                    start_time = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    stop_time = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    effective_time = table.Column<int>(type: "int(11)", nullable: false),
                    cost = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    browse = table.Column<int>(type: "int(11)", nullable: true),
                    unit_name = table.Column<string>(type: "varchar(32)", nullable: false),
                    temp_id = table.Column<int>(type: "int(11)", nullable: true),
                    weight = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    volume = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    num = table.Column<int>(type: "int(11)", nullable: true),
                    quota = table.Column<int>(type: "int(10)", nullable: false),
                    quota_show = table.Column<int>(type: "int(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_store_combination", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_store_coupon",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(11) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(64)", nullable: false),
                    integral = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    coupon_price = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: false),
                    use_min_price = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: false),
                    coupon_time = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    sort = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    status = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    add_time = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    is_del = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    product_id = table.Column<string>(type: "varchar(64)", nullable: false),
                    category_id = table.Column<int>(type: "int(11)", nullable: false),
                    type = table.Column<sbyte>(type: "tinyint(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_store_coupon", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_store_coupon_issue",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cid = table.Column<int>(type: "int(10)", nullable: true),
                    coupon_title = table.Column<string>(type: "varchar(255)", nullable: true),
                    start_time = table.Column<int>(type: "int(10)", nullable: true),
                    end_time = table.Column<int>(type: "int(10)", nullable: true),
                    total_count = table.Column<int>(type: "int(10)", nullable: true),
                    remain_count = table.Column<int>(type: "int(10)", nullable: true),
                    is_permanent = table.Column<bool>(nullable: false),
                    status = table.Column<bool>(nullable: false),
                    is_give_subscribe = table.Column<bool>(nullable: false),
                    is_full_give = table.Column<bool>(nullable: false),
                    full_reduction = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    is_del = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    add_time = table.Column<int>(type: "int(10)", nullable: true),
                    title = table.Column<string>(type: "varchar(64)", nullable: false),
                    integral = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    coupon_price = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: false),
                    use_min_price = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: false),
                    coupon_time = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    product_id = table.Column<string>(type: "varchar(64)", nullable: false),
                    category_id = table.Column<int>(type: "int(11)", nullable: false),
                    type = table.Column<sbyte>(type: "tinyint(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_store_coupon_issue", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_store_coupon_issue_user",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int(10)", nullable: false),
                    issue_coupon_id = table.Column<int>(type: "int(10)", nullable: false),
                    add_time = table.Column<int>(type: "int(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_store_coupon_issue_user", x => new { x.uid, x.issue_coupon_id });
                });

            migrationBuilder.CreateTable(
                name: "abp_store_coupon_product",
                columns: table => new
                {
                    coupon_id = table.Column<int>(type: "int(11)", nullable: false),
                    product_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_store_coupon_product", x => new { x.coupon_id, x.product_id });
                });

            migrationBuilder.CreateTable(
                name: "abp_store_coupon_user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cid = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    uid = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    coupon_title = table.Column<string>(type: "varchar(32)", nullable: false),
                    coupon_price = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: false),
                    use_min_price = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: false),
                    add_time = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    end_time = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    use_time = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    type = table.Column<string>(type: "varchar(32)", nullable: false),
                    status = table.Column<bool>(nullable: false),
                    is_fail = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_store_coupon_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_store_order",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(11) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    order_id = table.Column<string>(type: "varchar(32)", nullable: false),
                    uid = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    real_name = table.Column<string>(type: "varchar(32)", nullable: false),
                    user_phone = table.Column<string>(type: "varchar(18)", nullable: false),
                    user_address = table.Column<string>(type: "varchar(100)", nullable: false),
                    cart_id = table.Column<string>(type: "text", nullable: false),
                    freight_price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    total_num = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    total_price = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: false),
                    total_postage = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: false),
                    pay_price = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: false),
                    pay_postage = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: false),
                    deduction_price = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: false),
                    coupon_id = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    coupon_price = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: false),
                    paid = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    pay_time = table.Column<uint>(type: "int(11) unsigned", nullable: true),
                    pay_type = table.Column<string>(type: "varchar(32)", nullable: false),
                    add_time = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    status = table.Column<bool>(nullable: false),
                    refund_status = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    refund_reason_wap_img = table.Column<string>(type: "varchar(2000)", nullable: true),
                    refund_reason_wap_explain = table.Column<string>(type: "varchar(255)", nullable: true),
                    refund_reason_time = table.Column<uint>(type: "int(11) unsigned", nullable: true),
                    refund_reason_wap = table.Column<string>(type: "varchar(255)", nullable: true),
                    refund_reason = table.Column<string>(type: "varchar(255)", nullable: true),
                    refund_price = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: false),
                    delivery_name = table.Column<string>(type: "varchar(64)", nullable: true),
                    delivery_type = table.Column<string>(type: "varchar(32)", nullable: true),
                    delivery_id = table.Column<string>(type: "varchar(64)", nullable: true),
                    gain_integral = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: false),
                    use_integral = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: false),
                    back_integral = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: true),
                    mark = table.Column<string>(type: "varchar(512)", nullable: false),
                    is_del = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    unique = table.Column<string>(type: "char(32)", nullable: false),
                    remark = table.Column<string>(type: "varchar(512)", nullable: true),
                    mer_id = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    is_mer_check = table.Column<byte>(type: "tinyint(3) unsigned", nullable: false),
                    combination_id = table.Column<uint>(type: "int(11) unsigned", nullable: true),
                    pink_id = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    cost = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: false),
                    seckill_id = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    bargain_id = table.Column<uint>(type: "int(11) unsigned", nullable: true),
                    verify_code = table.Column<string>(type: "varchar(12)", nullable: false),
                    store_id = table.Column<int>(type: "int(11)", nullable: false),
                    shipping_type = table.Column<bool>(nullable: false),
                    clerk_id = table.Column<int>(type: "int(11)", nullable: false),
                    is_channel = table.Column<byte>(type: "tinyint(1) unsigned", nullable: true),
                    is_remind = table.Column<byte>(type: "tinyint(1) unsigned", nullable: true),
                    is_system_del = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_store_order", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_store_order_cart_info",
                columns: table => new
                {
                    oid = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    cart_id = table.Column<string>(type: "varchar(50)", nullable: false),
                    product_id = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    cart_info = table.Column<string>(type: "text", nullable: false),
                    unique = table.Column<string>(type: "char(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_store_order_cart_info", x => new { x.oid, x.cart_id, x.product_id });
                });

            migrationBuilder.CreateTable(
                name: "abp_store_order_status",
                columns: table => new
                {
                    oid = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    change_type = table.Column<string>(type: "varchar(32)", nullable: false),
                    change_message = table.Column<string>(type: "varchar(256)", nullable: false),
                    change_time = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_store_order_status", x => new { x.oid, x.change_type });
                });

            migrationBuilder.CreateTable(
                name: "abp_store_pink",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    uid = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    order_id = table.Column<string>(type: "varchar(32)", nullable: false),
                    order_id_key = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    total_num = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    total_price = table.Column<decimal>(type: "decimal(10,2) unsigned", nullable: false),
                    cid = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    pid = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    people = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2) unsigned", nullable: false),
                    add_time = table.Column<string>(type: "varchar(24)", nullable: false),
                    stop_time = table.Column<string>(type: "varchar(24)", nullable: false),
                    k_id = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    is_tpl = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    is_refund = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    status = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_store_pink", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_store_product",
                columns: table => new
                {
                    id = table.Column<int>(type: "mediumint(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    mer_id = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    image = table.Column<string>(type: "varchar(256)", nullable: false),
                    slider_image = table.Column<string>(type: "varchar(2000)", nullable: false),
                    store_name = table.Column<string>(type: "varchar(128)", nullable: false),
                    store_info = table.Column<string>(type: "varchar(256)", nullable: false),
                    keyword = table.Column<string>(type: "varchar(256)", nullable: false),
                    bar_code = table.Column<string>(type: "varchar(15)", nullable: false),
                    cate_id = table.Column<string>(type: "varchar(64)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: false),
                    vip_price = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: false),
                    ot_price = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: false),
                    postage = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: false),
                    unit_name = table.Column<string>(type: "varchar(32)", nullable: false),
                    sort = table.Column<short>(type: "smallint(11)", nullable: false),
                    sales = table.Column<uint>(type: "mediumint(11) unsigned", nullable: false),
                    stock = table.Column<uint>(type: "mediumint(11) unsigned", nullable: false),
                    is_show = table.Column<bool>(nullable: false),
                    is_hot = table.Column<bool>(nullable: false),
                    is_benefit = table.Column<bool>(nullable: false),
                    is_best = table.Column<bool>(nullable: false),
                    is_new = table.Column<bool>(nullable: false),
                    add_time = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    is_postage = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    is_del = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    mer_use = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    give_integral = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: false),
                    cost = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: false),
                    is_seckill = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    is_bargain = table.Column<byte>(type: "tinyint(1) unsigned", nullable: true),
                    is_good = table.Column<bool>(nullable: false),
                    is_sub = table.Column<bool>(nullable: false),
                    ficti = table.Column<int>(type: "mediumint(11)", nullable: true),
                    browse = table.Column<int>(type: "int(11)", nullable: true),
                    code_path = table.Column<string>(type: "varchar(64)", nullable: false),
                    soure_link = table.Column<string>(type: "varchar(255)", nullable: true),
                    video_link = table.Column<string>(type: "varchar(200)", nullable: false),
                    temp_id = table.Column<int>(type: "int(11)", nullable: false),
                    spec_type = table.Column<bool>(nullable: false),
                    activity = table.Column<string>(type: "varchar(255)", nullable: false),
                    spu = table.Column<string>(type: "char(13)", nullable: false),
                    label_id = table.Column<string>(type: "varchar(64)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_store_product", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_store_product_attr",
                columns: table => new
                {
                    product_id = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    attr_name = table.Column<string>(type: "varchar(32)", nullable: false),
                    type = table.Column<bool>(nullable: false),
                    attr_values = table.Column<string>(type: "varchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_store_product_attr", x => new { x.product_id, x.attr_name, x.type });
                });

            migrationBuilder.CreateTable(
                name: "abp_store_product_attr_result",
                columns: table => new
                {
                    product_id = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    type = table.Column<bool>(nullable: false),
                    result = table.Column<string>(type: "text", nullable: false),
                    change_time = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_store_product_attr_result", x => new { x.product_id, x.type });
                });

            migrationBuilder.CreateTable(
                name: "abp_store_product_attr_value",
                columns: table => new
                {
                    product_id = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    suk = table.Column<string>(type: "varchar(128)", nullable: false),
                    stock = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    sales = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    price = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: false),
                    image = table.Column<string>(type: "varchar(128)", nullable: true),
                    unique = table.Column<string>(type: "char(8)", nullable: false),
                    cost = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: false),
                    bar_code = table.Column<string>(type: "varchar(50)", nullable: false),
                    ot_price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    weight = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    volume = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    brokerage = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    brokerage_two = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    type = table.Column<bool>(nullable: true),
                    quota = table.Column<int>(type: "int(11)", nullable: true),
                    quota_show = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "abp_store_product_cate",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    product_id = table.Column<int>(type: "int(11)", nullable: false),
                    cate_id = table.Column<int>(type: "int(11)", nullable: false),
                    add_time = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_store_product_cate", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_store_product_coupon",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    product_id = table.Column<int>(type: "int(10)", nullable: false),
                    issue_coupon_id = table.Column<int>(type: "int(10)", nullable: false),
                    title = table.Column<string>(type: "varchar(255)", nullable: false),
                    add_time = table.Column<int>(type: "int(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_store_product_coupon", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_store_product_description",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int(11)", nullable: false),
                    type = table.Column<bool>(nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_store_product_description", x => new { x.product_id, x.type });
                });

            migrationBuilder.CreateTable(
                name: "abp_store_product_relation",
                columns: table => new
                {
                    uid = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    product_id = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    type = table.Column<string>(type: "varchar(32)", nullable: false),
                    category = table.Column<string>(type: "varchar(32)", nullable: false),
                    add_time = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_store_product_relation", x => new { x.uid, x.product_id, x.type, x.category });
                });

            migrationBuilder.CreateTable(
                name: "abp_store_product_reply",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    uid = table.Column<int>(type: "int(11)", nullable: false),
                    oid = table.Column<int>(type: "int(11)", nullable: false),
                    unique = table.Column<string>(type: "char(32)", nullable: false),
                    product_id = table.Column<int>(type: "int(11)", nullable: false),
                    reply_type = table.Column<string>(type: "varchar(32)", nullable: false),
                    product_score = table.Column<bool>(nullable: false),
                    service_score = table.Column<bool>(nullable: false),
                    comment = table.Column<string>(type: "varchar(512)", nullable: false),
                    pics = table.Column<string>(type: "text", nullable: false),
                    add_time = table.Column<int>(type: "int(11)", nullable: false),
                    merchant_reply_content = table.Column<string>(type: "varchar(300)", nullable: true),
                    merchant_reply_time = table.Column<int>(type: "int(11)", nullable: true),
                    is_del = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    is_reply = table.Column<bool>(nullable: false),
                    nickname = table.Column<string>(type: "varchar(64)", nullable: false),
                    avatar = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_store_product_reply", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_store_product_rule",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    rule_name = table.Column<string>(type: "varchar(32)", nullable: false),
                    rule_value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_store_product_rule", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_store_seckill",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    product_id = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    image = table.Column<string>(type: "varchar(255)", nullable: false),
                    images = table.Column<string>(type: "varchar(2000)", nullable: false),
                    title = table.Column<string>(type: "varchar(255)", nullable: false),
                    info = table.Column<string>(type: "varchar(255)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2) unsigned", nullable: false),
                    cost = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: false),
                    ot_price = table.Column<decimal>(type: "decimal(10,2) unsigned", nullable: false),
                    give_integral = table.Column<decimal>(type: "decimal(10,2) unsigned", nullable: false),
                    sort = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    stock = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    sales = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    unit_name = table.Column<string>(type: "varchar(16)", nullable: false),
                    postage = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    start_time = table.Column<string>(type: "varchar(128)", nullable: false),
                    stop_time = table.Column<string>(type: "varchar(128)", nullable: false),
                    add_time = table.Column<string>(type: "varchar(128)", nullable: false),
                    status = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    is_postage = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    is_hot = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    is_del = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    num = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    is_show = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    time_id = table.Column<int>(type: "int(11)", nullable: true),
                    temp_id = table.Column<int>(type: "int(11)", nullable: true),
                    weight = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    volume = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    quota = table.Column<int>(type: "int(10)", nullable: false),
                    quota_show = table.Column<int>(type: "int(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_store_seckill", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_store_seckill_time",
                columns: table => new
                {
                    seckill_id = table.Column<int>(type: "int(10)", nullable: false),
                    time_id = table.Column<int>(type: "int(10)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "abp_store_service",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    mer_id = table.Column<int>(type: "int(11)", nullable: false),
                    uid = table.Column<int>(type: "int(11)", nullable: false),
                    avatar = table.Column<string>(type: "varchar(250)", nullable: false),
                    nickname = table.Column<string>(type: "varchar(50)", nullable: false),
                    phone = table.Column<string>(type: "varchar(20)", nullable: false),
                    add_time = table.Column<int>(type: "int(11)", nullable: false),
                    status = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    notify = table.Column<int>(type: "int(2)", nullable: true),
                    customer = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_store_service", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_store_service_log",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    mer_id = table.Column<int>(type: "int(11)", nullable: false),
                    msn = table.Column<string>(type: "text", nullable: false),
                    uid = table.Column<int>(type: "int(11)", nullable: false),
                    to_uid = table.Column<int>(type: "int(11)", nullable: false),
                    add_time = table.Column<int>(type: "int(11)", nullable: false),
                    type = table.Column<bool>(nullable: false),
                    remind = table.Column<bool>(nullable: false),
                    msn_type = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_store_service_log", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_store_visit",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    product_id = table.Column<int>(type: "int(11)", nullable: true),
                    product_type = table.Column<string>(type: "varchar(32)", nullable: true),
                    cate_id = table.Column<int>(type: "int(11)", nullable: true),
                    type = table.Column<string>(type: "char(50)", nullable: true),
                    uid = table.Column<int>(type: "int(11)", nullable: true),
                    count = table.Column<int>(type: "int(11)", nullable: true),
                    content = table.Column<string>(type: "varchar(255)", nullable: true),
                    add_time = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_store_visit", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_system_admin",
                columns: table => new
                {
                    id = table.Column<ushort>(type: "smallint(5) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    account = table.Column<string>(type: "varchar(32)", nullable: false),
                    head_pic = table.Column<string>(type: "varchar(255)", nullable: false),
                    pwd = table.Column<string>(type: "char(100)", nullable: false),
                    real_name = table.Column<string>(type: "varchar(16)", nullable: false),
                    roles = table.Column<string>(type: "varchar(128)", nullable: false),
                    last_ip = table.Column<string>(type: "varchar(16)", nullable: true),
                    last_time = table.Column<uint>(type: "int(10) unsigned", nullable: true),
                    add_time = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    login_count = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    level = table.Column<byte>(type: "tinyint(3) unsigned", nullable: false),
                    status = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    is_del = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_system_admin", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_system_attachment",
                columns: table => new
                {
                    att_id = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(100)", nullable: false),
                    att_dir = table.Column<string>(type: "varchar(200)", nullable: false),
                    satt_dir = table.Column<string>(type: "varchar(200)", nullable: true),
                    att_size = table.Column<string>(type: "char(30)", nullable: false),
                    att_type = table.Column<string>(type: "char(30)", nullable: false),
                    pid = table.Column<int>(type: "int(10)", nullable: false),
                    time = table.Column<int>(type: "int(11)", nullable: false),
                    image_type = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    module_type = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_system_attachment", x => x.att_id);
                });

            migrationBuilder.CreateTable(
                name: "abp_system_attachment_category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    pid = table.Column<int>(type: "int(11)", nullable: true),
                    name = table.Column<string>(type: "varchar(50)", nullable: false),
                    enname = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_system_attachment_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_system_city",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    city_id = table.Column<int>(type: "int(11)", nullable: false),
                    level = table.Column<int>(type: "int(11)", nullable: false),
                    parent_id = table.Column<int>(type: "int(11)", nullable: false),
                    area_code = table.Column<string>(type: "varchar(30)", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", nullable: false),
                    merger_name = table.Column<string>(type: "varchar(255)", nullable: false),
                    lng = table.Column<string>(type: "varchar(50)", nullable: false),
                    lat = table.Column<string>(type: "varchar(50)", nullable: false),
                    is_show = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_system_city", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_system_config",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    menu_name = table.Column<string>(type: "varchar(255)", nullable: false),
                    type = table.Column<string>(type: "varchar(255)", nullable: false),
                    input_type = table.Column<string>(type: "varchar(20)", nullable: true),
                    config_tab_id = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    parameter = table.Column<string>(type: "varchar(255)", nullable: true),
                    upload_type = table.Column<byte>(type: "tinyint(1) unsigned", nullable: true),
                    required = table.Column<string>(type: "varchar(255)", nullable: true),
                    width = table.Column<uint>(type: "int(10) unsigned", nullable: true),
                    high = table.Column<uint>(type: "int(10) unsigned", nullable: true),
                    value = table.Column<string>(type: "varchar(5000)", nullable: true),
                    info = table.Column<string>(type: "varchar(255)", nullable: false),
                    desc = table.Column<string>(type: "varchar(255)", nullable: true),
                    sort = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    status = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_system_config", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_system_config_tab",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    pid = table.Column<int>(type: "int(11)", nullable: false),
                    title = table.Column<string>(type: "varchar(255)", nullable: false),
                    eng_title = table.Column<string>(type: "varchar(255)", nullable: false),
                    status = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    info = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    icon = table.Column<string>(type: "varchar(30)", nullable: true),
                    type = table.Column<int>(type: "int(2)", nullable: true),
                    sort = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_system_config_tab", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_system_file",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cthash = table.Column<string>(type: "char(32)", nullable: false),
                    filename = table.Column<string>(type: "varchar(255)", nullable: false),
                    atime = table.Column<string>(type: "char(12)", nullable: false),
                    mtime = table.Column<string>(type: "char(12)", nullable: false),
                    ctime = table.Column<string>(type: "char(12)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_system_file", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_system_group",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", nullable: false),
                    info = table.Column<string>(type: "varchar(256)", nullable: false),
                    config_name = table.Column<string>(type: "varchar(50)", nullable: false),
                    fields = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_system_group", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_system_group_data",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    gid = table.Column<int>(type: "int(11)", nullable: false),
                    value = table.Column<string>(type: "text", nullable: false),
                    add_time = table.Column<int>(type: "int(10)", nullable: false),
                    sort = table.Column<int>(type: "int(11)", nullable: false),
                    status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_system_group_data", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_system_log",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    admin_id = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    admin_name = table.Column<string>(type: "varchar(64)", nullable: false),
                    path = table.Column<string>(type: "varchar(128)", nullable: false),
                    page = table.Column<string>(type: "varchar(64)", nullable: false),
                    method = table.Column<string>(type: "varchar(12)", nullable: false),
                    ip = table.Column<string>(type: "varchar(16)", nullable: false),
                    type = table.Column<string>(type: "varchar(32)", nullable: false),
                    add_time = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    merchant_id = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_system_log", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_system_menus",
                columns: table => new
                {
                    id = table.Column<ushort>(type: "smallint(5) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    pid = table.Column<ushort>(type: "smallint(5) unsigned", nullable: false),
                    icon = table.Column<string>(type: "varchar(16)", nullable: false),
                    menu_name = table.Column<string>(type: "varchar(32)", nullable: false),
                    module = table.Column<string>(type: "varchar(32)", nullable: false),
                    controller = table.Column<string>(type: "varchar(64)", nullable: false),
                    action = table.Column<string>(type: "varchar(32)", nullable: false),
                    api_url = table.Column<string>(type: "varchar(100)", nullable: false),
                    methods = table.Column<string>(type: "varchar(10)", nullable: false),
                    @params = table.Column<string>(name: "params", type: "varchar(128)", nullable: false),
                    sort = table.Column<sbyte>(type: "tinyint(3)", nullable: false),
                    is_show = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    is_show_path = table.Column<bool>(nullable: false),
                    access = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    menu_path = table.Column<string>(type: "varchar(128)", nullable: false),
                    auth_type = table.Column<bool>(nullable: false),
                    header = table.Column<string>(type: "varchar(50)", nullable: false),
                    is_header = table.Column<bool>(nullable: false),
                    unique_auth = table.Column<string>(type: "varchar(150)", nullable: false),
                    is_del = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_system_menus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_system_notice",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(64)", nullable: false),
                    type = table.Column<string>(type: "varchar(64)", nullable: false),
                    icon = table.Column<string>(type: "varchar(16)", nullable: false),
                    url = table.Column<string>(type: "varchar(64)", nullable: false),
                    table_title = table.Column<string>(type: "varchar(256)", nullable: false),
                    template = table.Column<string>(type: "varchar(64)", nullable: false),
                    push_admin = table.Column<string>(type: "varchar(128)", nullable: false),
                    status = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_system_notice", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_system_notice_admin",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    notice_type = table.Column<string>(type: "varchar(64)", nullable: false),
                    admin_id = table.Column<ushort>(type: "smallint(5) unsigned", nullable: false),
                    link_id = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    table_data = table.Column<string>(type: "text", nullable: false),
                    is_click = table.Column<byte>(type: "tinyint(3) unsigned", nullable: false),
                    is_visit = table.Column<byte>(type: "tinyint(3) unsigned", nullable: false),
                    visit_time = table.Column<int>(type: "int(11)", nullable: false),
                    add_time = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_system_notice_admin", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_system_role",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    role_name = table.Column<string>(type: "varchar(32)", nullable: false),
                    rules = table.Column<string>(type: "text", nullable: false),
                    level = table.Column<byte>(type: "tinyint(3) unsigned", nullable: false),
                    status = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_system_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_system_store",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(100)", nullable: false),
                    introduction = table.Column<string>(type: "varchar(1000)", nullable: false),
                    phone = table.Column<string>(type: "char(25)", nullable: false),
                    address = table.Column<string>(type: "varchar(255)", nullable: false),
                    detailed_address = table.Column<string>(type: "varchar(255)", nullable: false),
                    image = table.Column<string>(type: "varchar(255)", nullable: false),
                    latitude = table.Column<string>(type: "char(25)", nullable: false),
                    longitude = table.Column<string>(type: "char(25)", nullable: false),
                    valid_time = table.Column<string>(type: "varchar(100)", nullable: false),
                    day_time = table.Column<string>(type: "varchar(100)", nullable: false),
                    add_time = table.Column<int>(type: "int(11)", nullable: false),
                    is_show = table.Column<bool>(nullable: false),
                    is_del = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_system_store", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_system_store_staff",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(11) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    uid = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    avatar = table.Column<string>(type: "varchar(255)", nullable: false),
                    store_id = table.Column<int>(type: "int(11)", nullable: false),
                    staff_name = table.Column<string>(type: "varchar(64)", nullable: true),
                    phone = table.Column<string>(type: "char(15)", nullable: true),
                    verify_status = table.Column<sbyte>(type: "tinyint(2)", nullable: false),
                    status = table.Column<sbyte>(type: "tinyint(2)", nullable: true),
                    add_time = table.Column<int>(type: "int(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_system_store_staff", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_system_user_level",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    mer_id = table.Column<int>(type: "int(11)", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", nullable: false),
                    money = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    valid_date = table.Column<int>(type: "int(11)", nullable: false),
                    is_forever = table.Column<bool>(nullable: false),
                    is_pay = table.Column<bool>(nullable: false),
                    is_show = table.Column<bool>(nullable: false),
                    grade = table.Column<int>(type: "int(11)", nullable: false),
                    discount = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    image = table.Column<string>(type: "varchar(255)", nullable: false),
                    icon = table.Column<string>(type: "varchar(255)", nullable: false),
                    explain = table.Column<string>(type: "text", nullable: false),
                    add_time = table.Column<int>(type: "int(11)", nullable: false),
                    is_del = table.Column<bool>(nullable: false),
                    exp_num = table.Column<int>(type: "int(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_system_user_level", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_system_user_task",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(255)", nullable: false),
                    real_name = table.Column<string>(type: "varchar(255)", nullable: false),
                    task_type = table.Column<string>(type: "varchar(50)", nullable: false),
                    number = table.Column<int>(type: "int(11)", nullable: false),
                    level_id = table.Column<int>(type: "int(11)", nullable: false),
                    sort = table.Column<int>(type: "int(11)", nullable: false),
                    is_show = table.Column<bool>(nullable: false),
                    is_must = table.Column<bool>(nullable: false),
                    illustrate = table.Column<string>(type: "varchar(255)", nullable: false),
                    add_time = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_system_user_task", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_template_message",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    type = table.Column<bool>(nullable: false),
                    tempkey = table.Column<string>(type: "char(50)", nullable: false),
                    name = table.Column<string>(type: "char(100)", nullable: false),
                    content = table.Column<string>(type: "varchar(1000)", nullable: false),
                    tempid = table.Column<string>(type: "char(100)", nullable: true),
                    add_time = table.Column<string>(type: "varchar(15)", nullable: false),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_template_message", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_user",
                columns: table => new
                {
                    uid = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    account = table.Column<string>(type: "varchar(32)", nullable: false),
                    pwd = table.Column<string>(type: "varchar(32)", nullable: false),
                    real_name = table.Column<string>(type: "varchar(25)", nullable: false),
                    birthday = table.Column<int>(type: "int(11)", nullable: false),
                    card_id = table.Column<string>(type: "varchar(20)", nullable: false),
                    mark = table.Column<string>(type: "varchar(255)", nullable: false),
                    partner_id = table.Column<int>(type: "int(11)", nullable: false),
                    group_id = table.Column<int>(type: "int(11)", nullable: false),
                    nickname = table.Column<string>(type: "varchar(60)", nullable: false),
                    avatar = table.Column<string>(type: "varchar(256)", nullable: false),
                    phone = table.Column<string>(type: "char(15)", nullable: true),
                    add_time = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    add_ip = table.Column<string>(type: "varchar(16)", nullable: false),
                    last_time = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    last_ip = table.Column<string>(type: "varchar(16)", nullable: false),
                    now_money = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: false),
                    brokerage_price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    integral = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: false),
                    exp = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: false),
                    sign_num = table.Column<int>(type: "int(11)", nullable: false),
                    status = table.Column<bool>(nullable: false),
                    level = table.Column<byte>(type: "tinyint(2) unsigned", nullable: false),
                    spread_uid = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    spread_time = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    user_type = table.Column<string>(type: "varchar(32)", nullable: false),
                    is_promoter = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    pay_count = table.Column<uint>(type: "int(11) unsigned", nullable: true),
                    spread_count = table.Column<int>(type: "int(11)", nullable: true),
                    clean_time = table.Column<int>(type: "int(11)", nullable: true),
                    addres = table.Column<string>(type: "varchar(255)", nullable: false),
                    adminid = table.Column<uint>(type: "int(11) unsigned", nullable: true),
                    login_type = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_user", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "abp_user_address",
                columns: table => new
                {
                    id = table.Column<uint>(type: "mediumint(8) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    uid = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    real_name = table.Column<string>(type: "varchar(32)", nullable: false),
                    phone = table.Column<string>(type: "varchar(16)", nullable: false),
                    province = table.Column<string>(type: "varchar(64)", nullable: false),
                    city = table.Column<string>(type: "varchar(64)", nullable: false),
                    city_id = table.Column<int>(type: "int(11)", nullable: false),
                    district = table.Column<string>(type: "varchar(64)", nullable: false),
                    detail = table.Column<string>(type: "varchar(256)", nullable: false),
                    post_code = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    longitude = table.Column<string>(type: "varchar(16)", nullable: false),
                    latitude = table.Column<string>(type: "varchar(16)", nullable: false),
                    is_default = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    is_del = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    add_time = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_user_address", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_user_bill",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    uid = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    link_id = table.Column<string>(type: "varchar(32)", nullable: false),
                    pm = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    title = table.Column<string>(type: "varchar(64)", nullable: false),
                    category = table.Column<string>(type: "varchar(64)", nullable: false),
                    type = table.Column<string>(type: "varchar(64)", nullable: false),
                    number = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: false),
                    balance = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: false),
                    mark = table.Column<string>(type: "varchar(512)", nullable: false),
                    add_time = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    status = table.Column<bool>(nullable: false),
                    take = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_user_bill", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_user_enter",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    uid = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    province = table.Column<string>(type: "varchar(32)", nullable: false),
                    city = table.Column<string>(type: "varchar(32)", nullable: false),
                    district = table.Column<string>(type: "varchar(32)", nullable: false),
                    address = table.Column<string>(type: "varchar(256)", nullable: false),
                    merchant_name = table.Column<string>(type: "varchar(256)", nullable: false),
                    link_user = table.Column<string>(type: "varchar(32)", nullable: false),
                    link_tel = table.Column<string>(type: "varchar(16)", nullable: false),
                    charter = table.Column<string>(type: "varchar(512)", nullable: false),
                    add_time = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    apply_time = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    success_time = table.Column<int>(type: "int(11)", nullable: false),
                    fail_message = table.Column<string>(type: "varchar(256)", nullable: false),
                    fail_time = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    status = table.Column<bool>(nullable: false),
                    is_lock = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    is_del = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_user_enter", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_user_extract",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    uid = table.Column<uint>(type: "int(10) unsigned", nullable: true),
                    real_name = table.Column<string>(type: "varchar(64)", nullable: true),
                    extract_type = table.Column<string>(type: "varchar(32)", nullable: true),
                    bank_code = table.Column<string>(type: "varchar(32)", nullable: true),
                    bank_address = table.Column<string>(type: "varchar(256)", nullable: true),
                    alipay_code = table.Column<string>(type: "varchar(64)", nullable: true),
                    extract_price = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: true),
                    mark = table.Column<string>(type: "varchar(512)", nullable: true),
                    balance = table.Column<decimal>(type: "decimal(8,2) unsigned", nullable: true),
                    fail_msg = table.Column<string>(type: "varchar(128)", nullable: true),
                    fail_time = table.Column<uint>(type: "int(10) unsigned", nullable: true),
                    add_time = table.Column<uint>(type: "int(10) unsigned", nullable: true),
                    status = table.Column<sbyte>(type: "tinyint(2)", nullable: true),
                    wechat = table.Column<string>(type: "varchar(15)", nullable: true),
                    qrcode_url = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_user_extract", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_user_group",
                columns: table => new
                {
                    id = table.Column<ushort>(type: "smallint(5) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    group_name = table.Column<string>(type: "varchar(64)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_user_group", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_user_label",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    label_name = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_user_label", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_user_label_relation",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int(11)", nullable: false),
                    label_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_user_label_relation", x => new { x.uid, x.label_id });
                });

            migrationBuilder.CreateTable(
                name: "abp_user_level",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    uid = table.Column<int>(type: "int(11)", nullable: false),
                    level_id = table.Column<int>(type: "int(11)", nullable: false),
                    grade = table.Column<int>(type: "int(11)", nullable: false),
                    valid_time = table.Column<int>(type: "int(11)", nullable: false),
                    is_forever = table.Column<bool>(nullable: false),
                    mer_id = table.Column<int>(type: "int(11)", nullable: false),
                    status = table.Column<bool>(nullable: false),
                    mark = table.Column<string>(type: "varchar(255)", nullable: false),
                    remind = table.Column<bool>(nullable: false),
                    is_del = table.Column<bool>(nullable: false),
                    add_time = table.Column<int>(type: "int(11)", nullable: false),
                    discount = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_user_level", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_user_notice",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    uid = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<bool>(nullable: false),
                    user = table.Column<string>(type: "varchar(20)", nullable: false),
                    title = table.Column<string>(type: "varchar(20)", nullable: false),
                    content = table.Column<string>(type: "varchar(500)", nullable: false),
                    add_time = table.Column<int>(type: "int(11)", nullable: false),
                    is_send = table.Column<bool>(nullable: false),
                    send_time = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_user_notice", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_user_notice_see",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nid = table.Column<int>(type: "int(11)", nullable: false),
                    uid = table.Column<int>(type: "int(11)", nullable: false),
                    add_time = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_user_notice_see", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_user_recharge",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    uid = table.Column<int>(type: "int(10)", nullable: true),
                    order_id = table.Column<string>(type: "varchar(32)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    give_price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    recharge_type = table.Column<string>(type: "varchar(32)", nullable: true),
                    paid = table.Column<bool>(nullable: true),
                    pay_time = table.Column<int>(type: "int(10)", nullable: true),
                    add_time = table.Column<int>(type: "int(12)", nullable: true),
                    refund_price = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_user_recharge", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_user_sign",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    uid = table.Column<int>(type: "int(11)", nullable: false),
                    title = table.Column<string>(type: "varchar(255)", nullable: false),
                    number = table.Column<int>(type: "int(11)", nullable: false),
                    balance = table.Column<int>(type: "int(11)", nullable: false),
                    add_time = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_user_sign", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_user_task_finish",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    task_id = table.Column<int>(type: "int(11)", nullable: false),
                    uid = table.Column<int>(type: "int(11)", nullable: false),
                    status = table.Column<bool>(nullable: false),
                    add_time = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_user_task_finish", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_user_token",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    uid = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    token = table.Column<string>(type: "varchar(500)", nullable: false),
                    create_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    expires_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    login_ip = table.Column<string>(type: "varchar(32)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_user_token", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_user_visit",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    uid = table.Column<int>(type: "int(11)", nullable: false),
                    url = table.Column<string>(type: "varchar(255)", nullable: false),
                    ip = table.Column<string>(type: "varchar(255)", nullable: false),
                    stay_time = table.Column<int>(type: "int(11)", nullable: false),
                    add_time = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_user_visit", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_wechat_key",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    reply_id = table.Column<int>(type: "int(10)", nullable: false),
                    keys = table.Column<string>(type: "varchar(64)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_wechat_key", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_wechat_media",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    type = table.Column<string>(type: "varchar(16)", nullable: false),
                    path = table.Column<string>(type: "varchar(128)", nullable: false),
                    media_id = table.Column<string>(type: "varchar(64)", nullable: false),
                    url = table.Column<string>(type: "varchar(256)", nullable: false),
                    temporary = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    add_time = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_wechat_media", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_wechat_message",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    openid = table.Column<string>(type: "varchar(32)", nullable: false),
                    type = table.Column<string>(type: "varchar(32)", nullable: false),
                    result = table.Column<string>(type: "varchar(512)", nullable: false),
                    add_time = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_wechat_message", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_wechat_news_category",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cate_name = table.Column<string>(type: "varchar(255)", nullable: false),
                    sort = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    status = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    new_id = table.Column<string>(type: "varchar(255)", nullable: false),
                    add_time = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_wechat_news_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_wechat_qrcode",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    third_type = table.Column<string>(type: "varchar(32)", nullable: false),
                    third_id = table.Column<uint>(type: "int(11) unsigned", nullable: false),
                    ticket = table.Column<string>(type: "varchar(255)", nullable: false),
                    expire_seconds = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    status = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    add_time = table.Column<string>(type: "varchar(255)", nullable: false),
                    url = table.Column<string>(type: "varchar(255)", nullable: false),
                    qrcode_url = table.Column<string>(type: "varchar(255)", nullable: false),
                    scan = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_wechat_qrcode", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_wechat_reply",
                columns: table => new
                {
                    id = table.Column<uint>(type: "mediumint(8) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    key = table.Column<string>(type: "varchar(64)", nullable: false),
                    type = table.Column<string>(type: "varchar(32)", nullable: false),
                    data = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    hide = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_wechat_reply", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abp_wechat_user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    uid = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    unionid = table.Column<string>(type: "varchar(30)", nullable: true),
                    openid = table.Column<string>(type: "varchar(30)", nullable: true),
                    nickname = table.Column<string>(type: "varchar(64)", nullable: false),
                    headimgurl = table.Column<string>(type: "varchar(256)", nullable: false),
                    sex = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false),
                    city = table.Column<string>(type: "varchar(64)", nullable: false),
                    language = table.Column<string>(type: "varchar(64)", nullable: false),
                    province = table.Column<string>(type: "varchar(64)", nullable: false),
                    country = table.Column<string>(type: "varchar(64)", nullable: false),
                    remark = table.Column<string>(type: "varchar(256)", nullable: true),
                    groupid = table.Column<ushort>(type: "smallint(5) unsigned", nullable: true),
                    tagid_list = table.Column<string>(type: "varchar(256)", nullable: true),
                    subscribe = table.Column<byte>(type: "tinyint(3) unsigned", nullable: true),
                    subscribe_time = table.Column<uint>(type: "int(10) unsigned", nullable: true),
                    add_time = table.Column<uint>(type: "int(10) unsigned", nullable: true),
                    user_type = table.Column<string>(type: "varchar(32)", nullable: true),
                    is_complete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_wechat_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AbpOrganizationUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: true),
                    Code = table.Column<string>(maxLength: 95, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpOrganizationUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpOrganizationUnits_AbpOrganizationUnits_ParentId",
                        column: x => x.ParentId,
                        principalTable: "AbpOrganizationUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppCommunity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(10,6)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(10,6)", nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCommunity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpOrganizationUnitRoles",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(nullable: false),
                    OrganizationUnitId = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpOrganizationUnitRoles", x => new { x.OrganizationUnitId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AbpOrganizationUnitRoles_AbpOrganizationUnits_OrganizationUn~",
                        column: x => x.OrganizationUnitId,
                        principalTable: "AbpOrganizationUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbpOrganizationUnitRoles_AbpRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AbpRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpUserOrganizationUnits",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    OrganizationUnitId = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserOrganizationUnits", x => new { x.OrganizationUnitId, x.UserId });
                    table.ForeignKey(
                        name: "FK_AbpUserOrganizationUnits_AbpOrganizationUnits_OrganizationUn~",
                        column: x => x.OrganizationUnitId,
                        principalTable: "AbpOrganizationUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbpUserOrganizationUnits_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbpOrganizationUnitRoles_RoleId_OrganizationUnitId",
                table: "AbpOrganizationUnitRoles",
                columns: new[] { "RoleId", "OrganizationUnitId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpOrganizationUnits_Code",
                table: "AbpOrganizationUnits",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_AbpOrganizationUnits_ParentId",
                table: "AbpOrganizationUnits",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserOrganizationUnits_UserId_OrganizationUnitId",
                table: "AbpUserOrganizationUnits",
                columns: new[] { "UserId", "OrganizationUnitId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "abp_article");

            migrationBuilder.DropTable(
                name: "abp_article_category");

            migrationBuilder.DropTable(
                name: "abp_article_content");

            migrationBuilder.DropTable(
                name: "abp_cache");

            migrationBuilder.DropTable(
                name: "abp_diy");

            migrationBuilder.DropTable(
                name: "abp_express");

            migrationBuilder.DropTable(
                name: "abp_qrcode");

            migrationBuilder.DropTable(
                name: "abp_routine_access_token");

            migrationBuilder.DropTable(
                name: "abp_routine_form_id");

            migrationBuilder.DropTable(
                name: "abp_routine_qrcode");

            migrationBuilder.DropTable(
                name: "abp_shipping_templates");

            migrationBuilder.DropTable(
                name: "abp_shipping_templates_free");

            migrationBuilder.DropTable(
                name: "abp_shipping_templates_region");

            migrationBuilder.DropTable(
                name: "abp_sms_record");

            migrationBuilder.DropTable(
                name: "abp_store_bargain");

            migrationBuilder.DropTable(
                name: "abp_store_bargain_user");

            migrationBuilder.DropTable(
                name: "abp_store_bargain_user_help");

            migrationBuilder.DropTable(
                name: "abp_store_cart");

            migrationBuilder.DropTable(
                name: "abp_store_category");

            migrationBuilder.DropTable(
                name: "abp_store_combination");

            migrationBuilder.DropTable(
                name: "abp_store_coupon");

            migrationBuilder.DropTable(
                name: "abp_store_coupon_issue");

            migrationBuilder.DropTable(
                name: "abp_store_coupon_issue_user");

            migrationBuilder.DropTable(
                name: "abp_store_coupon_product");

            migrationBuilder.DropTable(
                name: "abp_store_coupon_user");

            migrationBuilder.DropTable(
                name: "abp_store_order");

            migrationBuilder.DropTable(
                name: "abp_store_order_cart_info");

            migrationBuilder.DropTable(
                name: "abp_store_order_status");

            migrationBuilder.DropTable(
                name: "abp_store_pink");

            migrationBuilder.DropTable(
                name: "abp_store_product");

            migrationBuilder.DropTable(
                name: "abp_store_product_attr");

            migrationBuilder.DropTable(
                name: "abp_store_product_attr_result");

            migrationBuilder.DropTable(
                name: "abp_store_product_attr_value");

            migrationBuilder.DropTable(
                name: "abp_store_product_cate");

            migrationBuilder.DropTable(
                name: "abp_store_product_coupon");

            migrationBuilder.DropTable(
                name: "abp_store_product_description");

            migrationBuilder.DropTable(
                name: "abp_store_product_relation");

            migrationBuilder.DropTable(
                name: "abp_store_product_reply");

            migrationBuilder.DropTable(
                name: "abp_store_product_rule");

            migrationBuilder.DropTable(
                name: "abp_store_seckill");

            migrationBuilder.DropTable(
                name: "abp_store_seckill_time");

            migrationBuilder.DropTable(
                name: "abp_store_service");

            migrationBuilder.DropTable(
                name: "abp_store_service_log");

            migrationBuilder.DropTable(
                name: "abp_store_visit");

            migrationBuilder.DropTable(
                name: "abp_system_admin");

            migrationBuilder.DropTable(
                name: "abp_system_attachment");

            migrationBuilder.DropTable(
                name: "abp_system_attachment_category");

            migrationBuilder.DropTable(
                name: "abp_system_city");

            migrationBuilder.DropTable(
                name: "abp_system_config");

            migrationBuilder.DropTable(
                name: "abp_system_config_tab");

            migrationBuilder.DropTable(
                name: "abp_system_file");

            migrationBuilder.DropTable(
                name: "abp_system_group");

            migrationBuilder.DropTable(
                name: "abp_system_group_data");

            migrationBuilder.DropTable(
                name: "abp_system_log");

            migrationBuilder.DropTable(
                name: "abp_system_menus");

            migrationBuilder.DropTable(
                name: "abp_system_notice");

            migrationBuilder.DropTable(
                name: "abp_system_notice_admin");

            migrationBuilder.DropTable(
                name: "abp_system_role");

            migrationBuilder.DropTable(
                name: "abp_system_store");

            migrationBuilder.DropTable(
                name: "abp_system_store_staff");

            migrationBuilder.DropTable(
                name: "abp_system_user_level");

            migrationBuilder.DropTable(
                name: "abp_system_user_task");

            migrationBuilder.DropTable(
                name: "abp_template_message");

            migrationBuilder.DropTable(
                name: "abp_user");

            migrationBuilder.DropTable(
                name: "abp_user_address");

            migrationBuilder.DropTable(
                name: "abp_user_bill");

            migrationBuilder.DropTable(
                name: "abp_user_enter");

            migrationBuilder.DropTable(
                name: "abp_user_extract");

            migrationBuilder.DropTable(
                name: "abp_user_group");

            migrationBuilder.DropTable(
                name: "abp_user_label");

            migrationBuilder.DropTable(
                name: "abp_user_label_relation");

            migrationBuilder.DropTable(
                name: "abp_user_level");

            migrationBuilder.DropTable(
                name: "abp_user_notice");

            migrationBuilder.DropTable(
                name: "abp_user_notice_see");

            migrationBuilder.DropTable(
                name: "abp_user_recharge");

            migrationBuilder.DropTable(
                name: "abp_user_sign");

            migrationBuilder.DropTable(
                name: "abp_user_task_finish");

            migrationBuilder.DropTable(
                name: "abp_user_token");

            migrationBuilder.DropTable(
                name: "abp_user_visit");

            migrationBuilder.DropTable(
                name: "abp_wechat_key");

            migrationBuilder.DropTable(
                name: "abp_wechat_media");

            migrationBuilder.DropTable(
                name: "abp_wechat_message");

            migrationBuilder.DropTable(
                name: "abp_wechat_news_category");

            migrationBuilder.DropTable(
                name: "abp_wechat_qrcode");

            migrationBuilder.DropTable(
                name: "abp_wechat_reply");

            migrationBuilder.DropTable(
                name: "abp_wechat_user");

            migrationBuilder.DropTable(
                name: "AbpOrganizationUnitRoles");

            migrationBuilder.DropTable(
                name: "AbpUserOrganizationUnits");

            migrationBuilder.DropTable(
                name: "AppCommunity");

            migrationBuilder.DropTable(
                name: "AbpOrganizationUnits");

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "IdentityServerPersistedGrants",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "IdentityServerIdentityResources",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "IdentityServerDeviceFlowCodes",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "IdentityServerClients",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "IdentityServerApiResources",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "AbpUsers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "AbpTenants",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "AbpRoles",
                type: "varchar(256) CHARACTER SET utf8mb4",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "AbpClaimTypes",
                type: "varchar(256) CHARACTER SET utf8mb4",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "AbpBackgroundJobs",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "AbpAuditLogs",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40,
                oldNullable: true);
        }
    }
}
