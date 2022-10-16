using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Concurrent;


namespace ITMO_ASP.NET
{
    public class ResponseRepository
    {
        private static ResponseRepository repository = new ResponseRepository();
        private List<GuestRespnse> responses = new List<GuestRespnse>();
        public static ResponseRepository GetRepository()
        {
            return repository;
        }
        public IEnumerable<GuestRespnse> GetAllResponses()
        {
            return responses;
        }
        public void AddResponse(GuestRespnse response)
        {
            responses.Add(response);
        }
    }
}