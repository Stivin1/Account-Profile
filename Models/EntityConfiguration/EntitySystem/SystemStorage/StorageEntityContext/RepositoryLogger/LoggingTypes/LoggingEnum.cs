using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.RepositoryLogger.LoggingTypes
{
    public class LoggingEnum : ILogging
    {
        public enum InformationLoggingEnum
        {
            //<summary>
            //Попытка входа пользователя
            //</summary>
            Userloginattempt = 1,
            //<summary>
            //Выход пользователя
            //</summary>
            Userlogout = 2,
            //<summary>
            //Получение данных страницы профиля 
            //</summary>
            Getprofilepagedata = 3,
            //<summary>
            //Получение данных страницы пользователей
            //</summary>
            Gettinguserpagedata = 4,
            //<summary>
            //Получение данных страницы изменения профиля
            //</summary>
            RetrievingProfileEditPageData = 5,
            //<summary>
            //Получение данных страницы изменения пользователя
            //</summary>
            Retrievinguserchangepagedata = 6,
            //<summary>
            //Получение данных страницы изменить пароль
            //</summary>
            Getpagedatachangepassword = 7,
            //<summary>
            //Получение данных страницы списка групп
            //</summary>
            RetrievingGroupListPageData = 8,
            //<summary>
            //Получение данных страницы добавления группы 
            //</summary>
            Gettingpagedataforaddingagroup = 9,
            //<summary>
            //Получение данных страницы добавления группы пользователю 
            //</summary>
            Gettingpagedataforaddingagrouptoauser = 10,
            //<summary>
            //Получение данных страницы добавления роли 
            //</summary>
            Gettingdatafromtheaddrolepage = 11,
            //<summary>
            //Получение данных страницы добавления роли пользователю 
            //</summary>
            Gettingthedataofthepageforaddingaroletoauser = 12,
            //<summary>
            //Получение данных страницы мои документы 
            //</summary>
            Gettingpagedatamydocuments = 13,
            //<summary>
            //Получение данных страницы корзины документов 
            //</summary>
            RetrievingDocumentBasketPageData = 14,
            //<summary>
            //Получение данных страницы почты 
            //</summary>
            Gettingmailpagedata = 15,
            //<summary>
            //Получение данных страницы отправки  
            //</summary>
            Gettingpagedataforsendingamessage = 16,
            //<summary>
            //Получение данных страницы удаленных сообщений  
            //</summary>
            RetrievingDeletedMessagesPageData = 17,
            //<summary>
            //Получение данных страницы активности аккаунта 
            //</summary>
            Gettingaccountactivitypagedata = 18,
            //<summary>
            //Изменение данных профиля  
            //</summary>
            Changingprofileinformation = 19,
            //<summary>
            //Изменение данных пользователя  
            //</summary>
            Changinguserdata = 20,
            //<summary>
            //Изменение данных пароля  
            //</summary>
            Changingpasswordinformation = 21,
            //<summary>
            //Добавление группы пользователем  
            //</summary>
            Addingagroupbyauser = 22,
            //<summary>
            //Добавление группы пользователю  
            //</summary>
            Addingagrouptoauser = 23,
            //<summary>
            //Удаление группы пользователя  
            //</summary>
            Deletingausergroup = 24,
            //<summary>
            //Добавление роли пользователем 
            //</summary>
            AddingaRolebyaUser = 25,
            //<summary>
            //Добавление роли пользователю  
            //</summary>
            AddingaRoletoaUser = 26,
            //<summary>
            //Удаление роли пользователем  
            //</summary>
            Removingarolebyauser = 27,
            //<summary>
            //Добавление документа 
            //</summary>
            Addingadocument = 28,
            //<summary>
            //Отправка сообщения  
            //</summary>
            Sendingamessage = 29,
            //<summary>
            //Получение данных формы просмотра сообщений 
            //</summary>
            GetDataListMessagesUsers = 30,
            //<summary>
            //Получение данных формы чтения сообщения 
            //</summary>
            Gettingmessageviewformdata = 31
        }

        public Logging GetInformationLogging(string user, InformationLoggingEnum LogInfo)
        {
            return LogInfo switch
            {
                InformationLoggingEnum.Userloginattempt => Userloginattempt(user, LogInfo),
                InformationLoggingEnum.Userlogout => Userlogout(user, LogInfo),
                InformationLoggingEnum.Getprofilepagedata => Getprofilepagedata(user, LogInfo),
                InformationLoggingEnum.Gettinguserpagedata => Gettinguserpagedata(user, LogInfo),
                InformationLoggingEnum.RetrievingProfileEditPageData => RetrievingProfileEditPageData(user, LogInfo),
                InformationLoggingEnum.Retrievinguserchangepagedata => Retrievinguserchangepagedata(user, LogInfo),
                InformationLoggingEnum.Getpagedatachangepassword => Getpagedatachangepassword(user, LogInfo),
                InformationLoggingEnum.RetrievingGroupListPageData => RetrievingGroupListPageData(user, LogInfo),
                InformationLoggingEnum.Gettingpagedataforaddingagroup => Gettingpagedataforaddingagroup(user, LogInfo),
                InformationLoggingEnum.Gettingpagedataforaddingagrouptoauser => Gettingpagedataforaddingagrouptoauser(user, LogInfo),
                InformationLoggingEnum.Gettingdatafromtheaddrolepage => Gettingdatafromtheaddrolepage(user, LogInfo),
                InformationLoggingEnum.Gettingthedataofthepageforaddingaroletoauser => Gettingthedataofthepageforaddingaroletoauser(user, LogInfo),
                InformationLoggingEnum.Gettingpagedatamydocuments => Gettingpagedatamydocuments(user, LogInfo),
                InformationLoggingEnum.RetrievingDocumentBasketPageData => RetrievingDocumentBasketPageData(user, LogInfo),
                InformationLoggingEnum.Gettingmailpagedata => Gettingmailpagedata(user, LogInfo),
                InformationLoggingEnum.Gettingpagedataforsendingamessage => Gettingpagedataforsendingamessage(user, LogInfo),
                InformationLoggingEnum.RetrievingDeletedMessagesPageData => RetrievingDeletedMessagesPageData(user, LogInfo),
                InformationLoggingEnum.Gettingaccountactivitypagedata => Gettingaccountactivitypagedata(user, LogInfo),
                InformationLoggingEnum.Changingprofileinformation => Changingprofileinformation(user, LogInfo),
                InformationLoggingEnum.Changinguserdata => Changinguserdata(user, LogInfo),
                InformationLoggingEnum.Changingpasswordinformation => Changingpasswordinformation(user, LogInfo),
                InformationLoggingEnum.Addingagroupbyauser => Addingagroupbyauser(user, LogInfo),
                InformationLoggingEnum.Addingagrouptoauser => Addingagrouptoauser(user, LogInfo),
                InformationLoggingEnum.Deletingausergroup => Deletingausergroup(user, LogInfo),
                InformationLoggingEnum.AddingaRolebyaUser => AddingaRolebyaUser(user, LogInfo),
                InformationLoggingEnum.Removingarolebyauser => Removingarolebyauser(user, LogInfo),
                InformationLoggingEnum.Addingadocument => Addingadocument(user, LogInfo),
                InformationLoggingEnum.Sendingamessage => Sendingamessage(user, LogInfo),
                InformationLoggingEnum.GetDataListMessagesUsers => GetDataListMessagesUsers(user, LogInfo),
                InformationLoggingEnum.Gettingmessageviewformdata => Gettingmessageviewformdata(user, LogInfo),
                _ => throw new Exception("Internal error recording user data stories")
            };
        }

        public Logging Userloginattempt(string user, InformationLoggingEnum LogInfo)
        {
            return new Logging
            {
                UserId = user,
                LoggingInformationId = (int)LogInfo,
                Description = "Попытка входа пользователя",
                DateCreate = DateTime.Now.ToString()
            };
        }

        public Logging Userlogout(string user, InformationLoggingEnum LogInfo)
        {
            return new Logging
            {
                UserId = user,
                LoggingInformationId = (int)LogInfo,
                Description = "Выход пользователя",
                DateCreate = DateTime.Now.ToString()
            };
        }

        public Logging Getprofilepagedata(string user, InformationLoggingEnum LogInfo)
        {
            return new Logging
            {
                UserId = user,
                LoggingInformationId = (int)LogInfo,
                Description = "Получение данных страницы профиля ",
                DateCreate = DateTime.Now.ToString()
            };
        }

        public Logging Gettinguserpagedata(string user, InformationLoggingEnum LogInfo)
        {
            return new Logging
            {
                UserId = user,
                LoggingInformationId = (int)LogInfo,
                Description = "Получение данных страницы пользователей",
                DateCreate = DateTime.Now.ToString()
            };
        }

        public Logging RetrievingProfileEditPageData(string user, InformationLoggingEnum LogInfo)
        {
            return new Logging
            {
                UserId = user,
                LoggingInformationId = (int)LogInfo,
                Description = "олучение данных страницы изменения профиля",
                DateCreate = DateTime.Now.ToString()
            };
        }

        public Logging Retrievinguserchangepagedata(string user, InformationLoggingEnum LogInfo)
        {
            return new Logging
            {
                UserId = user,
                LoggingInformationId = (int)LogInfo,
                Description = "Получение данных страницы изменения пользователя",
                DateCreate = DateTime.Now.ToString()
            };
        }

        public Logging Getpagedatachangepassword(string user, InformationLoggingEnum LogInfo)
        {
            return new Logging
            {
                UserId = user,
                LoggingInformationId = (int)LogInfo,
                Description = "Получение данных страницы изменить пароль",
                DateCreate = DateTime.Now.ToString()
            };
        }

        public Logging RetrievingGroupListPageData(string user, InformationLoggingEnum LogInfo)
        {
            return new Logging
            {
                UserId = user,
                LoggingInformationId = (int)LogInfo,
                Description = "Получение данных страницы списка групп",
                DateCreate = DateTime.Now.ToString()
            };
        }

        public Logging Gettingpagedataforaddingagroup(string user, InformationLoggingEnum LogInfo)
        {
            return new Logging
            {
                UserId = user,
                LoggingInformationId = (int)LogInfo,
                Description = "Получение данных страницы добавления группы",
                DateCreate = DateTime.Now.ToString()
            };
        }

        public Logging Gettingpagedataforaddingagrouptoauser(string user, InformationLoggingEnum LogInfo)
        {
            return new Logging
            {
                UserId = user,
                LoggingInformationId = (int)LogInfo,
                Description = "Получение данных страницы добавления группы пользователю",
                DateCreate = DateTime.Now.ToString()
            };
        }

        public Logging Gettingdatafromtheaddrolepage(string user, InformationLoggingEnum LogInfo)
        {
            return new Logging
            {
                UserId = user,
                LoggingInformationId = (int)LogInfo,
                Description = "Получение данных страницы добавления роли ",
                DateCreate = DateTime.Now.ToString()
            };
        }

        public Logging Gettingthedataofthepageforaddingaroletoauser(string user, InformationLoggingEnum LogInfo)
        {
            return new Logging
            {
                UserId = user,
                LoggingInformationId = (int)LogInfo,
                Description = "Получение данных страницы добавления роли пользователю ",
                DateCreate = DateTime.Now.ToString()
            };
        }

        public Logging Gettingpagedatamydocuments(string user, InformationLoggingEnum LogInfo)
        {
            return new Logging
            {
                UserId = user,
                LoggingInformationId = (int)LogInfo,
                Description = "Получение данных страницы мои документы",
                DateCreate = DateTime.Now.ToString()
            };
        }

        public Logging RetrievingDocumentBasketPageData(string user, InformationLoggingEnum LogInfo)
        {
            return new Logging
            {
                UserId = user,
                LoggingInformationId = (int)LogInfo,
                Description = "Получение данных страницы корзины документов ",
                DateCreate = DateTime.Now.ToString()
            };
        }

        public Logging Gettingmailpagedata(string user, InformationLoggingEnum LogInfo)
        {
            return new Logging
            {
                UserId = user,
                LoggingInformationId = (int)LogInfo,
                Description = "Получение данных страницы почты ",
                DateCreate = DateTime.Now.ToString()
            };
        }

        public Logging Gettingpagedataforsendingamessage(string user, InformationLoggingEnum LogInfo)
        {
            return new Logging
            {
                UserId = user,
                LoggingInformationId = (int)LogInfo,
                Description = "Получение данных страницы отправки ",
                DateCreate = DateTime.Now.ToString()
            };
        }

        public Logging RetrievingDeletedMessagesPageData(string user, InformationLoggingEnum LogInfo)
        {
            return new Logging
            {
                UserId = user,
                LoggingInformationId = (int)LogInfo,
                Description = "Получение данных страницы удаленных сообщений",
                DateCreate = DateTime.Now.ToString()
            };
        }

        public Logging Gettingaccountactivitypagedata(string user, InformationLoggingEnum LogInfo)
        {
            return new Logging
            {
                UserId = user,
                LoggingInformationId = (int)LogInfo,
                Description = "Получение данных страницы активности аккаунта",
                DateCreate = DateTime.Now.ToString()
            };
        }

        public Logging Changingprofileinformation(string user, InformationLoggingEnum LogInfo)
        {
            return new Logging
            {
                UserId = user,
                LoggingInformationId = (int)LogInfo,
                Description = "Изменение данных профиля",
                DateCreate = DateTime.Now.ToString()
            };
        }

        public Logging Changinguserdata(string user, InformationLoggingEnum LogInfo)
        {
            return new Logging
            {
                UserId = user,
                LoggingInformationId = (int)LogInfo,
                Description = "Изменение данных пользователя",
                DateCreate = DateTime.Now.ToString()
            };
        }

        public Logging Changingpasswordinformation(string user, InformationLoggingEnum LogInfo)
        {
            return new Logging
            {
                UserId = user,
                LoggingInformationId = (int)LogInfo,
                Description = "Изменение данных пароля",
                DateCreate = DateTime.Now.ToString()
            };
        }

        public Logging Addingagroupbyauser(string user, InformationLoggingEnum LogInfo)
        {
            return new Logging
            {
                UserId = user,
                LoggingInformationId = (int)LogInfo,
                Description = "Добавление группы пользователем",
                DateCreate = DateTime.Now.ToString()
            };
        }

        public Logging Addingagrouptoauser(string user, InformationLoggingEnum LogInfo)
        {
            return new Logging
            {
                UserId = user,
                LoggingInformationId = (int)LogInfo,
                Description = "Добавление группы пользователю",
                DateCreate = DateTime.Now.ToString()
            };
        }

        public Logging Deletingausergroup(string user, InformationLoggingEnum LogInfo)
        {
            return new Logging
            {
                UserId = user,
                LoggingInformationId = (int)LogInfo,
                Description = "Удаление группы пользователя",
                DateCreate = DateTime.Now.ToString()
            };
        }

        public Logging AddingaRolebyaUser(string user, InformationLoggingEnum LogInfo)
        {
            return new Logging
            {
                UserId = user,
                LoggingInformationId = (int)LogInfo,
                Description = "Добавление роли пользователем",
                DateCreate = DateTime.Now.ToString()
            };
        }

        public Logging Removingarolebyauser(string user, InformationLoggingEnum LogInfo)
        {
            return new Logging
            {
                UserId = user,
                LoggingInformationId = (int)LogInfo,
                Description = "Удаление роли пользователем",
                DateCreate = DateTime.Now.ToString()
            };
        }

        public Logging Addingadocument(string user, InformationLoggingEnum LogInfo)
        {
            return new Logging
            {
                UserId = user,
                LoggingInformationId = (int)LogInfo,
                Description = "Добавление документа",
                DateCreate = DateTime.Now.ToString()
            };
        }

        public Logging Sendingamessage(string user, InformationLoggingEnum LogInfo)
        {
            return new Logging
            {
                UserId = user,
                LoggingInformationId = (int)LogInfo,
                Description = "Отправка сообщения",
                DateCreate = DateTime.Now.ToString()
            }; ;
        }

        public Logging GetDataListMessagesUsers(string user, InformationLoggingEnum LogInfo)
        {
            return new Logging
            {
                UserId = user,
                LoggingInformationId = (int)LogInfo,
                Description = "Получение данных формы просмотра сообщений",
                DateCreate = DateTime.Now.ToString()
            };
        }

        public Logging Gettingmessageviewformdata(string user, InformationLoggingEnum LogInfo)
        {
            return new Logging
            {
                UserId = user,
                LoggingInformationId = (int)LogInfo,
                Description = "Получение данных формы чтения сообщения",
                DateCreate = DateTime.Now.ToString()
            };
        }
    }
}
