using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using MusicPrefApp.Application.Interfaces;

namespace MusicPrefApp.UI.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class DownloadController : ControllerBase
    {
        private readonly IRecommendationResult<string> _recommendationResult;

        public DownloadController(IRecommendationResult<string> recommendationResult)
        {
            _recommendationResult = recommendationResult;
        }

        [HttpGet, Route("recommendations")]
        public ActionResult Get()
        {

            var buffer = Encoding.UTF8.GetBytes(_recommendationResult.Recommendations);
            var stream = new MemoryStream(buffer);

            var result = new FileStreamResult(stream, "text/csv")
            {
                FileDownloadName = "recommendations.csv"
            };
            return result;
        }


    }
}
