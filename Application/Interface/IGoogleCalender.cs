using Domain.Codes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface
{
    public interface IGoogleCalender
    {
        dynamic DeleteEvent(string eventCode);
        dynamic GetEvents();
        dynamic Insert(CalenderEvents calenderEvents);
    }
}
