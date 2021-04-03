using Examiner.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.DAL.Entities
{
    public class AnswerArchive : AbstractEntity
    {
        public Guid ArchiveId { get; set; }
        public Guid AnswerId { get; set; }
        public Archive Archive { get; set; }
        public Answer Answer { get; set; }

    }
}
