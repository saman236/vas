using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VAS.Panel.Application.Data;
using VAS.Panel.DataModels;

namespace VAS.Panel.Models
{
    public class RequestPOCO : IDataModel
    {
        public int ID { get; set; }
        public int PersonTypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string IdentityNo { get; set; }
        public int BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string NationalCode { get; set; }
        public string NationalId { get; set; }
        public string EducationDegree { get; set; }
        public string OrgzanisationPost { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string AgentName { get; set; }
        public string AgentMobile { get; set; }
        public string AgentEmail { get; set; }
        public string AgentOrganizationPost { get; set; }
        public string ActivityType { get; set; }
        public string Address { get; set; }
        public DateTime InsertDateTime { get; set; }
        public RequestState CurrentState { get; set; }
    }

    internal class RequestMapper : ApplicationEntityMapper<RequestPOCO, Request>
    {
        public RequestMapper(ApplicationEntityContext context)
            : base(context)
        { }

        #region Implement Methods

        public override Request ToDBEntity(RequestPOCO source)
        {
            return new Request
            {
                Id = source.ID,
                PersonTypeId = (byte)source.PersonTypeId,
                FirstName = source.FirstName,
                LastName = source.LastName,
                FatherName = source.FatherName,
                IdentityNo = source.IdentityNo,
                BirthDate = source.BirthDate == default(int) ? null : (int?)source.BirthDate,
                BirthPlace = source.BirthPlace,
                NationalCode = source.NationalCode,
                NationalId = source.NationalId,
                EducationDegree = source.EducationDegree,
                OrgzanisationPost = source.OrgzanisationPost,
                Email = source.Email,
                Phone = source.Phone,
                Mobile = source.Mobile,
                AgentName = source.AgentName,
                AgentMobile = source.AgentMobile,
                AgentEmail = source.AgentEmail,
                AgentOrganizationPost = source.AgentOrganizationPost,
                ActivityType = source.ActivityType,
                Address = source.Address,
                InsertDateTime = source.InsertDateTime
            };
        }

        public override IQueryable<RequestPOCO> ToModel(IQueryable<Request> source)
        {
            return source.Select(t => new RequestPOCO
            {
                ID = t.Id,
                PersonTypeId = t.PersonTypeId,
                FirstName = t.FirstName,
                LastName = t.LastName,
                FatherName = t.FatherName,
                IdentityNo = t.IdentityNo,
                BirthDate = t.BirthDate ?? 0,
                BirthPlace = t.BirthPlace,
                NationalCode = t.NationalCode,
                NationalId = t.NationalId,
                EducationDegree = t.EducationDegree,
                OrgzanisationPost = t.OrgzanisationPost,
                Email = t.Email,
                Phone = t.Phone,
                Mobile = t.Mobile,
                AgentName = t.AgentName,
                AgentMobile = t.AgentMobile,
                AgentEmail = t.AgentEmail,
                AgentOrganizationPost = t.AgentOrganizationPost,
                ActivityType = t.ActivityType,
                Address = t.Address,
                InsertDateTime = t.InsertDateTime
            });
        }

        #endregion

        #region Class Methods

        internal IQueryable<RequestPOCO> GetRequestPOCOQueryable()
        {
            return from request in Context.Requests
                   join requestHistory in Context.RequestHistories on request.Id equals requestHistory.RequestId into requestHistories

                   from requestHistory in requestHistories.OrderByDescending(t => t.InsertDateTime).Take(1).DefaultIfEmpty()

                   select new RequestPOCO
                   {
                       ID = request.Id,
                       PersonTypeId = request.PersonTypeId,
                       FirstName = request.FirstName,
                       LastName = request.LastName,
                       FatherName = request.FatherName,
                       IdentityNo = request.IdentityNo,
                       BirthDate = request.BirthDate ?? 0,
                       BirthPlace = request.BirthPlace,
                       NationalCode = request.NationalCode,
                       NationalId = request.NationalId,
                       EducationDegree = request.EducationDegree,
                       OrgzanisationPost = request.OrgzanisationPost,
                       Email = request.Email,
                       Phone = request.Phone,
                       Mobile = request.Mobile,
                       AgentName = request.AgentName,
                       AgentMobile = request.AgentMobile,
                       AgentEmail = request.AgentEmail,
                       AgentOrganizationPost = request.AgentOrganizationPost,
                       ActivityType = request.ActivityType,
                       Address = request.Address,
                       InsertDateTime = request.InsertDateTime,
                       CurrentState = requestHistory == null ? RequestState.UnChecked : (RequestState)requestHistory.State
                   };
        }

        #endregion
    }

    public enum RequestState
    {
        Rejected = -1,
        UnChecked = 0,
        EmployeeApproved = 1,
        ManagerApproved = 2,
    }
}