<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_AddressAutocomplete.ascx.cs" Inherits="NeemoAdmin.UC_AddressAutocomplete" %>
<!DOCTYPE html>
<html>
  <head>
    <title>Place Autocomplete Address Form</title>
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no">
    <meta charset="utf-8">
    <style>
      html, body, #map-canvas {
        height: 100%;
        margin: 0;
        padding: 0;
      }

    </style>
    <link type="text/css" rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500">
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&signed_in=true&libraries=places"></script>
    <script>
// This example displays an address form, using the autocomplete feature
// of the Google Places API to help users fill in the information.

var placeSearch, autocomplete;
var componentForm = {
  street_number: 'short_name',
  route: 'long_name',
  locality: 'long_name',
  administrative_area_level_1: 'short_name',
  country: 'long_name',
  postal_code: 'short_name',
  latitude: 'short_name',
  longitude: 'short_name'
};

function initialize() {
  // Create the autocomplete object, restricting the search
  // to geographical location types.
  autocomplete = new google.maps.places.Autocomplete(
      /** @type {HTMLInputElement} */(document.getElementById('autocomplete')),
      { types: ['geocode'] });
  // When the user selects an address from the dropdown,
  // populate the address fields in the form.
  google.maps.event.addListener(autocomplete, 'place_changed', function() {
    fillInAddress();
  });
}

// [START region_fillform]
function fillInAddress() {
  // Get the place details from the autocomplete object.
  var place = autocomplete.getPlace();

  for (var component in componentForm) {
    document.getElementById(component).value = '';
    document.getElementById(component).disabled = false;
  }

  // Get each component of the address from the place details
  // and fill the corresponding field on the form.
  for (var i = 0; i < place.address_components.length; i++) {
    var addressType = place.address_components[i].types[0];
    if (componentForm[addressType]) {
      var val = place.address_components[i][componentForm[addressType]];
      document.getElementById(addressType).value = val;
      document.getElementById('latitude').value = place.geometry.location.lat();
      document.getElementById('longitude').value = place.geometry.location.lng();
    }
   
  }
}
// [END region_fillform]

// [START region_geolocation]
// Bias the autocomplete object to the user's geographical location,
// as supplied by the browser's 'navigator.geolocation' object.
function geolocate() {
  if (navigator.geolocation) {
    navigator.geolocation.getCurrentPosition(function(position) {
      var geolocation = new google.maps.LatLng(
          position.coords.latitude, position.coords.longitude);
      var circle = new google.maps.Circle({
        center: geolocation,
        radius: position.coords.accuracy
      });
      autocomplete.setBounds(circle.getBounds());
    });
  }
}
// [END region_geolocation]

    </script>

    <style>
      #locationField, #controls {
        position: relative;
        width: 480px;
      }
      #autocomplete {
        position: absolute;
        top: 0px;
        left: -2px;
        width: 99%;
      }
      .label {
        text-align: right;
        font-weight: bold;
        width: 100px;
        color: #303030;
      }
      #address {
        border: 1px solid #000090;
        background-color: #f0f0ff;
        width: 480px;
        padding-right: 2px;
      }
      #address td {
        font-size: 10pt;
            text-align: left;
        }
      .field {
        width: 99%;
      }
      .slimField {
        width: 80px;
      }
      .wideField {
        width: 200px;
      }
      #locationField {
        height: 20px;
        margin-bottom: 2px;
      }
        .auto-style1 {
            width: 277px;
        }
        .auto-style2 {
            width: 116px;
        }
    </style>
  </head>

  <body onload="initialize()">
    <div id="locationField">
      Type Address Here <input id="autocomplete" placeholder="Enter your address"
             onFocus="geolocate()" type="text"></input>
    </div>
     
    <table id="address">
      <tr>
        <td class="label">Level no</td>
        <td class="auto-style2">
           <td class="auto-style2"><input class="field" id="levelno" name="levelno"
              disabled="false"></input></td>
          </td>
          <td>Unit No</td>
        <td class="wideField">
           <td class="auto-style2"><input class="field" id="unitno" name="unitno"
              disabled="false"></input></td>
          </td>
      </tr>
      <tr>
        <td class="label">Street No</td>
        <td class="auto-style2"><input class="field" id="street_number" name="street_number"
              disabled="false"></input></td>
          <td>Street</td>
        <td class="wideField"><input class="field" id="route" name="route"
              disabled="false"></input></td>
      </tr>
      <tr>
        <td class="label">City</td>
        <td class="wideField" colspan="3"><input class="field" id="locality" name="locality"
              disabled="false"></input></td>
      </tr>
      <tr>
        <td class="label">State</td>
        <td class="auto-style2"><input class="field"
              id="administrative_area_level_1"  name="administrative_area_level_1" disabled="false"></input></td>
        <td class="label">Zip code</td>
        <td class="auto-style1"><input class="field" id="postal_code" name="postal_code"
              disabled="false"></input></td>
      </tr>
      <tr>
        <td class="label">Country</td>
        <td class="wideField" colspan="3"><input class="field"
              id="country" name="country" disabled="false"></input></td>
      </tr>
      <tr>
        <td class="label">Latitude</td>
        <td class="wideField" colspan="3"><input class="field"
              id="latitude"  name="latitude" disabled="false"></td>
      </tr>
      <tr>
        <td class="label">Longitude</td>
        <td class="wideField" colspan="3"><input class="field"
              id="longitude"  name="longitude" disabled="false"> </td>
      </tr>
    </table>

       </body>
</html>




