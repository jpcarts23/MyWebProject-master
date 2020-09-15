using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebProject.Models
{
    public class RequestHistoryFunction
    {
        public static void InsertRequestHistory(int id, string comment)
        {
            try
            {
                using (var context = new TMGEntities())
                {
                    var requestHistory = new RequestHistory();
                    requestHistory.Request_ID = id;
                    requestHistory.RequestHistoryStatus = comment;

                    context.RequestHistories.Add(requestHistory);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}