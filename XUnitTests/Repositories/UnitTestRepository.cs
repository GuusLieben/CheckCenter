using CheckCenter.Repositories.EF;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace XUnitTests {
    static class UnitTestRepository {

        // Methods that create mock DbContexts to use for test purposes
        public static ProductionDbContext GetProductionDbContext(string db) {
            var options = new DbContextOptionsBuilder<ProductionDbContext>()
                .UseInMemoryDatabase(databaseName: db)
                .Options;
            var context = new ProductionDbContext(options);
            // Make sure we clear the database before each run
            context.Database.EnsureDeleted();
            return context;
        }
        public static ArchiveDbContext GetArchiveDbContext(string db)
        {
            var options = new DbContextOptionsBuilder<ArchiveDbContext>()
                .UseInMemoryDatabase(databaseName: db)
                .Options;
            var context = new ArchiveDbContext(options);
            // Make sure we clear the database before each run
            context.Database.EnsureDeleted();
            return context;
        }

        // Test instances for all repo's
        public static EntityFrameworkTypeRepository GetTypeRepo(string db) {
            return new EntityFrameworkTypeRepository(GetProductionDbContext(db));
        }
        public static EntityFrameworkStateRepository GetStateRepo(string db) {
            return new EntityFrameworkStateRepository(GetProductionDbContext(db));
        }
        public static EntityFrameworkSourceRepository GetSourceRepo(string db) {
            return new EntityFrameworkSourceRepository(GetProductionDbContext(db));
        }
        public static EntityFrameworkFinishedEventRepository GetFinishedEventRepo(string prodDb, string archDb) {
            return new EntityFrameworkFinishedEventRepository(GetProductionDbContext(prodDb), GetArchiveDbContext(archDb));
        }
        public static EntityFrameworkEventRepository GetEventRepo(string prodDb, string archDb) {
            return new EntityFrameworkEventRepository(GetProductionDbContext(prodDb), GetArchiveDbContext(archDb));
        }
        public static EntityFrameworkCommentRepository GetCommentRepo(string prodDb, string archDb) {
            return new EntityFrameworkCommentRepository(GetProductionDbContext(prodDb), GetArchiveDbContext(archDb));
        }
        public static EntityFrameworkAdditionalInfoRepository GetAdditionalInfoRepo(string prodDb, string archDb) {
            return new EntityFrameworkAdditionalInfoRepository(GetProductionDbContext(prodDb), GetArchiveDbContext(archDb));
        }
        public static EntityFrameworkActionLogRepository GetActionLogRepo(string prodDb, string archDb) {
            return new EntityFrameworkActionLogRepository(GetProductionDbContext(prodDb), GetArchiveDbContext(archDb));
        }

        public static EntityFrameworkFeedbackRepository GetFeedbackRepo(string prodDb, string archDb)
        {
            return new EntityFrameworkFeedbackRepository(GetProductionDbContext(prodDb), GetArchiveDbContext(archDb));
        }
    }
}