using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Models;
using System.Text;

namespace CSVTest.Services
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }


        protected override bool CanWriteType(Type? type)
        {
            if (typeof(EmployeeDTO).IsAssignableFrom(type) || typeof(IEnumerable<EmployeeDTO>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
           
            StringBuilder buffer = new StringBuilder();

            if(context.Object is IEnumerable<EmployeeDTO>)
            {
                foreach(var employee in (IEnumerable<EmployeeDTO>)context.Object)
                {
                    FormatCsv(buffer, employee);

                }
            }
            else
            {
                FormatCsv(buffer, (EmployeeDTO)context.Object);
            }

            await context.HttpContext.Response.WriteAsync(buffer.ToString());
        }

        public static void FormatCsv(StringBuilder buffer, EmployeeDTO employee)
        {
            buffer.AppendLine($"\"{employee.Id}\", \"{employee.FirstName + " " + employee.LastName}\", \"{employee.Gender}\", \"{employee.DateOfBirth.Date.ToString("dd/MM/yyyy")}\", \"{employee.FullAddress}\" ");
        }
    }
}
