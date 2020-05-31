using CheckCenter.Repositories.Interfaces;
using Domain;
using Infrastructure.Data;

namespace CheckCenter.Repositories.EF {
    public class EntityFrameworkTypeRepository : EntityFrameworkRepository, ITypeRepository {
        public EntityFrameworkTypeRepository(ProductionDbContext context) : base(context) {}

        public int CreateType(CheckType type)
        {
            Context.CheckCenterCheckTypes.Add(type);
            Context.SaveChanges();
            return type.Id;
        }
    }
}
