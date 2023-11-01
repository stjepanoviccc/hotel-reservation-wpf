﻿using HotelReservations.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Repositories
{
    public interface IRoomTypeRepository
    {
        List<RoomType> Load();

        void Save(List<RoomType> roomTypes);
    }
}
