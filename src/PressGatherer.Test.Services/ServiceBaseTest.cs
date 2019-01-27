using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using PressGatherer.Services;
using PressGatherer.Services.ServiceEntities;


namespace PressGatherer.Test.Services
{
    [TestClass]
    public class ServiceBaseTest
    {
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
    }
}
