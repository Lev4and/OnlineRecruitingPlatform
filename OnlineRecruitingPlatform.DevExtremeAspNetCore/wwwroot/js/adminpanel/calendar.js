(function() {
  "use strict";

  function makeArray(list) {
    return [].slice.call(list);
  }

  document.addEventListener("DOMContentLoaded", function() {
    var calendarEl = document.querySelector(".fullcalendar");

    var calendar = new FullCalendar.Calendar(calendarEl, {
      plugins: ["bootstrap", "interaction", "dayGrid", "timeGrid", "list"],
      themeSystem: "bootstrap",
      header: {
        right: "prev,next today",
        left: "title",
        center: "dayGridMonth,timeGridWeek,timeGridDay,listMonth"
      },
      defaultDate: "2019-08-12",
      weekNumbers: true,
      navLinks: true, // can click day/week names to navigate views
      editable: true,
      eventLimit: true, // allow "more" link when too many events
      events: [
        {
          title: "All Day Event",
          start: "2019-08-01"
        },
        {
          title: "Long Event",
          start: "2019-08-07",
          end: "2019-08-10"
        },
        {
          groupId: 999,
          title: "Repeating Event",
          start: "2019-08-09T16:00:00"
        },
        {
          groupId: 999,
          title: "Repeating Event",
          start: "2019-08-16T16:00:00"
        },
        {
          title: "Conference",
          start: "2019-08-11",
          end: "2019-08-13"
        },
        {
          title: "Meeting",
          start: "2019-08-12T10:30:00",
          end: "2019-08-12T12:30:00"
        },
        {
          title: "Lunch",
          start: "2019-08-12T12:00:00"
        },
        {
          title: "Meeting",
          start: "2019-08-12T14:30:00"
        },
        {
          title: "Happy Hour",
          start: "2019-08-12T17:30:00"
        },
        {
          title: "Dinner",
          start: "2019-08-12T20:00:00"
        },
        {
          title: "Birthday Party",
          start: "2019-08-13T07:00:00"
        },
        {
          title: "Click for Google",
          url: "http://google.com/",
          start: "2019-08-28"
        }
      ],
      viewSkeletonRender: function() {
        document
          .querySelector(".fullcalendar .fc-header-toolbar")
          .classList.add(
            "d-flex",
            "justify-content-between",
            "align-items-center",
            "p-3",
            "flex-column",
            "flex-sm-row"
          );
        document.querySelector(
          ".fullcalendar .fc-toolbar .fc-prev-button"
        ).innerHTML = "Prev";
        document.querySelector(
          ".fullcalendar .fc-toolbar .fc-next-button"
        ).innerHTML = "Next";

        makeArray(
          document.querySelectorAll(
            ".fullcalendar .fc-toolbar .fc-today-button"
          )
        ).forEach(function(btn) {
          btn.classList.remove("btn-primary");
          btn.classList.add("button-shadow");
        });

        makeArray(
          document.querySelectorAll(".fullcalendar .btn-group")
        ).forEach(function(group) {
          group.classList.add("button-shadow");
          makeArray(group.querySelectorAll(".btn")).forEach(function(btn) {
            btn.classList.remove("btn-primary");
          });
        });
      }
    });

    calendar.render();
  });
})();
