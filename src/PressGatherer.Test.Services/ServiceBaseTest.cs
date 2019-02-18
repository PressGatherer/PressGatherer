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
                service = new Hu444Service();
                await service.OnLoadSetToFalse();
                service = new AlfahirService();
                await service.OnLoadSetToFalse();
                service = new Hu168OraService();
                await service.OnLoadSetToFalse();
                service = new AzonnaliService();
                await service.OnLoadSetToFalse();
                service = new MerceService();
                await service.OnLoadSetToFalse();
                service = new MnoService();
                await service.OnLoadSetToFalse();
                service = new TenyekService();
                await service.OnLoadSetToFalse();
                service = new HiradoHuService();
                await service.OnLoadSetToFalse();
                service = new PestiSracokService();
                await service.OnLoadSetToFalse();
                service = new HircsardaService();
                await service.OnLoadSetToFalse();
                service = new Hu888Service();
                await service.OnLoadSetToFalse();
                service = new AutoMotorService();
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

        [TestMethod]
        public async Task LoadNews_Success_Hu444()
        {
            try
            {
                Hu444Service service = new Hu444Service();
                await service.LoadNews();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task LoadNews_Success_Alfahir()
        {
            try
            {
                AlfahirService service = new AlfahirService();
                await service.LoadNews();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task LoadNews_Success_168Ora()
        {
            try
            {
                Hu168OraService service = new Hu168OraService();
                await service.LoadNews();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task LoadNews_Success_Azonnali()
        {
            try
            {
                AzonnaliService service = new AzonnaliService();
                await service.LoadNews();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task LoadNews_Success_Mno()
        {
            try
            {
                MnoService service = new MnoService();
                await service.LoadNews();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task LoadNews_Success_HiradoHu()
        {
            try
            {
                HiradoHuService service = new HiradoHuService();
                await service.LoadNews();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task LoadNews_Success_Tenyek()
        {
            try
            {
                TenyekService service = new TenyekService();
                await service.LoadNews();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task LoadNews_Success_PestiSracok()
        {
            try
            {
                PestiSracokService service = new PestiSracokService();
                await service.LoadNews();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task LoadNews_Success_Merce()
        {
            try
            {
                MerceService service = new MerceService();
                await service.LoadNews();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task LoadNews_Success_AutoMotor()
        {
            try
            {
                AutoMotorService service = new AutoMotorService();
                await service.LoadNews();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task LoadNews_Success_Hu888()
        {
            try
            {
                Hu888Service service = new Hu888Service();
                await service.LoadNews();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task LoadNews_Success_Hircsarda()
        {
            try
            {
                HircsardaService service = new HircsardaService();
                await service.LoadNews();
            }
            catch
            {
                Assert.Fail();
            }
        }

        //[TestMethod]
        //public async Task TestDataChange()
        //{
        //    try
        //    {
        //        BaseService service = new IndexService();
        //        await BusinessLogic.ArticleModules.ArticleDriver.AddArticleContentXPathToPage(service.PageId, "//div[contains(concat(' ', normalize-space(@class), ' '), ' cikk-torzs ')]");
        //        service = new KurucInfoService();
        //        await BusinessLogic.ArticleModules.ArticleDriver.AddArticleContentXPathToPage(service.PageId, "//div[contains(concat(' ', normalize-space(@class), ' '), ' cikktext ')]");
        //        service = new NsoService();
        //        await BusinessLogic.ArticleModules.ArticleDriver.AddArticleContentXPathToPage(service.PageId, "//div[contains(concat(' ', normalize-space(@class), ' '), ' cikkbody clearfix ')]");
        //        service = new BlikkService();
        //        await BusinessLogic.ArticleModules.ArticleDriver.AddArticleContentXPathToPage(service.PageId, "//div[contains(concat(' ', normalize-space(@itemprop), ' '), ' articleBody ')]");
        //        service = new HvgService();
        //        await BusinessLogic.ArticleModules.ArticleDriver.AddArticleContentXPathToPage(service.PageId, "//div[contains(concat(' ', normalize-space(@class), ' '), ' article-content entry-content ')]");
        //        service = new Hu24Service();
        //        await BusinessLogic.ArticleModules.ArticleDriver.AddArticleContentXPathToPage(service.PageId, "//div[contains(concat(' ', normalize-space(@class), ' '), ' post-body ')]");
        //        service = new Hu444Service();
        //        await BusinessLogic.ArticleModules.ArticleDriver.AddArticleContentXPathToPage(service.PageId, "//article");
        //    }
        //    catch
        //    {
        //        Assert.Fail();
        //    }
        //}
    }
}
