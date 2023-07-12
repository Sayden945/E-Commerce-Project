#nullable disable

using Microsoft.EntityFrameworkCore;
using E_Commerce_Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce_Project.Data
{
	public class ApplicationDbContext : IdentityDbContext<User>
	{

		public ApplicationDbContext(DbContextOptions options)
			: base(options)
		{
		}

		public virtual DbSet<CartItem> CartItem { get; set; }

		public virtual DbSet<Discount> Discount { get; set; }

		public virtual DbSet<OrderDetails> OrderDetails { get; set; }

		public virtual DbSet<OrderItems> OrderItems { get; set; }

		public virtual DbSet<PaymentDetails> PaymentDetails { get; set; }

		public virtual DbSet<Product> Product { get; set; }

		public virtual DbSet<ProductCategory> ProductCategory { get; set; }

		public virtual DbSet<ProductInventory> ProductInventory { get; set; }

		public virtual DbSet<ShoppingSession> ShoppingSession { get; set; }

		public virtual DbSet<User> User { get; set; }

		public virtual DbSet<UserAddress> UserAddress { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<CartItem>(entity =>
			{
				entity.ToTable("cart_item");

				entity.HasIndex(e => e.SessionId, "IX_cart_item_session_id");

				entity.Property(e => e.Id)
					.ValueGeneratedNever()
					.HasColumnName("ID");
				entity.Property(e => e.Created)
					.HasDefaultValueSql("(getdate())")
					.HasColumnType("datetime")
					.HasColumnName("created");
				entity.Property(e => e.ProductId).HasColumnName("product_id");
				entity.Property(e => e.Quantity).HasColumnName("quantity");
				entity.Property(e => e.SessionId).HasColumnName("session_id");

				entity.HasOne(d => d.Product).WithMany(p => p.CartItem)
					.HasForeignKey(d => d.ProductId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Cart_Product");

				entity.HasOne(d => d.Session).WithMany(p => p.CartItem)
					.HasForeignKey(d => d.SessionId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Cart_Session");
			});

			modelBuilder.Entity<Discount>(entity =>
			{
				entity.ToTable("discount");

				entity.Property(e => e.Id)
					.ValueGeneratedNever()
					.HasColumnName("ID");
				entity.Property(e => e.Active).HasColumnName("active");
				entity.Property(e => e.Description)
					.IsRequired()
					.HasColumnType("text")
					.HasColumnName("description");
				entity.Property(e => e.DiscountPercent)
					.HasColumnType("decimal(18, 0)")
					.HasColumnName("discount_percent");
				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(15)
					.IsUnicode(false)
					.HasColumnName("name");
			});

			modelBuilder.Entity<OrderDetails>(entity =>
			{
				entity.ToTable("order_details");

				entity.HasIndex(e => e.PaymentId, "IX_order_details_payment_id");

				entity.HasIndex(e => e.UserId, "IX_order_details_user_id");

				entity.Property(e => e.Id)
					.ValueGeneratedNever()
					.HasColumnName("ID");
				entity.Property(e => e.Created)
					.HasDefaultValueSql("(getdate())")
					.HasColumnType("datetime")
					.HasColumnName("created");
				entity.Property(e => e.PaymentId).HasColumnName("payment_id");
				entity.Property(e => e.Total)
					.HasColumnType("decimal(18, 0)")
					.HasColumnName("total");
				entity.Property(e => e.UserId).HasColumnName("user_id");

				entity.HasOne(d => d.Payment).WithMany(p => p.OrderDetails)
					.HasForeignKey(d => d.PaymentId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Order_Payment");

				entity.HasOne(d => d.User).WithMany(p => p.OrderDetails)
					.HasForeignKey(d => d.UserId)
					.HasConstraintName("FK_Order_Users");
			});

			modelBuilder.Entity<OrderItems>(entity =>
			{
				entity.ToTable("order_items");

				entity.HasIndex(e => e.OrderId, "IX_order_items_order_id");

				entity.HasIndex(e => e.ProductId, "IX_order_items_product_id");

				entity.Property(e => e.Id)
					.ValueGeneratedNever()
					.HasColumnName("ID");
				entity.Property(e => e.OrderId).HasColumnName("order_id");
				entity.Property(e => e.ProductId).HasColumnName("product_id");
				entity.Property(e => e.Quantity).HasColumnName("quantity");

				entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
					.HasForeignKey(d => d.OrderId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Items_Order");

				entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
					.HasForeignKey(d => d.ProductId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Items_Product");
			});

			modelBuilder.Entity<PaymentDetails>(entity =>
			{
				entity.ToTable("payment_details");

				entity.HasIndex(e => e.OrderId, "IX_payment_details_order_id");

				entity.Property(e => e.Id)
					.ValueGeneratedNever()
					.HasColumnName("ID");
				entity.Property(e => e.Amount)
					.HasColumnType("decimal(18, 0)")
					.HasColumnName("amount");
				entity.Property(e => e.OrderId).HasColumnName("order_id");
				entity.Property(e => e.Status)
					.IsRequired()
					.HasMaxLength(15)
					.IsUnicode(false)
					.HasColumnName("status");

				entity.HasOne(d => d.Order).WithMany(p => p.PaymentDetails)
					.HasForeignKey(d => d.OrderId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Payment_Order");
			});

			modelBuilder.Entity<Product>(entity =>
			{
				entity.ToTable("product");

				entity.HasIndex(e => e.CategoryId, "IX_product_category_id");

				entity.HasIndex(e => e.DiscountId, "IX_product_discount_id");

				entity.HasIndex(e => e.InventoryId, "IX_product_inventory_id");

				entity.Property(e => e.Id)
					.ValueGeneratedNever()
					.HasColumnName("ID");
				entity.Property(e => e.CategoryId).HasColumnName("category_id");
				entity.Property(e => e.Description)
					.IsRequired()
					.HasColumnType("text")
					.HasColumnName("description");
				entity.Property(e => e.DiscountId).HasColumnName("discount_id");
				entity.Property(e => e.Image).HasColumnName("image");
				entity.Property(e => e.InventoryId).HasColumnName("inventory_id");
				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(29)
					.IsUnicode(false)
					.HasColumnName("name");
				entity.Property(e => e.Price)
					.HasColumnType("decimal(18, 0)")
					.HasColumnName("price");
				entity.Property(e => e.Sku)
					.IsRequired()
					.HasMaxLength(15)
					.IsUnicode(false)
					.HasColumnName("SKU");

				entity.HasOne(d => d.Category).WithMany(p => p.Product)
					.HasForeignKey(d => d.CategoryId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Product_Category");

				entity.HasOne(d => d.Discount).WithMany(p => p.Product)
					.HasForeignKey(d => d.DiscountId)
					.HasConstraintName("FK_Product_Discount");

				entity.HasOne(d => d.Inventory).WithMany(p => p.Product)
					.HasForeignKey(d => d.InventoryId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Product_Inventory");
			});

			modelBuilder.Entity<ProductCategory>(entity =>
			{
				entity.ToTable("product_category");

				entity.Property(e => e.Id)
					.ValueGeneratedNever()
					.HasColumnName("ID");
				entity.Property(e => e.Description)
					.IsRequired()
					.HasColumnType("text")
					.HasColumnName("description");
				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(30)
					.IsUnicode(false)
					.HasColumnName("name");
			});

			modelBuilder.Entity<ProductInventory>(entity =>
			{
				entity.ToTable("product_inventory");

				entity.Property(e => e.Id)
					.ValueGeneratedNever()
					.HasColumnName("ID");
				entity.Property(e => e.Created)
					.HasDefaultValueSql("(getdate())")
					.HasColumnType("datetime")
					.HasColumnName("created");
				entity.Property(e => e.Quantity).HasColumnName("quantity");
			});

			modelBuilder.Entity<ShoppingSession>(entity =>
			{
				entity.ToTable("shopping_session");

				entity.HasIndex(e => e.UserId, "IX_shopping_session_user_id");

				entity.Property(e => e.Id)
					.ValueGeneratedNever()
					.HasColumnName("ID");
				entity.Property(e => e.Created)
					.HasDefaultValueSql("(getdate())")
					.HasColumnType("datetime")
					.HasColumnName("created");
				entity.Property(e => e.Total)
					.HasColumnType("decimal(18, 0)")
					.HasColumnName("total");
				entity.Property(e => e.UserId).HasColumnName("user_id");

				entity.HasOne(d => d.User).WithMany(p => p.ShoppingSession)
					.HasForeignKey(d => d.UserId)
					.HasConstraintName("FK_Session_User");
			});

			modelBuilder.Entity<User>(entity =>
			{
				entity.ToTable("user");

				entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

				entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
					.IsUnique()
					.HasFilter("([NormalizedUserName] IS NOT NULL)");

				entity.Property(e => e.Id).HasColumnName("ID");
				entity.Property(e => e.Created)
					.HasDefaultValueSql("(getdate())")
					.HasColumnType("datetime")
					.HasColumnName("created");
				entity.Property(e => e.Email)
					.IsRequired()
					.HasMaxLength(320)
					.IsUnicode(false)
					.HasColumnName("email");
				entity.Property(e => e.FirstName)
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("first_name");
				entity.Property(e => e.LastName)
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("last_name");
				entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
				entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
				entity.Property(e => e.UserName).HasMaxLength(256);
			});

			modelBuilder.Entity<UserAddress>(entity =>
			{
				entity.ToTable("user_address");

				entity.HasIndex(e => e.UserId, "IX_user_address_user_id");

				entity.Property(e => e.Id)
					.ValueGeneratedNever()
					.HasColumnName("ID");
				entity.Property(e => e.AddressLine1)
					.IsRequired()
					.HasMaxLength(30)
					.IsUnicode(false)
					.HasColumnName("address_line1");
				entity.Property(e => e.AddressLine2)
					.HasMaxLength(30)
					.IsUnicode(false)
					.HasColumnName("address_line2");
				entity.Property(e => e.City)
					.IsRequired()
					.HasMaxLength(20)
					.IsUnicode(false)
					.HasColumnName("city");
				entity.Property(e => e.PostalCode)
					.IsRequired()
					.HasMaxLength(4)
					.IsUnicode(false)
					.HasColumnName("postal_code");
				entity.Property(e => e.State)
					.IsRequired()
					.HasMaxLength(3)
					.IsUnicode(false)
					.HasColumnName("state");
				entity.Property(e => e.UserId).HasColumnName("user_id");

				entity.HasOne(d => d.User).WithMany(p => p.UserAddress)
					.HasForeignKey(d => d.UserId)
					.HasConstraintName("FK_user_id");
			});

		}

	}
}