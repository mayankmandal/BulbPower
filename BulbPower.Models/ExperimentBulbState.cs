using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbPower.Models
{
    public class ExperimentBulbState
    {
        [Key]
        public int ExperimentBulbStateId { get; set; }
        public int ExperimentId { get; set; }
        [ForeignKey("ExperimentId")]
        public Experiment Experiments { get; set; }
        public int BulbNumber { get; set; }
        public bool BulbState { get; set; }
        public DateTime ToggledOnDateTime { get; set; }
    }
}
