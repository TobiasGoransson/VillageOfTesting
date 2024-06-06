using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageOfTesting;
using VillageOfTesting.Objects;
using Xunit.Sdk;

namespace VillageOfTestingTest
{
  public class VillageTest
    {
    
        [Fact]
        public void AddWorkerSuccess()
        {
            var village = new Village();


            village.AddWorker("John", "farmer");

            Assert.Equal(1, village.Workers.Count);

        }

        [Theory]
        [InlineData("John", "farmer")]
        [InlineData("Jane", "builder")]
        
        public void AddWorkerSuccess1(string name, string occupation)
        {
            var village = new Village();

            village.AddWorker(name, occupation);

            Assert.Equal(1, village.Workers.Count);
        }

        [Fact]
        public void AddWorkerCheckName()
        {
            var village = new Village();

            village.AddWorker("John", "farmer");
            

            Assert.Equal("John", village.Workers[0].Name);
        }

        [Fact]
        public void AddWorkerCheckOccupation()
        {
            var village = new Village();

            village.AddWorker("John", "farmer");

            Assert.Equal("farmer", village.Workers[0].Occupation);
        }

        [Fact]
        public void FeedWorkersTest()
        {
            var village = new Village();
            village.AddWorker("John", "farmer");
            village.AddWorker("Jane", "builder");
            village.Food = 10;

            village.FeedWorkers();

            Assert.Equal(8, village.Food);
        }

        [Fact]
        public void FeedWorkersNotEnoughFoodTest()
        {
            var village = new Village();
            village.AddWorker("John", "farmer");
            village.AddWorker("Jane", "builder");
            village.Food = 1;

            village.FeedWorkers();

            Assert.Equal(0, village.Food);
        }

        [Fact]
        public void DayTest()
        {
            var village = new Village();
            village.AddWorker("John", "farmer");
            village.AddWorker("Jane", "lumberjack");
            village.Food = 10;
            village.Wood = 10;

            village.Day();

            Assert.Equal(13, village.Food);
            Assert.Equal(11, village.Wood);

        }

        [Fact]
        public void DayWorkerDiesTest()
        {
            var village = new Village();
            village.AddWorker("John", "framer");
            village.AddWorker("Jane", "lumberjack");
            village.AddWorker("Bob", "miner");

            village.Food = 10;


           
            foreach (var worker in village.Workers)
            {
                if (worker.Name == "John")
                {
                    worker.Alive = false;
                    
                }
            }   

            village.Day();

            Assert.Equal(8, village.Food);


        }
        [Fact]
        public void DayAllWorkersDieTest()
        {
            var village = new Village();
            village.AddWorker("John", "farmer");
            village.AddWorker("Jane", "lumberjack");
            village.AddWorker("Bob", "miner");

            village.Food = 10;

            foreach (var worker in village.Workers)
            {
                worker.Alive = false;
            }
            village.Day();

            Assert.True(village.GameOver);
        }
        [Fact]
        public void AddProjectHouseTest()
        {
            var village = new Village();
            village.AddWorker("John", "builder");
            
            string name = "House";

            village.Wood = 10;
            village.Metal= 10;
            village.Food = 10;


            village.AddProject(name);

            Assert.Equal(1, village.Projects.Count);
            Assert.Equal(5, village.Wood);
            Assert.Equal(10, village.Metal);

        }
        [Fact]
        public void AddProjectWoodMillTest()
        {
            var village = new Village();
            village.AddWorker("John", "builder");

            string name = "Woodmill";

            village.Wood = 10;
            village.Metal = 10;
            village.Food = 10;


            village.AddProject(name);

            Assert.Equal(1, village.Projects.Count);
            Assert.Equal(5, village.Wood);
            Assert.Equal(9, village.Metal);

        }
        [Fact]
        public void AddProjectQuarryTest()
        {
            var village = new Village();
            village.AddWorker("John", "builder");

            string name = "Quarry";

            village.Wood = 10;
            village.Metal = 10;
            village.Food = 10;


            village.AddProject(name);

            Assert.Equal(1, village.Projects.Count);
            Assert.Equal(7, village.Wood);
            Assert.Equal(5, village.Metal);

        }
        [Fact]
        public void AddProjectNotEnoughWoodTest()
        {
            var village = new Village();
            village.AddWorker("John", "builder");

            string name = "House";

            village.Wood = 4;
            village.Metal = 10;
            village.Food = 10;

            village.AddProject(name);

            Assert.Equal(0, village.Projects.Count);
        }
       
       
    }
}
