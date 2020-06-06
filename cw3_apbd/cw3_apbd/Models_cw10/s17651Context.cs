using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace cw3_apbd.Models_cw10
{
    public partial class s17651Context : DbContext
    {
        public s17651Context()
        {
        }

        public s17651Context(DbContextOptions<s17651Context> options)
            : base(options)
        {
        }

        public virtual DbSet<CharakterWystepu> CharakterWystepu { get; set; }
        public virtual DbSet<Dept> Dept { get; set; }
        public virtual DbSet<Emp> Emp { get; set; }
        public virtual DbSet<EmpDeptView> EmpDeptView { get; set; }
        public virtual DbSet<Enrollment> Enrollment { get; set; }
        public virtual DbSet<Gosc> Gosc { get; set; }
        public virtual DbSet<Instrument> Instrument { get; set; }
        public virtual DbSet<Kategoria> Kategoria { get; set; }
        public virtual DbSet<Kompozytor> Kompozytor { get; set; }
        public virtual DbSet<MiejsceWystepu> MiejsceWystepu { get; set; }
        public virtual DbSet<Nauczyciel> Nauczyciel { get; set; }
        public virtual DbSet<Ocena> Ocena { get; set; }
        public virtual DbSet<Osoba> Osoba { get; set; }
        public virtual DbSet<Pianista> Pianista { get; set; }
        public virtual DbSet<Pokoj> Pokoj { get; set; }
        public virtual DbSet<Proba> Proba { get; set; }
        public virtual DbSet<Rezerwacja> Rezerwacja { get; set; }
        public virtual DbSet<Salgrade> Salgrade { get; set; }
        public virtual DbSet<Srednia> Srednia { get; set; }
        public virtual DbSet<StopienAwansu> StopienAwansu { get; set; }
        public virtual DbSet<StopienNaukowy> StopienNaukowy { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Studies> Studies { get; set; }
        public virtual DbSet<Tonacja> Tonacja { get; set; }
        public virtual DbSet<Uczen> Uczen { get; set; }
        public virtual DbSet<UczenUtworProba> UczenUtworProba { get; set; }
        public virtual DbSet<UczenUtworWystep> UczenUtworWystep { get; set; }
        public virtual DbSet<Utwor> Utwor { get; set; }
        public virtual DbSet<Wystep> Wystep { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder//.UseSqlServer("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s17651;Integrated Security=True")
                .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharakterWystepu>(entity =>
            {
                entity.HasKey(e => e.IdCharakterWystepu)
                    .HasName("PK__Charakte__A04B3811AB1EBCE0");

                entity.ToTable("Charakter_Wystepu");

                entity.Property(e => e.IdCharakterWystepu)
                    .HasColumnName("Id_Charakter_Wystepu")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dept>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DEPT");

                entity.Property(e => e.Deptno).HasColumnName("DEPTNO");

                entity.Property(e => e.Dname)
                    .HasColumnName("DNAME")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Loc)
                    .HasColumnName("LOC")
                    .HasMaxLength(13)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Emp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EMP");

                entity.Property(e => e.Comm).HasColumnName("COMM");

                entity.Property(e => e.Deptno).HasColumnName("DEPTNO");

                entity.Property(e => e.Empno).HasColumnName("EMPNO");

                entity.Property(e => e.Ename)
                    .HasColumnName("ENAME")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hiredate)
                    .HasColumnName("HIREDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Job)
                    .HasColumnName("JOB")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Mgr).HasColumnName("MGR");

                entity.Property(e => e.Sal).HasColumnName("SAL");
            });

            modelBuilder.Entity<EmpDeptView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("EmpDept_View");

                entity.Property(e => e.Dname)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Ename)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(e => e.IdEnrollment)
                    .HasName("Enrollment_pk");

                entity.Property(e => e.IdEnrollment).ValueGeneratedNever();

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.IdStudyNavigation)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(d => d.IdStudy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Enrollment_Studies");
            });

            modelBuilder.Entity<Gosc>(entity =>
            {
                entity.HasKey(e => e.IdGosc)
                    .HasName("PK__Gosc__8126AB6D7BE6282F");

                entity.Property(e => e.IdGosc).ValueGeneratedNever();

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProcentRabatu).HasColumnName("Procent_rabatu");
            });

            modelBuilder.Entity<Instrument>(entity =>
            {
                entity.HasKey(e => e.IdInstrument)
                    .HasName("PK__Instrume__760C5E6C8AA33226");

                entity.Property(e => e.IdInstrument)
                    .HasColumnName("Id_Instrument")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kategoria>(entity =>
            {
                entity.HasKey(e => e.IdKategoria)
                    .HasName("PK__Kategori__31412B2669751ADD");

                entity.Property(e => e.IdKategoria).ValueGeneratedNever();

                entity.Property(e => e.Cena).HasColumnType("numeric(8, 2)");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kompozytor>(entity =>
            {
                entity.HasKey(e => e.IdOsoba)
                    .HasName("Id_Kompozytor");

                entity.Property(e => e.IdOsoba)
                    .HasColumnName("Id_Osoba")
                    .ValueGeneratedNever();

                entity.Property(e => e.DataSmierci)
                    .HasColumnName("Data_Smierci")
                    .HasColumnType("date");

                entity.Property(e => e.DataUrodzenia)
                    .HasColumnName("Data_Urodzenia")
                    .HasColumnType("date");

                entity.HasOne(d => d.IdOsobaNavigation)
                    .WithOne(p => p.Kompozytor)
                    .HasForeignKey<Kompozytor>(d => d.IdOsoba)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Osoba_Kompozytor_FK1");
            });

            modelBuilder.Entity<MiejsceWystepu>(entity =>
            {
                entity.HasKey(e => e.IdMiejsce)
                    .HasName("PK__Miejsce___72B6452127B8A566");

                entity.ToTable("Miejsce_Wystepu");

                entity.Property(e => e.IdMiejsce)
                    .HasColumnName("Id_Miejsce")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adres)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Nauczyciel>(entity =>
            {
                entity.HasKey(e => e.IdOsoba)
                    .HasName("Id_Nauczyciel");

                entity.Property(e => e.IdOsoba)
                    .HasColumnName("Id_Osoba")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdAwansu).HasColumnName("Id_Awansu");

                entity.Property(e => e.IdNaukowy).HasColumnName("Id_Naukowy");

                entity.HasOne(d => d.IdAwansuNavigation)
                    .WithMany(p => p.Nauczyciel)
                    .HasForeignKey(d => d.IdAwansu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Nauczycie__Id_Aw__1332DBDC");

                entity.HasOne(d => d.IdNaukowyNavigation)
                    .WithMany(p => p.Nauczyciel)
                    .HasForeignKey(d => d.IdNaukowy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Nauczycie__Id_Na__123EB7A3");

                entity.HasOne(d => d.IdOsobaNavigation)
                    .WithOne(p => p.Nauczyciel)
                    .HasForeignKey<Nauczyciel>(d => d.IdOsoba)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Osoba_Nauczyciel_FK1");
            });

            modelBuilder.Entity<Ocena>(entity =>
            {
                entity.HasKey(e => e.IdOceny)
                    .HasName("PK__Ocena__3DB457B864F227BF");

                entity.Property(e => e.IdOceny).ValueGeneratedNever();

                entity.Property(e => e.Przedmiot)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Wartosc).HasColumnType("decimal(2, 1)");
            });

            modelBuilder.Entity<Osoba>(entity =>
            {
                entity.HasKey(e => e.IdOsoba)
                    .HasName("PK__OSOBA__3B65AAD2FAF438DD");

                entity.ToTable("OSOBA");

                entity.Property(e => e.IdOsoba)
                    .HasColumnName("Id_Osoba")
                    .ValueGeneratedNever();

                entity.Property(e => e.Imie)
                    .HasColumnName("IMIE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .HasColumnName("NAZWISKO")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pianista>(entity =>
            {
                entity.HasKey(e => e.IdOsoba)
                    .HasName("Id_Pianista");

                entity.Property(e => e.IdOsoba)
                    .HasColumnName("Id_Osoba")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdAwansu).HasColumnName("Id_Awansu");

                entity.Property(e => e.IdNaukowy).HasColumnName("Id_Naukowy");

                entity.Property(e => e.KierownikSekcji).HasColumnName("Kierownik_Sekcji");

                entity.HasOne(d => d.IdAwansuNavigation)
                    .WithMany(p => p.Pianista)
                    .HasForeignKey(d => d.IdAwansu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pianista__Id_Awa__17F790F9");

                entity.HasOne(d => d.IdNaukowyNavigation)
                    .WithMany(p => p.Pianista)
                    .HasForeignKey(d => d.IdNaukowy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pianista__Id_Nau__17036CC0");

                entity.HasOne(d => d.IdOsobaNavigation)
                    .WithOne(p => p.Pianista)
                    .HasForeignKey<Pianista>(d => d.IdOsoba)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Osoba_Pianista_FK1");

                entity.HasOne(d => d.KierownikSekcjiNavigation)
                    .WithMany(p => p.InverseKierownikSekcjiNavigation)
                    .HasForeignKey(d => d.KierownikSekcji)
                    .HasConstraintName("FK__Pianista__Kierow__18EBB532");
            });

            modelBuilder.Entity<Pokoj>(entity =>
            {
                entity.HasKey(e => e.NrPokoju)
                    .HasName("PK__Pokoj__18804ABE274A1A13");

                entity.Property(e => e.NrPokoju).ValueGeneratedNever();

                entity.Property(e => e.LiczbaMiejsc).HasColumnName("Liczba_miejsc");

                entity.HasOne(d => d.IdKategoriaNavigation)
                    .WithMany(p => p.Pokoj)
                    .HasForeignKey(d => d.IdKategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pokoj__IdKategor__7F2BE32F");
            });

            modelBuilder.Entity<Proba>(entity =>
            {
                entity.HasKey(e => e.IdProba)
                    .HasName("PK__Proba__194BAC45C00771CD");

                entity.Property(e => e.IdProba)
                    .HasColumnName("Id_Proba")
                    .ValueGeneratedNever();

                entity.Property(e => e.DataRozpoczecia)
                    .HasColumnName("Data_Rozpoczecia")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataZakonczenia)
                    .HasColumnName("Data_Zakonczenia")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdNauczyciel).HasColumnName("Id_Nauczyciel");

                entity.Property(e => e.IdPianista).HasColumnName("Id_Pianista");

                entity.Property(e => e.IdUczen).HasColumnName("Id_Uczen");

                entity.Property(e => e.NrSali)
                    .IsRequired()
                    .HasColumnName("Nr_Sali")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNauczycielNavigation)
                    .WithMany(p => p.Proba)
                    .HasForeignKey(d => d.IdNauczyciel)
                    .HasConstraintName("FK__Proba__Id_Nauczy__245D67DE");

                entity.HasOne(d => d.IdPianistaNavigation)
                    .WithMany(p => p.Proba)
                    .HasForeignKey(d => d.IdPianista)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Proba__Id_Pianis__22751F6C");

                entity.HasOne(d => d.IdUczenNavigation)
                    .WithMany(p => p.Proba)
                    .HasForeignKey(d => d.IdUczen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Proba__Id_Uczen__236943A5");
            });

            modelBuilder.Entity<Rezerwacja>(entity =>
            {
                entity.HasKey(e => e.IdRezerwacja)
                    .HasName("PK__Rezerwac__68F5E1864E994CBD");

                entity.Property(e => e.IdRezerwacja).ValueGeneratedNever();

                entity.Property(e => e.DataDo).HasColumnType("datetime");

                entity.Property(e => e.DataOd).HasColumnType("datetime");

                entity.HasOne(d => d.IdGoscNavigation)
                    .WithMany(p => p.Rezerwacja)
                    .HasForeignKey(d => d.IdGosc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rezerwacj__IdGos__02084FDA");

                entity.HasOne(d => d.NrPokojuNavigation)
                    .WithMany(p => p.Rezerwacja)
                    .HasForeignKey(d => d.NrPokoju)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rezerwacj__NrPok__02FC7413");
            });

            modelBuilder.Entity<Salgrade>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SALGRADE");

                entity.Property(e => e.Grade).HasColumnName("GRADE");

                entity.Property(e => e.Hisal).HasColumnName("HISAL");

                entity.Property(e => e.Losal).HasColumnName("LOSAL");
            });

            modelBuilder.Entity<Srednia>(entity =>
            {
                entity.HasKey(e => e.Rok)
                    .HasName("PK__Srednia__CAF005123D45B5E9");

                entity.Property(e => e.Rok).ValueGeneratedNever();

                entity.Property(e => e.Srednia1)
                    .HasColumnName("Srednia")
                    .HasColumnType("decimal(2, 1)");
            });

            modelBuilder.Entity<StopienAwansu>(entity =>
            {
                entity.HasKey(e => e.IdAwansu)
                    .HasName("PK__Stopien___73973F327BC025BA");

                entity.ToTable("Stopien_Awansu");

                entity.Property(e => e.IdAwansu)
                    .HasColumnName("Id_Awansu")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StopienNaukowy>(entity =>
            {
                entity.HasKey(e => e.IdNaukowy)
                    .HasName("PK__Stopien___661B54597E10A4B8");

                entity.ToTable("Stopien_Naukowy");

                entity.Property(e => e.IdNaukowy)
                    .HasColumnName("Id_Naukowy")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.IndexNumber)
                    .HasName("Student_pk");

                entity.Property(e => e.IndexNumber).HasMaxLength(100);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.HasOne(d => d.IdEnrollmentNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.IdEnrollment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Student_Enrollment");
            });

            modelBuilder.Entity<Studies>(entity =>
            {
                entity.HasKey(e => e.IdStudy)
                    .HasName("Studies_pk");

                entity.Property(e => e.IdStudy).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Tonacja>(entity =>
            {
                entity.HasKey(e => e.IdTonacja)
                    .HasName("PK__Tonacja__56EADF770A73CF17");

                entity.Property(e => e.IdTonacja)
                    .HasColumnName("Id_Tonacja")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Uczen>(entity =>
            {
                entity.HasKey(e => e.IdOsoba)
                    .HasName("Id_Uczen");

                entity.Property(e => e.IdOsoba)
                    .HasColumnName("Id_Osoba")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdInstrument).HasColumnName("Id_Instrument");

                entity.Property(e => e.IdNauczyciel).HasColumnName("Id_Nauczyciel");

                entity.Property(e => e.IdPianista).HasColumnName("Id_Pianista");

                entity.Property(e => e.Klasa)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdInstrumentNavigation)
                    .WithMany(p => p.Uczen)
                    .HasForeignKey(d => d.IdInstrument)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Uczen__Id_Instru__1CBC4616");

                entity.HasOne(d => d.IdNauczycielNavigation)
                    .WithMany(p => p.Uczen)
                    .HasForeignKey(d => d.IdNauczyciel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Uczen__Id_Nauczy__1DB06A4F");

                entity.HasOne(d => d.IdOsobaNavigation)
                    .WithOne(p => p.Uczen)
                    .HasForeignKey<Uczen>(d => d.IdOsoba)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Osoba_Uczen_FK1");

                entity.HasOne(d => d.IdPianistaNavigation)
                    .WithMany(p => p.Uczen)
                    .HasForeignKey(d => d.IdPianista)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Uczen__Id_Pianis__1EA48E88");
            });

            modelBuilder.Entity<UczenUtworProba>(entity =>
            {
                entity.HasKey(e => new { e.IdUczen, e.IdUtwor, e.IdProba })
                    .HasName("PK__Uczen_Ut__D1C573CCB3503C67");

                entity.ToTable("Uczen_Utwor_Proba");

                entity.Property(e => e.IdUczen).HasColumnName("Id_Uczen");

                entity.Property(e => e.IdUtwor).HasColumnName("Id_Utwor");

                entity.Property(e => e.IdProba).HasColumnName("Id_Proba");

                entity.HasOne(d => d.IdProbaNavigation)
                    .WithMany(p => p.UczenUtworProba)
                    .HasForeignKey(d => d.IdProba)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Uczen_Utw__Id_Pr__2EDAF651");

                entity.HasOne(d => d.IdUczenNavigation)
                    .WithMany(p => p.UczenUtworProba)
                    .HasForeignKey(d => d.IdUczen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Uczen_Utw__Id_Uc__2CF2ADDF");

                entity.HasOne(d => d.IdUtworNavigation)
                    .WithMany(p => p.UczenUtworProba)
                    .HasForeignKey(d => d.IdUtwor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Uczen_Utw__Id_Ut__2DE6D218");
            });

            modelBuilder.Entity<UczenUtworWystep>(entity =>
            {
                entity.HasKey(e => new { e.IdUczen, e.IdUtwor, e.IdWystep })
                    .HasName("PK__Uczen_Ut__9DAC466086EF8C4A");

                entity.ToTable("Uczen_Utwor_Wystep");

                entity.Property(e => e.IdUczen).HasColumnName("Id_Uczen");

                entity.Property(e => e.IdUtwor).HasColumnName("Id_Utwor");

                entity.Property(e => e.IdWystep).HasColumnName("Id_Wystep");

                entity.HasOne(d => d.IdUczenNavigation)
                    .WithMany(p => p.UczenUtworWystep)
                    .HasForeignKey(d => d.IdUczen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Uczen_Utw__Id_Uc__3A4CA8FD");

                entity.HasOne(d => d.IdUtworNavigation)
                    .WithMany(p => p.UczenUtworWystep)
                    .HasForeignKey(d => d.IdUtwor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Uczen_Utw__Id_Ut__3B40CD36");

                entity.HasOne(d => d.IdWystepNavigation)
                    .WithMany(p => p.UczenUtworWystep)
                    .HasForeignKey(d => d.IdWystep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Uczen_Utw__Id_Wy__3C34F16F");
            });

            modelBuilder.Entity<Utwor>(entity =>
            {
                entity.HasKey(e => e.IdUtwor)
                    .HasName("PK__Utwor__E1E341598A82788D");

                entity.Property(e => e.IdUtwor)
                    .HasColumnName("Id_Utwor")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdKompozytor).HasColumnName("Id_Kompozytor");

                entity.Property(e => e.IdTonacja).HasColumnName("Id_Tonacja");

                entity.Property(e => e.Numer)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Opus)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Tytul)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdKompozytorNavigation)
                    .WithMany(p => p.Utwor)
                    .HasForeignKey(d => d.IdKompozytor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Utwor__Id_Kompoz__29221CFB");

                entity.HasOne(d => d.IdTonacjaNavigation)
                    .WithMany(p => p.Utwor)
                    .HasForeignKey(d => d.IdTonacja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Utwor__Id_Tonacj__2A164134");
            });

            modelBuilder.Entity<Wystep>(entity =>
            {
                entity.HasKey(e => e.IdWystep)
                    .HasName("PK__Wystep__707E0009AAE2A358");

                entity.Property(e => e.IdWystep)
                    .HasColumnName("Id_Wystep")
                    .ValueGeneratedNever();

                entity.Property(e => e.DataGodzina)
                    .IsRequired()
                    .HasColumnName("Data_godzina")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.IdCharakterWystepu).HasColumnName("Id_Charakter_wystepu");

                entity.Property(e => e.IdMiejsce).HasColumnName("Id_Miejsce");

                entity.Property(e => e.IdPianista).HasColumnName("Id_Pianista");

                entity.HasOne(d => d.IdCharakterWystepuNavigation)
                    .WithMany(p => p.Wystep)
                    .HasForeignKey(d => d.IdCharakterWystepu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Wystep__Id_Chara__37703C52");

                entity.HasOne(d => d.IdMiejsceNavigation)
                    .WithMany(p => p.Wystep)
                    .HasForeignKey(d => d.IdMiejsce)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Wystep__Id_Miejs__367C1819");

                entity.HasOne(d => d.IdPianistaNavigation)
                    .WithMany(p => p.Wystep)
                    .HasForeignKey(d => d.IdPianista)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Wystep__Id_Piani__3587F3E0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
