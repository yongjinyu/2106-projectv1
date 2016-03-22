using SentosaWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SentosaWebsite.DAL
{
    interface IDataGateway<T> where T:class
    {
        IEnumerable<T> SelectAll();
        T SelectById(int? id);
        void Insert(T attraction);
        void Update(T attraction);
        T Delete(int? id);
        void Save();

        //IEnumerable<TicketPrice> Search(int? atID);
        IEnumerable<TicketPrice> ticketById(int id, IEnumerable<TicketPrice> allTickets);


    }
}
