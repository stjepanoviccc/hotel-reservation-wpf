using HotelReservations.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Service
{
    class PriceService
    {

        public void SavePrice(Price price)
        {
            if (price.Id == 0)
            {
                price.Id = GetNextId();
                Hotel.GetInstance().Prices.Add(price);
            }
            else
            {
                var index = Hotel.GetInstance().Prices.FindIndex(p => p.Id == price.Id);
                Hotel.GetInstance().Prices[index] = price;
                // DataUtil.PersistData();
                // DataUtil.LoadData();
            }
        }

        public int GetNextId()
        {
            return Hotel.GetInstance().Prices.Max(p => p.Id) + 1;
        }

        public void MakePriceInactive(Price price)
        {
            var makePriceInactive = Hotel.GetInstance().Prices.Find(p => p.Id == price.Id);
            makePriceInactive.IsActive = false;
        }
    }
}
