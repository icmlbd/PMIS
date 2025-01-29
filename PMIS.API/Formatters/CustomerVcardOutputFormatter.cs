using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using PMIS.Models.DTOs.Customers;
using PMIS.Models.EntityModels;
using System.Text;

namespace PMIS.API.Formatters
{
    public class CustomerVcardOutputFormatter : TextOutputFormatter
    {
        public CustomerVcardOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/mamun"));

            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
           var buffer = new StringBuilder();

            if (context.Object is IList<CustomerResponseDTO> contacts)
            {
                foreach (var contact in contacts)
                {
                    FormatVcard(buffer, contact);
                }
            }
            else
            {
                FormatVcard(buffer, (CustomerResponseDTO)context.Object!);
            }

            await context.HttpContext.Response.WriteAsync(buffer.ToString(), selectedEncoding);
        }

        private static void FormatVcard(
    StringBuilder buffer, CustomerResponseDTO contact)
        {
            buffer.AppendLine("BEGIN:VCARD");
            buffer.AppendLine("VERSION:2.1");
            buffer.AppendLine($"নাম:{contact.Name};");
            buffer.AppendLine($"Address:{contact.Address}");
            buffer.AppendLine($"Age:{contact.Age}");
            buffer.AppendLine("END:VCARD");            
        }
    }
}
