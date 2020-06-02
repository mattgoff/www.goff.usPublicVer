$(document).ready(function () {
  $.ajax({
    url: '/api/humphrey/',
    dataType: "json",
    type: "GET",
    contentType: "application/json; charset=utf-8",
    success: function (response) {
      BindHumphreyDataTable(response);
      BuildAndDisplayGraph(response)
    }
  });
});

var BindHumphreyDataTable = function (response) {

  $("#Humphrey_Data").DataTable({
    responsive: true,
    data: response,
    order: [[ 0, "asc"]],
    columns: [
      { data: "orgIndex" },
      { data: "created_at" },
      { data: "laps" },
      { data: "miles" },
      { data: "kilometers" }
    ]
  });
}

  var BuildAndDisplayGraph = function (jsonData){
    google.charts.load('current', {'packages':['corechart']});
    google.charts.setOnLoadCallback(drawChart);

    var chartData = [["Date", "Laps"]]

    jsonData.forEach(element => {
      var lineData = []
      var dateLine = (element["created_at"].split(" ")[0]).split("-")
      lineData.push(`${dateLine[1]}/${dateLine[2]}/${dateLine[0].slice(2)}`)
      lineData.push(element["laps"])
      chartData.push(lineData)
    });

    function drawChart() {
      var data = google.visualization.arrayToDataTable(chartData);

      var options = {
        title: '',
        curveType: 'function',
        legend: { position: 'bottom' }
      };

      var chart = new google.visualization.LineChart(document.getElementById('curve_chart'));

      chart.draw(data, options);

    }
    $(window).resize(function(){
      drawChart()
    })
  }


