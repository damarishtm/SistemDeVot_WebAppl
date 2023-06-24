using System;

namespace SistemDeVot_WebAppl.Models
{
    public class Perioada
    {
        public Perioada()
        {
            // Default constructor
        }

        public Perioada(Guid id, DateTime startDate, DateTime endDate, bool active)
        {
            this.PeriodID = id;
            this.PeriodStartDate = startDate;
            this.PeriodEndDate = endDate;
            this.IsActive = active;
        }

        public Guid PeriodID { get; }
        public DateTime PeriodStartDate { get; }
        public DateTime PeriodEndDate { get; }
        public bool IsActive { get; set; }
    }
}
