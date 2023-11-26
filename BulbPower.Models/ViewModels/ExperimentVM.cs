using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbPower.Models.ViewModels
{
    public class ExperimentVM
    {
        public Experiment Experiment {  get; set; }
        public IEnumerable<ExperimentBulbState> ExperimentBulbStateList { get; set; }

    }
}
