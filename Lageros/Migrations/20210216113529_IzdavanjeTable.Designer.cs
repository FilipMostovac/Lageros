// <auto-generated />
using System;
using Lageros.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lageros.Migrations
{
    [DbContext(typeof(LagerosContext))]
    [Migration("20210216113529_IzdavanjeTable")]
    partial class IzdavanjeTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Lageros.Models.AdminKorisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AdminKorisnik");
                });

            modelBuilder.Entity("Lageros.Models.Izbor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("NazivPeriferije")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Izbor");
                });

            modelBuilder.Entity("Lageros.Models.Izdavanje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DatumZamjene")
                        .HasColumnType("datetime2");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int?>("LaptopId")
                        .HasColumnType("int");

                    b.Property<int?>("MonitorId")
                        .HasColumnType("int");

                    b.Property<int?>("PeriferijaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("LaptopId");

                    b.HasIndex("MonitorId");

                    b.HasIndex("PeriferijaId");

                    b.ToTable("Izdavanje");
                });

            modelBuilder.Entity("Lageros.Models.Korisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SektorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SektorId");

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("Lageros.Models.Laptop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CPU")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HDD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("INV")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RAM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WINDOWS")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Laptop");
                });

            modelBuilder.Entity("Lageros.Models.Monitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("INV")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Velicina")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Monitor");
                });

            modelBuilder.Entity("Lageros.Models.NabavaTonera", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DatumZamjene")
                        .HasColumnType("datetime2");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int>("TonerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TonerId");

                    b.ToTable("NabavaTonera");
                });

            modelBuilder.Entity("Lageros.Models.Periferija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IzborId")
                        .HasColumnType("int");

                    b.Property<int>("Kolicnina")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IzborId");

                    b.ToTable("Periferija");
                });

            modelBuilder.Entity("Lageros.Models.Printer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("IP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Printeri");
                });

            modelBuilder.Entity("Lageros.Models.Sektor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("NazivSektora")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sektor");
                });

            modelBuilder.Entity("Lageros.Models.Toner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Boja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Toner");
                });

            modelBuilder.Entity("Lageros.Models.ZamjenaToner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AdminKorisnikId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumZamjene")
                        .HasColumnType("datetime2");

                    b.Property<int>("PrinterId")
                        .HasColumnType("int");

                    b.Property<int>("TonerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdminKorisnikId");

                    b.HasIndex("PrinterId");

                    b.HasIndex("TonerId");

                    b.ToTable("ZamjenaToner");
                });

            modelBuilder.Entity("Lageros.Models.Izdavanje", b =>
                {
                    b.HasOne("Lageros.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lageros.Models.Laptop", "Laptop")
                        .WithMany()
                        .HasForeignKey("LaptopId");

                    b.HasOne("Lageros.Models.Monitor", "Monitor")
                        .WithMany()
                        .HasForeignKey("MonitorId");

                    b.HasOne("Lageros.Models.Periferija", "Periferija")
                        .WithMany()
                        .HasForeignKey("PeriferijaId");

                    b.Navigation("Korisnik");

                    b.Navigation("Laptop");

                    b.Navigation("Monitor");

                    b.Navigation("Periferija");
                });

            modelBuilder.Entity("Lageros.Models.Korisnik", b =>
                {
                    b.HasOne("Lageros.Models.Sektor", "Sektor")
                        .WithMany()
                        .HasForeignKey("SektorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sektor");
                });

            modelBuilder.Entity("Lageros.Models.NabavaTonera", b =>
                {
                    b.HasOne("Lageros.Models.Toner", "Toner")
                        .WithMany()
                        .HasForeignKey("TonerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Toner");
                });

            modelBuilder.Entity("Lageros.Models.Periferija", b =>
                {
                    b.HasOne("Lageros.Models.Izbor", "Izbor")
                        .WithMany()
                        .HasForeignKey("IzborId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Izbor");
                });

            modelBuilder.Entity("Lageros.Models.ZamjenaToner", b =>
                {
                    b.HasOne("Lageros.Models.AdminKorisnik", "AdminKorisnik")
                        .WithMany()
                        .HasForeignKey("AdminKorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lageros.Models.Printer", "Printer")
                        .WithMany()
                        .HasForeignKey("PrinterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lageros.Models.Toner", "Toner")
                        .WithMany()
                        .HasForeignKey("TonerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdminKorisnik");

                    b.Navigation("Printer");

                    b.Navigation("Toner");
                });
#pragma warning restore 612, 618
        }
    }
}
