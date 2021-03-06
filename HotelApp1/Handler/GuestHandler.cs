﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp1.ViewModel;
using HotelApp1.Model;
using HotelApp1.Common;
using HotelApp1.Persistency;

namespace HotelApp1.Handler
{
    class GuestHandler
    {
        //private GuestHandler MyHandler;
        public GuestViewModel gvm { get; set; }
        public GuestHandler(GuestViewModel ViewModel)
        {
            this.gvm = ViewModel;
        }

        public void AddGuest()
        {
            Guest tempGuest = new Guest();
            tempGuest.Name = gvm.Name;
            tempGuest.Address = gvm.Address;
            //int maxId = gvm.GuestList.OrderByDescending(item => item.Guest_No).First().Guest_No + 1;
            tempGuest.Guest_No = gvm.GuestId;

            GuestCatalogSingleton.SingletonInstance.AddNewGuest(tempGuest);
            GuestCatalogSingleton.SingletonInstance.LoadGuests();
        }
        public async void DeleteGuest()
        {
            await PersistencyService.DeleteOneGuest(gvm.SelectedGuest);
            GuestCatalogSingleton.SingletonInstance.LoadGuests();
        }

        public void EditGuest()
        {
            Guest tempGuest = new Guest();
            tempGuest.Name = gvm.EditName;
            tempGuest.Address = gvm.EditAddress;
            tempGuest.Guest_No = gvm.EditGuestId;
            GuestCatalogSingleton.SingletonInstance.EditGuest(tempGuest);
            GuestCatalogSingleton.SingletonInstance.LoadGuests();
        }

        public void FindGuestBooking()
        {
            gvm.BookingBGuestId = PersistencyService.FindGuestBooking(SelectedGuest.Guest_No.ToString());
        }


    }
}
