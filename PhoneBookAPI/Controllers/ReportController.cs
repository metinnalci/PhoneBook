using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PhoneBookAPI.Models.Entities;
using PhoneBookAPI.Models.MessageModel;
using PhoneBookAPI.Models.ORM.Context;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookAPI.Controllers
{
    
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly PhoneBookContext _phoneBookContext;
        public ReportController(PhoneBookContext phoneBookContext)
        {
            _phoneBookContext = phoneBookContext;
        }

        [Route("report/{location}")]
        [HttpGet]
        public IActionResult ReportProducer(string location)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://yzpwpmfr:kXG_094LCRZZouYjRGoaXtQeSfpHNdgJ@eagle.rmq.cloudamqp.com/yzpwpmfr");

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare("setur", ExchangeType.Direct, true, false, null);
                    channel.QueueDeclare("report", true, false, false, null);
                    channel.QueueBind("report", "setur", "kocsistem");

                    Message message = new Message();

                    User user = _phoneBookContext.Users.Include(q => q.ContactTypes).Where(q => q.ContactTypes.Location == location).FirstOrDefault();

                    message.Location = location;
                    message.Phone = user.ContactTypes.Phone;
                    message.UserID = user.ID;

                    string serializemessage = JsonConvert.SerializeObject(message);

                    byte[] byteMessage = Encoding.UTF8.GetBytes(serializemessage);

                    var properties = channel.CreateBasicProperties();
                    properties.Persistent = true;

                    channel.BasicPublish("setur", "kocsistem", properties, byteMessage);

                    return Ok("girdiğiniz lokasyon için rapor hazırlandı.");
                }
            }
        }
    }
}
