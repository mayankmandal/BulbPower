using BulbPower.Business.Service;
using BulbPower.Business.Service.IService;
using BulbPower.DataAccess.Data;
using BulbPower.DataAccess.Repository;
using BulbPower.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using static BulbPower.Utility.Constants;

namespace BulbPower.Tests
{
    public class BulbManagerTests
    {

        private readonly ApplicationDbContext _testContext;
        private readonly IExperimentRepository _repository;
        private readonly IExperimentService _service;

        public BulbManagerTests(ApplicationDbContext testContext)
        {
            _testContext = testContext;
            _repository = new ExperimentRepository(_testContext);
            _service = new ExperimentService(_repository);
        }

        [Fact]
        public void CreateExperiment_ShouldCreateNewExperiment()
        {
            // Arrange
            int numberOfPeople = 10;
            int numberOfBulbs = 20;

            // Act
            var createdExperiment = _service.CreateExperiment(numberOfPeople, numberOfBulbs);

            // Assert
            Assert.NotNull(createdExperiment);
            Assert.Equal(numberOfPeople, createdExperiment.NumberOfPeople);
            Assert.Equal(numberOfBulbs, createdExperiment.NumberOfBulbs);
            Assert.Equal(ExperimentStatus.NotStarted, createdExperiment.ExperimentStatus);
            
        }

        [Fact]
        public void SendNextPerson_ShouldUpdateExperimentState()
        {
            // Arrange
            var experiment = _service.CreateExperiment(10, 20);

            // Act
            _service.SendNextPerson(experiment.ExperimentId);

            // Assert
            var updatedExperiment = _repository.GetExperiment(experiment.ExperimentId);
            Assert.Equal(ExperimentStatus.InProgress, updatedExperiment.ExperimentStatus);
            
        }

        [Fact]
        public void ResetExperiment_ShouldResetExperimentState()
        {
            // Arrange
            var experiment = _service.CreateExperiment(10, 20);

            // Act
            _service.SendNextPerson(experiment.ExperimentId);  
            _service.ResetExperiment(experiment.ExperimentId);

            // Assert
            var resetExperiment = _repository.GetExperiment(experiment.ExperimentId);
            Assert.Equal(ExperimentStatus.NotStarted, resetExperiment.ExperimentStatus);
            
        }
    }
}