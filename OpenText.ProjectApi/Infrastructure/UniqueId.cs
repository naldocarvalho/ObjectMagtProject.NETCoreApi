using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenText.ProjectApi.Infrastructure
{
    public class UniqueId
    {
        private static readonly Lazy<UniqueId> LazyInstance = new Lazy<UniqueId>(() => new UniqueId());
        /// <summary>
        /// Get actual value
        /// </summary>
        public static UniqueId Instance
        {
            get
            {
                return LazyInstance.Value;
            }
        }

        private readonly object nextIdLock = new object();
        private int nextId;

        /// <summary>
        /// Safely generate the next integer
        /// </summary>
        /// <returns></returns>
        public int NextId()
        {
            lock (nextIdLock)
            {
                return ++nextId;
            }
        }

        /// <summary>
        /// Safely generate next user id
        /// </summary>
        /// <returns></returns>
        public static int Next()
        {
            return Instance.NextId();
        }
    }
}
