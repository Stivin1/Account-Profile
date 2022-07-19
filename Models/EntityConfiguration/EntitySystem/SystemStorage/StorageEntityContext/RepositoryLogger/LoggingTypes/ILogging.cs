using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.RepositoryLogger.LoggingTypes.LoggingEnum;

namespace OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.RepositoryLogger.LoggingTypes
{
    interface ILogging
    {
        Logging Userloginattempt(string user, InformationLoggingEnum LogInfo);

        Logging Userlogout(string user, InformationLoggingEnum LogInfo);

        Logging Getprofilepagedata(string user, InformationLoggingEnum LogInfo);

        Logging Gettinguserpagedata(string user, InformationLoggingEnum LogInfo);

        Logging RetrievingProfileEditPageData(string user, InformationLoggingEnum LogInfo);

        Logging Retrievinguserchangepagedata(string user, InformationLoggingEnum LogInfo);

        Logging Getpagedatachangepassword(string user, InformationLoggingEnum LogInfo);

        Logging RetrievingGroupListPageData(string user, InformationLoggingEnum LogInfo);

        Logging Gettingpagedataforaddingagroup(string user, InformationLoggingEnum LogInfo);

        Logging Gettingpagedataforaddingagrouptoauser(string user, InformationLoggingEnum LogInfo);

        Logging Gettingdatafromtheaddrolepage(string user, InformationLoggingEnum LogInfo);

        Logging Gettingthedataofthepageforaddingaroletoauser(string user, InformationLoggingEnum LogInfo);

        Logging Gettingpagedatamydocuments(string user, InformationLoggingEnum LogInfo);

        Logging RetrievingDocumentBasketPageData(string user, InformationLoggingEnum LogInfo);

        Logging Gettingmailpagedata(string user, InformationLoggingEnum LogInfo);

        Logging Gettingpagedataforsendingamessage(string user, InformationLoggingEnum LogInfo);

        Logging RetrievingDeletedMessagesPageData(string user, InformationLoggingEnum LogInfo);

        Logging Gettingaccountactivitypagedata(string user, InformationLoggingEnum LogInfo);

        Logging Changingprofileinformation(string user, InformationLoggingEnum LogInfo);

        Logging Changinguserdata(string user, InformationLoggingEnum LogInfo);

        Logging Changingpasswordinformation(string user, InformationLoggingEnum LogInfo);

        Logging Addingagroupbyauser(string user, InformationLoggingEnum LogInfo);

        Logging Addingagrouptoauser(string user, InformationLoggingEnum LogInfo);

        Logging Deletingausergroup(string user, InformationLoggingEnum LogInfo);

        Logging AddingaRolebyaUser(string user, InformationLoggingEnum LogInfo);

        Logging Removingarolebyauser(string user, InformationLoggingEnum LogInfo);

        Logging Addingadocument(string user, InformationLoggingEnum LogInfo);

        Logging Sendingamessage(string user, InformationLoggingEnum LogInfo);

        Logging GetDataListMessagesUsers(string user, InformationLoggingEnum LogInfo);

        Logging Gettingmessageviewformdata(string user, InformationLoggingEnum LogInfo);

    }
}
