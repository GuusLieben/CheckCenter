using System;
using System.Collections.Generic;
using System.Linq;
using CheckCenter.Repositories.Interfaces;
using Domain;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;

namespace CheckCenter.Repositories.EF
{
    public class EntityFrameworkSourceRepository : EntityFrameworkRepository, ISourceRepository
    {
        public EntityFrameworkSourceRepository(ProductionDbContext context) : base(context)
        {
        }

        public int CreateSource(Source source) {
            source = ValidateProperties(source);
            Context.CheckCenterSources.Add(source);
            Context.SaveChanges();
            return source.Id;
        }

        public bool UpdateSource(Source source)
        {
            Context.CheckCenterSources.Attach(source);
            Context.CheckCenterSources.Update(source);
            Context.SaveChanges();
            return true;
        }

        public bool DeleteSource(Source source)
        {
            try {
                Context.CheckCenterSources.Remove(source);
                Context.SaveChanges();
                return true;
            } catch {
                return false;
            }
            
        }

        public IEnumerable<Source> GetAllSources() {
            return Context.CheckCenterSources;
        }

        public Source GetSource(int id) {
            return Context.CheckCenterSources
                .Where(s => s.Id == id)
                .Include(s => s.CheckType)
                .Include(s => s.States)
                .ToList()
                .FirstOr(Source.Empty());
        }
        private Source ValidateProperties(Source source) {
            if (source.CheckType == null || source.States == null)
                throw new System.Exception("Source model is invalid");
            
            // Assign properties
            source.CheckType = Context.CheckCenterCheckTypes.Find(source.CheckType.Id);
            var states = new List<State>();
            foreach (var state in source.States) {
                var temp = Context.CheckCenterStates.Find(state.Id);
                if (temp == null) throw new Exception("Source model is invalid");
                states.Add(temp);
            }
            source.States = states;

            // Do not overwrite existing entities
            Context.Entry(source.CheckType).State = EntityState.Unchanged;

            return source;
        }
    }
}
