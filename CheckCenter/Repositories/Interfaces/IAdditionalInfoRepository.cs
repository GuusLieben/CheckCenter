using Domain;

namespace CheckCenter.Repositories.Interfaces
{
    public interface IAdditionalInfoRepository
    {

        int CreateAdditionalInfo(AdditionalInfo additionalInfo);

        bool UpdateAdditionalInfo(AdditionalInfo additionalInfo);

        bool DeleteAdditionalInfo(int id);
        void ArchiveAdditionalInfo(AdditionalInfo info, int id);
    }
}
