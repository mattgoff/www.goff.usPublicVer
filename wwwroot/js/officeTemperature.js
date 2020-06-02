$(document).ready(function () {
  $.ajax({
    url: '/api/office/',
    dataType: "json",
    type: "GET",
    contentType: "application/json; charset=utf-8",
    success: function (response) {
      // console.log("Office -> ");
      // console.log(response);
      BindOfficeDataTable(response);
    }
  });

  $.ajax({
    url: '/api/frontdoor/',
    dataType: "json",
    type: "GET",
    contentType: "application/json; charset=utf-8",
    success: function (response) {
      // console.log("Front -> ")
      // console.log(response);
      BindFrontDataTable(response);
    }
  });

  $.ajax({
    url: '/api/patio/',
    dataType: "json",
    type: "GET",
    contentType: "application/json; charset=utf-8",
    success: function (response) {
      // console.log("Front -> ")
      // console.log(response);
      BindPatioDataTable(response);
    }
  });

});


var BindOfficeDataTable = function (response) {

  $("#Office_Data").DataTable({
    "responsive": true,
    "aaData": response,
     "order": [[ 0, "desc"]],
    "aoColumns": [
      { "data": "id" },
      { "data": "officeProbeTemp" },
      { "data": "officeProbeHumidity" },
      { "data": "officeProbeRecordStamp" }
    ]
  });
};

var BindFrontDataTable = function (response) {

  $("#Front_Data").DataTable({
    "responsive": true,
    "aaData": response,
    "order": [[ 0, "desc"]],
    "aoColumns": [
      { "data": "id" },
      { "data": "frontProbeTemp" },
      { "data": "frontProbeRecordStamp" }
    ]
  });
};

var BindPatioDataTable = function (response) {

  $("#Patio_Data").DataTable({
    "responsive": true,
    "aaData": response,
    "order": [[ 0, "desc"]],
    "aoColumns": [
      { "data": "id" },
      { "data": "patioProbeTemp" },
      { "data": "patioProbeRecordStamp" }
    ]
  });
};
