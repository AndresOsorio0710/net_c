using Authentication.Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Backend.Infrastructure.Data.Configs.UserConfig
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("tblUsers");
            entityTypeBuilder.HasKey(user => user.UserId);
        }
    }
}
