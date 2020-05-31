using CheckCenter.Repositories.Interfaces;
using Domain;
using Infrastructure.Data;

namespace CheckCenter.Repositories.EF {
    public class EntityFrameworkStateRepository : EntityFrameworkRepository, IStateRepository {
        public EntityFrameworkStateRepository(ProductionDbContext context) : base(context) {}

        public int CreateState(State state)
        {
            Context.CheckCenterStates.Add(state);
            Context.SaveChanges();
            return state.Id;
        }
    }
}
