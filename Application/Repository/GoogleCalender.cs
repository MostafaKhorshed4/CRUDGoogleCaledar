using Application.Interface;
using Domain.Codes;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Repository
{
   public class GoogleCalender : IGoogleCalender
    {

        static string[] Scopes = { CalendarService.Scope.Calendar };
        static string ApplicationName = "Google Calendar API";

        public dynamic CheckCredentials()
        {
            try
            { 
            UserCredential credential;

            using (var stream =
                new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                var clientsecret = GoogleClientSecrets.Load(stream).Secrets;
                var Scope = Scopes;
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    clientsecret,
                    Scope,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
                return service;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public dynamic GetEvents()
        {
            try {
                
                EventsResource.ListRequest request = CheckCredentials().Events.List("primary");
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            List<CalenderEvents> calendarEvents = new List<CalenderEvents>();
            Events events = request.Execute();
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    CalenderEvents calendarEvent = new CalenderEvents();
                        calendarEvent.Description = eventItem.Description;
                        calendarEvent.EndDate = DateTime.Parse(eventItem.End.ToString());
                        calendarEvent.StartDate = DateTime.Parse(eventItem.Start.ToString());
                        calendarEvent.Summary = eventItem.Summary;
                    calendarEvents.Add(calendarEvent);
                }
            }

            return calendarEvents;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public dynamic Insert (CalenderEvents calenderEvents)
        {
            try {    
            var GoogleCalendarevent = new Event();
        
         
                EventDateTime start = new EventDateTime();
                start.DateTime = calenderEvents.StartDate;
                start.TimeZone = TimeZoneInfo.Local.Id;

                EventDateTime end = new EventDateTime();
                end.DateTime = calenderEvents.EndDate;
                end.TimeZone = TimeZoneInfo.Local.Id;

                GoogleCalendarevent.Start = start;
            GoogleCalendarevent.End = end;
            GoogleCalendarevent.Summary = calenderEvents.Summary;
            GoogleCalendarevent.Description = calenderEvents.Description;

            var calendarId = "primary";
            Event recurringEvent = CheckCredentials().Events.Insert(GoogleCalendarevent, calendarId).Execute();
            return recurringEvent;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public dynamic DeleteEvent(string eventCode)
        {
            try { 
            string calendarId = "primary"; 
            string eventId = eventCode; 

            EventsResource.DeleteRequest request = CheckCredentials().Events.Delete(calendarId, eventId);
            request.Execute();
                return eventCode + "Deleted";
            } 
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
