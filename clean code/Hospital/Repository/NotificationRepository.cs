/***********************************************************************
 * Module:  NotificationRepository.cs
 * Author:  Vanja
 * Purpose: Definition of the Class Repository.NotificationRepository
 ***********************************************************************/

using Hospital.Model;
using Hospital.Repository.Abstract;
using Hospital.Repository.CSV;
using Hospital.Repository.CSV.Stream;
using Hospital.Repository.Sequencer;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class NotificationRepository : CSVRepository<Notification, long>, INotificationRepository
    {
        private const string ENTITY_NAME = "Notification";

        public NotificationRepository(ICSVStream<Notification> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer) { }

        public long GetIdDoctor(Notification notification)
        {
            return notification.IdDoctor;
        }

        public Notification GetNotification()
        {
            // TODO: implement
            return null;
        }

        public IEnumerable<Notification> GetNotificationsForDoctor(long id)
        => Find(notification => notification.IdDoctor == id);
    }
}