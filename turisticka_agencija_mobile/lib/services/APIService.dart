import 'package:flutter/material.dart';
import 'dart:convert';
import 'dart:io';

import 'package:http/http.dart' as http;

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
    String baseUrl = 'http://192.168.0.20:5000/api/$route';
    if (object != null) {
      baseUrl = '$baseUrl?$queryString';
    }
    String basicAuth =
        'Basic ${base64Encode(utf8.encode("$username:$password"))}';
    final response = await http.get(Uri.parse(baseUrl),
        headers: {HttpHeaders.authorizationHeader: basicAuth});
    if (response.statusCode == 200) {
      print(response.body);
      return const JsonDecoder().convert(response.body) as List;
    }

    return null;
  }

  static Future<List<dynamic>?> GetById(String route, dynamic id) async {
    String baseUrl = "http://192.168.0.20:5000/api/$route/$id"; //43791
    final String basicAuth =
        'Basic ${base64Encode(utf8.encode('$username:$password'))}';
    final response = await http.get(Uri.parse(baseUrl),
        headers: {HttpHeaders.authorizationHeader: basicAuth});
    if (response.statusCode == 200) {
      return json.decode(response.body);
    }
    return null;
  }

  //static Future<List<dynamic>?> Post(String route, String body) async
  static Future<dynamic?> Post(String route, Map<String, dynamic> body) async {
    String baseUrl = "http://192.168.0.20:5000/api/$route";
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
    String baseUrl = "http://192.168.0.20:5000/api/$route/$id";
    final String basicAuth =
        'Basic ${base64Encode(utf8.encode('$username:$password'))}';
    final response = await http.delete(Uri.parse(baseUrl),
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

  static Future<dynamic?> Authenticate(
      String route, String username, String password) async {
    String baseUrl =
        "http://192.168.0.20:5000/api/$route/Authenticiraj/$username,$password";
    String basicAuth =
        'Basic ${base64Encode(utf8.encode("$username:$password"))}';
    print(basicAuth);
    final response = await http.get(Uri.parse(baseUrl),
        headers: {HttpHeaders.authorizationHeader: basicAuth});
    if (response.statusCode == 200) {
      print(response.statusCode);
      return const JsonDecoder().convert(response.body);
    }
    return null;
  }
}
