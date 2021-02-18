using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CuratedList.Models;
using CuratedList.Models.DTO;
using CuratedList.Services;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;

namespace CuratedList.Controllers
{
    [Route("api")]
    public class LinksController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILinkService _linkService;

        public LinksController(IMapper mapper, ILinkService linkService)
        {
            _mapper = mapper;
            _linkService = linkService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetLinks(ODataQueryOptions<LinkEntryResponse> options)
        {
            return Ok(await _linkService.GetLinksAsync(options));
        }
        
        [HttpPost("")]
        public async Task<IActionResult> AddLink([FromBody] LinkEntryResponse newEntry)
        {
            var newLinkEntry = _mapper.Map<LinkEntryResponse, LinkEntry>(newEntry);
            return Ok(_mapper.Map<LinkEntry, LinkEntryResponse>(await _linkService.AddLinkAsync(newLinkEntry)));
        }
    }
}