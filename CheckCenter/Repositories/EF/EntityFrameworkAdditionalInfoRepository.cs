using CheckCenter.Repositories.Interfaces;
using Domain;
using Domain.Archive;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CheckCenter.Repositories.EF
{
    public class EntityFrameworkAdditionalInfoRepository : EntityFrameworkRepository, IAdditionalInfoRepository {
        private readonly ArchiveDbContext _archive;

        public EntityFrameworkAdditionalInfoRepository(ProductionDbContext context, ArchiveDbContext archive) : base(context)
        {
            _archive = archive;
        }

        public int CreateAdditionalInfo(AdditionalInfo additionalInfo) {
            additionalInfo = ValidateProperties(additionalInfo);
            Context.CheckCenterAdditionalInfo.Add(additionalInfo);
            Context.SaveChanges();

            return additionalInfo.Id;
        }

        public bool UpdateAdditionalInfo(AdditionalInfo additionalInfo) {
            Context.CheckCenterAdditionalInfo.Attach(additionalInfo);
            var entry = Context.Entry(additionalInfo);

            if (additionalInfo.Key != null && !additionalInfo.Key.Equals("")) entry.Property(ai => ai.Key)
                .IsModified = true;
            if (additionalInfo.Value != null && !additionalInfo.Value.Equals("")) entry.Property(ai => ai.Value)
                .IsModified = true;

            Context.SaveChanges();

            return true;
        }

        public bool DeleteAdditionalInfo(int id) {
            try {
                var info = new AdditionalInfo {Id = id};
                Context.CheckCenterAdditionalInfo.Attach(info);
                Context.CheckCenterAdditionalInfo.Remove(info);
                Context.SaveChanges();

                return true;
            } catch {
                return false;
            }
            
        }

        public void ArchiveAdditionalInfo(AdditionalInfo info, int id)
        {
            var archivedInfo = new ArchivedInfo()
            {
                EventId = id,
                Id = info.Id,
                Key = info.Key,
                Value = info.Value
            };
            _archive.CheckCenterAdditionalInfo.Add(archivedInfo);
            _archive.SaveChanges();

            DeleteAdditionalInfo(info.Id);
        }

        private AdditionalInfo ValidateProperties(AdditionalInfo additionalInfo) {
            if (additionalInfo.Event == null) return AdditionalInfo.Empty();
            // Assign properties
            additionalInfo.Event = Context.CheckCenterEvents.Find(additionalInfo.Event.Id);

            // Do not overwrite existing entities
            Context.Entry(additionalInfo.Event).State = EntityState.Unchanged;
            return additionalInfo;
        }
    }
}
