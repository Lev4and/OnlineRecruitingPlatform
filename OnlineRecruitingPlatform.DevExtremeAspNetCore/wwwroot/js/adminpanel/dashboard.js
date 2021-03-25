"use strict";

function ownKeys(object, enumerableOnly) {
  var keys = Object.keys(object);
  if (Object.getOwnPropertySymbols) {
    var symbols = Object.getOwnPropertySymbols(object);
    if (enumerableOnly)
      symbols = symbols.filter(function(sym) {
        return Object.getOwnPropertyDescriptor(object, sym).enumerable;
      });
    keys.push.apply(keys, symbols);
  }
  return keys;
}

function _objectSpread(target) {
  for (var i = 1; i < arguments.length; i++) {
    var source = arguments[i] != null ? arguments[i] : {};
    if (i % 2) {
      ownKeys(Object(source), true).forEach(function(key) {
        _defineProperty(target, key, source[key]);
      });
    } else if (Object.getOwnPropertyDescriptors) {
      Object.defineProperties(target, Object.getOwnPropertyDescriptors(source));
    } else {
      ownKeys(Object(source)).forEach(function(key) {
        Object.defineProperty(
          target,
          key,
          Object.getOwnPropertyDescriptor(source, key)
        );
      });
    }
  }
  return target;
}

function _defineProperty(obj, key, value) {
  if (key in obj) {
    Object.defineProperty(obj, key, {
      value: value,
      enumerable: true,
      configurable: true,
      writable: true
    });
  } else {
    obj[key] = value;
  }
  return obj;
}

(function() {
  "use strict";

  var sharedOptions = {
    borderWidth: 3,
    pointRadius: 3,
    pointBorderWidth: 1,
    maintainAspectRatio: true,
    responsive: true,
    legend: {
      display: false
    }
  };
  var gridOptions = {
    scales: {
      xAxes: [
        {
          gridLines: {
            color: "rgba(0,0,0,0.02)",
            zeroLineColor: "rgba(0,0,0,0)"
          }
        }
      ],
      yAxes: [
        {
          gridLines: {
            color: "rgba(0,0,0,0)",
            zeroLineColor: "rgba(0,0,0,0)"
          },
          position: "left",
          ticks: {
            display: false,
            beginAtZero: true,
            suggestedMax: 7
          }
        }
      ]
    }
  };
  var colors = [
    {
      backgroundColor: "rgba(88, 77, 130, 0.05)",
      borderColor: "rgba(88, 77, 130, 1)",
      pointBackgroundColor: "rgba(88, 77, 130, 1)",
      pointBorderColor: "#fff"
    },
    {
      backgroundColor: "#eeeeee",
      borderColor: "#eeeeee",
      pointBackgroundColor: "#eeeeee",
      pointBorderColor: "#fff"
    },
    {
      backgroundColor: "#5dcff3",
      borderColor: "#5dcff3",
      pointBackgroundColor: "#5dcff3",
      pointBorderColor: "#fff"
    }
  ];
  var labels = [
    "Jan",
    "Feb",
    "Mar",
    "Apr",
    "May",
    "Jun",
    "Jul",
    "Aug",
    "Sep",
    "Oct",
    "Nov",
    "Dec"
  ];
  var datasets = [
    {
      label: "Sales",
      backgroundColor: "rgba(88, 77, 130, 1)",
      borderColor: "rgba(88, 77, 130, 1)",
      pointBackgroundColor: "rgba(88, 77, 130, 1)",
      pointBorderColor: "#fff",
      borderWidth: 0,
      data: [6]
    },
    _objectSpread(
      {
        label: "Views"
      },
      colors[1],
      {
        borderWidth: 0,
        data: [5]
      }
    )
  ];
  var data = {
    labels: ["Jul"],
    datasets: datasets
  };

  var randomIntFromInterval = function randomIntFromInterval(min, max) {
    return Math.floor(Math.random() * (max - min + 1) + min);
  };

  var chartData = function chartData(max) {
    var data = [];

    for (var index = 0; index < max; index++) {
      data.push(randomIntFromInterval(4, 6));
    }

    return data;
  };

  var lineData = {
    labels: labels,
    datasets: [
      _objectSpread(
        {
          label: "Sales"
        },
        colors[0],
        {
          data: chartData(12)
        }
      )
    ]
  };
  var lineData2 = {
    labels: ["Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
    datasets: [
      _objectSpread(
        {
          label: "Sales"
        },
        colors[0],
        {
          data: chartData(6)
        }
      )
    ]
  };
  var dataPie = {
    labels: ["Download Sales", "In-Store Sales", "Mail Sales"],
    datasets: [
      {
        data: [350, 450, 100],
        backgroundColor: ["#584d82", "#eeeeee", "#5cad66"]
      }
    ]
  };
  var height = 60;
  var dashboardData = [
    {
      elm: document.getElementById("mainChart").getContext("2d"),
      type: "line",
      data: lineData,
      height: height,
      options: _objectSpread({}, sharedOptions, {}, gridOptions)
    },
    {
      elm: document.getElementById("viewsChart").getContext("2d"),
      type: "line",
      data: lineData2,
      height: 180,
      options: _objectSpread({}, sharedOptions, {}, gridOptions)
    },
    {
      elm: document.getElementById("revenueChart").getContext("2d"),
      type: "bar",
      data: data,
      height: 180,
      options: _objectSpread({}, sharedOptions, {}, gridOptions)
    },
    {
      elm: document.getElementById("visitorsChart").getContext("2d"),
      type: "pie",
      data: dataPie,
      height: 180,
      options: _objectSpread({}, sharedOptions, {
        elements: {
          arc: {
            borderWidth: 0.5
          }
        }
      })
    }
  ];
  dashboardData.map(function(item) {
    new Chart(item.elm, {
      type: item.type,
      data: item.data,
      options: item.options
    });
  });
})();
