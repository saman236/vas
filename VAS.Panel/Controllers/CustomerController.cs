using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using VAS.Panel.Application;
using VAS.Panel.Application.Data;
using VAS.Panel.Models;

namespace VAS.Panel.Controllers
{
    public class CustomerController : ApiController
    {
        public CustomerController()
        {

        }

        [Route("requests")]
        [HttpGet]
        [CustomAuthorization(Roles = Role.Admin)]
        public HttpResponseMessage GetRequest()
        {
            var context = ApplicationEntityContextFactory.Current;
            var map = new RequestMapper(context);
            var result = map.GetRequestPOCOQueryable().ToList();
            return Request.CreateResponse(result);
        }

        [Route("requests")]
        [HttpGet]
        [CustomAuthorization(Roles = Role.Admin)]
        public HttpResponseMessage GetRequest(DateTime date, string lastname, RequestState state)
        {
            var context = ApplicationEntityContextFactory.Current;
            var map = new RequestMapper(context);
            var Query = map.GetRequestPOCOQueryable();

            Query = Query.Where(t =>
                                    t.InsertDateTime == date &&
                                    t.CurrentState == state
                               );

            if (!string.IsNullOrEmpty(lastname))
                Query = Query.Where(t => t.LastName.Contains(lastname));

            var result = Query.ToList();
            return Request.CreateResponse(result);
        }


        [Route("changeRequestSatet")]
        [HttpPost]
        public HttpResponseMessage ChangeState(int requestID, RequestState state)
        {
            if (UserManagment.CurrentUser == null)
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Forbidden,
                    Content = new StringContent(Messages.UN_AUTHENTICATED)
                };
            }

            if (!UserManagment.CurrentUser.IsAdmin && !UserManagment.CurrentUser.IsEmployee)
            {
                // فقط کاربر مدیر و کارمند
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Forbidden,
                    Content = new StringContent(Messages.ACCESS_DENIED)
                };
            }

            var context = ApplicationEntityContextFactory.Current;
            var map = new RequestMapper(context);
            var historyMap = new RequestHistoryMapper(context);
            var request = map.GetRequestPOCOQueryable().FirstOrDefault(t => t.ID == requestID);

            if (state == RequestState.UnChecked)
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent("وضعیت درخواستی نامعتبر است.")
                };
            }

            if (request == null)
            {
                // شماره درخواست نامعتبر است
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Content = new StringContent("شماره درخواست نامعتبر است.")
                };
            }

            if (request.CurrentState == RequestState.ManagerApproved)
            {
                // درخواست پیش از این توسط مدیریت تایید شده است.
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent("درخواست پیش از این توسط مدیریت تایید شده است.")
                };
            }

            if (request.CurrentState == RequestState.Rejected)
            {
                // صلاحیت درخواست پیش از این رد شده است.
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent("صلاحیت درخواست پیش از این رد شده است.")
                };
            }

            if (state == RequestState.EmployeeApproved)
            {
                if (request.CurrentState != RequestState.UnChecked)
                {
                    return new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Content = new StringContent("تایید اولیه درخواست پیش از این صورت گرفته است.")
                    };
                }

                if (!UserManagment.CurrentUser.IsEmployee)
                {
                    // فقط کاربر کارمند
                    return new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.Forbidden,
                        Content = new StringContent(Messages.ACCESS_DENIED)
                    };
                }
            }

            if (state == RequestState.ManagerApproved)
            {
                if (request.CurrentState != RequestState.UnChecked)
                {
                    return new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Content = new StringContent("تایید اولیه درخواست انجام نشده است.")
                    };
                }
                if (!UserManagment.CurrentUser.IsAdmin)
                {
                    // فقط کاربر مدیر
                    return new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.Forbidden,
                        Content = new StringContent(Messages.ACCESS_DENIED)
                    };
                }
            }

            var histoy = new RequestHistoryPOCO
            {
                RequestId = request.ID,
                InsertDateTime = DateTime.Now,
                State = state,
                UserId = UserManagment.CurrentUser.UserID
            };
            historyMap.Save(histoy);

            return Request.CreateResponse(true);
        }

    }
}