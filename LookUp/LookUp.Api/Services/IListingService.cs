using LookUp.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LookUp.Api.Services
{
    public interface IListingService
    {
        public List<Listing> GetListingByPrice(int passengers, List<Listing> listings);
        public Task<ListingDetails> GetAllListings();

    }
}
