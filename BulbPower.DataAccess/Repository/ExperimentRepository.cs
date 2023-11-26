using BulbPower.DataAccess.Data;
using BulbPower.DataAccess.Repository.IRepository;
using BulbPower.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BulbPower.Utility.Constants;

namespace BulbPower.DataAccess.Repository
{
    public class ExperimentRepository : IExperimentRepository
    {
        private ApplicationDbContext _db;
        public ExperimentRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Experiment> GetExperiments()
        {
            return _db.Experiments.ToList();
        }

        public Experiment GetExperiment(int experimentId)
        {
            return _db.Experiments.Find(experimentId);
        }

        public IEnumerable<ExperimentBulbState> GetExperimentBulbStates(int experimentId)
        {
            return _db.ExperimentBulbStates
                .Where(e => e.ExperimentId == experimentId)
                .ToList();
        }
        public void CreateExperimentBulbState(ExperimentBulbState bulbState)
        {
            _db.ExperimentBulbStates.Add(bulbState);
            _db.SaveChanges();
        }

        public Experiment CreateExperiment(int numberOfPeople, int numberOfBulbs)
        {
            var experiment = new Experiment
            {
                NumberOfPeople = numberOfPeople,
                NumberOfBulbs = numberOfBulbs,
                ExperimentName = $"{numberOfPeople}-people-{numberOfBulbs}-bulbs",
                ExperimentStatus = ExperimentStatus.NotStarted,
                CreatedDateTime = DateTime.Now
            };

            _db.Experiments.Add(experiment);
            _db.SaveChanges();

            // Initialize ExperimentBulbStates
            for (int bulbNumber = 1; bulbNumber <= numberOfBulbs; bulbNumber++)
            {
                var bulbState = new ExperimentBulbState
                {
                    ExperimentId = experiment.ExperimentId,
                    BulbNumber = bulbNumber,
                    BulbState = false,  // You can set the initial state as needed
                    ToggledOnDateTime = DateTime.Now
                };

                _db.ExperimentBulbStates.Add(bulbState);
            }

            _db.SaveChanges();

            return experiment;
        }

        public void UpdateExperimentBulbState(int experimentBulbStateId, bool bulbState)
        {
            var bulbStateToUpdate = _db.ExperimentBulbStates.Find(experimentBulbStateId);
            bulbStateToUpdate.BulbState = bulbState;
            bulbStateToUpdate.ToggledOnDateTime = DateTime.Now;

            _db.SaveChanges();
        }

        public void UpdateExperimentStatus(int experimentId, ExperimentStatus status)
        {
            var experimentToUpdate = _db.Experiments.Find(experimentId);
            experimentToUpdate.ExperimentStatus = status;

            _db.SaveChanges();
        }

        public void ResetBulbStates(int experimentId)
        {
            var bulbStates = _db.ExperimentBulbStates
                .Where(e => e.ExperimentId == experimentId)
                .ToList();

            foreach (var bulbState in bulbStates)
            {
                bulbState.BulbState = false; // Reset bulb state to OFF
            }

            _db.SaveChanges();
        }

        public void UpdateLastExitedPerson(int experimentId, int lastExitedPersonNumber)
        {
            var experiment = _db.Experiments.Find(experimentId);

            if (experiment != null)
            {
                experiment.LastExitedPersonNumber = lastExitedPersonNumber;
                _db.SaveChanges();
            }
        }
    }
}
