using Sales.Shared.Entities;

namespace Sales.Api.Data
{
    public class SeedDb
    {
        private readonly DataContext _Context;
        public SeedDb(DataContext contex)
        {
            _Context = contex;
        }

        public async Task SeedAsync()
        {
            await _Context.Database.EnsureCreatedAsync();

            await CheckCountriesAsync();
        }

        private async Task CheckCountriesAsync()
        {
            if (!_Context.Countries.Any())
            {
                _Context.Countries.Add(new Country { Name = "Haiti" });
                _Context.Countries.Add(new Country { Name = "España" });
                _Context.Countries.Add(new Country { Name = "Republica dominicana" });
                _Context.Countries.Add(new Country { Name = "Perú" });
                _Context.Countries.Add(new Country { Name = "Colombia" });
                await _Context.SaveChangesAsync();

            }
        }
    }
}
