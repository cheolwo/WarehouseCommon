using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace 창고Common.Model
{
    public class 창고DbContext : DbContext
    {
        public DbSet<창고> 창고 { get; set; }

        public 창고DbContext(DbContextOptions<창고DbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new 창고Configuration());
        }
    }
    public class 창고Configuration : IEntityTypeConfiguration<창고>
    {
        public void Configure(EntityTypeBuilder<창고> builder)
        {
            builder.HasKey(x => x.창고코드); // 기본 키 설정
            builder.Property(x => x.창고명).HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.구분).HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.생산공정명).HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.외주거래처명).HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.사용).IsRequired(false);

            // 창고와 창고상품 간의 관계 설정
            builder.HasMany(x => x.창고상품목록)
                   .WithOne(x => x.창고)
                   .HasForeignKey(x => x.창고코드)
                   .IsRequired(false); // 창고 코드는 null을 허용
        }
    }
    public class 창고상품Configuration : IEntityTypeConfiguration<창고상품>
    {
        public void Configure(EntityTypeBuilder<창고상품> builder)
        {
            builder.HasKey(x => x.창고상품코드); // 기본 키 설정
            builder.Property(x => x.품목코드).IsRequired(false).HasMaxLength(20);
            builder.Property(x => x.입고단가).HasColumnType("decimal(18, 2)").IsRequired(false);
            builder.Property(x => x.출고단가).HasColumnType("decimal(18, 2)").IsRequired(false);

            // 창고상품과 창고 간의 참조 설정
            builder.HasOne(x => x.창고)
                   .WithMany(x => x.창고상품목록)
                   .HasForeignKey(x => x.창고코드)
                   .IsRequired(false); // 창고코드는 null을 허용
        }
    }

}
