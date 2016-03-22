﻿using SentosaWebsite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace SentosaWebsite.DAL
{
    //Data Gateway for the Sentosa Website



    public class DataGateway<T> : IDataGateway<T> where T : class
    {
        internal SentosaContext db = new SentosaContext();

        // added for RestaurantContext 
      

        internal DbSet<T> data = null;
            internal DbSet<T> dataRest = null;

        public DataGateway()
        {
            this.data = db.Set<T>();
            this.dataRest = db.Set<T>();
        }
        public T Delete(int? id)
        {
            T obj = data.Find(id);
            data.Remove(obj);
            db.SaveChanges();
            return obj;
        }

        public void Insert(T obj)
        {
            data.Add(obj);
            db.SaveChanges();
        }

        public void Save()
        {
            

        }

        public IEnumerable<T> SelectAll()
        {
            return data.ToList();
        }

        public T SelectById(int? id)
        {
            return data.Find(id);
        }

        public void Update(T obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

        //public IEnumerable<TicketPrice> Search(int atID)
        //{
        //   return db.Database.SqlQuery("SELECT * FROM " + "lalal " + "WHERE atID = " + atID);
        //}

        public IEnumerable<TicketPrice> ticketById(int id, IEnumerable<TicketPrice> allTickets)
        {
            List<TicketPrice> result = new List<TicketPrice>();
            foreach (TicketPrice t in allTickets)
            {
                if (t.atID == id)
                {
                    result.Add(t);
                }
            }
            return result;
        }

    }
}