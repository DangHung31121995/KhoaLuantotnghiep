using System.Collections.Generic;
namespace Ecommerce.Infrastructure.Attribute
{
    public class GeneralResponse
    {
        public bool Success { get; set; }

        public IList<ResponseMessage> Messages { get; set; } = (IList<ResponseMessage>)new List<ResponseMessage>();

        public string Id { get; set; }

        public static GeneralResponse Error()
        {
            return new GeneralResponse() { Success = false };
        }

        public static GeneralResponse Error(string message)
        {
            GeneralResponse generalResponse = GeneralResponse.Error();
            generalResponse.Messages.Add(new ResponseMessage()
            {
                Key = string.Empty,
                Message = message
            });
            return generalResponse;
        }

        public static GeneralResponse Error(string key, string message)
        {
            GeneralResponse generalResponse = GeneralResponse.Error();
            generalResponse.Messages.Add(new ResponseMessage()
            {
                Key = key,
                Message = message
            });
            return generalResponse;
        }
    }
}
