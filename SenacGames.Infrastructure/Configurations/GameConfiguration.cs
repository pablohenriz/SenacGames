using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SenacGames.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacGames.Infrastructure.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Title)
                .IsRequired() // Define que o campo é obrigatório
                .HasMaxLength(200); // Define um tamanho máximo para o campo

            builder.Property(g => g.Description)
                .HasMaxLength(2000); // Define um tamanho máximo para o campo

            builder.Property(g => g.CoverImageUrl)
                .HasMaxLength(500); // Define um tamanho máximo para o campo

            builder.Property(g => g.Description)
                .HasMaxLength(2000); // Define um tamanho máximo para o campo

            builder.HasOne(g => g.Category) // Uma game tem UMA Categoria
                .WithMany(c => c.Games) // uma categoria tem muitos games
                .HasForeignKey(g => g.CategoryId) // A FK é category.id
                .OnDelete(DeleteBehavior.Restrict); // Define o comportamento do delete (que nesse codigo está como restrito)
        }
    }
}
