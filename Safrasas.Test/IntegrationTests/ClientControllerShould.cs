using Safrasas.Api.Controllers;
using Safrasas.Application.Interfaces;
using Safrasas.Core.Entities;
using Safrasas.Infrastructure.Repository;
using Safrasas.Test.Helper;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Safrasas.Test.IntegrationTests
{
    [TestClass]
    public class ClientControllerShould
    {
        #region ===[ Private Members ]=============================================================

        protected readonly IConfigurationRoot _configuration;
        private readonly ClientsController _controllerObj;
        private readonly ClientsController _moqControllerObj;
        private readonly Mock<IUnitOfWork> _moqRepo;

        #endregion

        #region ===[ Constructor ]=================================================================

        /// <summary>
        /// Constructor
        /// </summary>
        public ClientControllerShould()
        {
            _configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                      .AddJsonFile("appsettings.json")
                                                      .Build();

            var repository = new ClientRepository(_configuration);
            var unitofWork = new UnitOfWork(repository);

            _controllerObj = new ClientsController(unitofWork);

            _moqRepo = new Mock<IUnitOfWork>();
            _moqControllerObj = new ClientsController(_moqRepo.Object);
        }

        #endregion

        #region ===[ Test Methods ]================================================================

        [TestMethod]
        public async Task AddUpdateDeleteAndGetClient()
        {
            //Add Client
            await SaveClient();

            //Get All Client
            var Clients = await GetAll();

            //Update Client
            await UpdateClient(Clients);
            var ClientId = Clients.ClientId ?? 0;
           
            //Get Client By Id
            await GetById(ClientId);

            //Delete Client
            await DeleteClient(ClientId);
        }

        [TestMethod]
        public async Task GetAll_Throw_Exception()
        {
            //SQL Exception Test.
            _moqRepo.Setup(x => x.Clients.GetAllAsync()).Throws(TestConstants.GetSqlException());

            var result = await _moqControllerObj.GetAll();

            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Result);

            //General Exception Test.
            _moqRepo.Setup(x => x.Clients.GetAllAsync()).Throws(TestConstants.GetGeneralException());

            result = await _moqControllerObj.GetAll();

            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Result);
        }

        [TestMethod]
        public async Task GetById_Throw_Exception()
        {
            //SQL Exception Test.
            _moqRepo.Setup(x => x.Clients.GetByIdAsync(It.IsAny<long>())).Throws(TestConstants.GetSqlException());

            var result = await _moqControllerObj.GetById(1);

            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Result);

            //General Exception Test.
            _moqRepo.Setup(x => x.Clients.GetByIdAsync(It.IsAny<long>())).Throws(TestConstants.GetGeneralException());

            result = await _moqControllerObj.GetById(1);

            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Result);
        }

        [TestMethod]
        public async Task Add_Throw_Exception()
        {
            //SQL Exception Test.
            _moqRepo.Setup(x => x.Clients.AddAsync(It.IsAny<Clients>())).Throws(TestConstants.GetSqlException());

            var result = await _moqControllerObj.Add(new Clients());

            Assert.IsFalse(result.Success);

            //General Exception Test.
            _moqRepo.Setup(x => x.Clients.AddAsync(It.IsAny<Clients>())).Throws(TestConstants.GetGeneralException());

            result = await _moqControllerObj.Add(new Clients());

            Assert.IsFalse(result.Success);
        }

        [TestMethod]
        public async Task Update_Throw_Exception()
        {
            //SQL Exception Test.
            _moqRepo.Setup(x => x.Clients.UpdateAsync(It.IsAny<Clients>())).Throws(TestConstants.GetSqlException());

            var result = await _moqControllerObj.Update(new Clients());

            Assert.IsFalse(result.Success);

            //General Exception Test.
            _moqRepo.Setup(x => x.Clients.UpdateAsync(It.IsAny<Clients>())).Throws(TestConstants.GetGeneralException());

            result = await _moqControllerObj.Update(new Clients());

            Assert.IsFalse(result.Success);
        }

        [TestMethod]
        public async Task Delete_Throw_Exception()
        {
            //SQL Exception Test.
            _moqRepo.Setup(x => x.Clients.DeleteAsync(It.IsAny<long>())).Throws(TestConstants.GetSqlException());

            var result = await _moqControllerObj.Delete(1);

            Assert.IsFalse(result.Success);

            //General Exception Test.
            _moqRepo.Setup(x => x.Clients.DeleteAsync(It.IsAny<long>())).Throws(TestConstants.GetGeneralException());

            result = await _moqControllerObj.Delete(1);

            Assert.IsFalse(result.Success);
        }

        #endregion

        #region ===[ Private Methods ]=============================================================

        private async Task SaveClient()
        {
            var Clients = new Clients
            {
                FirstName = TestConstants.ClientTest.FirstName,
                LastName = TestConstants.ClientTest.LastName,
                Email = TestConstants.ClientTest.Email,
                Document = TestConstants.ClientTest.Document,
            };

            var result = await _controllerObj.Add(Clients);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
        }

        private async Task UpdateClient(Clients Client)
        {
            //Update Document Path.
            Client.Document = TestConstants.ClientTest.NewDocument;
            var result = await _controllerObj.Update(Client);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
        }

        private async Task<Clients> GetAll()
        {
            var result = await _controllerObj.GetAll();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Result.Count > 0);

            var Clients = result.Result
                            .Where(x => x.FirstName == TestConstants.ClientTest.FirstName
                                    && x.LastName == TestConstants.ClientTest.LastName
                                    && x.Email == TestConstants.ClientTest.Email
                                    && x.Document == TestConstants.ClientTest.Document).First();

            return Clients;
        }

        private async Task GetById(int ClientId)
        {
            var result = await _controllerObj.GetById(ClientId);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Result);
        }

        private async Task DeleteClient(int ClientId)
        {
            var result = await _controllerObj.Delete(ClientId);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
        }

        #endregion
    }
}
