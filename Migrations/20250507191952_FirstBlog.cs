using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace hlzn1.Migrations
{
    /// <inheritdoc />
    public partial class FirstBlog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:BlogPostSectionContentType", "audio,code,image,link,list,other,quote,table,text,video");

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Primary key of the entity")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false, comment: "The title of the blog post"),
                    Preview = table.Column<string>(type: "text", maxLength: 500, nullable: false, comment: "Preview of the blog post"),
                    PreviewImageSource = table.Column<string>(type: "text", nullable: true, comment: "The preview size image of the blog post"),
                    PublishedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "When the blog post was published"),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false, comment: "Is the blog post public?"),
                    Tags = table.Column<List<string>>(type: "text[]", nullable: false, comment: "The tags of the blog post"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()", comment: "When the entity was created"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()", comment: "When the entity was last updated")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                },
                comment: "Table storing blog posts");

            migrationBuilder.CreateTable(
                name: "BlogPostSections",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Primary key of the entity")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Index = table.Column<int>(type: "integer", nullable: false, comment: "The order of the section in the blog post"),
                    Content = table.Column<string>(type: "text", nullable: false, comment: "The content of the blog post section"),
                    ContentType = table.Column<string>(type: "text", nullable: false, comment: "The type of content in the blog post section"),
                    BlogPostId = table.Column<int>(type: "integer", nullable: false, comment: "The ID of the associated blog post"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()", comment: "When the entity was created"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()", comment: "When the entity was last updated")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPostSections_BlogPosts_BlogPostId",
                        column: x => x.BlogPostId,
                        principalSchema: "public",
                        principalTable: "BlogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Table storing sections of blog posts");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostSections_BlogPostId",
                schema: "public",
                table: "BlogPostSections",
                column: "BlogPostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPostSections",
                schema: "public");

            migrationBuilder.DropTable(
                name: "BlogPosts",
                schema: "public");
        }
    }
}
