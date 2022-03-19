using ClaySmartLock.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.DataAccess.Context
{
    public class ClaySmartLockDBContext : DbContext
    {
        public ClaySmartLockDBContext(DbContextOptions<ClaySmartLockDBContext> options) : base(options) { }
        public DbSet<Door> Doors { get; set; }
        public DbSet<DoorHistory> DoorHistories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserTag> UserTags { get; set; }
        public DbSet<DoorRight> DoorRights { get; set; }
    }
}
