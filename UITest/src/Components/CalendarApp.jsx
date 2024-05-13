import React, { useState, useRef } from 'react';
import FullCalendar from '@fullcalendar/react';
import dayGridPlugin from '@fullcalendar/daygrid';
import { Tooltip } from "bootstrap";
import { createEventId } from './event-utils';
import CalendarForm from './CalendarForm';
import './index.css';

let tooltipInstance = null;

export default function CalendarApp() {
  const [currentEvents, setCurrentEvents] = useState([]);
  const calendarRef = useRef();

  const handleEventClick = (info) => {
    if (confirm(`Are you sure you want to delete the event '${info.event.title}'`)) {
      info.event.remove();
    }
  }

  const handleEvents = (events) => {
    setCurrentEvents(events);
  }

  const handleFormSubmit = (title, description, start, end) => {
    const calendarApi = calendarRef.current.getApi()
    calendarApi.addEvent({
      id: createEventId(),
      title,
      description,
      start,
      end
    });
  };

  const handleMouseEnter = (info) => {
    if (info.event.extendedProps.description) {
      tooltipInstance = new Tooltip(info.el, {
        title: info.event.extendedProps.description,
        html: true,
        placement: "top",
        trigger: "hover",
        container: "body"
      });
      tooltipInstance.show();
    }
  };

  const handleMouseLeave = (info) => {
    if (tooltipInstance) {
      tooltipInstance.dispose();
      tooltipInstance = null;
    }
  };

  return (
    <>
      <div className='app'>
        <div className='calendar-form'>
          <CalendarForm submitForm={handleFormSubmit} />
        </div>
        <div className='calendar-app'>
          <FullCalendar
            ref={calendarRef}
            plugins={[dayGridPlugin]}
            initialView='dayGridMonth'
            editable={true}
            selectable={true}
            selectMirror={true}
            weekends={true}
            eventClick={handleEventClick}
            eventMouseEnter={handleMouseEnter}
            eventMouseLeave={handleMouseLeave}
            eventsSet={handleEvents}
          />
        </div>
      </div>
    </>
  )
}