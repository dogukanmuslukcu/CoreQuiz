using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Exam:IEntity
    {
        public int Id { get; set; }
        public string ExamName { get; set; }
        public List<Question> Questions { get; set; }
        public int MinimumScore { get; set; }
        public int TotalVotes { get; set; } = 0;
        public int VoteAmount { get; set; } = 0;

    }
}
