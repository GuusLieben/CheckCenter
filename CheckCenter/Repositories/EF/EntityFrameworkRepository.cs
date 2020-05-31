using Infrastructure.Data;

namespace CheckCenter.Repositories.EF {
    public class EntityFrameworkRepository {
        protected readonly ProductionDbContext Context;

        protected EntityFrameworkRepository(ProductionDbContext context) {
            Context = context;
        }
    }
}
