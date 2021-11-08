using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository.CSV.Converter
{
    public class FAQCSVConverter : ICSVConverter<Faq>
    {
        private readonly string _delimiter;
        //private readonly string _datetimeFormat;

        public FAQCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public string ConvertEntityToCSVFormat(Faq faq)
           => string.Join(_delimiter,
               faq.Patient.Id,
               faq.Question,
               faq.Id,
               faq.Answer);

        public Faq ConvertCSVFormatToEntity(string faqCSVFormat)
        {
            string[] tokens = faqCSVFormat.Split(_delimiter.ToCharArray());
            return new Faq(
                new Patient (long.Parse(tokens[0])),
                tokens[1],
                long.Parse(tokens[2]),
                tokens[3]);
        }
    }
}


