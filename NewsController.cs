
using DAL;
using News.Filter;
using News.MyResult;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using Image = DAL.Image;

namespace News.Controllers
{
    public class NewsController : Controller
    {
        NewsRepository newsRepository;
        ImageRepository imageRepository;
        CategoryRepository categoryRepository;
        public NewsController(NewsRepository newsRepo,ImageRepository imageRepo,CategoryRepository categoryRepo)
        {
            newsRepository = newsRepo;
            imageRepository = imageRepo;
            categoryRepository = categoryRepo;
        }
        // GET: News
        public ActionResult Index()
        {
            return View();
        }

        public MyFileResult<NewsT> ExportToExcelNews()
        {
            var news = newsRepository.List();           
            return new MyFileResult<NewsT>(news);
        }

        public MyFileResult<Catagory> ExportToExcelCategory()
        {
            var catagories = categoryRepository.List();           
            return new MyFileResult<Catagory>(catagories);
        }
    }
}