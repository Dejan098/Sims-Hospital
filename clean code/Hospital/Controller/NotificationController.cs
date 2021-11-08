/***********************************************************************
 * Module:  NotificationController.cs
 * Author:  Vanja
 * Purpose: Definition of the Class Controller.NotificationController
 ***********************************************************************/

using Hospital.Controller;
using Hospital.Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class NotificationController : IController<Notification, long>
    {
        private readonly NotificationService _service;

        public NotificationController(NotificationService service)
        {
            _service = service;
        }

        public Notification Get(long id) => _service.Get(id);

        public IEnumerable<Notification> GetAll() => _service.GetAll();

        public void SendNotification(RegisteredUser user, Notification notification)
        {
            // TODO: implement
        }

        public IEnumerable<Notification> GetNotificationsForDoctor(long id) => _service.GetNotificationsForDoctor(id);
    }
}