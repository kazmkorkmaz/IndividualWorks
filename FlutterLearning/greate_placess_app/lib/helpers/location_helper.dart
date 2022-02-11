const MAP_BOX_API_KEY =
    'sk.eyJ1Ijoia2F6bWtvcmttYXo1NSIsImEiOiJja3lyajBjd3EwZGNjMnlzMDZna3lxdXQyIn0.TsyDag3WBAtjn13Tb-3wlw';

class LocationHelper {
  static String generateLocationPreviewImage(
      double latitude, double longitude) {
    return 'https://api.mapbox.com/styles/v1/mapbox/streets-v11/static/pin-l($longitude,$latitude)/$longitude,$latitude,14.25,0,0/600x300?access_token=$MAP_BOX_API_KEY';
  }
}
