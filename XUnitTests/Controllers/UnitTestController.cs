using System;
using System.Collections.Generic;
using System.Text;
using CheckCenter.ApplicationInterface.Functional;
using CheckCenter.ApplicationInterface.ReadOnly;
using static XUnitTests.UnitTestRepository;

namespace XUnitTests.Controllers
{
    class UnitTestController
    {
        public static FunctionalEventController GetFunctionalEventController(string eventDb, string archiveDb)
        {
              return new FunctionalEventController(
                  GetEventRepo(eventDb, archiveDb),
                  GetCommentRepo(eventDb, archiveDb),
                  GetAdditionalInfoRepo(eventDb, archiveDb),
                  GetActionLogRepo(eventDb, archiveDb),
                  GetFeedbackRepo(eventDb, archiveDb));
        }

        public static FunctionalSourceController GetFunctionalSourceController(string eventDb)
        {
            return new FunctionalSourceController(GetSourceRepo(eventDb));
        }

        public static FunctionalStateController GetFunctionalStateController(string eventDb)
        {
            return new FunctionalStateController(GetStateRepo(eventDb));
        }

        public static FunctionalTypeController GetFunctionalTypeController(string eventDb)
        {
            return new FunctionalTypeController(GetTypeRepo(eventDb));
        }

        public static ReadOnlyEventController GetReadOnlyEventController(string eventDb, string archiveDb)
        {
            return new ReadOnlyEventController(
                GetEventRepo(eventDb, archiveDb), 
                GetFinishedEventRepo(eventDb, archiveDb));
        }

        public static ReadOnlySourceController GetReadOnlySourceController(string eventDb)
        {
            return new ReadOnlySourceController(GetSourceRepo(eventDb));
        }
    }
}
