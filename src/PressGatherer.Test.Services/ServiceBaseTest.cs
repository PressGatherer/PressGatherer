using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using PressGatherer.Services;
using PressGatherer.Services.ServiceEntities;


namespace PressGatherer.Test.Services
{
    [TestClass]
    public class ServiceBaseTest
    {
        [TestInitialize]
        public async Task SetAllServiceToNoOnload()
        {
            try
            {
                BaseService service = new IndexService();
                await service.OnLoadSetToFalse();
                service = new KurucInfoService();
                await service.OnLoadSetToFalse();
                service = new NsoService();
                await service.OnLoadSetToFalse();
                service = new BlikkService();
                await service.OnLoadSetToFalse();
                service = new HvgService();
                await service.OnLoadSetToFalse();
                service = new Hu24Service();
                await service.OnLoadSetToFalse();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task LoadNews_Success_Index()
        {
            try
            {
                IndexService service = new IndexService();
                await service.LoadNews();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task LoadNews_Success_KurucInfo()
        {
            try
            {
                KurucInfoService service = new KurucInfoService();
                await service.LoadNews();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task LoadNews_Success_NSO()
        {
            try
            {
                NsoService service = new NsoService();
                await service.LoadNews();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task LoadNews_Success_Blikk()
        {
            try
            {
                BlikkService service = new BlikkService();
                await service.LoadNews();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task LoadNews_Success_Hvg()
        {
            try
            {
                HvgService service = new HvgService();
                await service.LoadNews();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task LoadNews_Success_Hu24()
        {
            try
            {
                Hu24Service service = new Hu24Service();
                await service.LoadNews();
            }
            catch
            {
                Assert.Fail();
            }
        }
    }
}
