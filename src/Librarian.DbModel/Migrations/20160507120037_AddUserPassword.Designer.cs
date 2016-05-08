using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Librarian.DbModel.DbModel;

namespace Librarian.DbModel.Migrations
{
    [DbContext(typeof(DbModelConfiguration))]
    [Migration("20160507120037_AddUserPassword")]
    partial class AddUserPassword
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Librarian.DbModel.DbModel.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<Guid>("LibraryId");

                    b.Property<string>("Name");

                    b.HasKey("Id")
                        .HasAnnotation("Relational:Name", "PK_Books");

                    b.HasAnnotation("Relational:TableName", "Books");
                });

            modelBuilder.Entity("Librarian.DbModel.DbModel.History", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BookId");

                    b.Property<DateTime>("DatePut");

                    b.Property<DateTime>("DateTake");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id")
                        .HasAnnotation("Relational:Name", "PK_Histories");

                    b.HasAnnotation("Relational:TableName", "Histories");
                });

            modelBuilder.Entity("Librarian.DbModel.DbModel.Library", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id")
                        .HasAnnotation("Relational:Name", "PK_Libraries");

                    b.HasAnnotation("Relational:TableName", "Libraries");
                });

            modelBuilder.Entity("Librarian.DbModel.DbModel.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BookId");

                    b.Property<string>("Comment");

                    b.Property<DateTime>("Date");

                    b.Property<int>("RatingMark");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id")
                        .HasAnnotation("Relational:Name", "PK_Ratings");

                    b.HasAnnotation("Relational:TableName", "Ratings");
                });

            modelBuilder.Entity("Librarian.DbModel.DbModel.Statistics", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BookId");

                    b.Property<DateTime>("Date");

                    b.Property<decimal>("SpeedRead");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id")
                        .HasAnnotation("Relational:Name", "PK_Statisticses");

                    b.HasAnnotation("Relational:TableName", "Statisticses");
                });

            modelBuilder.Entity("Librarian.DbModel.DbModel.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adress");

                    b.Property<int>("Age");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.Property<string>("SecondName");

                    b.HasKey("Id")
                        .HasAnnotation("Relational:Name", "PK_Users");

                    b.HasAnnotation("Relational:TableName", "Users");
                });

            modelBuilder.Entity("Librarian.DbModel.DbModel.Book", b =>
                {
                    b.HasOne("Librarian.DbModel.DbModel.Library")
                        .WithMany()
                        .HasForeignKey("LibraryId");
                });

            modelBuilder.Entity("Librarian.DbModel.DbModel.History", b =>
                {
                    b.HasOne("Librarian.DbModel.DbModel.Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.HasOne("Librarian.DbModel.DbModel.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Librarian.DbModel.DbModel.Rating", b =>
                {
                    b.HasOne("Librarian.DbModel.DbModel.Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.HasOne("Librarian.DbModel.DbModel.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Librarian.DbModel.DbModel.Statistics", b =>
                {
                    b.HasOne("Librarian.DbModel.DbModel.Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.HasOne("Librarian.DbModel.DbModel.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
