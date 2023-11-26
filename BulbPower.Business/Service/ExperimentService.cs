using BulbPower.Business.Service.IService;
using BulbPower.DataAccess.Repository;
using BulbPower.DataAccess.Repository.IRepository;
using BulbPower.Models;
using BulbPower.Models.ViewModels;
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

        public ExperimentVM GetExperimentVM(int experimentId)
        {
            var experiment = _db.GetExperiment(experimentId);

            if (experiment == null)
            {
                return null;
            }

            var experimentBulbStateList = _db.GetExperimentBulbStates(experiment.ExperimentId);

            var experimentVm = new ExperimentVM
            {
                Experiment = experiment,
                ExperimentBulbStateList = experimentBulbStateList
            };

            return experimentVm;
        }

        public IEnumerable<Experiment> ShowAllExperiments()
        {
            return _db.GetExperiments();
        }

        public IEnumerable<ExperimentVM> ShowAllExperimentVMs()
        {
            var experiments = _db.GetExperiments();
            var experimentVMs = new List<ExperimentVM>();

            foreach (var experiment in experiments)
            {
                var experimentBulbStateList = _db.GetExperimentBulbStates(experiment.ExperimentId);

                var experimentVm = new ExperimentVM
                {
                    Experiment = experiment,
                    ExperimentBulbStateList = experimentBulbStateList
                };

                experimentVMs.Add(experimentVm);
            }

            return experimentVMs;
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

            if (experiment.LastExitedPersonNumber < experiment.NumberOfPeople)
            { 
                experiment.LastExitedPersonNumber++;
                for (int bulbNumber = 1; bulbNumber <= experiment.NumberOfBulbs; bulbNumber += experiment.LastExitedPersonNumber)
                {
                    var bulbState = !bulbStates[bulbNumber - 1].BulbState; // Toggle the bulb state
                    _db.UpdateExperimentBulbState(bulbStates[bulbNumber - 1].ExperimentBulbStateId, bulbState);
                }

                if (experiment.LastExitedPersonNumber.Equals(experiment.NumberOfPeople))
                {
                    _db.UpdateExperimentStatus(experimentId, ExperimentStatus.Completed);
                }
                else 
                {
                    _db.UpdateExperimentStatus(experimentId, ExperimentStatus.InProgress);
                }
                _db.UpdateLastExitedPerson(experimentId, experiment.LastExitedPersonNumber);
            }
            return;
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
        public void DeleteExperiment(int experimentId)
        {
            _db.RemoveExperiment(experimentId);
        }
    }
}
