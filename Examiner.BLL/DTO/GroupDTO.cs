using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.BLL.DTO
{
    public class GroupDTO
    {
        public Guid Id;
        public string Title { get; set; }
        public Guid TeacherId { get; set; }
        public Guid StudentId { get; set; }
    }
}
