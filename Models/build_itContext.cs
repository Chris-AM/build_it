using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace build_it.Models
{
    public partial class build_itContext : DbContext
    {
        public build_itContext()
        {
        }

        public build_itContext(DbContextOptions<build_itContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Arrival> Arrivals { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientState> ClientStates { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<DefaultClientPayMethod> DefaultClientPayMethods { get; set; }
        public virtual DbSet<EfmigrationsHistory> EfmigrationsHistories { get; set; }
        public virtual DbSet<IsClient> IsClients { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<OfferHistory> OfferHistories { get; set; }
        public virtual DbSet<OfferState> OfferStates { get; set; }
        public virtual DbSet<PayMethod> PayMethods { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductHistory> ProductHistories { get; set; }
        public virtual DbSet<ProductState> ProductStates { get; set; }
        public virtual DbSet<Publication> Publications { get; set; }
        public virtual DbSet<PublicationHistory> PublicationHistories { get; set; }
        public virtual DbSet<PublicationState> PublicationStates { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<PurchaseHistory> PurchaseHistories { get; set; }
        public virtual DbSet<PurchaseState> PurchaseStates { get; set; }
        public virtual DbSet<Shipping> Shippings { get; set; }
        public virtual DbSet<ShippingCompany> ShippingCompanies { get; set; }
        public virtual DbSet<ShippingCountry> ShippingCountries { get; set; }
        public virtual DbSet<ShippingState> ShippingStates { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserState> UserStates { get; set; }
        public virtual DbSet<World> Worlds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=192.168.56.101;user id=db_admin;password=1704;database=build_it", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.5.11-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            modelBuilder.Entity<Arrival>(entity =>
            {
                entity.HasKey(e => e.IdArrival)
                    .HasName("PRIMARY");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasOne(d => d.IdShippingNavigation)
                    .WithMany(p => p.Arrivals)
                    .HasForeignKey(d => d.IdShipping)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_arrival_shipping");
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient)
                    .HasName("PRIMARY");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasOne(d => d.IdClientStateNavigation)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.IdClientState)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_client_clientState");

                entity.HasOne(d => d.IdDefaultClientPayMethodNavigation)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.IdDefaultClientPayMethod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_client_metodoPagoclient");
            });

            modelBuilder.Entity<ClientState>(entity =>
            {
                entity.HasKey(e => e.IdClientState)
                    .HasName("PRIMARY");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.IdCompany)
                    .HasName("PRIMARY");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.IdCountry)
                    .HasName("PRIMARY");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<DefaultClientPayMethod>(entity =>
            {
                entity.HasKey(e => e.IdDefaultClientPayMethod)
                    .HasName("PRIMARY");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<EfmigrationsHistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<IsClient>(entity =>
            {
                entity.HasKey(e => e.IdIsClient)
                    .HasName("PRIMARY");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.IsClients)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_isClient_client");
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.HasKey(e => e.IdOffer)
                    .HasName("PRIMARY");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasOne(d => d.IdOfferHistoryNavigation)
                    .WithMany(p => p.Offers)
                    .HasForeignKey(d => d.IdOfferHistory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_offer_offerHistory");

                entity.HasOne(d => d.IdOfferStateNavigation)
                    .WithMany(p => p.Offers)
                    .HasForeignKey(d => d.IdOfferState)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_offer_offerState");
            });

            modelBuilder.Entity<OfferHistory>(entity =>
            {
                entity.HasKey(e => e.IdOfferHistory)
                    .HasName("PRIMARY");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<OfferState>(entity =>
            {
                entity.HasKey(e => e.IdOfferState)
                    .HasName("PRIMARY");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<PayMethod>(entity =>
            {
                entity.HasKey(e => e.IdPayMethod)
                    .HasName("PRIMARY");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PRIMARY");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasOne(d => d.IdCompanyNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdCompany)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_product_company");

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdCountry)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_product_country");

                entity.HasOne(d => d.IdOfferNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdOffer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_product_offer");

                entity.HasOne(d => d.IdProductHistoryNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdProductHistory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_product_productHistory");

                entity.HasOne(d => d.IdProductSatateNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdProductSatate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_product_productState");

                entity.HasOne(d => d.IdWorldNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdWorld)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_product_world");
            });

            modelBuilder.Entity<ProductHistory>(entity =>
            {
                entity.HasKey(e => e.IdProductHistory)
                    .HasName("PRIMARY");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<ProductState>(entity =>
            {
                entity.HasKey(e => e.IdProductSatate)
                    .HasName("PRIMARY");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Publication>(entity =>
            {
                entity.HasKey(e => e.IdPublication)
                    .HasName("PRIMARY");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.Publications)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_publication_product");

                entity.HasOne(d => d.IdPublicationHistoryNavigation)
                    .WithMany(p => p.Publications)
                    .HasForeignKey(d => d.IdPublicationHistory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_publication_publicationHistory");

                entity.HasOne(d => d.IdPublicationStateNavigation)
                    .WithMany(p => p.Publications)
                    .HasForeignKey(d => d.IdPublicationState)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_publication_publicationState");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Publications)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_publication_user");
            });

            modelBuilder.Entity<PublicationHistory>(entity =>
            {
                entity.HasKey(e => e.IdPublicationHistory)
                    .HasName("PRIMARY");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<PublicationState>(entity =>
            {
                entity.HasKey(e => e.IdPublicationState)
                    .HasName("PRIMARY");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasKey(e => e.IdPurchase)
                    .HasName("PRIMARY");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasOne(d => d.IdPayMethodNavigation)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.IdPayMethod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_purchase_metodoPago");

                entity.HasOne(d => d.IdPublicationNavigation)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.IdPublication)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_purchase_publication");

                entity.HasOne(d => d.IdPurchaseStateNavigation)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.IdPurchaseState)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_purchase_purchaseState");

                entity.HasOne(d => d.IdPurchasingHistoryNavigation)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.IdPurchasingHistory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_purchase_purchaseHistory");
            });

            modelBuilder.Entity<PurchaseHistory>(entity =>
            {
                entity.HasKey(e => e.IdPurchasingHistory)
                    .HasName("PRIMARY");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<PurchaseState>(entity =>
            {
                entity.HasKey(e => e.IdPurchaseState)
                    .HasName("PRIMARY");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Shipping>(entity =>
            {
                entity.HasKey(e => e.IdShipping)
                    .HasName("PRIMARY");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasOne(d => d.IdShippingCompanyNavigation)
                    .WithMany(p => p.Shippings)
                    .HasForeignKey(d => d.IdShippingCompany)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_shipping_shippingCompany");

                entity.HasOne(d => d.IdShippingCountryNavigation)
                    .WithMany(p => p.Shippings)
                    .HasForeignKey(d => d.IdShippingCountry)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_shipping_shippingCountry");

                entity.HasOne(d => d.IdShippingStateNavigation)
                    .WithMany(p => p.Shippings)
                    .HasForeignKey(d => d.IdShippingState)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_shipping_shippingState");

                entity.HasOne(d => d.IdpurchaseNavigation)
                    .WithMany(p => p.Shippings)
                    .HasForeignKey(d => d.Idpurchase)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_shipping_purchase");
            });

            modelBuilder.Entity<ShippingCompany>(entity =>
            {
                entity.HasKey(e => e.IdShippingCompany)
                    .HasName("PRIMARY");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<ShippingCountry>(entity =>
            {
                entity.HasKey(e => e.IdShippingCountry)
                    .HasName("PRIMARY");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<ShippingState>(entity =>
            {
                entity.HasKey(e => e.IdShippingState)
                    .HasName("PRIMARY");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdCountry)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_country");

                entity.HasOne(d => d.IdIsClientNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdIsClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_isClient");

                entity.HasOne(d => d.IdUserStateNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdUserState)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_userState");
            });

            modelBuilder.Entity<UserState>(entity =>
            {
                entity.HasKey(e => e.IdUserState)
                    .HasName("PRIMARY");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<World>(entity =>
            {
                entity.HasKey(e => e.IdWorld)
                    .HasName("PRIMARY");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
