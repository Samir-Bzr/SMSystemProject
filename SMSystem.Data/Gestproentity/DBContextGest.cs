using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SMSystem.Core.Models;
using SMSystem.Core;

using SMSystem.Core.Models;
using System.Configuration;

#nullable disable

namespace SMSystem.Data.Gestproentity
{
    public partial class DBContextGest : DbContext
    {
        public DBContextGest()
        {
        }

        public DBContextGest(DbContextOptions<DBContextGest> options)
            : base(options)
        {
        }

        public virtual DbSet<BonCommand> BonCommands { get; set; }
        public virtual DbSet<BonEnlevement> BonEnlevements { get; set; }
        public virtual DbSet<BonLivraison> BonLivraisons { get; set; }
        public virtual DbSet<BonProduction> BonProductions { get; set; }
        public virtual DbSet<BonReception> BonReceptions { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientFacture> ClientFactures { get; set; }
        public virtual DbSet<ConscienceCard> ConscienceCards { get; set; }
       // public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Damage> Damages { get; set; }
        public virtual DbSet<DetailBc> DetailBcs { get; set; }
        public virtual DbSet<DetailBem> DetailBems { get; set; }
        public virtual DbSet<DetailBl> DetailBls { get; set; }
        public virtual DbSet<DetailBrm> DetailBrms { get; set; }
        public virtual DbSet<DetailComposit> DetailComposits { get; set; }
        public virtual DbSet<DetailDevi> DetailDevis { get; set; }
        public virtual DbSet<DetailFactavoir> DetailFactavoirs { get; set; }
        public virtual DbSet<DetailFacture> DetailFactures { get; set; }
        public virtual DbSet<DetailMachine> DetailMachines { get; set; }
        public virtual DbSet<DetailTarage> DetailTarages { get; set; }
        public virtual DbSet<Devi> Devis { get; set; }
        public virtual DbSet<Dossier> Dossiers { get; set; }
        public virtual DbSet<EntreeStkmatiere> EntreeStkmatieres { get; set; }
        public virtual DbSet<EntreeStkprdfini> EntreeStkprdfinis { get; set; }
        public virtual DbSet<EntreeStkrecycle> EntreeStkrecycles { get; set; }
        public virtual DbSet<EntreeStkretour> EntreeStkretours { get; set; }
        public virtual DbSet<EtatTaragePrdPoid> EtatTaragePrdPoids { get; set; }
        public virtual DbSet<EtatTaragePrdUnite> EtatTaragePrdUnites { get; set; }
        public virtual DbSet<Factavoir> Factavoirs { get; set; }
        public virtual DbSet<Facture> Factures { get; set; }
        public virtual DbSet<Fournisseur> Fournisseurs { get; set; }
        public virtual DbSet<HistReglClt> HistReglClts { get; set; }
        public virtual DbSet<Income> Incomes { get; set; }
        public virtual DbSet<Machine> Machines { get; set; }
        public virtual DbSet<Materails> Materails { get; set; }
        public virtual DbSet<ModeReglement> ModeReglements { get; set; }
        public virtual DbSet<OutCome> OutComes { get; set; }
        public virtual DbSet<OutComeMaterail> OutComeMaterails { get; set; }
        public virtual DbSet<OutOfConscinesMaterials> OutOfConscinesMaterials { get; set; }
        public virtual DbSet<Parametre> Parametres { get; set; }
        public virtual DbSet<PrdfiniComposit> PrdfiniComposits { get; set; }
        public virtual DbSet<SortieStkmatiere> SortieStkmatieres { get; set; }
        public virtual DbSet<SortieStkprdfini> SortieStkprdfinis { get; set; }
        public virtual DbSet<SortieStkrecycle> SortieStkrecycles { get; set; }
        public virtual DbSet<SortieStkretour> SortieStkretours { get; set; }
        public virtual DbSet<Stkmatiere> Stkmatieres { get; set; }
        public virtual DbSet<Stkprdfini> Stkprdfinis { get; set; }
        public virtual DbSet<Stkrecycle> Stkrecycles { get; set; }
        public virtual DbSet<Stkretour> Stkretours { get; set; }
        //public virtual DbSet<Store> Stores { get; set; }
        //public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Tarage> Tarages { get; set; }
        public virtual DbSet<TarageDay> TarageDays { get; set; }
        public virtual DbSet<TotalBc> TotalBcs { get; set; }
        public virtual DbSet<TotalBem> TotalBems { get; set; }
        public virtual DbSet<TotalBl> TotalBls { get; set; }
        public virtual DbSet<TotalBrm> TotalBrms { get; set; }
        public virtual DbSet<TotalDevi> TotalDevis { get; set; }
        public virtual DbSet<TotalFactavoir> TotalFactavoirs { get; set; }
        public virtual DbSet<TotalFacture> TotalFactures { get; set; }
        public virtual DbSet<UniteProd> UniteProds { get; set; }
       
        public virtual DbSet<Users> Users1 { get; set; }
        public virtual DbSet<UserHisto> UserHistos { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Retrieve connection string from app.config
                var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "French_CI_AS");

            modelBuilder.Entity<BonCommand>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BON_COMMAND");

                entity.Property(e => e.DateBc)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_BC");

                entity.Property(e => e.DateTimeCreat)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_TIME_CREAT");

                entity.Property(e => e.IdBc).HasColumnName("ID_BC");

                entity.Property(e => e.IdFrs).HasColumnName("ID_FRS");

                entity.Property(e => e.NumPiece)
                    .HasMaxLength(10)
                    .HasColumnName("NUM_PIECE");

                entity.Property(e => e.ObsvBc)
                    .HasMaxLength(255)
                    .HasColumnName("OBSV_BC");

                entity.Property(e => e.TotalHtBc)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("TOTAL_HT_BC");

                entity.Property(e => e.TotalTtcBc)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("TOTAL_TTC_BC");

                entity.Property(e => e.TotalTvaBc)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("TOTAL_TVA_BC");

                entity.Property(e => e.TypePiece)
                    .HasMaxLength(255)
                    .HasColumnName("TYPE_PIECE");
            });

            modelBuilder.Entity<BonEnlevement>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BON_ENLEVEMENT");

                entity.Property(e => e.DateBem)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_BEM");

                entity.Property(e => e.DateTimeCreat)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_TIME_CREAT");

                entity.Property(e => e.IdBem).HasColumnName("ID_BEM");

                entity.Property(e => e.IdMatUser).HasColumnName("ID_MAT_USER");

                entity.Property(e => e.ObsvBem)
                    .HasMaxLength(255)
                    .HasColumnName("OBSV_BEM");

                entity.Property(e => e.TimeBem)
                    .HasColumnType("datetime")
                    .HasColumnName("TIME_BEM");

                entity.Property(e => e.TotalHtBem).HasColumnName("TOTAL_HT_BEM");

                entity.Property(e => e.TotalTtcBem).HasColumnName("TOTAL_TTC_BEM");

                entity.Property(e => e.TotalTvaBem).HasColumnName("TOTAL_TVA_BEM");
            });

            modelBuilder.Entity<BonLivraison>(entity =>
            {
                entity.HasKey(e => e.IdBl);

                entity.ToTable("BON_LIVRAISON");

                entity.Property(e => e.IdBl)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_BL");

                entity.Property(e => e.DateBl)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_BL");

                entity.Property(e => e.Datetimecreation)
                    .HasColumnType("datetime")
                    .HasColumnName("DATETIMECREATION");

                entity.Property(e => e.IdClt).HasColumnName("ID_CLT");

                entity.Property(e => e.IsInvoiced)
                    .HasMaxLength(1)
                    .HasColumnName("IsINVOICED")
                    .HasDefaultValueSql("((0))")
                    .IsFixedLength(true);

                entity.Property(e => e.ModeBl)
                    .HasMaxLength(50)
                    .HasColumnName("MODE_BL");

                entity.Property(e => e.NumFact)
                    .HasMaxLength(10)
                    .HasColumnName("NUM_FACT");

                entity.Property(e => e.ObsvBl)
                    .HasMaxLength(255)
                    .HasColumnName("OBSV_BL");

                entity.Property(e => e.TotalHtBl)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("TOTAL_HT_BL");

                entity.Property(e => e.TotalTtcBl)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("TOTAL_TTC_BL");

                entity.Property(e => e.TotalTvaBl)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("TOTAL_TVA_BL");
            });

            modelBuilder.Entity<BonProduction>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BON_PRODUCTION");

                entity.Property(e => e.DateProd)
                    .HasMaxLength(255)
                    .HasColumnName("DATE_PROD");

                entity.Property(e => e.DateTimeCreat)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_TIME_CREAT");

                entity.Property(e => e.IdAtelier).HasColumnName("ID_ATELIER");

                entity.Property(e => e.IdBprod).HasColumnName("ID_BPROD");

                entity.Property(e => e.ModeProd)
                    .HasMaxLength(255)
                    .HasColumnName("MODE_PROD");

                entity.Property(e => e.ObsvProd)
                    .HasMaxLength(255)
                    .HasColumnName("OBSV_PROD");

                entity.Property(e => e.TotalHtProd).HasColumnName("TOTAL_HT_PROD");

                entity.Property(e => e.TotalTtcProd).HasColumnName("TOTAL_TTC_PROD");

                entity.Property(e => e.TotalTvaProd).HasColumnName("TOTAL_TVA_PROD");
            });

            modelBuilder.Entity<BonReception>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BON_RECEPTION");

                entity.Property(e => e.DateBrm)
                    .HasMaxLength(255)
                    .HasColumnName("DATE_BRM");

                entity.Property(e => e.DateTimeCreat)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_TIME_CREAT");

                entity.Property(e => e.IdBrm).HasColumnName("ID_BRM");

                entity.Property(e => e.IdFrs).HasColumnName("ID_FRS");

                entity.Property(e => e.ModeBrm)
                    .HasMaxLength(255)
                    .HasColumnName("MODE_BRM");

                entity.Property(e => e.ObsvBrm)
                    .HasMaxLength(255)
                    .HasColumnName("OBSV_BRM");

                entity.Property(e => e.TotalHtBrm).HasColumnName("TOTAL_HT_BRM");

                entity.Property(e => e.TotalTtcBrm).HasColumnName("TOTAL_TTC_BRM");

                entity.Property(e => e.TotalTvaBrm).HasColumnName("TOTAL_TVA_BRM");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClt);

                entity.ToTable("CLIENT");

                entity.Property(e => e.IdClt).HasColumnName("ID_CLT");

                entity.Property(e => e.AdrClt)
                    .HasMaxLength(255)
                    .HasColumnName("ADR_CLT");

                entity.Property(e => e.CategClt)
                    .HasMaxLength(30)
                    .HasColumnName("CATEG_CLT");

                entity.Property(e => e.Datetimecreation)
                    .HasColumnType("datetime")
                    .HasColumnName("DATETIMECREATION");

                entity.Property(e => e.EmailClt)
                    .HasMaxLength(200)
                    .HasColumnName("EMAIL_CLT");

                entity.Property(e => e.MobilClt)
                    .HasMaxLength(10)
                    .HasColumnName("MOBIL_CLT");

                entity.Property(e => e.NaiClt)
                    .HasMaxLength(20)
                    .HasColumnName("NAI_CLT");

                entity.Property(e => e.NifClt)
                    .HasMaxLength(20)
                    .HasColumnName("NIF_CLT");

                entity.Property(e => e.NisClt)
                    .HasMaxLength(20)
                    .HasColumnName("NIS_CLT");

                entity.Property(e => e.NomClt)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("NOM_CLT");

                entity.Property(e => e.NrcClt)
                    .HasMaxLength(20)
                    .HasColumnName("NRC_CLT");

                entity.Property(e => e.SoldeCreance)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("SOLDE_CREANCE");

                entity.Property(e => e.TelClt)
                    .HasMaxLength(10)
                    .HasColumnName("TEL_CLT");

                entity.Property(e => e.VilleClt)
                    .HasMaxLength(30)
                    .HasColumnName("VILLE_CLT");
            });

            modelBuilder.Entity<ClientFacture>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CLIENT_FACTURE");

                entity.Property(e => e.IdClt).HasColumnName("ID_CLT");

                entity.Property(e => e.IdFact).HasColumnName("ID_FACT");
            });

            modelBuilder.Entity<ConscienceCard>(entity =>
            {
                entity.ToTable("ConscienceCard");

                entity.HasIndex(e => e.CustomerId, "IX_ConscienceCard_customersId");

                entity.Property(e => e.CustomerId).HasColumnName("customersId");

                entity.Property(e => e.DepName).IsRequired();

                entity.Property(e => e.MaterialName).IsRequired();

                entity.Property(e => e.ReciverName).IsRequired();

                 entity.HasOne(d => d.customers)
                     .WithMany(p =>p.conscienceCards)
                     .HasForeignKey(d => d.CustomerId);
             });

             modelBuilder.Entity<Customer>(entity =>
             {
                 entity.Property(e => e.Location).HasColumnName("location");

                 entity.Property(e => e.Name).IsRequired();
             });

                modelBuilder.Entity<Damage>(entity =>
                {
                    entity.ToTable("Damage");

                    entity.Property(e => e.Code).IsRequired();

                    entity.Property(e => e.Name).IsRequired();

                    entity.Property(e => e.ReciptNo).IsRequired();

                    entity.Property(e => e.RectipName).IsRequired();

                    entity.Property(e => e.Store).IsRequired();

                    entity.Property(e => e.Supplier).IsRequired();

                    entity.Property(e => e.Unit).IsRequired();

                    entity.Property(e => e.User).IsRequired();
                });

                modelBuilder.Entity<DetailBc>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("DETAIL_BC");

                    entity.Property(e => e.IdArt).HasColumnName("ID_ART");

                    entity.Property(e => e.IdBc).HasColumnName("ID_BC");

                    entity.Property(e => e.PuaCmd)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("PUA_CMD");

                    entity.Property(e => e.QteCmd).HasColumnName("QTE_CMD");
                });

                modelBuilder.Entity<DetailBem>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("DETAIL_BEM");

                    entity.Property(e => e.Colisx1Dem).HasColumnName("COLISX1_DEM");

                    entity.Property(e => e.Colisx2Dem).HasColumnName("COLISX2_DEM");

                    entity.Property(e => e.IdArt).HasColumnName("ID_ART");

                    entity.Property(e => e.IdBem).HasColumnName("ID_BEM");

                    entity.Property(e => e.NbrColisDem).HasColumnName("NBR_COLIS_DEM");

                    entity.Property(e => e.PoidsDem)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("POIDS_DEM");

                    entity.Property(e => e.PrxMatDem)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("PRX_MAT_DEM");

                    entity.Property(e => e.QteMatDem).HasColumnName("QTE_MAT_DEM");

                    entity.Property(e => e.RefArt)
                        .HasMaxLength(255)
                        .HasColumnName("REF_ART");

                    entity.Property(e => e.TotalPdsDem)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("TOTAL_PDS_DEM");
                });

                modelBuilder.Entity<DetailBl>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("DETAIL_BL");

                    entity.Property(e => e.ColissageBl).HasColumnName("COLISSAGE_BL");

                    entity.Property(e => e.IdBl).HasColumnName("ID_BL");

                    entity.Property(e => e.PaletissageBl).HasColumnName("PALETISSAGE_BL");

                    entity.Property(e => e.PuvBl)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("PUV_BL");

                    entity.Property(e => e.QteBl).HasColumnName("QTE_BL");

                    entity.Property(e => e.RefArtFini)
                        .IsRequired()
                        .HasMaxLength(20);

                    entity.Property(e => e.RemiseBl)
                        .HasColumnType("decimal(5, 2)")
                        .HasColumnName("REMISE_BL");

                    entity.Property(e => e.TvaBl)
                        .HasColumnType("decimal(5, 2)")
                        .HasColumnName("TVA_BL");
                });

                modelBuilder.Entity<DetailBrm>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("DETAIL_BRM");

                    entity.Property(e => e.Colisx1Rcept).HasColumnName("COLISX1_RCEPT");

                    entity.Property(e => e.Colisx2Rcept).HasColumnName("COLISX2_RCEPT");

                    entity.Property(e => e.IdArt).HasColumnName("ID_ART");

                    entity.Property(e => e.IdBrm).HasColumnName("ID_BRM");

                    entity.Property(e => e.NbrColisRcept).HasColumnName("NBR_COLIS_RCEPT");

                    entity.Property(e => e.PoidsRcept).HasColumnName("POIDS_RCEPT");

                    entity.Property(e => e.PrxRceptMat).HasColumnName("PRX_RCEPT_MAT");

                    entity.Property(e => e.QteRceptMat).HasColumnName("QTE_RCEPT_MAT");

                    entity.Property(e => e.RefArt)
                        .HasMaxLength(50)
                        .HasColumnName("REF_ART");

                    entity.Property(e => e.TotPdsRcept).HasColumnName("TOT_PDS_RCEPT");
                });

                modelBuilder.Entity<DetailComposit>(entity =>
                {
                    entity.HasKey(e => e.CopsitId);

                    entity.ToTable("DETAIL_COMPOSIT");

                    entity.Property(e => e.CopsitId)
                        .ValueGeneratedNever()
                        .HasColumnName("Copsit_ID");

                    entity.Property(e => e.CopsitQte).HasColumnName("Copsit_Qte");

                    entity.Property(e => e.CopsitTaux).HasColumnName("Copsit_Taux");

                    entity.Property(e => e.RefArtMat)
                        .IsRequired()
                        .HasMaxLength(20);
                });

                modelBuilder.Entity<DetailDevi>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("DETAIL_DEVIS");

                    entity.Property(e => e.IdArt).HasColumnName("ID_ART");

                    entity.Property(e => e.IdDevis).HasColumnName("ID_DEVIS");

                    entity.Property(e => e.PuvDevis)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("PUV_DEVIS");

                    entity.Property(e => e.QteDevis).HasColumnName("QTE_DEVIS");
                });

                modelBuilder.Entity<DetailFactavoir>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("DETAIL_FACTAVOIR");

                    entity.Property(e => e.IdClt).HasColumnName("ID_CLT");

                    entity.Property(e => e.IdFact).HasColumnName("ID_FACT");
                });

                modelBuilder.Entity<DetailFacture>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("DETAIL_FACTURE");

                    entity.Property(e => e.IdBl).HasColumnName("ID_BL");

                    entity.Property(e => e.IdClt).HasColumnName("ID_CLT");
                });

                modelBuilder.Entity<DetailMachine>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("DETAIL_MACHINE");

                    entity.Property(e => e.DatePanne)
                        .HasColumnType("datetime")
                        .HasColumnName("DATE_PANNE");

                    entity.Property(e => e.DureePanne).HasColumnName("DUREE_PANNE");

                    entity.Property(e => e.IdMachine)
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnName("ID_MACHINE");

                    entity.Property(e => e.Obsv)
                        .HasMaxLength(255)
                        .HasColumnName("OBSV");

                    entity.Property(e => e.TypePanne)
                        .HasMaxLength(255)
                        .HasColumnName("TYPE_PANNE");
                });

                modelBuilder.Entity<DetailTarage>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("DETAIL_TARAGE");

                    entity.Property(e => e.DateGross).HasColumnType("datetime");

                    entity.Property(e => e.GrossId).HasColumnName("GrossID");

                    entity.Property(e => e.MachineId)
                        .HasMaxLength(255)
                        .HasColumnName("MachineID");

                    entity.Property(e => e.RefArtFini).HasMaxLength(255);

                    entity.Property(e => e.TimeGross).HasColumnType("datetime");
                });

                modelBuilder.Entity<Devi>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("DEVIS");

                    entity.Property(e => e.DateDevis)
                        .HasColumnType("datetime")
                        .HasColumnName("DATE_DEVIS");

                    entity.Property(e => e.IdClt).HasColumnName("ID_CLT");

                    entity.Property(e => e.IdDevis).HasColumnName("ID_DEVIS");

                    entity.Property(e => e.NumDevis).HasColumnName("NUM_DEVIS");

                    entity.Property(e => e.ObsvDevis)
                        .HasMaxLength(255)
                        .HasColumnName("OBSV_DEVIS");

                    entity.Property(e => e.TothtDevis).HasColumnName("TOTHT_DEVIS");

                    entity.Property(e => e.TottcDevis).HasColumnName("TOTTC_DEVIS");

                    entity.Property(e => e.TotvaDevis).HasColumnName("TOTVA_DEVIS");
                });

                modelBuilder.Entity<Dossier>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("DOSSIER");

                    entity.Property(e => e.ActivEntp)
                        .HasMaxLength(100)
                        .HasColumnName("ACTIV_ENTP");

                    entity.Property(e => e.AdresseEntp)
                        .HasMaxLength(100)
                        .HasColumnName("ADRESSE_ENTP");

                    entity.Property(e => e.EmailEntp)
                        .HasMaxLength(50)
                        .HasColumnName("EMAIL_ENTP");

                    entity.Property(e => e.LogoEntp)
                        .HasColumnType("image")
                        .HasColumnName("LOGO_ENTP");

                    entity.Property(e => e.NaiEntp)
                        .HasMaxLength(20)
                        .HasColumnName("NAI_ENTP");

                    entity.Property(e => e.NameEntp)
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnName("NAME_ENTP");

                    entity.Property(e => e.NifEntp)
                        .HasMaxLength(20)
                        .HasColumnName("NIF_ENTP");

                    entity.Property(e => e.NisEntp)
                        .HasMaxLength(20)
                        .HasColumnName("NIS_ENTP");

                    entity.Property(e => e.NrcEntp)
                        .HasMaxLength(20)
                        .HasColumnName("NRC_ENTP");

                    entity.Property(e => e.Tel01Entp)
                        .HasMaxLength(15)
                        .HasColumnName("TEL01_ENTP")
                        .IsFixedLength(true);

                    entity.Property(e => e.Tel02Entp)
                        .HasMaxLength(15)
                        .HasColumnName("TEL02_ENTP")
                        .IsFixedLength(true);

                    entity.Property(e => e.Tel03Entp)
                        .HasMaxLength(15)
                        .HasColumnName("TEL03_ENTP")
                        .IsFixedLength(true);
                });

                modelBuilder.Entity<EntreeStkmatiere>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("ENTREE_STKMATIERE");

                    entity.Property(e => e.IdArt).HasColumnName("ID_ART");

                    entity.Property(e => e.QteEntree).HasColumnName("Qte_Entree");

                    entity.Property(e => e.Tachat).HasColumnName("TAchat");

                    entity.Property(e => e.TpuAchat).HasColumnName("TPuAchat");
                });

                modelBuilder.Entity<EntreeStkprdfini>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("ENTREE_STKPRDFINI");

                    entity.Property(e => e.IdArt).HasColumnName("ID_ART");

                    entity.Property(e => e.QteEntree).HasColumnName("Qte_Entree");

                    entity.Property(e => e.Tachat).HasColumnName("TAchat");

                    entity.Property(e => e.TpuAchat).HasColumnName("TPuAchat");
                });

                modelBuilder.Entity<EntreeStkrecycle>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("ENTREE_STKRECYCLE");

                    entity.Property(e => e.IdArt).HasColumnName("ID_ART");

                    entity.Property(e => e.QteEntree).HasColumnName("Qte_Entree");

                    entity.Property(e => e.Tachat).HasColumnName("TAchat");

                    entity.Property(e => e.TpuAchat).HasColumnName("TPuAchat");
                });

                modelBuilder.Entity<EntreeStkretour>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("ENTREE_STKRETOUR");

                    entity.Property(e => e.IdArt).HasColumnName("ID_ART");

                    entity.Property(e => e.QteEntree).HasColumnName("Qte_Entree");

                    entity.Property(e => e.Tachat).HasColumnName("TAchat");

                    entity.Property(e => e.TpuAchat).HasColumnName("TPuAchat");
                });

                modelBuilder.Entity<EtatTaragePrdPoid>(entity =>
                {
                    entity.HasNoKey();

                    entity.Property(e => e.DateGross).HasColumnType("datetime");

                    entity.Property(e => e.Designation).HasMaxLength(255);

                    entity.Property(e => e.MachineId)
                        .HasMaxLength(255)
                        .HasColumnName("MachineID");

                    entity.Property(e => e.Shift06).HasColumnName("Shift-06");

                    entity.Property(e => e.Shift14).HasColumnName("Shift-14");

                    entity.Property(e => e.Shift22).HasColumnName("Shift-22");

                    entity.Property(e => e.TotalPoids).HasColumnName("Total_Poids");
                });

                modelBuilder.Entity<EtatTaragePrdUnite>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("EtatTaragePrdUnite");

                    entity.Property(e => e.DateGross).HasColumnType("datetime");

                    entity.Property(e => e.Designation).HasMaxLength(255);

                    entity.Property(e => e.MachineId)
                        .HasMaxLength(255)
                        .HasColumnName("MachineID");

                    entity.Property(e => e.Shift06).HasColumnName("Shift-06");

                    entity.Property(e => e.Shift14).HasColumnName("Shift-14");

                    entity.Property(e => e.Shift22).HasColumnName("Shift-22");

                    entity.Property(e => e.TotalUnite).HasColumnName("Total_Unite");
                });

                modelBuilder.Entity<Factavoir>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("FACTAVOIR");

                    entity.Property(e => e.DateFactavr)
                        .HasColumnType("datetime")
                        .HasColumnName("DATE_FACTAVR");

                    entity.Property(e => e.IdClt).HasColumnName("ID_CLT");

                    entity.Property(e => e.IdFact).HasColumnName("ID_FACT");

                    entity.Property(e => e.IdFactavoir).HasColumnName("ID_FACTAVOIR");

                    entity.Property(e => e.NatFactavr)
                        .HasMaxLength(255)
                        .HasColumnName("NAT_FACTAVR");

                    entity.Property(e => e.NumFactavr).HasColumnName("NUM_FACTAVR");

                    entity.Property(e => e.NumFat).HasColumnName("NUM_FAT");

                    entity.Property(e => e.ObsvFactavr)
                        .HasMaxLength(255)
                        .HasColumnName("OBSV_FACTAVR");

                    entity.Property(e => e.TothtFactavr).HasColumnName("TOTHT_FACTAVR");

                    entity.Property(e => e.TottcFactavr).HasColumnName("TOTTC_FACTAVR");

                    entity.Property(e => e.TotvaFactavr).HasColumnName("TOTVA_FACTAVR");
                });

                modelBuilder.Entity<Facture>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("FACTURE");

                    entity.Property(e => e.DateFact)
                        .HasColumnType("datetime")
                        .HasColumnName("DATE_FACT");

                    entity.Property(e => e.IdClt).HasColumnName("ID_CLT");

                    entity.Property(e => e.IdFact).HasColumnName("ID_FACT");

                    entity.Property(e => e.NatFact)
                        .HasMaxLength(255)
                        .HasColumnName("NAT_FACT");

                    entity.Property(e => e.NumFact)
                        .HasMaxLength(10)
                        .HasColumnName("NUM_FACT");

                    entity.Property(e => e.ObsvFact)
                        .HasMaxLength(255)
                        .HasColumnName("OBSV_FACT");

                    entity.Property(e => e.TothtFact)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("TOTHT_FACT");

                    entity.Property(e => e.TottcFact)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("TOTTC_FACT");

                    entity.Property(e => e.TotvaFact)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("TOTVA_FACT");
                });

                modelBuilder.Entity<Fournisseur>(entity =>
                {
                    entity.HasKey(e => e.IdFrs);

                    entity.ToTable("FOURNISSEUR");

                    entity.Property(e => e.IdFrs).HasColumnName("ID_FRS");

                    entity.Property(e => e.AdrFrs)
                        .HasMaxLength(255)
                        .HasColumnName("ADR_FRS");

                    entity.Property(e => e.CategFrs)
                        .HasMaxLength(30)
                        .HasColumnName("CATEG_FRS");

                    entity.Property(e => e.Datetimecreation)
                        .HasColumnType("datetime")
                        .HasColumnName("DATETIMECREATION");

                    entity.Property(e => e.EmailFrs)
                        .HasMaxLength(255)
                        .HasColumnName("EMAIL_FRS");

                    entity.Property(e => e.MobilFrs)
                        .HasMaxLength(10)
                        .HasColumnName("MOBIL_FRS");

                    entity.Property(e => e.NaiFrs)
                        .HasMaxLength(20)
                        .HasColumnName("NAI_FRS");

                    entity.Property(e => e.NifFrs)
                        .HasMaxLength(20)
                        .HasColumnName("NIF_FRS");

                    entity.Property(e => e.NisFrs)
                        .HasMaxLength(20)
                        .HasColumnName("NIS_FRS");

                    entity.Property(e => e.NomFrs)
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnName("NOM_FRS");

                    entity.Property(e => e.NrcFrs)
                        .HasMaxLength(20)
                        .HasColumnName("NRC_FRS");

                    entity.Property(e => e.SoldeDette).HasColumnName("SOLDE_DETTE");

                    entity.Property(e => e.TelFrs)
                        .HasMaxLength(10)
                        .HasColumnName("TEL_FRS");

                    entity.Property(e => e.VilleFrs)
                        .HasMaxLength(30)
                        .HasColumnName("VILLE_FRS");
                });

                modelBuilder.Entity<HistReglClt>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("HIST_REGL_CLT");

                    entity.Property(e => e.DateBl)
                        .HasColumnType("date")
                        .HasColumnName("DATE_BL");

                    entity.Property(e => e.DateCheque)
                        .HasColumnType("date")
                        .HasColumnName("DATE_CHEQUE");

                    entity.Property(e => e.DateReglement)
                        .HasColumnType("datetime")
                        .HasColumnName("DATE_REGLEMENT");

                    entity.Property(e => e.DateVersement)
                        .HasColumnType("date")
                        .HasColumnName("DATE_VERSEMENT");

                    entity.Property(e => e.DateVirement)
                        .HasColumnType("date")
                        .HasColumnName("DATE_VIREMENT");

                    entity.Property(e => e.IdBl).HasColumnName("ID_BL");

                    entity.Property(e => e.IdClt).HasColumnName("ID_CLT");

                    entity.Property(e => e.IdMode).HasColumnName("ID_MODE");

                    entity.Property(e => e.ModeReglement)
                        .HasMaxLength(50)
                        .HasColumnName("MODE_REGLEMENT");

                    entity.Property(e => e.MontReglement)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("MONT_REGLEMENT");

                    entity.Property(e => e.MontTtcBl)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("MONT_TTC_BL");

                    entity.Property(e => e.NumCheque)
                        .HasMaxLength(10)
                        .HasColumnName("NUM_CHEQUE")
                        .IsFixedLength(true);

                    entity.Property(e => e.NumComptclt)
                        .HasMaxLength(21)
                        .HasColumnName("NUM_COMPTCLT");

                    entity.Property(e => e.NumVersement)
                        .HasMaxLength(10)
                        .HasColumnName("NUM_VERSEMENT")
                        .IsFixedLength(true);

                    entity.Property(e => e.NumVirement)
                        .HasMaxLength(10)
                        .HasColumnName("NUM_VIREMENT")
                        .IsFixedLength(true);
                });

                modelBuilder.Entity<Income>(entity =>
                {
                    entity.ToTable("Income");

                     entity.HasIndex(e => e.MaterailId, "IX_Income_MaterailsId");

                    entity.Property(e => e.Code).IsRequired();

                    entity.Property(e => e.Name).IsRequired();

                    entity.Property(e => e.ReciptNo).IsRequired();

                    entity.Property(e => e.RectipName).IsRequired();

                    entity.Property(e => e.Store).IsRequired();

                    entity.Property(e => e.Supplier).IsRequired();

                    entity.Property(e => e.Unit).IsRequired();

                    entity.Property(e => e.User).IsRequired();

                    entity.HasOne(d => d.Materails)
                         .WithMany(p => p.Income)
                         .HasForeignKey(d => d.MaterailId);
                });

                modelBuilder.Entity<Machine>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("MACHINE");

                    entity.Property(e => e.IdMachine)
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnName("ID_MACHINE");

                    entity.Property(e => e.IdUnit).HasColumnName("ID_UNIT");

                    entity.Property(e => e.RefMachine)
                        .HasMaxLength(255)
                        .HasColumnName("REF_MACHINE");

                    entity.Property(e => e.StatusMachine)
                        .HasMaxLength(255)
                        .HasColumnName("STATUS_MACHINE");

                    entity.Property(e => e.TypeMachine)
                        .HasMaxLength(255)
                        .HasColumnName("TYPE_MACHINE");
                });

                  modelBuilder.Entity<Materails>(entity =>
                  {
                      entity.HasIndex(e => e.StoreId, "IX_Materails_StoresId");

                      entity.Property(e => e.Code).IsRequired();

                      entity.Property(e => e.Name).IsRequired();

                      entity.Property(e => e.Store).IsRequired();

                      entity.Property(e => e.Unit).IsRequired();

                      entity.HasOne(d => d.Stores)
                          .WithMany(p => p.Materails)
                          .HasForeignKey(d => d.StoreId);
                  });

                modelBuilder.Entity<ModeReglement>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("MODE_REGLEMENT");

                    entity.Property(e => e.IdMode)
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_MODE");

                    entity.Property(e => e.LabelMode)
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnName("LABEL_MODE");
                });

                modelBuilder.Entity<OutCome>(entity =>
                {
                    entity.ToTable("OutCome");

                    entity.Property(e => e.Customer).IsRequired();

                    entity.Property(e => e.User).IsRequired();
                });

                modelBuilder.Entity<OutComeMaterail>(entity =>
                {
                    entity.ToTable("outComeMaterail");

                    entity.HasIndex(e => e.OutComeID, "IX_outComeMaterail_outComeId");

                    entity.Property(e => e.MaterialName).IsRequired();

                    entity.Property(e => e.OutComeID).HasColumnName("outComeId");

                    entity.HasOne(d => d.outCome)
                        .WithMany(p => p.OutComeMaterails)
                        .HasForeignKey(d => d.OutComeID);
                });

                modelBuilder.Entity<OutOfConscinesMaterials>(entity =>
                {
                    entity.Property(e => e.Code).IsRequired();

                    entity.Property(e => e.Name).IsRequired();

                    entity.Property(e => e.ReciptNo).IsRequired();

                    entity.Property(e => e.RectipName).IsRequired();

                    entity.Property(e => e.Store).IsRequired();

                    entity.Property(e => e.Supplier).IsRequired();

                    entity.Property(e => e.Unit).IsRequired();

                    entity.Property(e => e.User).IsRequired();
                });

                modelBuilder.Entity<Parametre>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("PARAMETRES");

                    entity.Property(e => e.IsQteInsufAllowed)
                        .IsRequired()
                        .HasMaxLength(1)
                        .IsFixedLength(true);

                    entity.Property(e => e.NbrPagePrintBl).HasColumnName("NbrPagePrintBL");
                });

                modelBuilder.Entity<PrdfiniComposit>(entity =>
                {
                    entity.HasKey(e => e.RefArtMat);

                    entity.ToTable("PRDFINI_COMPOSIT");

                    entity.HasIndex(e => e.RefArtMat, "IX_PRDFINI_COMPOSIT");

                    entity.Property(e => e.RefArtMat).HasMaxLength(20);

                    entity.Property(e => e.CopsitId).HasColumnName("Copsit_ID");
                });

                modelBuilder.Entity<SortieStkmatiere>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("SORTIE_STKMATIERE");

                    entity.Property(e => e.IdArt).HasColumnName("ID_ART");
                });

                modelBuilder.Entity<SortieStkprdfini>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("SORTIE_STKPRDFINI");

                    entity.Property(e => e.IdArt).HasColumnName("ID_ART");
                });

                modelBuilder.Entity<SortieStkrecycle>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("SORTIE_STKRECYCLE");

                    entity.Property(e => e.IdArt).HasColumnName("ID_ART");
                });

                modelBuilder.Entity<SortieStkretour>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("SORTIE_STKRETOUR");

                    entity.Property(e => e.IdArt).HasColumnName("ID_ART");
                });

                modelBuilder.Entity<Stkmatiere>(entity =>
                {
                    entity.HasKey(e => e.RefArtMat);

                    entity.ToTable("STKMATIERE");

                    entity.Property(e => e.RefArtMat).HasMaxLength(20);

                    entity.Property(e => e.DefaultPds).HasColumnType("decimal(18, 2)");

                    entity.Property(e => e.Designation)
                        .IsRequired()
                        .HasMaxLength(255);

                    entity.Property(e => e.NatArt).HasMaxLength(20);

                    entity.Property(e => e.PdsStock).HasColumnType("decimal(18, 2)");

                    entity.Property(e => e.PdsUnit).HasColumnType("decimal(18, 2)");

                    entity.Property(e => e.Puachat)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("PUAchat");

                    entity.Property(e => e.Puvente)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("PUVente");

                    entity.Property(e => e.TauxTva)
                        .HasColumnType("decimal(5, 2)")
                        .HasColumnName("TauxTVA");

                    entity.Property(e => e.TypeArt).HasMaxLength(20);
                });

                modelBuilder.Entity<Stkprdfini>(entity =>
                {
                    entity.HasKey(e => e.RefArtFini);

                    entity.ToTable("STKPRDFINI");

                    entity.Property(e => e.RefArtFini).HasMaxLength(20);

                    entity.Property(e => e.DefaultPds).HasColumnType("decimal(18, 2)");

                    entity.Property(e => e.Designation)
                        .IsRequired()
                        .HasMaxLength(255);

                    entity.Property(e => e.MachineId)
                        .HasMaxLength(20)
                        .HasColumnName("MachineID");

                    entity.Property(e => e.NatArt).HasMaxLength(20);

                    entity.Property(e => e.PdsArtFini).HasColumnType("decimal(18, 2)");

                    entity.Property(e => e.PdsStock).HasColumnType("decimal(18, 2)");

                    entity.Property(e => e.PdsUnit).HasColumnType("decimal(18, 2)");

                    entity.Property(e => e.Puachat)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("PUAchat");

                    entity.Property(e => e.Puvente)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("PUVente");

                    entity.Property(e => e.TvaVente)
                        .HasColumnType("decimal(5, 2)")
                        .HasColumnName("TVA_Vente");

                    entity.Property(e => e.TypeArt).HasMaxLength(20);
                });

                modelBuilder.Entity<Stkrecycle>(entity =>
                {
                    entity.HasKey(e => e.RefArtRcyl);

                    entity.ToTable("STKRECYCLE");

                    entity.Property(e => e.RefArtRcyl).HasMaxLength(20);

                    entity.Property(e => e.DefaultPds).HasColumnType("decimal(18, 2)");

                    entity.Property(e => e.Designation)
                        .IsRequired()
                        .HasMaxLength(255);

                    entity.Property(e => e.NatArt).HasMaxLength(20);

                    entity.Property(e => e.PdsStock).HasColumnType("decimal(18, 2)");

                    entity.Property(e => e.PdsUnit).HasColumnType("decimal(18, 2)");

                    entity.Property(e => e.Puachat)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("PUAchat");

                    entity.Property(e => e.Puvente)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("PUVente");

                    entity.Property(e => e.TauxTva)
                        .HasColumnType("decimal(5, 2)")
                        .HasColumnName("TauxTVA");

                    entity.Property(e => e.TypeArt).HasMaxLength(20);
                });

                modelBuilder.Entity<Stkretour>(entity =>
                {
                    entity.HasKey(e => e.RefArtRet);

                    entity.ToTable("STKRETOUR");

                    entity.Property(e => e.RefArtRet).HasMaxLength(20);

                    entity.Property(e => e.DefaultPds).HasColumnType("decimal(18, 2)");

                    entity.Property(e => e.Designation)
                        .IsRequired()
                        .HasMaxLength(255);

                    entity.Property(e => e.NatArt).HasMaxLength(20);

                    entity.Property(e => e.PdsStock).HasColumnType("decimal(18, 2)");

                    entity.Property(e => e.PdsUnit).HasColumnType("decimal(18, 2)");

                    entity.Property(e => e.Puachat)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("PUAchat");

                    entity.Property(e => e.Puvente)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("PUVente");

                    entity.Property(e => e.TauxTva)
                        .HasColumnType("decimal(5, 2)")
                        .HasColumnName("TauxTVA");

                    entity.Property(e => e.TypeArt).HasMaxLength(20);
                });

                modelBuilder.Entity<Store>(entity =>
                {
                    entity.Property(e => e.Name).IsRequired();
                });

                modelBuilder.Entity<Supplier>(entity =>
                {
                    entity.Property(e => e.location).HasColumnName("location");

                    entity.Property(e => e.Name).IsRequired();
                });

                modelBuilder.Entity<Tarage>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("TARAGE");

                    entity.Property(e => e.DateCreation).HasColumnType("datetime");

                    entity.Property(e => e.DateGross).HasColumnType("datetime");

                    entity.Property(e => e.GrossId).HasColumnName("GrossID");

                    entity.Property(e => e.MachineId)
                        .HasMaxLength(255)
                        .HasColumnName("MachineID");

                    entity.Property(e => e.ObsvPesage).HasMaxLength(255);

                    entity.Property(e => e.SaisiePar).HasMaxLength(255);

                    entity.Property(e => e.ValiderPar).HasMaxLength(255);
                });

                modelBuilder.Entity<TarageDay>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("TARAGE_DAY");

                    entity.Property(e => e.DateCreation).HasColumnType("datetime");

                    entity.Property(e => e.DateGross).HasColumnType("datetime");

                    entity.Property(e => e.IdDay).HasColumnName("ID_DAY");

                    entity.Property(e => e.ValiderPar).HasMaxLength(255);
                });

                modelBuilder.Entity<TotalBc>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("TOTAL_BC");

                    entity.Property(e => e.IdBc).HasColumnName("ID_BC");

                    entity.Property(e => e.SommeMht)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("SommeMHT");

                    entity.Property(e => e.SommeMttc)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("SommeMTTC");

                    entity.Property(e => e.SommeMtva)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("SommeMTVA");
                });

                modelBuilder.Entity<TotalBem>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("TOTAL_BEM");

                    entity.Property(e => e.IdBem).HasColumnName("ID_BEM");

                    entity.Property(e => e.SommeMht)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("SommeMHT");

                    entity.Property(e => e.SommeMttc)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("SommeMTTC");

                    entity.Property(e => e.SommeMtva)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("SommeMTVA");
                });

                modelBuilder.Entity<TotalBl>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("TOTAL_BL");

                    entity.Property(e => e.IdBl).HasColumnName("ID_BL");

                    entity.Property(e => e.SommeMht)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("SommeMHT");

                    entity.Property(e => e.SommeMttc)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("SommeMTTC");

                    entity.Property(e => e.SommeMtva)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("SommeMTVA");
                });

                modelBuilder.Entity<TotalBrm>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("TOTAL_BRM");

                    entity.Property(e => e.IdBrm).HasColumnName("ID_BRM");

                    entity.Property(e => e.SommeMht).HasColumnName("SommeMHT");

                    entity.Property(e => e.SommeMttc).HasColumnName("SommeMTTC");

                    entity.Property(e => e.SommeMtva).HasColumnName("SommeMTVA");
                });

                modelBuilder.Entity<TotalDevi>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("TOTAL_DEVIS");

                    entity.Property(e => e.IdDevis).HasColumnName("ID_DEVIS");

                    entity.Property(e => e.SommeMht)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("SommeMHT");

                    entity.Property(e => e.SommeMttc)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("SommeMTTC");

                    entity.Property(e => e.SommeMtva)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("SommeMTVA");
                });

                modelBuilder.Entity<TotalFactavoir>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("TOTAL_FACTAVOIR");

                    entity.Property(e => e.IdFactavr).HasColumnName("ID_FACTAVR");

                    entity.Property(e => e.SommeMht)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("SommeMHT");

                    entity.Property(e => e.SommeMttc)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("SommeMTTC");

                    entity.Property(e => e.SommeMtva)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("SommeMTVA");
                });

                modelBuilder.Entity<TotalFacture>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("TOTAL_FACTURE");

                    entity.Property(e => e.IdFact).HasColumnName("ID_FACT");

                    entity.Property(e => e.SommeMht)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("SommeMHT");

                    entity.Property(e => e.SommeMttc)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("SommeMTTC");

                    entity.Property(e => e.SommeMtva)
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("SommeMTVA");
                });

                modelBuilder.Entity<UniteProd>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("UNITE_PROD");

                    entity.Property(e => e.IdUnit).HasColumnName("ID_UNIT");

                    entity.Property(e => e.LabelUnit).HasMaxLength(255);

                    entity.Property(e => e.RespUnit).HasMaxLength(255);
                });



                modelBuilder.Entity<Users>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("USERS");

                    entity.Property(e => e.IdRole).HasColumnName("ID_ROLE");

                    entity.Property(e => e.IdUser).HasColumnName("ID_USER");

                    entity.Property(e => e.Login)
                        .HasMaxLength(255)
                        .HasColumnName("LOGIN");

                    entity.Property(e => e.Nomcomplet)
                        .HasMaxLength(255)
                        .HasColumnName("NOMCOMPLET");

                    entity.Property(e => e.Pwd)
                        .HasMaxLength(255)
                        .HasColumnName("PWD");
                });

                modelBuilder.Entity<UserHisto>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("USER_HISTO");

                    entity.Property(e => e.DateEntree)
                        .HasColumnType("datetime")
                        .HasColumnName("DATE_ENTREE");

                    entity.Property(e => e.DateSortie)
                        .HasColumnType("datetime")
                        .HasColumnName("DATE_SORTIE");

                    entity.Property(e => e.IdHisto).HasColumnName("ID_HISTO");

                    entity.Property(e => e.IdUser).HasColumnName("ID_USER");

                    entity.Property(e => e.Login)
                        .HasMaxLength(255)
                        .HasColumnName("LOGIN");

                    entity.Property(e => e.NbrLogin).HasColumnName("NBR_LOGIN");

                    entity.Property(e => e.Nomcomplet)
                        .HasMaxLength(255)
                        .HasColumnName("NOMCOMPLET");
                });

                modelBuilder.Entity<UserLogin>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("USER_LOGIN");

                    entity.Property(e => e.Date)
                        .HasColumnType("datetime")
                        .HasColumnName("date");

                    entity.Property(e => e.Droit)
                        .HasMaxLength(50)
                        .HasColumnName("droit");

                    entity.Property(e => e.Id).HasColumnName("id");

                    entity.Property(e => e.Nom)
                        .HasMaxLength(50)
                        .HasColumnName("nom");

                    entity.Property(e => e.PassWord).HasMaxLength(50);
                });

                modelBuilder.Entity<UserRole>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("USER_ROLE");

                    entity.Property(e => e.CodeRole)
                        .HasMaxLength(255)
                        .HasColumnName("CODE_ROLE");

                    entity.Property(e => e.DesigRole)
                        .HasMaxLength(255)
                        .HasColumnName("DESIG_ROLE");

                    entity.Property(e => e.IdRole).HasColumnName("ID_ROLE");
                });

                OnModelCreatingPartial(modelBuilder);
            } 

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
