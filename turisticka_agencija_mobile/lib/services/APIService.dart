import 'package:flutter/material.dart';
import 'dart:convert';
import 'dart:io';

import 'package:http/http.dart' as http;
import 'package:http/http.dart';
import 'package:http/io_client.dart';

class APIService {
  static String username = "";
  static String password = "";
  String route;

  APIService({required this.route});

  void setParameter(String Username, String Password) {
    username = Username;
    password = Password;
  }

  static Future<List<dynamic>?> Get(String route, dynamic object) async {
    String queryString = Uri(queryParameters: object).query;
    String baseUrl = 'https://10.0.2.2:5001/api/$route';
    HttpClient client = HttpClient();
    client.badCertificateCallback = ((X509Certificate cert, String host, int port) => true);
    final http = IOClient(client);
    if (object != null) {
      baseUrl = '$baseUrl?$queryString';
    }
    String basicAuth =
        'Basic ${base64Encode(utf8.encode("$username:$password"))}';
    var response = await http.get(Uri.parse(baseUrl),
        headers: {HttpHeaders.authorizationHeader: basicAuth});
    if (response.statusCode == 200) {
      print(response.body);
      return const JsonDecoder().convert(response.body) as List;
    }

    return null;
  }

  static Future<List<dynamic>?> GetById(String route, dynamic id) async {
    String baseUrl = "https://10.0.2.2:5001/api/$route/$id"; //43791
    HttpClient client = HttpClient();
    client.badCertificateCallback = ((X509Certificate cert, String host, int port) => true);
    final http = IOClient(client);
    final String basicAuth =
        'Basic ${base64Encode(utf8.encode('$username:$password'))}';
    var response = await http.get(Uri.parse(baseUrl),
        headers: {HttpHeaders.authorizationHeader: basicAuth});
    if (response.statusCode == 200) {
      return json.decode(response.body);
    }
    return null;
  }

  //static Future<List<dynamic>?> Post(String route, String body) async
  static Future<dynamic?> Post(String route, Map<String, dynamic> body) async {
    String baseUrl = "https://10.0.2.2:5001/api/$route";
    HttpClient client = HttpClient();
    client.badCertificateCallback = ((X509Certificate cert, String host, int port) => true);
    final http = IOClient(client);
    final String basicAuth =
        'Basic ${base64Encode(utf8.encode('$username:$password'))}';
    final response = await http.post(Uri.parse(baseUrl),
        headers: <String, String>{
          'Authorization': basicAuth,
          'Content-Type': 'application/json'
        },
        body: jsonEncode(body));
    print("Response:\n" + response.body);

    if (response.statusCode == 201) {
      print("Response status code:" + response.statusCode.toString());
      return json.decode(response.body);
    }
    print("Response status code:" + response.statusCode.toString());
    return null;
  }

  static Future<dynamic?> Delete(String route, String id) async {
    String baseUrl = "https://10.0.2.2:5001/api/$route/$id";
    final String basicAuth =
        'Basic ${base64Encode(utf8.encode('$username:$password'))}';
    var response = await http.delete(Uri.parse(baseUrl),
        headers: <String, String>{
          'Authorization': basicAuth,
          'Content-Type': 'application/json'
        });
    print("Response:\n" + response.body);

    if (response.statusCode == 201) {
      print("Response status code:" + response.statusCode.toString());
      return json.decode(response.body);
    }
    print("Response status code:" + response.statusCode.toString());
    return null;
  }

  static Future<int> Authenticate(
      String route, String username, String password) async {
    String usernamePass = (username+","+password).replaceAll(' ', '');
    HttpClient client = HttpClient();
    client.badCertificateCallback = ((X509Certificate cert, String host, int port) => true);
    final http = IOClient(client);
    String baseUrl =
        "https://10.0.2.2:5001/api/$route/Authenticiraj/$usernamePass";
    String basicAuth =
        'Basic ${base64Encode(utf8.encode("$username:$password"))}';
    print(basicAuth);
    print(baseUrl);
    final response = await http.get(Uri.parse(baseUrl),
        headers: {HttpHeaders.authorizationHeader: basicAuth});
    if (response.statusCode == 200) {
      return response.statusCode;
    }
    return 0;
  }
}
