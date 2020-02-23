using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Issue_Tracker_MVC.Models;

namespace Issue_Tracker_MVC.Models
{
    public class Issue_Tracker_MVCDataContext : DbContext
    {
        public Issue_Tracker_MVCDataContext (DbContextOptions<Issue_Tracker_MVCDataContext> options)
            : base(options)
        {
        }

        public DbSet<Issue_Tracker_MVC.Models.Assignee> Assignee { get; set; }

        public DbSet<Issue_Tracker_MVC.Models.Issue> Issue { get; set; }

        public DbSet<Issue_Tracker_MVC.Models.IssueReporter> IssueReporter { get; set; }
    }
}
