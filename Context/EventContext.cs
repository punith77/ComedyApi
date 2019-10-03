using ComedyEvents.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComedyEvents.Context
{
    public class EventContext:DbContext
    {
        private readonly IConfiguration _configuration;
        public EventContext(IConfiguration configuration, DbContextOptions options) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Comedian> Comedians { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("ComedyEvent"));
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Event>().HasData(new
            {
                EventId = 1,
                EventName = "Funny Comedy Night",
                EventDate = new DateTime(2019, 05, 19),
                VenueId = 1
            });
            builder.Entity<Venue>().HasData(new
            {
                VenueId = 1,
                VenueName = "Mohegan Sun",
                Street = "123 Main Street",
                City = "Wilkes Barre",
                State = "PA",
                ZipCode = "18702",
                Seating = 125,
                ServesAlcohol = true
            });
            builder.Entity<Gig>().HasData(new
            {
                GigId = 1,
                GigHeadLine ="Punith's Funny Show",
                GigLengthInMinutes=60 ,
                EventId = 1,
                ComedianId = 1

            }, new {
                GigId = 2,
                GigHeadLine = "LifeTime of Fun",
                GigLengthInMinutes = 45,
                EventId = 1,
                ComedianId = 2
            });

            builder.Entity<Comedian>().HasData(new
            {
                ComedianId = 1,
                FirstName = "Punith",
                LastName = "Chirumamilla",
                ContactPhone = "1234567890"
            }, new
            {
                ComedianId = 2,
                FirstName = "Nani",
                LastName = "Kittu",
                ContactPhone = "1234567891"
            });
        }

    }
}
