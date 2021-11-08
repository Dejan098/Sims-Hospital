using Controller;
using Hospital.Controller;
using Hospital.Model;
using Hospital.Repository.CSV.Converter;
using Hospital.Repository.CSV.Stream;
using Hospital.Repository.Sequencer;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Hospital.Repository;
using Hospital.Service;


namespace Hospital
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //private const string FEEDBACK_CSV = "../../Files/Data/Feedback.csv";*/
        private const string APPOINTMENTS_CSV = "../../../Files/Data/Appointments.csv";
        private const string MEDICATION_CSV = "../../../Files/Data/Medication.csv";
        private const string PATIENTS_CSV = "../../../Files/Data/Patients.csv";
        private const string STATIC_CSV= "../../../Files/Data/StaticEquipment.csv";
        private const string SUPPLIES_CSV = "../../../Files/Data/Supplies.csv";
        private const string FAQ_CSV = "../../../Files/Data/Faq.csv";
        private const string ROOM_CSV = "../../../Files/Data/Room.csv";
        private const string STAFF_CSV = "../../../Files/Data/Staff.csv";
        private const string NOTIFICATION_CSV = "../../../Files/Data/Notification.csv";
        private const string EXAMINATION_CSV = "../../../Files/Data/Examination.csv";
        private const string FEEDBACK_CSV = "../../../Files/Data/Feedback.csv";

        private const string CSV_DELIMITER = ",";
        private const string DATETIME_FORMAT = "dd.MM.yyyy. hh:mm";

        public App()
        {

            var roomRepository = new RoomRepository(
               new CSVStream<Room>(ROOM_CSV, new RoomConverter(CSV_DELIMITER, DATETIME_FORMAT)),
               new LongSequencer());

            var staticRepository = new StaticEquipmentRepository(
                new CSVStream<StaticEquipment>(STATIC_CSV, new StaticEquipmentConverter(CSV_DELIMITER)),
                new LongSequencer(),roomRepository);

            var medicationRepository = new MedicationRepository(
                new CSVStream<Medication>(MEDICATION_CSV, new MedicationConverter(CSV_DELIMITER)),
                new LongSequencer());

            var suppliesRepository = new SuppliesRepository(
                new CSVStream<Supplies>(SUPPLIES_CSV, new SupplyConverter(CSV_DELIMITER)),
                new LongSequencer());

            var patientRepository = new PatientRepository(
                new CSVStream<Patient>(PATIENTS_CSV, new PatientConverter(CSV_DELIMITER)),
                new LongSequencer());

            var faqRepository = new FaqRepository(
                new CSVStream<Faq>(FAQ_CSV, new FAQCSVConverter(CSV_DELIMITER)),
                new LongSequencer(), patientRepository);

            var staffRepository = new StaffRepository(
                new CSVStream<Staff>(STAFF_CSV, new StaffConverter(CSV_DELIMITER)),
                new LongSequencer());

            var feedbackRepository= new FeedbackRepository(
                new CSVStream<Feedback>(FEEDBACK_CSV, new FeedbackConverter(CSV_DELIMITER)),
                new LongSequencer(), patientRepository);

            var notificationRepository = new NotificationRepository(
                new CSVStream<Notification>(NOTIFICATION_CSV, new NotificationConverter(CSV_DELIMITER)),
                new LongSequencer());

            var examinationRepository = new ExaminationRepository(
                new CSVStream<Examination>(EXAMINATION_CSV, new ExaminationConverter(CSV_DELIMITER)),
                new LongSequencer());

            var appointmentRepository = new AppointmentRepository(
                new CSVStream<Appointment>(APPOINTMENTS_CSV, new AppointmentConverter(CSV_DELIMITER, DATETIME_FORMAT)),
                new LongSequencer(), patientRepository, staffRepository, roomRepository);

            var scheduleAppointmentAsSecretary = new ScheduleAppointmentAsSecretary(appointmentRepository, notificationRepository);
            var scheduleAppointmentAsPatient = new ScheduleAppointmentAsPatient(appointmentRepository, notificationRepository);
            var scheduleCheckupAppointmentAsDoctor = new ScheduleCheckUpAppointmentAsDoctor(appointmentRepository, notificationRepository);
            var scheduleOperationAsDoctor = new ScheduleOperationAsDoctor(appointmentRepository, notificationRepository);
            var scheduleReferralAsDoctor = new ScheduleReferralAppointmentAsDoctor(appointmentRepository, notificationRepository);
            var scheduleUrgentAppointmentAsSecretary = new ScheduleUrgentAppointmentAsSecretary(appointmentRepository, notificationRepository);


            var appointmentService = new AppointmentService(appointmentRepository, scheduleAppointmentAsSecretary, scheduleAppointmentAsPatient, 
                scheduleCheckupAppointmentAsDoctor, scheduleOperationAsDoctor, scheduleReferralAsDoctor, scheduleUrgentAppointmentAsSecretary);
            var medicationService = new MedicationService(medicationRepository);
            var patientService = new PatientService(patientRepository);
            var faqService = new FaqService(faqRepository);
            var staffService = new StaffService(staffRepository);
            var feedbackService = new FeedbackService(feedbackRepository);
            var notificationService = new NotificationService(notificationRepository);
            var examinationService = new ExaminationService(examinationRepository);
            var staticEquipmentService = new StaticEquipmentService(staticRepository);
            var suppliesService = new SuppliesService(suppliesRepository);
            var roomService = new RoomService(roomRepository);


            AppointmentController = new AppointmentController(appointmentService);
            MedicationController = new MedicationController(medicationService);
            PatientController = new PatientController(patientService);
            FaqController = new FaqController(faqService);
            StaffController = new StaffController(staffService);
            FeedbackController = new FeedbackController(feedbackService);
            NotificationController = new NotificationController(notificationService);
            ExaminationController = new ExaminationController(examinationService);
            StaticController = new StaticEquipmentController(staticEquipmentService);
            SuppliesController = new SuppliesController(suppliesService);
            RoomController = new RoomController(roomService);


        }

        public AppointmentController AppointmentController { get; private set; }
        public RoomController RoomController { get; private set; }
        public MedicationController MedicationController { get; private set; }
        public PatientController PatientController { get; private set; }
        public FaqController FaqController { get; private set; }
        public StaffController StaffController { get; private set; }
        public NotificationController NotificationController { get; private set; }
        public ExaminationController ExaminationController { get; private set; }
        public SuppliesController SuppliesController { get; private set; }
        public StaticEquipmentController StaticController { get; private set; }
        public FeedbackController FeedbackController { get; private set; }
       

    }
}
