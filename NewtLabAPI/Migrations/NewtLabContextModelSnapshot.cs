// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewtlabAPI.Data;

namespace NewtlabAPI.Migrations
{
    [DbContext(typeof(NewtLabContext))]
    partial class NewtLabContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NewtlabAPI.Models.BancoPregunta", b =>
                {
                    b.Property<int>("BancoPreguntaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CalifTotalPublicado")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExperimentoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaLimite")
                        .HasColumnType("datetime2");

                    b.Property<string>("Grado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instruccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOn")
                        .HasColumnType("bit");

                    b.Property<bool>("Publicado")
                        .HasColumnType("bit");

                    b.Property<string>("Tema")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TituloPublicado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BancoPreguntaId");

                    b.HasIndex("ExperimentoId");

                    b.HasIndex("UserId");

                    b.ToTable("BancoPreguntas");
                });

            modelBuilder.Entity("NewtlabAPI.Models.Experimento", b =>
                {
                    b.Property<int>("ExperimentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Concepto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Puntuacion")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExperimentoId");

                    b.ToTable("Experimentos");
                });

            modelBuilder.Entity("NewtlabAPI.Models.History", b =>
                {
                    b.Property<int>("HistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("What")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HistoryId");

                    b.ToTable("History");
                });

            modelBuilder.Entity("NewtlabAPI.Models.Pregunta", b =>
                {
                    b.Property<int>("PreguntaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BancoPreguntaId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOn")
                        .HasColumnType("bit");

                    b.Property<int>("Puntuacion")
                        .HasColumnType("int");

                    b.Property<string>("TP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoPreguntaId")
                        .HasColumnType("int");

                    b.HasKey("PreguntaId");

                    b.HasIndex("BancoPreguntaId");

                    b.HasIndex("TipoPreguntaId");

                    b.ToTable("Preguntas");
                });

            modelBuilder.Entity("NewtlabAPI.Models.PruebaExperimento", b =>
                {
                    b.Property<int>("PruebaExperimentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BancoPreguntaId")
                        .HasColumnType("int");

                    b.Property<int>("CalificacionObtenida")
                        .HasColumnType("int");

                    b.Property<int>("CalificacionObtenidaReal")
                        .HasColumnType("int");

                    b.Property<int>("CalificacionTotal")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaTomado")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCerrada")
                        .HasColumnType("bit");

                    b.Property<string>("Periodo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PruebaExperimentoId");

                    b.HasIndex("BancoPreguntaId");

                    b.HasIndex("UserId");

                    b.ToTable("PruebaExperimentos");
                });

            modelBuilder.Entity("NewtlabAPI.Models.PruebaRespuesta", b =>
                {
                    b.Property<int>("PruebaRespuestaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PEId")
                        .HasColumnType("int");

                    b.Property<int>("PreguntaId")
                        .HasColumnType("int");

                    b.Property<int>("RespuestaId")
                        .HasColumnType("int");

                    b.HasKey("PruebaRespuestaId");

                    b.HasIndex("PEId");

                    b.HasIndex("PreguntaId");

                    b.HasIndex("RespuestaId");

                    b.ToTable("PruebaRespuesta");
                });

            modelBuilder.Entity("NewtlabAPI.Models.Respuesta", b =>
                {
                    b.Property<int>("RespuestaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EsCorrecta")
                        .HasColumnType("bit");

                    b.Property<int>("PreguntaId")
                        .HasColumnType("int");

                    b.HasKey("RespuestaId");

                    b.HasIndex("PreguntaId");

                    b.ToTable("Respuestas");
                });

            modelBuilder.Entity("NewtlabAPI.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("NewtlabAPI.Models.Sesion", b =>
                {
                    b.Property<int>("SesionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Grado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOn")
                        .HasColumnType("bit");

                    b.Property<string>("SesionNombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SesionId");

                    b.ToTable("Sesions");
                });

            modelBuilder.Entity("NewtlabAPI.Models.TipoPregunta", b =>
                {
                    b.Property<int>("TipoPreguntaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Concepto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipoPreguntaId");

                    b.ToTable("TipoPreguntas");
                });

            modelBuilder.Entity("NewtlabAPI.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cedula")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Grado")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("HouseNumber")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<bool>("IsOn")
                        .HasColumnType("bit");

                    b.Property<string>("LastName1")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("LastName2")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime>("Nacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Password")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Phone")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Seccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sector")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Street")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Username")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NewtlabAPI.Models.BancoPregunta", b =>
                {
                    b.HasOne("NewtlabAPI.Models.Experimento", "Experimento")
                        .WithMany()
                        .HasForeignKey("ExperimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewtlabAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Experimento");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NewtlabAPI.Models.Pregunta", b =>
                {
                    b.HasOne("NewtlabAPI.Models.BancoPregunta", "BancoPregunta")
                        .WithMany()
                        .HasForeignKey("BancoPreguntaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewtlabAPI.Models.TipoPregunta", "TipoPregunta")
                        .WithMany()
                        .HasForeignKey("TipoPreguntaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BancoPregunta");

                    b.Navigation("TipoPregunta");
                });

            modelBuilder.Entity("NewtlabAPI.Models.PruebaExperimento", b =>
                {
                    b.HasOne("NewtlabAPI.Models.BancoPregunta", "BancoPregunta")
                        .WithMany()
                        .HasForeignKey("BancoPreguntaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewtlabAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BancoPregunta");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NewtlabAPI.Models.PruebaRespuesta", b =>
                {
                    b.HasOne("NewtlabAPI.Models.PruebaExperimento", "PE")
                        .WithMany("PruebaRespuestas")
                        .HasForeignKey("PEId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("NewtlabAPI.Models.Pregunta", "Pregunta")
                        .WithMany()
                        .HasForeignKey("PreguntaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewtlabAPI.Models.Respuesta", "Respuesta")
                        .WithMany()
                        .HasForeignKey("RespuestaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PE");

                    b.Navigation("Pregunta");

                    b.Navigation("Respuesta");
                });

            modelBuilder.Entity("NewtlabAPI.Models.Respuesta", b =>
                {
                    b.HasOne("NewtlabAPI.Models.Pregunta", null)
                        .WithMany("Respuestas")
                        .HasForeignKey("PreguntaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NewtlabAPI.Models.User", b =>
                {
                    b.HasOne("NewtlabAPI.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("NewtlabAPI.Models.Pregunta", b =>
                {
                    b.Navigation("Respuestas");
                });

            modelBuilder.Entity("NewtlabAPI.Models.PruebaExperimento", b =>
                {
                    b.Navigation("PruebaRespuestas");
                });
#pragma warning restore 612, 618
        }
    }
}
