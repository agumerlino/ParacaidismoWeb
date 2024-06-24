using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Data.Migrations
{
    /// <inheritdoc />
    public partial class categoria1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Categoria_categoriaId",
                table: "Producto");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropIndex(
                name: "IX_Producto_categoriaId",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "categoriaId",
                table: "Producto");

            migrationBuilder.RenameColumn(
                name: "marca",
                table: "Producto",
                newName: "subcategoria");

            migrationBuilder.AddColumn<string>(
                name: "categoria",
                table: "Producto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "categoria",
                table: "Producto");

            migrationBuilder.RenameColumn(
                name: "subcategoria",
                table: "Producto",
                newName: "marca");

            migrationBuilder.AddColumn<int>(
                name: "categoriaId",
                table: "Producto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Producto_categoriaId",
                table: "Producto",
                column: "categoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Categoria_categoriaId",
                table: "Producto",
                column: "categoriaId",
                principalTable: "Categoria",
                principalColumn: "Id");
        }
    }
}
