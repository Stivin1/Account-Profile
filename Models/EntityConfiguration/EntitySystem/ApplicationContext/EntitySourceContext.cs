using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.EntityConfiguration.EntityTypeConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.ApplicationContext
{
    public class EntitySourceContext : IdentityDbContext<User>
    {
        public DbSet<Participant> Participants { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Pol> Pols { get; set; }

        public DbSet<Theme> Themes { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<AddresSent> addresSents { get; set; }

        public DbSet<Groups> Groups { get; set; }

        public DbSet<Domains> Domains { get; set; }

        public DbSet<GroupsIntermediate> GroupsIntermediates { get; set; }

        public DbSet<DocumentType> DocumentTypes { get; set; }

        public DbSet<Document> Documents { get; set; }

        public DbSet<MessageSettings> MessageSettings { get; set; }

        public DbSet<Logging> Loggings { get; set; }

        public DbSet<LoggingInformation> LoggingInformations { get; set; }

        public EntitySourceContext(DbContextOptions<EntitySourceContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfigurationOption());
            modelBuilder.ApplyConfiguration(new DomainConfigurationOption());
            modelBuilder.ApplyConfiguration(new CountryConfigurationOption());
            modelBuilder.ApplyConfiguration(new GroupsConfigurationOption());
            modelBuilder.ApplyConfiguration(new PolConfigurationOption());
            modelBuilder.ApplyConfiguration(new ParticipantConfigurationOption());
            modelBuilder.ApplyConfiguration(new ThemeConfigurationOption());
            modelBuilder.ApplyConfiguration(new MessageConfigurationOption());
            modelBuilder.ApplyConfiguration(new AddresSentConfigurationOption());
            modelBuilder.ApplyConfiguration(new DocumentTypeConfigurationOption());
            modelBuilder.ApplyConfiguration(new DocumentConfigurationOption());
            modelBuilder.ApplyConfiguration(new MessageSettingsConfigurationOption());
            modelBuilder.ApplyConfiguration(new LoggingConfigurationOption());
            modelBuilder.ApplyConfiguration(new LoggingInfoConfigurationOption());

            modelBuilder.Entity<LoggingInformation>().HasData(new LoggingInformation[]
            {
                new LoggingInformation { id = 1, Name = "Попытка входа пользователя"},
                new LoggingInformation { id = 2, Name = "Выход пользователя"},
                new LoggingInformation { id = 3, Name = "Получение данных страницы профиля"},
                new LoggingInformation { id = 4, Name = "Получение данных страницы пользователей"},
                new LoggingInformation { id = 5, Name = "Получение данных страницы изменения профиля"},
                new LoggingInformation { id = 6, Name = "Получение данных страницы изменения пользователя"},
                new LoggingInformation { id = 7, Name = "Получение данных страницы изменить пароль"},
                new LoggingInformation { id = 8, Name = "Получение данных страницы списка групп"},
                new LoggingInformation { id = 9, Name = "Получение данных страницы добавления группы"},
                new LoggingInformation { id = 10, Name = "Получение данных страницы добавления группы пользователю"},
                new LoggingInformation { id = 11, Name = "Получение данных страницы добавления роли"},
                new LoggingInformation { id = 12, Name = "Получение данных страницы добавления роли пользователю"},
                new LoggingInformation { id = 13, Name = "Получение данных страницы мои документы"},
                new LoggingInformation { id = 14, Name = "Получение данных страницы корзины документов"},
                new LoggingInformation { id = 15, Name = "Получение данных страницы почты"},
                new LoggingInformation { id = 16, Name = "Получение данных страницы отправки"},
                new LoggingInformation { id = 17, Name = "Получение данных страницы удаленных сообщений"},
                new LoggingInformation { id = 18, Name = "Получение данных страницы активности аккаунта"},
                new LoggingInformation { id = 19, Name = "Изменение данных профиля"},
                new LoggingInformation { id = 20, Name = "Изменение данных пользователя"},
                new LoggingInformation { id = 21, Name = "Изменение данных пароля"},
                new LoggingInformation { id = 22, Name = "Добавление группы пользователем"},
                new LoggingInformation { id = 23, Name = "Добавление группы пользователю"},
                new LoggingInformation { id = 24, Name = "Удаление группы пользователя"},
                new LoggingInformation { id = 25, Name = "Добавление роли пользователем"},
                new LoggingInformation { id = 26, Name = "Добавление роли пользователю"},
                new LoggingInformation { id = 27, Name = "Удаление роли пользователем"},
                new LoggingInformation { id = 28, Name = "Добавление документа"},
                new LoggingInformation { id = 29, Name = "Отправка сообщения"},
                new LoggingInformation { id = 30, Name = "Получение данных формы просмотра сообщений"},
                new LoggingInformation { id = 31, Name = "Получение данных формы чтения сообщения"}
            });
        }
    }
}
