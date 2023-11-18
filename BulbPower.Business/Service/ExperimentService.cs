using BulbPower.Business.Service.IService;
using BulbPower.DataAccess.Repository.IRepository;
using BulbPower.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BulbPower.Utility.Constants;

namespace BulbPower.Business.Service
{
    public class ExperimentService : IExperimentService
    {
        private readonly IExperimentRepository _db;

        public ExperimentService(IExperimentRepository db)
        {
            _db = db;
        }
        public Experiment GetExperiment(int experimentId)
        {
            return _db.GetExperiment(experimentId);
        }
        public IEnumerable<Experiment> ShowAllExperiments()
        {
            return _db.GetExperiments();
        }

        public IEnumerable<ExperimentBulbState> ShowAllExperimentBulbStates(int experimentId)
        {
            return _db.GetExperimentBulbStates(experimentId);
        }

        public Experiment CreateExperiment(int numberOfPeople, int numberOfBulbs)
        {
            return _db.CreateExperiment(numberOfPeople, numberOfBulbs);
        }

        public void SendNextPerson(int experimentId)
        {
            var experiment = _db.GetExperiment(experimentId);

            if (experiment == null || experiment.ExperimentStatus == ExperimentStatus.Completed)
            {
                // Experiment not found or already completed
                return;
            }

            var bulbStates = _db.GetExperimentBulbStates(experimentId).ToList();

            for (int i = 1; i <= experiment.NumberOfPeople; i++)
            {
                for (int bulbNumber = i - 1; bulbNumber < experiment.NumberOfBulbs; bulbNumber += i)
                {
                    var bulbState = !bulbStates[bulbNumber].BulbState; // Toggle the bulb state
                    _db.UpdateExperimentBulbState(bulbStates[bulbNumber].ExperimentBulbStateId, bulbState);
                }
            }

            _db.UpdateExperimentStatus(experimentId, ExperimentStatus.InProgress);
            _db.UpdateLastExitedPerson(experimentId, experiment.LastExitedPersonNumber + 1);
        }

        public void ResetExperiment(int experimentId)
        {
            var experiment = _db.GetExperiment(experimentId);

            if (experiment == null)
            {
                // Experiment not found
                return;
            }

            _db.ResetBulbStates(experimentId);
            _db.UpdateExperimentStatus(experimentId, ExperimentStatus.NotStarted);
            _db.UpdateLastExitedPerson(experimentId, 0);
        }
    }
}
