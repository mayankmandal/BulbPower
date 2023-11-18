using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BulbPower.Utility.Constants;

namespace BulbPower.Models
{
    public class Experiment
    {
        [Key]
        public int ExperimentId { get; set; }
        [Required]
        public int NumberOfPeople { get; set; }
        [Required]
        public int NumberOfBulbs { get; set; }
        public string ExperimentName { get; set; }
        public ExperimentStatus ExperimentStatus { get; set; }
        public int LastExitedPersonNumber { get; set; }
        public DateTime LastExitedDateTime { get; set; }
        public DateTime CreatedDateTime { get; set; }
        // Add [NotMapped] attribute to exclude from database
        [NotMapped]
        public ICollection<ExperimentBulbState> ExperimentBulbStates { get; private set; }
        // Constructor to initialize ExperimentBulbStates
        public Experiment()
        {
            ExperimentBulbStates = new List<ExperimentBulbState>();
        }
    }
}
