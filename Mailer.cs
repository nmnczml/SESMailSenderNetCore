using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SESSample
{
    public class SESEmailSender 
    {
        public async Task SendEmailAsync(string senderAddress, string receiverAddress, string subject, string htmlBody)
        {
            
            // Change to your region
            using (var client = new AmazonSimpleEmailServiceClient("<amazonApi>", "<amazonSecret>",RegionEndpoint.EUWest2))
            {

                

                var sendRequest = new SendEmailRequest
                {
                    Source = senderAddress,
                    Destination = new Destination
                    {
                        ToAddresses =
                        new List<string> { receiverAddress }
                    },
                    Message = new Message
                    {
                        Subject = new Content(subject),
                        Body = new Body
                        {
                            Html = new Content
                            {
                                Charset = "UTF-8",
                                Data = htmlBody
                            },
                            Text = new Content
                            {
                                Charset = "UTF-8",
                                Data = htmlBody
                            }
                        }
                    }
                };
                var response = await client.SendEmailAsync(sendRequest);
            }
        }
    }
}
