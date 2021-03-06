﻿using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventOrganizer.Web.Models;
using EventOrganizer.Web.Services.Abstract;

namespace EventOrganizer.Web.Controllers
{
    public class JoinEventController : ApiController
    {
        private readonly IUserService _userService;

        public JoinEventController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public HttpResponseMessage Post(JoinEvent joinEvent)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Please log in.");
            }

            _userService.AddEventMember(joinEvent.User.Id, joinEvent.EventId);

            return Request.CreateResponse(HttpStatusCode.OK, new EventMember(joinEvent.User));
        }
    }
}