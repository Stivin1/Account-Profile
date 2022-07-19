using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers
{
    public class MessageRead : IHelpersCountMessage
    {
        public int MessageReadId { get; set; }

        public string UserId { get; set; }

        public string SenderName { get; set; }

        public string RecipientId { get; set; }

        public string RecipientName { get; set; }

        public string Theme { get; set; }

        public string Text { get; set; }

        public int HelpersDisplayCountMessage { get; set; }

        public int HelpersDeletedCountMessage { get; set; }
    }
}
