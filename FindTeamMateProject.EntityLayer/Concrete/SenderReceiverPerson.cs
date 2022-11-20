using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTeamMateProject.EntityLayer.Concrete
{
    public class SenderReceiverPerson
    {
        //birbirini takip eden iki kişi için
        // SenderAppUser ve ReceiverAppUser çoka çok ilişkisini tutan ara tablo 
        //arkadaş listesini tutar.
        [Key]
        public int SenderReceiverPersonID { get; set; }
        [ForeignKey("Sender")]
        public int? SenderID { get; set; }
        [ForeignKey("Receiver")]
        public int? ReceiverID { get; set; }
        public AppUser Sender { get; set; }
        public AppUser Receiver { get; set; }

        [ForeignKey("SenderReceiverMessage")]
        public int? SenderReceiverMessageID { get; set; }
        public SenderReceiverMessage SenderReceiverMessage { get; set; }




    }
}
