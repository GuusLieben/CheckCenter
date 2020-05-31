using System.Collections.Generic;
using Domain;

namespace CheckCenter.Repositories.Interfaces
{
    public interface ISourceRepository
    {
        IEnumerable<Source> GetAllSources();

        Source GetSource(int id);

        int CreateSource(Source source);
        bool UpdateSource(Source source);
        bool DeleteSource(Source source);
    }
}
