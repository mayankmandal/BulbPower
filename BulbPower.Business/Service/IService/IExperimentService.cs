using BulbPower.Models;
using BulbPower.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbPower.Business.Service.IService
{
    public interface IExperimentService
    {
        IEnumerable<Experiment> ShowAllExperiments();
        IEnumerable<ExperimentBulbState> ShowAllExperimentBulbStates(int experimentId);
        Experiment CreateExperiment(int numberOfPeople, int numberOfBulbs);
        void SendNextPerson(int experimentId);
        void ResetExperiment(int experimentId);
        Experiment GetExperiment(int experimentId);
        ExperimentVM GetExperimentVM(int id);
        IEnumerable<ExperimentVM> ShowAllExperimentVMs();
    }
}
