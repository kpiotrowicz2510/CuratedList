using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.AspNet.OData;
using CuratedList.Data;
using CuratedList.Models;
using CuratedList.Models.DTO;
using Microsoft.AspNet.OData.Query;
using Microsoft.EntityFrameworkCore;

namespace CuratedList.Services
{
    
    public class LinkService : ILinkService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        
        public LinkService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<LinkEntryResponse>> GetLinksAsync(ODataQueryOptions<LinkEntryResponse> options)
        {
            var responses = await _context.LinkEntries.Include(x => x.User).GetQueryAsync(_mapper, options);
            return await responses.ToListAsync();
        }

        public async Task<LinkEntry> AddLinkAsync(LinkEntry linkEntry)
        {
            await _context.LinkEntries.AddAsync(linkEntry);
            await _context.SaveChangesAsync();
            return linkEntry;
        }
    }

    public interface ILinkService
    {
        public Task<IEnumerable<LinkEntryResponse>> GetLinksAsync(ODataQueryOptions<LinkEntryResponse> options);
        public Task<LinkEntry> AddLinkAsync(LinkEntry linkEntry);
    }
}