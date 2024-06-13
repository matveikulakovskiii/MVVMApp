using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MVVMApp.Models
{
    public class FriendRepository
    {
        private readonly SQLiteConnection _database;
        private static object locker = new object();

        public FriendRepository(string databasePath)
        {
            _database = new SQLiteConnection(databasePath);
            _database.CreateTable<Friend>();
        }

        public IEnumerable<Friend> GetItems()
        {
            lock (locker)
            {
                return _database.Table<Friend>().ToList();
            }
        }

        public Friend GetItem(int id)
        {
            lock (locker)
            {
                return _database.Get<Friend>(id);
            }
        }

        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return _database.Delete<Friend>(id);
            }
        }

        public int SaveItem(Friend item)
        {
            lock (locker)
            {
                if (item.Id != 0)
                {
                    _database.Update(item);
                    return item.Id;
                }
                else
                {
                    return _database.Insert(item);
                }
            }
        }
    }
}
