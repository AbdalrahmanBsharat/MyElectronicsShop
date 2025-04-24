using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyElectronicShop.Migrations
{
    public partial class initial : Migration    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    TypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    PrId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.PrId);
                    table.ForeignKey(
                        name: "FK_Product_Type_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Type",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PrId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItem_Product_PrId",
                        column: x => x.PrId,
                        principalTable: "Product",
                        principalColumn: "PrId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Type",
                columns: new[] { "TypeId", "Name" },
                values: new object[,]
                {
                    { "Hp", "HeadPhone" },
                    { "Kb", "Keyboard" },
                    { "Lp", "Laptop" },
                    { "Ph", "Phone" },
                    { "Tb", "Tablet" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "admin@gmail.com", "admin", "admin" },
                    { 2, "bsh@gmail.com", "1234", "abdulrahman" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "PrId", "Name", "Price", "TypeId", "url" },
                values: new object[,]
                {
                    { 1, "Hp", 2333.0, "Lp", "https://i5.walmartimages.com/seo/HP-Pavilion-13-3-FHD-Intel-Core-i3-8GB-RAM-128GB-SSD-Silver_906cf222-d138-430a-8146-d129b0cca3a2_2.f838f300a6e31f50074faf4091a1da7b.jpeg" },
                    { 2, "Lenovo", 1933.0, "Lp", "https://5.imimg.com/data5/DE/DA/QN/SELLER-32244351/lenovo-laptop.jpg" },
                    { 3, "Logetich", 200.0, "Kb", "https://resource.logitechg.com/w_692,c_lpad,ar_4:3,q_auto,f_auto,dpr_2.0/d_transparent.gif/content/dam/gaming/en/non-braid/g213-finch/g213-gallery-1-nb.png?v=1" },
                    { 4, "dell", 2300.0, "Lp", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQMKs7Vxec19Gg5sde8PgYCpX8gWxnE95rQc_dOg0Z7zXWhy2k&s" },
                    { 5, "IPad", 1000.0, "Tb", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTMQNuL-_Ki109-IuOFLsuA0KqKqVfJFFqD2HuSsoBtWpYYBpQh&s" },
                    { 6, "Razer", 400.0, "Hp", "https://i5.walmartimages.com/seo/Razer-Kraken-V3-Pro-Wireless-Gaming-Headset-for-PC-2-4GHz-Haptics-Chroma-RGB-368g-Black_124e137a-e85f-459b-9fbb-0ac27e9391ef.561e94d10b97d275b6595b557ad4aea3.jpeg" },
                    { 7, "Iphone 15 pro max", 1200.0, "Ph", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS7_2BCfJmsRBXN3n7N6JAf3Wz8Qr-DIENaIVioqg0YxffTTGU&s" },
                    { 8, "MegaGee", 500.0, "Kb", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTwelPo0iIyzHKB-m-IH86RvUa2E7Q0igaR--CfVZkBkQ-4CLQ&s" }
                });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "CartItemId", "PrId", "Quantity", "UserId" },
                values: new object[] { 1, 1, 1, 2 });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "CartItemId", "PrId", "Quantity", "UserId" },
                values: new object[] { 2, 3, 2, 2 });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "CartItemId", "PrId", "Quantity", "UserId" },
                values: new object[] { 3, 1, 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_PrId",
                table: "CartItem",
                column: "PrId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_TypeId",
                table: "Product",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Type");
        }
    }
}
