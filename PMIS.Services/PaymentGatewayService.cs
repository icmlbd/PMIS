using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PMIS.Models.ConfigrationOptions;
using PMIS.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Services
{
    public class PaymentGatewayService : IPaymentGatewayService
    {
        IConfiguration _configuration;
        PaymentGatewayOption _paypalOption; 
        public PaymentGatewayService(IConfiguration configuration, IOptions<PaymentGatewayOption> paymentGateway){

            _configuration = configuration;
            _paypalOption = paymentGateway.Value; 
        }

        public void GetPaymentGateway()
        {
            //var configurationSection = _configuration.GetSection("PaymentGateway");

            //var paymentGatewayChilds = configurationSection.GetChildren(); 

            //var paypalSection = configurationSection.GetSection("Paypal");
            //var sslCommerzSection = configurationSection.GetSection("SSlCommerz");

            //string paypalAccessKey = _configuration["PaymentGateway:Paypal:AccessKey"];

            

            //PaymentGatewayOption paypal = _configuration.GetSection("PaymentGateway:Paypal").Get<PaymentGatewayOption>();

            string paypalAccessKeyText = _paypalOption.AccessKey; 


        }

    }
}
