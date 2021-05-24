using DataInjestion.Sql.Business.Implementation;
using DataInjestion.Sql.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace DataInjestion.Sql.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    [ExcludeFromCodeCoverage]
    public class LinkFireReadAllDataController : ControllerBase
    {
        private readonly LinkFireDBContext _context;
        private readonly IOptions<UrlConfiguration> _config;


        public LinkFireReadAllDataController(LinkFireDBContext context, IOptions<UrlConfiguration> config)
        {
            _context = context;
            _config = config;
        }

        [HttpGet("ReadDataRange")]
        public async Task<ActionResult> ReadDataRange()
        {
            //int startRange = 1548379197;//146338;//1548379197;
            //int endRange = 1548379197; ;//15158940;// 1548379198;
            GetData getData = new GetData(_context, _config);
            await getData.GetCollection();

            return StatusCode(200);
        }
    }
}
