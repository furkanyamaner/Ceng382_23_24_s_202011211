using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyApp.Data;
#nullable disable

namespace Lab11.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240502151959_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
{
#pragma warning disable 612, 618
    modelBuilder
        .HasAnnotation("ProductVersion", "8.0.4")
        .HasAnnotation("Relational:MaxIdentifierLength", 128);

    modelBuilder.Entity("Room", b =>
    {
        b.Property<int>("Id")
            .ValueGeneratedOnAdd() 
            .HasColumnType("int");

        b.Property<int>("Capacity")
            .HasColumnType("int");

        b.Property<string>("RoomName")
            .IsRequired()
            .HasColumnType("nvarchar(max)");

        b.HasKey("Id");

        b.ToTable("Rooms");
    });
#pragma warning restore 612, 618
}
    }
}