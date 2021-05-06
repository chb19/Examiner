using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examiner.DAL.Entities;

namespace Examiner.BLL.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Group>> GetAllStudentGroups(Guid studentId);
    }
}
