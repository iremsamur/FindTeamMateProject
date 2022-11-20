using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTeamMateProject.EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageStatus { get; set; }//mesaj okundu okunmadı bilgisi için olacak.
        public ICollection<SenderReceiverMessage> SenderReceiverPeopleForSenderMessage { get; set; }
        public ICollection<SenderReceiverMessage> SenderReceiverPeopleForReceiverMessage { get; set; }
        public ICollection<SenderReceiverMessage> SenderReceiverMessages { get; set; }

    }
}
