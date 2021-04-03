using Examiner.DAL.Abstractions;
using Examiner.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.DAL.Entities
{
    public class GroupTest : AbstractEntity
    {
        public Guid GroupId { get; set; }
        public Guid TestId { get; set; }
        public Group Group { get; set; }
        public Test Test { get; set; }
    }
}
