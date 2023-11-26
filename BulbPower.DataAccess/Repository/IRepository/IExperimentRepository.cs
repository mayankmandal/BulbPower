using BulbPower.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BulbPower.Utility.Constants;

namespace BulbPower.DataAccess.Repository.IRepository
{
    public interface IExperimentRepository 
    {
        IEnumerable<Experiment> GetExperiments();
        Experiment GetExperiment(int experimentId);
        IEnumerable<ExperimentBulbState> GetExperimentBulbStates(int experimentId);
        Experiment CreateExperiment(int numberOfPeople, int numberOfBulbs);
        void UpdateExperimentBulbState(int experimentBulbStateId, bool bulbState);
        void UpdateExperimentStatus(int experimentId, ExperimentStatus status);
        void ResetBulbStates(int experimentId);
        void UpdateLastExitedPerson(int experimentId, int lastExitedPersonNumber);
        void CreateExperimentBulbState(ExperimentBulbState bulbState);
        void RemoveExperiment(int experimentId);
    }
}
