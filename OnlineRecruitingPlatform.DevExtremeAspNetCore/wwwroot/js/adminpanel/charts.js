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
            beginAtZero: true,
            suggestedMax: 9
          }
        }
      ]
    }
  };
  var stackedGridOptions = {
    scales: {
      xAxes: [
        {
          gridLines: {
            color: "rgba(0,0,0,0.02)",
            zeroLineColor: "rgba(0,0,0,0.02)"
          },
          stacked: true
        }
      ],
      yAxes: [
        {
          gridLines: {
            color: "rgba(0,0,0,0)",
            zeroLineColor: "rgba(0,0,0,0.02)"
          },
          stacked: true,
          position: "left",
          ticks: {
            beginAtZero: true,
            suggestedMax: 9
          }
        }
      ]
    }
  };
  var colors = [
    {
      backgroundColor: "#584d82",
      borderColor: "#4d4373",
      pointBackgroundColor: "#584d82",
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
  var labels = ["1", "2", "3", "4", "5", "6", "7"];
  var datasets = [
    _objectSpread(
      {
        label: "Sales"
      },
      colors[0],
      {
        data: [6, 5, 8, 8, 5, 5, 4]
      }
    ),
    _objectSpread(
      {
        label: "Views"
      },
      colors[1],
      {
        data: [5, 4, 4, 2, 6, 2, 5]
      }
    )
  ];
  var data = {
    labels: labels,
    datasets: datasets
  };
  var lineData = {
    labels: labels,
    datasets: [
      {
        label: "Sales",
        backgroundColor: "rgba(238, 238, 238, 0.05)",
        borderColor: "rgba(238, 238, 238, 1)",
        pointBackgroundColor: "rgba(238, 238, 238, 1)",
        pointBorderColor: "#fff",
        data: [6, 5, 8, 8, 5, 5, 4]
      },
      {
        label: "Views",
        backgroundColor: "rgba(88, 77, 130, 0.05)",
        borderColor: "rgba(88, 77, 130, 1)",
        pointBackgroundColor: "rgba(88, 77, 130, 1)",
        pointBorderColor: "#fff",
        data: [5, 4, 4, 2, 6, 2, 5]
      }
    ]
  };
  var dataStepped = {
    labels: labels,
    datasets: [
      _objectSpread(
        {
          steppedLine: true,
          fill: false,
          label: "Sales"
        },
        colors[0],
        {
          data: [6, 5, 8, 8, 5, 5, 4]
        }
      ),
      _objectSpread(
        {
          steppedLine: true,
          fill: false,
          label: "Views"
        },
        colors[1],
        {
          data: [5, 4, 4, 2, 6, 2, 5]
        }
      )
    ]
  };
  var dataPoints = {
    labels: labels,
    datasets: [
      _objectSpread(
        {
          fill: false,
          pointRadius: 10,
          pointHoverRadius: 15,
          showLine: false,
          label: "Sales"
        },
        colors[0],
        {
          data: [6, 5, 8, 8, 5, 5, 4]
        }
      ),
      _objectSpread(
        {
          fill: false,
          pointRadius: 10,
          pointHoverRadius: 15,
          showLine: false,
          label: "Views"
        },
        colors[1],
        {
          data: [5, 4, 4, 2, 6, 2, 5]
        }
      )
    ]
  };
  var dataMixed = {
    labels: labels,
    datasets: [
      _objectSpread(
        {
          label: "Sales",
          type: "line",
          data: [6, 5, 6, 8, 5, 5, 4]
        },
        colors[0],
        {
          yAxisID: "y-axis-2"
        }
      ),
      _objectSpread(
        {
          type: "bar",
          label: "Visitor",
          data: [5, 6, 4, 3, 6, 4, 5]
        },
        colors[1],
        {
          yAxisID: "y-axis-1"
        }
      )
    ]
  };
  var options = {
    responsive: true,
    tooltips: {
      mode: "label"
    },
    elements: {
      line: {
        fill: false
      }
    },
    scales: {
      xAxes: [
        {
          display: true,
          gridLines: {
            display: false
          },
          labels: labels
        }
      ],
      yAxes: [
        {
          type: "linear",
          display: true,
          position: "left",
          id: "y-axis-1",
          gridLines: {
            display: false
          },
          labels: {
            show: true
          }
        },
        {
          type: "linear",
          display: true,
          position: "right",
          id: "y-axis-2",
          gridLines: {
            display: false
          },
          labels: {
            show: true
          }
        }
      ]
    }
  };
  var dataBubble = {
    labels: ["January"],
    datasets: [
      _objectSpread(
        {
          label: "Sales",
          fill: true,
          lineTension: 0.1
        },
        colors[0],
        {
          borderCapStyle: "butt",
          borderDash: [],
          borderDashOffset: 0.0,
          borderJoinStyle: "miter",
          pointBorderWidth: 1,
          pointRadius: 1,
          pointHitRadius: 10,
          data: [
            {
              x: 6,
              y: 5,
              r: 15
            },
            {
              x: 5,
              y: 4,
              r: 10
            },
            {
              x: 8,
              y: 4,
              r: 6
            },
            {
              x: 8,
              y: 4,
              r: 6
            },
            {
              x: 5,
              y: 14,
              r: 14
            },
            {
              x: 5,
              y: 6,
              r: 8
            },
            {
              x: 4,
              y: 2,
              r: 10
            }
          ],
          borderWidth: 0.5
        }
      )
    ]
  };
  var dataDoughnut = {
    labels: ["Download Sales", "In-Store Sales", "Mail-Order Sales"],
    datasets: [
      {
        data: [350, 450, 100],
        backgroundColor: ["#584d82", "#eeeeee", "#5cad66"]
      }
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
  var dataPolar = {
    datasets: [
      {
        data: [350, 450, 100],
        backgroundColor: ["#584d82", "#eeeeee", "#5cad66"]
      }
    ],
    labels: ["Download Sales", "In-Store Sales", "Mail Sales"]
  };
  var dataRadar = {
    labels: [
      "Eating",
      "Drinking",
      "Sleeping",
      "Designing",
      "Coding",
      "Cycling",
      "Running"
    ],
    datasets: [
      {
        label: "Sales",
        backgroundColor: "rgba(238, 238, 238, 0.05)",
        borderColor: "rgba(238, 238, 238, 1)",
        pointBackgroundColor: "rgba(238, 238, 238, 1)",
        pointBorderColor: "#fff",
        data: [65, 59, 90, 81, 56, 55, 40]
      },
      {
        label: "Views",
        backgroundColor: "rgba(88, 77, 130, 0.05)",
        borderColor: "rgba(88, 77, 130, 1)",
        pointBackgroundColor: "rgba(88, 77, 130, 1)",
        pointBorderColor: "#fff",
        data: [28, 48, 40, 19, 96, 27, 100]
      }
    ]
  };
  var height = 200;
  var chartData = [
    {
      elm: document.getElementById("bar").getContext("2d"),
      type: "bar",
      data: data,
      height: height,
      options: _objectSpread({}, sharedOptions, {}, gridOptions)
    },
    {
      elm: document.getElementById("barHorizontal").getContext("2d"),
      type: "horizontalBar",
      data: data,
      height: height,
      options: _objectSpread({}, sharedOptions, {}, gridOptions)
    },
    {
      elm: document.getElementById("barStacked").getContext("2d"),
      type: "bar",
      data: data,
      height: height,
      options: _objectSpread(
        {},
        sharedOptions,
        {},
        gridOptions,
        {},
        stackedGridOptions
      )
    },
    {
      elm: document.getElementById("lineBasic").getContext("2d"),
      type: "line",
      data: lineData,
      height: height,
      options: _objectSpread({}, sharedOptions, {}, gridOptions)
    },
    {
      elm: document.getElementById("lineStepped").getContext("2d"),
      type: "line",
      data: dataStepped,
      height: height,
      options: _objectSpread({}, sharedOptions, {}, gridOptions)
    },
    {
      elm: document.getElementById("linePoints").getContext("2d"),
      type: "line",
      data: dataPoints,
      height: height,
      options: _objectSpread({}, sharedOptions, {}, gridOptions, {
        responsive: true,
        elements: {
          point: {
            pointStyle: "rectRot"
          }
        }
      })
    },
    {
      elm: document.getElementById("lineAndBar").getContext("2d"),
      type: "bar",
      data: dataMixed,
      height: height,
      options: _objectSpread({}, sharedOptions, {}, gridOptions, {}, options)
    },
    {
      elm: document.getElementById("bubble").getContext("2d"),
      type: "bubble",
      data: dataBubble,
      height: height,
      options: _objectSpread({}, sharedOptions, {}, gridOptions)
    },
    {
      elm: document.getElementById("doughnut").getContext("2d"),
      type: "doughnut",
      data: dataDoughnut,
      height: height,
      options: _objectSpread({}, sharedOptions, {
        elements: {
          arc: {
            borderWidth: 0.5
          }
        }
      })
    },
    {
      elm: document.getElementById("pie").getContext("2d"),
      type: "pie",
      data: dataPie,
      height: height,
      options: _objectSpread({}, sharedOptions, {
        elements: {
          arc: {
            borderWidth: 0.5
          }
        }
      })
    },
    {
      elm: document.getElementById("polar").getContext("2d"),
      type: "polarArea",
      data: dataPolar,
      height: height,
      options: _objectSpread({}, sharedOptions, {
        elements: {
          arc: {
            borderWidth: 0.5
          }
        }
      })
    },
    {
      elm: document.getElementById("radar").getContext("2d"),
      type: "radar",
      data: dataRadar,
      height: height,
      options: _objectSpread({}, sharedOptions)
    }
  ];
  chartData.map(function(item) {
    new Chart(item.elm, {
      type: item.type,
      data: item.data,
      options: item.options
    });
  });
})();
