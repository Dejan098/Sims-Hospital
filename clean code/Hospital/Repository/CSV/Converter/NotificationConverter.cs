using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Repository.CSV.Converter
{
    class NotificationConverter : ICSVConverter<Notification>
    {
        private readonly string _delimiter;

        public NotificationConverter(string delimiter)
        {
            _delimiter = delimiter;
           
        }

        public string ConvertEntityToCSVFormat(Notification notification)
         => string.Join(_delimiter,
             notification.Id,
             notification.Text,
             notification.IdDoctor);


        public Notification ConvertCSVFormatToEntity(string notificationCSVFormat)
        {
            string[] tokens = notificationCSVFormat.Split(_delimiter.ToCharArray());
            return new Notification(
                long.Parse(tokens[0]),
                tokens[1],
                long.Parse(tokens[2]));


        }

    }
}
