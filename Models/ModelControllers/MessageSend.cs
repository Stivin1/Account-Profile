using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers
{
    public class MessageSend : IHelpersCountMessage
    {
        public int MessageSendId { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string UserRecipientId { get; set; }

        public string UserRecipientName { get; set; }

        public string Theme { get; set; }

        public string Text { get; set; }

        public int HelpersDisplayCountMessage { get; set; }

        public int HelpersDeletedCountMessage { get; set; }
    }
}
