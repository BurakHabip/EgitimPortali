using Microsoft.EntityFrameworkCore;

namespace EgitimPortali.Models
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Education>().HasData(
            new Education() { Id = 1, Name = "Eğitim1", Description = "Eğitim", IsActive = true },
            new Education() { Id = 2, Name = "Eğitim2", Description = "Eğitim açıklama", IsActive = true },
            new Education() { Id = 3, Name = "Eğitim3", Description = "Eğitim açıklama", IsActive = false },
            new Education() { Id = 4, Name = "Eğitim4", Description = "Eğitim açıklama", IsActive = false },
            new Education() { Id = 5, Name = "Eğitim5", Description = "Eğitim açıklama", IsActive = false }
                );
        }
    }
}
