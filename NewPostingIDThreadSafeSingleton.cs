using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMobileRefact
{
    public sealed class NewPostingIDThreadSafeSingleton: DataAccess
    {
        private static readonly object lockObject = new object();
        private static NewPostingIDThreadSafeSingleton instance = null;
        
        NewPostingIDThreadSafeSingleton()
        {
        }
        public static NewPostingIDThreadSafeSingleton GetInstance()
        {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new NewPostingIDThreadSafeSingleton();
                        }
                    }
                }
                return instance;
        }
        public long GetNewPostingID()
        {
            try
            {
                string query = "SELECT MAX(ID) FROM Posting";
                long result = this.ExecuteDatabaseCommand(query);
                return result++;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
