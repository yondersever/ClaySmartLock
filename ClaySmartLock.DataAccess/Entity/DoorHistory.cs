using ClaySmartLock.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.DataAccess.Entity
{
    public class DoorHistory : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public long DoorID { get; set; }
        public long UserID { get; set; }
        public DateTime ActionDate { get; set; }
        public int ActionType { get; set; }
        public int Source { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }

        [ForeignKey("DoorID")]
        public Door Door { get; set; }
    }
}
