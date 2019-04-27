using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormTask
{
    
        /// <summary>
        /// Бронирование номера
        /// </summary>
        public class Booking
        {

            /// <summary>
            /// Выбор номера
            /// </summary>
            public List<Rooms> GetRooms { get; set; }

            /// <summary>
            /// Отмена бронирования
            /// </summary>
            public string CancelBooking { get; set; }

        }

        /// <summary>
        /// Номера 
        /// </summary>
        public class Rooms
        {
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

            public string Services { get; set; }


            public override string ToString()
            {
                return $"Кол-во человек: {NumberOfPersons}, Кол-во кроватей: {NumberOfBeds}, Дата прибытия: {ResidencyFrom}, Дата выезда: {ResidencyTo}, Доп. Услуги: {Services}";
            }


        }   

        /// <summary>
        /// Авторизация
        /// </summary>
        public class Autorization
        {
            /// <summary>
            /// Имя пользователя
            /// </summary>
            public string UserName { get; set; }

            /// <summary>
            /// Пароль
            /// </summary>
            public string Password { get; set; }

            /// <summary>
            /// Почта
            /// </summary>
            public string Mail { get; set; }
        }


    

}
