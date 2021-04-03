using Examiner.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.DAL.Entities
{
    public class GroupStudent : AbstractEntity
    {
        public Guid GroupId { get; set; }
        public Guid StudentId { get; set; }
        public Group Group { get; set; }
        public Student Student { get; set; }

    }
}
