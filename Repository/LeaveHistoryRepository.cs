using leave_man.Contracts;
using leave_man.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_man.Repository
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveHistoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(LeaveHistory entity)
        {
            _db.LeaveHistories.Add(entity);
            return Save();
        }

        public bool Delete(LeaveHistory entity)
        {
            _db.LeaveHistories.Remove(entity);
            return Save();
        }

        public bool Exists(int id)
        {
            return _db.LeaveHistories.Any(q => q.Id == id);
        }

        public ICollection<LeaveHistory> FindAll()
        {
            var leaveHistories = _db.LeaveHistories.ToList();
            return leaveHistories;
        }

        public LeaveHistory FindById(int id)
        {
            var leaveHistory = _db.LeaveHistories.FirstOrDefault((obj) => obj.Id == id);
            return leaveHistory;
        }
        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(LeaveHistory entity)
        {
            _db.Update(entity);
            return Save();
        }
    }
}
