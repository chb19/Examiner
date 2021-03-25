using Examiner.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examiner.DAL.Models
{
    public class TestResult : AbstractEntity
    {
        public int Grade { get; set; }

    }
}
