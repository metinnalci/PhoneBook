using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ReportAPI.Models.MessageModel;
using ReportAPI.Models.ORM.Context;
using ReportAPI.Models.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportAPI.Controllers
{
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly ReportContext _reportContext;
        public MessagesController(ReportContext reportContext)
        {
            _reportContext = reportContext;
        }

        [Route("deneme")]
        [HttpGet]
        public ActionResult<Report> GetMessage()
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://yzpwpmfr:kXG_094LCRZZouYjRGoaXtQeSfpHNdgJ@eagle.rmq.cloudamqp.com/yzpwpmfr");


            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare("setur", ExchangeType.Direct, true, false, null);
                    channel.QueueBind("report", "setur", "kocsistem");
                    channel.BasicQos(0, 1, false);

                    var consumer = new EventingBasicConsumer(channel);

                    channel.BasicConsume("report", false, consumer);

                    consumer.Received += (model, ea) =>
                    {

                        string mes = Encoding.UTF8.GetString(ea.Body.Span);

                        Message message = JsonConvert.DeserializeObject<Message>(mes);
                        Report report = new Report();

                        report.ID = 1;
                        report.Location = message.Location;
                        report.ReportStatus = true;
                        report.TotalPhone = 1;
                        report.TotalUser = message.UserID;

                    };
                }
            }

        }

        [Route("report/{location}")]
        [HttpGet]
        public Report ReportDetail(string location)
        {
            Report report = _reportContext.Reports.Where(q => q.Location == location).FirstOrDefault();

            return report;

        }

    }
}
