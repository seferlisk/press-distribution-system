using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PressDistributionSystemWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PressDistributionController : ControllerBase
    {
        // Example data
        private static readonly List<PressDistribution> distributions = new List<PressDistribution>
        {
            new PressDistribution { Id = 1, Title = "Article 1", Content = "Content of Article 1" },
            new PressDistribution { Id = 2, Title = "Article 2", Content = "Content of Article 2" },
        };

        [HttpGet]
        public ActionResult<IEnumerable<PressDistribution>> GetAll()
        {
            return Ok(distributions);
        }

        [HttpGet("{id}")]
        public ActionResult<PressDistribution> Get(int id)
        {
            var distribution = distributions.FirstOrDefault(d => d.Id == id);
            if (distribution == null)
            {
                return NotFound();
            }
            return Ok(distribution);
        }
    }

    public class PressDistribution
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content
        {
            get; set;
        }
    }
}
