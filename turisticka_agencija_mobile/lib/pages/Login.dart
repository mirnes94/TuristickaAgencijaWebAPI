import 'dart:ffi';

import 'package:flutter/material.dart';
import 'package:http/http.dart';
import 'package:turisticka_agencija_mobile/services/APIService.dart';

import '../models/Korisnici.dart';

class Login extends StatefulWidget {
  const Login({Key? key}) : super(key: key);

  @override
  State<Login> createState() => _LoginState();
}

class _LoginState extends State<Login> {
  TextEditingController usernameController = new TextEditingController();
  TextEditingController passwordController = new TextEditingController();
  var result;
  bool _visible = false;
  void getData() async {
    result = await APIService.Get('Korisnici', null);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: Center(
            child: Padding(
      padding: EdgeInsets.all(60),
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Column(
            children: const [
              Image(
                  width: 100,
                  height: 100,
                  image: AssetImage("assets/tourist_agency_icon.jpg")),
              SizedBox(
                width: 30,
              ),
              Text(
                "Turisticka Agencija",
                style: TextStyle(fontSize: 20),
              )
            ],
          ),
          SizedBox(
            height: 20,
          ),
          TextField(
            controller: usernameController,
            decoration: InputDecoration(
                border:
                    OutlineInputBorder(borderRadius: BorderRadius.circular(30)),
                hintText: "Korisnicko ime"),
          ),
          SizedBox(
            height: 20,
          ),
          TextField(
            controller: passwordController,
            decoration: InputDecoration(
                border:
                    OutlineInputBorder(borderRadius: BorderRadius.circular(30)),
                hintText: "Password"),
          ),
          SizedBox(
            height: 20,
          ),
          Container(
            height: 50,
            width: 300,
            decoration: BoxDecoration(
                color: Colors.amber[500],
                borderRadius: BorderRadius.circular(30)),
            child: TextButton(
                onPressed: () async {
                  print(
                      usernameController.text + ' ' + passwordController.text);
                  APIService.username = usernameController.text;
                  APIService.password = passwordController.text;

                  var response = await APIService.Authenticate(
                      "Korisnici", APIService.username, APIService.password);
                  print("Response"+ response.toString());
                  if (response == 200) {
                    Navigator.of(context).pushReplacementNamed('/home');
                    print(result);
                  }
                  if (response == 0){
                  setState(() {
                    if(_visible == false){
                      _visible = !_visible;
                    }
                  usernameController.text = "";
                  passwordController.text = "";
                });
                  }
                  //Navigator.of(context).pushReplacementNamed('/home');
                },
                child: const Text(
                  "Login",
                  style: TextStyle(color: Colors.white, fontSize: 20),
                )),
          ),
          Visibility(
            child: Text(
                "Invalid username or password",
              style: TextStyle(color: Colors.red, fontSize: 15),
            ),
            visible: _visible,
          ),
        ],
      ),
    )));
  }
}
