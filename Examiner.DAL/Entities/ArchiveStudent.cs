using Examiner.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.DAL.Entities
{
    public class ArchiveStudent : AbstractEntity
    {
        public Guid ArchiveId { get; set; }
        public Guid StudentId { get; set; }
        public Archive Archive { get; set; }
        public Student Student { get; set; }

    }
}
