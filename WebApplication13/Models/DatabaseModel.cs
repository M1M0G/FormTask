using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FormTask.web.Models
{
    namespace DataAccessPostgreSqlProvider
    {
        public class HotelAppDbContext : DbContext
        {
            public HotelAppDbContext()
            {

                Database.EnsureCreated();
            }

            public HotelAppDbContext(DbContextOptions<HotelAppDbContext> options) : base(options)
            {
            }

            public DbSet<DbListrooms> Listrooms { get; set; }
            //public DbSet<DbFlight> Flights { get; set; }
            public static string ConnectionString { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseNpgsql(HotelAppDbContext.ConnectionString);

                base.OnConfiguring(optionsBuilder);
            }
        }

        public class DbListrooms
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            public List<DbRooms> Rooms { get; set; }

        }

        public class DbRooms
        {

            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            public int DbListroomsId { get; set; }
            [ForeignKey("SpaceShipId")]
            public virtual DbListrooms Listrooms { get; set; }

            /// <summary>
            /// Дата заезда и выезда 
            /// </summary>
            public DateTime ResidencyFrom { get; set; }

            /// <summary>
            /// Дата заезда и выезда 
            /// </summary>
            public DateTime ResidencyTo { get; set; }


            /// <summary>
            /// Номера с подходящим количеством человек
            /// </summary>
            public string NumberOfPersons { get; set; }

            /// <summary>
            /// Компановка спальных мест  
            /// </summary>
            public string NumberOfBeds { get; set; }

            public List<string> Services { get; set; }


            public override string ToString()
            {
                var joined_services = string.Join(",", Services);
                return $"Кол-во человек: {NumberOfPersons}, Кол-во кроватей: {NumberOfBeds}, Дата прибытия: {ResidencyFrom.ToShortDateString()}, Дата выезда: {ResidencyTo.ToShortDateString()}, Доп. Услуги: {joined_services}";
            }


        }
    }
    
}
