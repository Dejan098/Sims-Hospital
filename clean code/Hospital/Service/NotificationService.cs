/***********************************************************************
 * Module:  NotificationController.cs
 * Author:  Vanja
 * Purpose: Definition of the Class Controller.NotificationController
 ***********************************************************************/

using Hospital.Model;
using Hospital.Service;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class NotificationService:IService<Notification, long>
    {
        private readonly NotificationRepository _repository;

        public NotificationService(NotificationRepository repository)
        {
            _repository = repository;
        }

        public Notification Get(long id) => _repository.Get(id);

        public long GetIdDoctor(Notification notification) => _repository.GetIdDoctor(notification);
        public IEnumerable<Notification> GetAll() => _repository.GetAll();

        public void SendNotification(RegisteredUser user, Notification notification)
        {
            // TODO: implement
        }

        public IEnumerable<Notification> GetNotificationsForDoctor(long id) => _repository.GetNotificationsForDoctor(id);

    }
}