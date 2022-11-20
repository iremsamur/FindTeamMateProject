using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTeamMateProject.EntityLayer.Concrete
{
    public class SenderReceiverMessage
    {
        [Key]
        public int SenderReceiverMessageID{ get; set; }
        [ForeignKey("SenderMessage")]
        public int? SenderMessageID { get; set; }
        [ForeignKey("ReceiverMessage")]
        public int? ReceiverMessageID { get; set; }
        public Message SenderMessage { get; set; }
        public Message ReceiverMessage { get; set; }
    }
}
