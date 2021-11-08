using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Repository.CSV.Converter
{
    class FeedbackConverter: ICSVConverter<Feedback>
    {
        private readonly string _delimiter;

        public FeedbackConverter(string delimiter)
        {
            _delimiter = delimiter;

        }

        public string ConvertEntityToCSVFormat(Feedback feedback)
         => string.Join(_delimiter,
             feedback.Id,
             feedback.Description,
             feedback.isBug);


        public Feedback ConvertCSVFormatToEntity(string feedbackCSVFormat)
        {
            string[] tokens = feedbackCSVFormat.Split(_delimiter.ToCharArray());
            return new Feedback(
                long.Parse(tokens[0]),
                tokens[1],
                Boolean.Parse(tokens[2]));
        }





    }







   

}
