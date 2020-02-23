using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Issue_Tracker_MVC.Models
{
    public class Issue
    {
        public int Id { get; set; }

        public int AssigneeId { get; set; }

        public int IssueReporterId { get; set; }

        public Assignee Assignee { get; set; }

        public IssueReporter IssueReporter { get; set; }

        public DateTime ReportedDate { get; set; }

        public string Content { get; set; }
        [NotMapped]
        public string IssueId
        {
            get {
                return "ISSUE00" + Id;
            }
        }




    }
}
