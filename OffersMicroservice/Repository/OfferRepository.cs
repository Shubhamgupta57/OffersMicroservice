using Microsoft.EntityFrameworkCore;
using OffersMicroservice.DBContexts;
using OffersMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffersMicroservice.Repository
{
    public class OfferRepository : IOfferRepository
    {
        private readonly OfferContext _dbContext;

        public OfferRepository(OfferContext dbContext)
        {
            _dbContext = dbContext;
        }
        //public void DeleteOffer(int OfferId)
        //{
        //    var Offer = _dbContext.Offers.Find(OfferId);
        //    _dbContext.Offers.Remove(Offer);
        //    Save();
        //}

        public Offer GetOfferByID(int OfferId)
        {
            return _dbContext.Offers.Find(OfferId);
        }
        public IEnumerable<Offer> GetOfferByCategory(int category)
        {
            return _dbContext.Offers.Where(s=>s.CategoryId==category).ToList();
        }

        public IEnumerable<Offer> GetOfferByTopLikes()
        {
            return _dbContext.Offers.OrderByDescending(o=>o.Likes).Take(3).ToList();
        }

        public IEnumerable<Offer> GetOfferByPostedDate(DateTime dateTime)
        {
            return _dbContext.Offers.Where((x => DateTime.Compare(x.OpenedDate, dateTime) == 0)).ToList();
        }

        public IEnumerable<Offer> GetOffers()
        {
            return _dbContext.Offers.ToList();
        }

        public void AddOffer(Offer Offer)
        {
            _dbContext.Offers.Add(Offer);
            Save();
        }   

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void EditOffer(Offer Offer)
        {
            Offer offer = _dbContext.Offers.Find(Offer.OfferId);
            offer = Offer;
            _dbContext.Offers.Update(offer);
            Save();
        }

        public int GetLikesByOfferId(int id) {

            return _dbContext.Likes.Where(o => o.OfferId == id).Count();
        
        }
        public List<Offer> RecentlyLiked()
        {
            var recentlyLikedList= _dbContext.Likes.TakeLast(6).Select(o => o.OfferId).Distinct();
            List<Offer> offerList = new List<Offer>();
            foreach(int offerId in recentlyLikedList)
            {
                offerList.Add(GetOfferByID(offerId));
            }
            return offerList;
        }
    }

}

