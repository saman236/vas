using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VAS.Panel.Application.Data;
using VAS.Panel.DataModels;

namespace VAS.Panel.Models
{
    public class RequestHistoryPOCO : IDataModel
    {
        public int ID { get; set; }
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public RequestState State { get; set; }
        public DateTime InsertDateTime { get; set; }

    }

    internal class RequestHistoryMapper : ApplicationEntityMapper<RequestHistoryPOCO, RequestHistory>
    {
        public RequestHistoryMapper(ApplicationEntityContext context)
            : base(context)
        { }

        #region Implemet Methods
        
        public override RequestHistory ToDBEntity(RequestHistoryPOCO source)
        {
            return new RequestHistory
            {
                Id = source.ID,
                RequestId = source.RequestId,
                UserId = source.UserId,
                State = (byte)source.State,
                InsertDateTime = source.InsertDateTime,
            };
        }

        public override IQueryable<RequestHistoryPOCO> ToModel(IQueryable<RequestHistory> source)
        {
            return source.Select(t => new RequestHistoryPOCO
            {
                ID = t.Id,
                RequestId = t.RequestId,
                UserId = t.UserId,
                State = (RequestState)t.State,
                InsertDateTime = t.InsertDateTime,
            });
        }

        #endregion

        #region Class Methods

        internal void SaveHistory(RequestHistoryPOCO history)
        {
            Context.RequestHistories.Add(ToDBEntity(history));
            Context.SaveChanges();
        }

        #endregion
    }
}