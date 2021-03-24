using OffersMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffersMicroservice.Repository
{
    public interface IOfferRepository
    {
        public Offer GetOfferByID(int OfferId);

        public IEnumerable<Offer> GetOfferByCategory(int category);

        public IEnumerable<Offer> GetOfferByTopLikes();
        public IEnumerable<Offer> GetOfferByPostedDate(DateTime dateTime);

        public IEnumerable<Offer> GetOffers();

        public void AddOffer(Offer Offer);

        void EditOffer(Offer Offer);

        int GetLikesByOfferId(int id);

        public List<Offer> RecentlyLiked();
    }
}
